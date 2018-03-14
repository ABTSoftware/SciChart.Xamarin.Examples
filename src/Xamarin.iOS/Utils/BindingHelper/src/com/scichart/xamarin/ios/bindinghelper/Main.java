package com.scichart.xamarin.ios.bindinghelper;

import java.io.*;
import java.nio.file.Files;
import java.util.HashSet;

public class Main {
    // Directory which contains ApiDefinition/Structs/Extras folders
    private static final String CSHARP_SRC_DIR = "--cSharpSrcDir=";

    // Directory where to put output ApiDefinition/Structs/Extras cs files
    private static final String OUT = "--out=";
    private static final String EXPECTED_FORMAT = "Expected next format: --cshSrcDir=<cSharpSrcDirectory> --out=<outPath>";

    private static final String API_DEFINITION = "ApiDefinition";
    private static final String STRUCTS = "Structs";
    private static final String EXTRAS = "Extras";

    private static final String NAMESPACE_KEYWORD = "namespace";
    private static final String IOS_NAMESPACE = "SciChart.iOS.Charting";

    public static void main(String[] args) {
        String out = null;
        String sharpSrcDir = null;

        for (String arg : args) {
            if (arg.startsWith(CSHARP_SRC_DIR)) {
                sharpSrcDir = arg.substring(CSHARP_SRC_DIR.length());
            } else if (arg.startsWith(OUT)) {
                out = arg.substring(OUT.length());
            } else {
                System.err.print(EXPECTED_FORMAT);
                System.exit(1);
            }
        }
        if (out == null || sharpSrcDir == null) {
            System.err.print(EXPECTED_FORMAT);
            System.exit(1);
        }

        combineFilesFromThePath(API_DEFINITION, sharpSrcDir, out);
        combineFilesFromThePath(STRUCTS, sharpSrcDir, out);
        combineFilesFromThePath(EXTRAS, sharpSrcDir, out);
    }

    private static void combineFilesFromThePath(String path, String sourceDirectory, String out) {
        final File sourceDir = new File(sourceDirectory + "\\" + path);
        final StringBuilder builder = new StringBuilder();

        final HashSet<String> usingsSet = new HashSet<>();
        iterateDirectory(sourceDir, usingsSet, builder);

        try (final FileWriter fileWriter = new FileWriter(out + "\\" + path + ".cs")) {
            try (final BufferedWriter bufferedWriter = new BufferedWriter(fileWriter)) {
                usingsSet.forEach(using -> {
                    try {
                        bufferedWriter.write(using);
                        bufferedWriter.write('\n');
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                });

                bufferedWriter.write(builder.toString());
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static void iterateDirectory(File file, HashSet<String> usingsSet, StringBuilder stringBuilder) {
        if (file.isDirectory()) {
            try {
                Files.list(file.toPath()).forEach(path -> iterateDirectory(path.toFile(), usingsSet, stringBuilder));
            } catch (IOException e) {
                e.printStackTrace();
            }
        } else {
            try {
                FileInputStream fis = new FileInputStream(file);
                InputStreamReader inputStreamReader = new InputStreamReader(fis);
                BufferedReader reader = new BomProofBufferedLineReader(inputStreamReader);

                String line = null;
                while ((line = reader.readLine()) != null) {
                    System.out.println(line);
                    if (line.startsWith("using")) {
                        usingsSet.add(line);
                    } else {
                        break;
                    }
                }
                stringBuilder.append('\n');
                while ((line = reader.readLine()) != null) {
                    if (line.startsWith(NAMESPACE_KEYWORD)) {
                        line = NAMESPACE_KEYWORD + " " + IOS_NAMESPACE;
                    }
                    stringBuilder.append(line);
                    stringBuilder.append('\n');
                }

                reader.close();
                fis.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}