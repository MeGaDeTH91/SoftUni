import java.io.File;
import java.io.PrintWriter;

public class t_08_get_folder_size {
    public static void main(String[] args) {
        try {
            File file = new File(System.getProperty("user.dir") + "../../Resources/Exercises Resources");
            long size = folderSize(file);

            PrintWriter writer = new PrintWriter(new File(System.getProperty("user.dir") + "../../Resources/folder-size.txt"));

            writer.write(String.format("Folder size: %d%n", size));

            writer.flush();
            writer.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public static long folderSize(File directory) {
        long length = 0;
        for (File file : directory.listFiles()) {
            if (file.isFile())
                length += file.length();
            else
                length += folderSize(file);
        }
        return length;
    }
}
