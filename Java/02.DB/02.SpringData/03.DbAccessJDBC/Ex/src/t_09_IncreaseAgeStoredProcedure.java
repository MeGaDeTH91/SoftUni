import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class t_09_IncreaseAgeStoredProcedure extends Connector {
    public static void main(String[] args) throws SQLException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int minionId = Integer.parseInt(reader.readLine());

        PreparedStatement updateMinionStatement =
                connection.prepareStatement("CALL usp_get_older(?);");

        updateMinionStatement.setInt(1, minionId);
        updateMinionStatement.executeUpdate();

        PreparedStatement getMinionsStatement =
                connection.prepareStatement("SELECT `name`,\n" +
                        "age\n" +
                        "FROM minions\n" +
                        "WHERE id = ?;");

        getMinionsStatement.setInt(1, minionId);
        var minionsRes = getMinionsStatement.executeQuery();

        while (minionsRes.next()) {
            System.out.println(minionsRes.getString("name") + " " +
                    minionsRes.getInt("age"));
        }
    }
}
