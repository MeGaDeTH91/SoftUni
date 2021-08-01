package connection;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public abstract class Connector {
    protected static Connection connection;

    static {
        Properties props = new Properties();
        props.setProperty("user", "");
        props.setProperty("password", "");

        try {
            connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/minions_db", props);
        } catch (SQLException e){
            System.out.println("There was error while setting connection: " + e.getMessage());
        }
    }
}
