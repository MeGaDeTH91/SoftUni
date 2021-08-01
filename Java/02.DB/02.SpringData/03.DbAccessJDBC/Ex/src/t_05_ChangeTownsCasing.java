import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class t_05_ChangeTownsCasing extends Connector {
    public static void main(String[] args) throws SQLException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        System.out.print("Please enter country name: ");
        String country = reader.readLine();

        PreparedStatement updateTownsStatement =
                connection.prepareStatement("UPDATE towns\n" +
                        "SET `name` = UPPER(`name`)\n" +
                        "WHERE country = ?;");
        updateTownsStatement.setNString(1, country);
        int rowsUpdated = updateTownsStatement.executeUpdate();

        PreparedStatement getTownsStatement =
                connection.prepareStatement("SELECT `name`\n" +
                        "FROM towns\n" +
                        "WHERE country = ?;");
        getTownsStatement.setNString(1, country);
        var res = getTownsStatement.executeQuery();
        List<String> towns = new ArrayList<>();

        while (res.next()) {
            String currentTown = res.getString("name");
            towns.add(currentTown);
        }

        if (towns.isEmpty()) {
            System.out.println("No town names were affected.");
        } else {
            System.out.println(rowsUpdated + " town names were affected.");
            System.out.println(towns);
        }
    }
}
