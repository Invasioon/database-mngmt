
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.io.FileWriter;
import java.io.IOException;

public class DatabaseExporter {

    public static void main(String[] args) {
        String connectionString = "jdbc:sqlserver://localhost;databaseName=YourDatabase;user=YourUser;password=YourPassword";
        String query = "SELECT * FROM Items";

        try (Connection connection = DriverManager.getConnection(connectionString);
             Statement statement = connection.createStatement();
             ResultSet resultSet = statement.executeQuery(query)) {

            FileWriter writer = new FileWriter("exported_data.csv");
            writer.write("Id,Name\n");

            while (resultSet.next()) {
                int id = resultSet.getInt("Id");
                String name = resultSet.getString("Name");
                writer.write(id + "," + name + "\n");
            }

            writer.close();
            System.out.println("Data exported successfully to exported_data.csv");

        } catch (Exception e) {
            System.out.println("Error exporting data: " + e.getMessage());
        }
    }
}
