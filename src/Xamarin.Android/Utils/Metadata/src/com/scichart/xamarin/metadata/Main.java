package com.scichart.xamarin.metadata;

import java.io.File;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class Main {

    private static final String JAVA_SRC_DIR = "--javaSrcDir=";
    private static final String OUT = "--out=";
    private static final String EXPECTED_FORMAT = "Expected next format: --javaSrcDir=<javaModuleSrcDirectory> --out=<xamarinTransformsMetadataPath>";

    private static final String SOURCES_RELATIVE_PATH = File.separator + "main" + File.separator + "java";
    private static final String METADATA_RELATIVE_PATH = File.separator + "Transforms" + File.separator + "Metadata.xml";

    private static final String START_TAG = "#AUTOGENTOOL START";
    private static final String END_TAG = "#AUTOGENTOOL END";

    private static final String COMPARABLE_TYPE = "java.lang.Comparable";
    private static final String TX = "TX";
    private static final String TY = "TY";

    private static boolean shouldAddLines = true;

    public static void main(String[] args) {
        String out = null;
        List<String> javaSrcDirs = new ArrayList<>();

        for (String arg : args) {
            if (arg.startsWith(JAVA_SRC_DIR)) {
                javaSrcDirs.add(arg.substring(JAVA_SRC_DIR.length()));
            } else if (arg.startsWith(OUT)) {
                out = arg.substring(OUT.length());
            } else {
                System.err.print(EXPECTED_FORMAT);
                System.exit(1);
            }
        }

        if (out == null || javaSrcDirs.size() == 0) {
            System.err.print(EXPECTED_FORMAT);
            System.exit(1);
        }

        Path metadataPath = Paths.get(out + METADATA_RELATIVE_PATH);
        try {
            updateMetadata(metadataPath, javaSrcDirs);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static void updateMetadata(Path metadataPath, List<String> sourcePaths) throws IOException {
        List<String> newLines = new ArrayList<>();

        for (String line : Files.readAllLines(metadataPath, StandardCharsets.UTF_8)) {
            if (line.contains(START_TAG)) {
                shouldAddLines = false;

                // Add START_TAG for future updates
                newLines.add(line);
            } else if (line.contains(END_TAG)) {
                shouldAddLines = true;

                // Add attributes to provide parameter names
                for (String path : sourcePaths) {
                    final File sourceDir = new File(path + SOURCES_RELATIVE_PATH);
                    iterateDirectory(sourceDir, newLines);
                }
            }
            // Copy all the lines if they are not between START_TAG\END_TAG
            if (shouldAddLines) {
                newLines.add(line);
            }
        }
        Files.write(metadataPath, newLines, StandardCharsets.UTF_8);
    }

    private static void iterateDirectory(File file, List<String> lines) {
        if (file.isDirectory()) {
            try {
                Files.list(file.toPath()).forEach(path -> iterateDirectory(path.toFile(), lines));
            } catch (IOException e) {
                e.printStackTrace();
            }
        } else {
            if (!file.getPath().endsWith(".java")) return;
            final JavaSourceClass javaSourceClass = new JavaSourceClass(file);
            javaSourceClass.getAttributeMetadata().forEach(s -> {
                String line = replaceGenericWithComparable(s, TX);
                line = replaceGenericWithComparable(line, TY);

                lines.add("  " + line);
            });
        }
    }

    private static String replaceGenericWithComparable(String input, String generic) {
        String temp = "'" + generic;
        if (input.contains(temp)) {
            return input.replace(temp, "'" + COMPARABLE_TYPE);
        }

        return input;
    }
}