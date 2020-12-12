package t_05_telephony;

import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Smartphone implements Callable, Browsable{
    private final List<String> numbers;
    private final List<String> urls;

    public Smartphone(List<String> numbers, List<String> urls) {
        this.numbers = numbers;
        this.urls = urls;
    }


    @Override
    public String call() {
        StringBuilder sb = new StringBuilder(26);

        Pattern pattern = Pattern.compile("[^0-9]+");
        Matcher matcher;

        for (String currentCall: numbers) {
            matcher = pattern.matcher(currentCall);

            if (!matcher.find()) {
                sb.append("Calling... ");
                sb.append(currentCall);
                sb.append("\n");
            } else {
                sb.append("Invalid number!\n");
            }
        }

        return sb.toString();
    }

    @Override
    public String browse() {
        StringBuilder sb = new StringBuilder(26);

        Pattern pattern = Pattern.compile("[0-9]+");
        Matcher matcher;

        for (String currentBrowse: urls) {
            matcher = pattern.matcher(currentBrowse);

            if (!matcher.find()) {
                sb.append("Browsing: ");
                sb.append(currentBrowse);
                sb.append("!\n");
            } else {
                sb.append("Invalid URL!\n");
            }
        }

        return sb.toString().trim();
    }

    @Override
    public String toString() {
        return call() + browse();
    }
}
