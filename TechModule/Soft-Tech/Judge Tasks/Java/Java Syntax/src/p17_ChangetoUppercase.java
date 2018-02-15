import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Marto on 7.8.2017 г..
 */
public class p17_ChangetoUppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String pattern = "(?<all>((<upcase>)(?<sent>([a-zA-Z0-9 -.@#$%^&*()!+,\\/?_:]+))(<\\/upcase>)))";
        String text = scanner.nextLine();
        Pattern r = Pattern.compile(pattern);

        Matcher m = r.matcher(text);
        while(true){
            if (m.find( )) {
                String forRepl = m.group("sent");
                forRepl = forRepl.toUpperCase();
                text = text.replace(m.group("all"), forRepl);
            }
            else{
                break;
            }
        }
        System.out.println(text);
    }
}
