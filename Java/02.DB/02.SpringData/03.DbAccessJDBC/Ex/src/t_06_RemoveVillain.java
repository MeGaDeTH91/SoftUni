import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class t_06_RemoveVillain extends Connector {
    public static void main(String[] args) throws IOException, SQLException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        int villainId = Integer.parseInt(reader.readLine());

        try {
            connection.setAutoCommit(false);
            PreparedStatement getVillainStatement =
                    connection.prepareStatement("SELECT id, `name`\n" +
                            "FROM villains\n" +
                            "WHERE id = ?;");
            getVillainStatement.setInt(1, villainId);
            var villainRes = getVillainStatement.executeQuery();
            String villainName = null;

            while (villainRes.next()) {
                villainName = villainRes.getNString("name");
            }

            if (villainName == null) {
                System.out.println("No such villain was found");
            } else {
                PreparedStatement removeMinionsStatement =
                        connection.prepareStatement("DELETE FROM minions_villains\n" +
                                "WHERE villain_id = ?;");
                removeMinionsStatement.setInt(1, villainId);
                int rowsUpdated = removeMinionsStatement.executeUpdate();

                PreparedStatement removeVillainStatement =
                        connection.prepareStatement("DELETE FROM villains\n" +
                                "WHERE id = ?;");
                removeVillainStatement.setInt(1, villainId);
                int villainRemoved = removeVillainStatement.executeUpdate();

                if (villainRemoved > 0) {
                    System.out.println(villainName + " was deleted");
                    System.out.println(rowsUpdated + " minions released");
                }
            }
            connection.commit();
        } catch (SQLException e) {
            connection.rollback();
        }

    }
}
