import connection.Connector;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class t_04_AddMinion extends Connector {
    public static void main(String[] args) throws SQLException, IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String[] minionArgs = reader.readLine().split(" ");
        String minionName = minionArgs[1];
        int minionAge = Integer.parseInt(minionArgs[2]);
        String minionTown = minionArgs[3];

        String villainName = reader.readLine().split(" ")[1];

        int townId = -1;
        PreparedStatement townsStatement =
                connection.prepareStatement("SELECT id\n" +
                        "FROM towns\n" +
                        "WHERE `name` = ?");
        townsStatement.setNString(1, minionTown);
        var townRes = townsStatement.executeQuery();
        while (townRes.next()) {
            townId = townRes.getInt("id");
        }

        if (townId < 0) {
            PreparedStatement createTownStatement =
                    connection.prepareStatement("INSERT INTO towns(`name`)\n" +
                            "VALUES(\n" +
                            "?\n" +
                            ");");
            createTownStatement.setNString(1, minionTown);
            createTownStatement.executeUpdate();

            townRes = townsStatement.executeQuery();
            while (townRes.next()) {
                townId = townRes.getInt("id");
            }

            System.out.println("Town " + minionTown + " was added to the database.");
        }

        int villainId = -1;
        PreparedStatement villainsStatement =
                connection.prepareStatement("SELECT id\n" +
                        "FROM villains\n" +
                        "WHERE `name` = ?;");
        villainsStatement.setNString(1, villainName);
        var villainRes = villainsStatement.executeQuery();
        while (villainRes.next()) {
            villainId = villainRes.getInt("id");
        }

        if (villainId < 0) {
            PreparedStatement createVillainStatement =
                    connection.prepareStatement("INSERT INTO villains(`name`, evilness_factor)\n" +
                            "VALUES(\n" +
                            "?, 'evil'\n" +
                            ");");
            createVillainStatement.setNString(1, villainName);
            createVillainStatement.executeUpdate();

            villainRes = villainsStatement.executeQuery();
            while (villainRes.next()) {
                villainId = villainRes.getInt("id");
            }

            System.out.println("Villain " + villainName + " was added to the database.");
        }

        PreparedStatement createMinionStatement =
                connection.prepareStatement("INSERT INTO minions(`name`, age, town_id)\n" +
                        "VALUES(\n" +
                        "?, ?, ?\n" +
                        ");");
        createMinionStatement.setNString(1, minionName);
        createMinionStatement.setInt(2, minionAge);
        createMinionStatement.setInt(3, townId);
        createMinionStatement.executeUpdate();

        PreparedStatement minionStatement =
                connection.prepareStatement("SELECT id\n" +
                        "FROM minions\n" +
                        "WHERE `name` = ? AND age = ?;");
        minionStatement.setNString(1, minionName);
        minionStatement.setInt(2, minionAge);
        var minionRes = minionStatement.executeQuery();

        while (minionRes.next()) {
            int minionId = minionRes.getInt("id");

            PreparedStatement addMinionToVillainStatement =
                    connection.prepareStatement("INSERT INTO minions_villains(minion_id, villain_id)\n" +
                            "VALUES(\n" +
                            "?, ?\n" +
                            ");");
            addMinionToVillainStatement.setInt(1, minionId);
            addMinionToVillainStatement.setInt(2, villainId);
            int rowsAffected = addMinionToVillainStatement.executeUpdate();

            if (rowsAffected > 0) {
                System.out.println("Successfully added " + minionName + " to be minion of " + villainName);
            } else {
                System.out.println("There was problem adding " + minionName + " to database.");
            }

        }
    }
}
