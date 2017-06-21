package com.scichart.xamarin.ios.bindinghelper;

import com.sun.istack.internal.NotNull;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.Reader;
import java.nio.charset.StandardCharsets;

public class BomProofBufferedLineReader extends BufferedReader {

    //This gets the UTF-8 bytes and makes a String in the current platform encoding.
    private final static String UTF8_BOM = new String("\uFEFF".getBytes(StandardCharsets.UTF_8));
    private boolean isFirstLine = true;

    public BomProofBufferedLineReader(@NotNull Reader in) {
        super(in);
    }

    @Override
    public String readLine() throws IOException {
        if (this.isFirstLine) {
            this.isFirstLine = false;

            String line = super.readLine();

            if (line.startsWith(UTF8_BOM)){
                line = line.substring(UTF8_BOM.length());
            }

            return line;
        }

        return super.readLine();
    }
}
