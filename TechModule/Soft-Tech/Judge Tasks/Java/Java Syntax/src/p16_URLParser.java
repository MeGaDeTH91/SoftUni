import jdk.nashorn.internal.runtime.regexp.joni.Regex;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.Scanner;

public class p16_URLParser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        String protocol = "";
        String server = "";
        String resource = "";
        String tempSpl = "";
        StringBuilder sb = new StringBuilder();

        String[] ifProtocol = input.split("://");
        if(ifProtocol.length == 1){
            tempSpl = ifProtocol[0];
            String[] secondSpl = tempSpl.split("/");

            if(secondSpl.length > 1){
                server = secondSpl[0];

                for (int i = 1; i < secondSpl.length; i++) {
                    if(i == 1){
                        sb.append(secondSpl[i]);
                    }else{
                        sb.append("/" + secondSpl[i]);
                    }
                }
                resource = sb.toString();
            }else if(secondSpl.length == 1){
                server = secondSpl[0];
            }
        }else if(ifProtocol.length == 2){
            protocol = ifProtocol[0];
            tempSpl = ifProtocol[1];

            String[] secondSpl = tempSpl.split("/");
            if(secondSpl.length > 1){
                server = secondSpl[0];

                for (int i = 1; i < secondSpl.length; i++) {
                    if(i == 1){
                        sb.append(secondSpl[i]);
                    }else{
                        sb.append("/" + secondSpl[i]);
                    }
                }
                resource = sb.toString();
            }else if(secondSpl.length == 1){
                server = secondSpl[0];
            }
        }
        System.out.println("[protocol] = " + '"' + protocol + '"' );
        System.out.println("[server] = " + '"' + server + '"' );
        System.out.println("[resource] = " + '"' + resource + '"' );
    }
}
