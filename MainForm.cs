
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DatabaseManagementApp
{
    public partial class MainForm : Form
    {
        private string connectionString = "YourConnectionStringHere";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Items";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    listBoxItems.Items.Clear();
                    while (reader.Read())
                    {
                        listBoxItems.Items.Add($"{reader["Id"]}: {reader["Name"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Items (Name) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Item added successfully!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding item: {ex.Message}");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to update.");
                return;
            }

            string selectedItem = listBoxItems.SelectedItem.ToString();
            int id = int.Parse(selectedItem.Split(':')[0]);
            string newName = txtName.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Items SET Name = @Name WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", newName);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Item updated successfully!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating item: {ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            string selectedItem = listBoxItems.SelectedItem.ToString();
            int id = int.Parse(selectedItem.Split(':')[0]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Items WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Item deleted successfully!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item: {ex.Message}");
                }
            }
        }
    }
}
