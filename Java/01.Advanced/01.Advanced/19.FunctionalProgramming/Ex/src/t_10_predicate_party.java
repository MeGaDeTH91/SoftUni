import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
import java.util.function.BiFunction;
import java.util.function.Function;
import java.util.stream.Collectors;

public class t_10_predicate_party {
    private static final BufferedReader reader;
    private static List<String> names;

    static {
        reader = new BufferedReader(new InputStreamReader(System.in));
    }

    public static void main(String[] args) throws IOException {
        names = Arrays.stream(reader.readLine().split("\\s+")).collect(Collectors.toList());

        String command;
        String[] commTokens;
        while (!(command = reader.readLine()).equals("Party!")) {
            commTokens = command.split("\\s+");

            if (commTokens[0].equals("Double")) {
                executeDoubleCommand(commTokens[1], commTokens[2]);
            } else if (commTokens[0].equals("Remove")) {
                executeRemoveCommand(commTokens[1], commTokens[2]);
            }
        }

        if (names.size() < 1) {
            System.out.println("Nobody is going to the party!");
        } else {
            Collections.sort(names);
            System.out.printf("%s are going to the party!", String.join(", ", names));
        }
    }

    private static void executeDoubleCommand (String type, String argument) {
        switch (type) {
            case "StartsWith":
                startDouble.apply(argument);
                break;
            case "EndsWith":
                endsDouble.apply(argument);
                break;
            case "Length":
                sizeDouble.apply(Integer.parseInt(argument));
                break;
        }
    }

    private static void executeRemoveCommand (String type, String argument) {
        switch (type) {
            case "StartsWith":
                startExclude.apply(argument);
                break;
            case "EndsWith":
                endsExclude.apply(argument);
                break;
            case "Length":
                sizeExclude.apply(Integer.parseInt(argument));
                break;
        }
    }

    private static final Function<String, List<String>> startDouble = (exclusion) -> {
        List<String> temp = names.stream().filter(x -> x.startsWith(exclusion)).collect(Collectors.toList());
        names.addAll(temp);

        return names;
    };

    private static final Function<String, List<String>> endsDouble = (exclusion) -> {
        List<String> temp = names.stream().filter(x -> x.endsWith(exclusion)).collect(Collectors.toList());
        names.addAll(temp);

        return names;
    };

    private static final Function<Integer, List<String>> sizeDouble = (exclusion) -> {
        List<String> temp = names.stream().filter(x -> x.length() == exclusion).collect(Collectors.toList());
        names.addAll(temp);

        return names;
    };

    private static final Function<String, List<String>> startExclude = (exclusion) -> {
        names = names.stream().filter(x -> !x.startsWith(exclusion)).collect(Collectors.toList());

        return names;
    };

    private static final Function<String, List<String>> endsExclude = (exclusion) -> {
        names = names.stream().filter(x -> !x.endsWith(exclusion)).collect(Collectors.toList());

        return names;
    };

    private static final Function<Integer, List<String>> sizeExclude = (exclusion) -> {
        names = names.stream().filter(x -> x.length() != exclusion).collect(Collectors.toList());

        return names;
    };
}
