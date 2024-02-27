using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SoccerstarClassicTool;
using MySql.Data.MySqlClient;

namespace SoccerStarClassicTool_remaster
{
    public partial class Form1 : Form
    {
        // Name of the controls
        private string amountTextBoxName = "textBox1";
        private string operationComboBoxName = "comboBox1";

        private string amountTextBoxNameSilver = "textBox6";
        private string operationComboBoxNameSilver = "comboBox4";

        private bool isDarkMode = false;

        // The name of your table
        private string tableName = "users";

        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProperties();
            //LoadData();
            //LoadData2();

            // Load the mode
            isDarkMode = Properties.Settings.Default.isDarkMode;

            // Apply the appropriate theme
            if (isDarkMode)
            {
                SwitchToDarkMode();
            }
            else
            {
                SwitchToLightMode();
            }
        }

        private void RefreshData()
        {
            // Refresh data in dataGridView1
            LoadData();

            // Refresh data in dataGridView2
            LoadData2();
        }



        // CHANGE THEME OF APP
        private void button4_Click(object sender, EventArgs e)
        {
            // Get tab control
            string tabControlName = "tabControl1";
            TabControl tabControl = (TabControl)this.Controls[tabControlName];

            // Access the fourth page (index 3)
            TabPage tabPage = tabControl.TabPages[3];

            // Get the Button from the TabPage
            Button button = (Button)tabPage.Controls["button4"];

            // Toggle the mode
            isDarkMode = !isDarkMode;

            // Save the mode
            Properties.Settings.Default.isDarkMode = isDarkMode;
            Properties.Settings.Default.Save();

            // Change the background image
            button.BackgroundImage = isDarkMode ? Properties.Resources.moon : Properties.Resources.sun;

            // Call the function to change the mode
            if (isDarkMode)
            {
                SwitchToDarkMode();
            }
            else
            {
                SwitchToLightMode();
            }
        }


        private void SwitchToDarkMode()
        {
            // Define dark colors
            Color darkColor = Color.FromArgb(32, 32, 32);
            Color lightTextColor = Color.White;
            Color darkTextColor = Color.Black;
            Color transparent = Color.Transparent;
            Color grayColor = Color.Gray;

            // Change the colors of the form and its controls to dark colors
            this.BackColor = darkColor;
            this.ForeColor = lightTextColor;

            // Change the colors of the TabControl and its TabPages
            tabControl1.BackColor = grayColor;
            tabPage1.BackColor = darkColor;
            tabPage2.BackColor = darkColor;
            tabPage3.BackColor = darkColor;
            tabPage4.BackColor = darkColor;

            // Change the colors of the controls on tabPage1
            label2.ForeColor = lightTextColor;
            label10.ForeColor = lightTextColor;
            label12.ForeColor = lightTextColor;
            button5.ForeColor = darkTextColor;
            button5.BackColor = lightTextColor;
            label1.ForeColor = lightTextColor;

            // Change the colors of the controls on tabPage2
            label3.ForeColor = lightTextColor;
            label8.ForeColor = lightTextColor;
            textBox1.BackColor = darkColor;
            textBox1.ForeColor = lightTextColor;
            button1.ForeColor = darkTextColor;
            button1.BackColor = lightTextColor;
            label9.ForeColor = lightTextColor;
            comboBox1.BackColor = darkColor;
            comboBox1.ForeColor = lightTextColor;
            label4.ForeColor = lightTextColor;
            label5.ForeColor = lightTextColor;
            textBox2.BackColor = darkColor;
            textBox2.ForeColor = lightTextColor;
            label6.ForeColor = lightTextColor;
            textBox3.BackColor = darkColor;
            textBox3.ForeColor = lightTextColor;
            label7.ForeColor = lightTextColor;
            comboBox2.BackColor = darkColor;
            comboBox2.ForeColor = lightTextColor;
            button2.ForeColor = darkTextColor;
            button2.BackColor = lightTextColor;
            dataGridView1.BackgroundColor = grayColor;
            dataGridView1.ForeColor = darkTextColor;
            dataGridView1.GridColor = lightTextColor;

            // Change the colors of the controls on tabPage3
            label19.ForeColor = lightTextColor;
            label14.ForeColor = lightTextColor;
            textBox6.BackColor = darkColor;
            textBox6.ForeColor = lightTextColor;
            button8.ForeColor = darkTextColor;
            button8.BackColor = lightTextColor;
            label13.ForeColor = lightTextColor;
            comboBox4.BackColor = darkColor;
            comboBox4.ForeColor = lightTextColor;
            label18.ForeColor = lightTextColor;
            label17.ForeColor = lightTextColor;
            textBox5.BackColor = darkColor;
            textBox5.ForeColor = lightTextColor;
            label16.ForeColor = lightTextColor;
            textBox4.BackColor = darkColor;
            textBox4.ForeColor = lightTextColor;
            label15.ForeColor = lightTextColor;
            comboBox3.BackColor = darkColor;
            comboBox3.ForeColor = lightTextColor;
            button6.ForeColor = darkTextColor;
            button6.BackColor = lightTextColor;
            dataGridView2.BackgroundColor = grayColor;
            dataGridView2.ForeColor = darkTextColor;
            dataGridView2.GridColor = lightTextColor;

            // Change the colors of the controls on tabPage4
            button4.ForeColor = transparent;
            button4.BackColor = transparent;

            button9.ForeColor = darkTextColor;
            button9.BackColor = lightTextColor;
        }

        private void SwitchToLightMode()
        {
            // Define light colors
            Color lightColor = SystemColors.Control;
            Color darkTextColor = SystemColors.ControlText;
            Color transparent = Color.Transparent;
            Color whiteColor = Color.White; // Define white color

            // Change the colors of the form and its controls to light colors
            this.BackColor = lightColor;
            this.ForeColor = darkTextColor;

            // Change the colors of the TabControl and its TabPages
            tabControl1.BackColor = lightColor;
            tabPage1.BackColor = lightColor;
            tabPage2.BackColor = lightColor;
            tabPage3.BackColor = lightColor;
            tabPage4.BackColor = lightColor;

            // Change the colors of the controls on tabPage1
            label2.ForeColor = darkTextColor;
            label10.ForeColor = darkTextColor;
            label12.ForeColor = darkTextColor;
            button5.ForeColor = darkTextColor;
            label1.ForeColor = darkTextColor;

            // Change the colors of the controls on tabPage2
            label3.ForeColor = darkTextColor;
            label8.ForeColor = darkTextColor;
            textBox1.BackColor = whiteColor; // Change to white
            textBox1.ForeColor = darkTextColor;
            button1.ForeColor = darkTextColor;
            label9.ForeColor = darkTextColor;
            comboBox1.BackColor = whiteColor;
            comboBox1.ForeColor = darkTextColor;
            label4.ForeColor = darkTextColor;
            label5.ForeColor = darkTextColor;
            textBox2.BackColor = whiteColor; // Change to white
            textBox2.ForeColor = darkTextColor;
            label6.ForeColor = darkTextColor;
            textBox3.BackColor = whiteColor; // Change to white
            textBox3.ForeColor = darkTextColor;
            label7.ForeColor = darkTextColor;
            comboBox2.BackColor = whiteColor;
            comboBox2.ForeColor = darkTextColor;
            button2.ForeColor = darkTextColor;
            dataGridView1.BackgroundColor = lightColor;
            dataGridView1.ForeColor = darkTextColor;
            dataGridView1.GridColor = darkTextColor;

            // Change the colors of the controls on tabPage3 for light mode
            label19.ForeColor = darkTextColor;
            label14.ForeColor = darkTextColor;
            textBox6.BackColor = whiteColor; // Change to white
            textBox6.ForeColor = darkTextColor;
            button8.ForeColor = darkTextColor;
            button8.BackColor = whiteColor; // Change to white
            label13.ForeColor = darkTextColor;
            comboBox4.BackColor = whiteColor; // Change to white
            comboBox4.ForeColor = darkTextColor;
            label18.ForeColor = darkTextColor;
            label17.ForeColor = darkTextColor;
            textBox5.BackColor = whiteColor; // Change to white
            textBox5.ForeColor = darkTextColor;
            label16.ForeColor = darkTextColor;
            textBox4.BackColor = whiteColor; // Change to white
            textBox4.ForeColor = darkTextColor;
            label15.ForeColor = darkTextColor;
            comboBox3.BackColor = whiteColor; // Change to white
            comboBox3.ForeColor = darkTextColor;
            button6.ForeColor = darkTextColor;
            button6.BackColor = whiteColor; // Change to white
            dataGridView2.BackgroundColor = lightColor;
            dataGridView2.ForeColor = darkTextColor;
            dataGridView2.GridColor = darkTextColor;



            // Change the colors of the controls on tabPage4
            button4.ForeColor = transparent;
            button4.BackColor = transparent;
            button9.ForeColor = darkTextColor;
            button9.BackColor = whiteColor; // Change to white
            
        }


        // FUNCTIONS RELATED TO STARS --------------------------------------------------------------------


        // MANAGE STARS FOR EVERYONE
        private void button1_Click(object sender, EventArgs e)
        {
            // Get tab control
            string tabControlName = "tabControl1";
            TabControl tabControl = (TabControl)this.Controls[tabControlName];

            // Access star's page
            TabPage tabPage = tabControl.TabPages[1];

            // Get the amount from the TextBox
            TextBox amountTextBox = (TextBox)tabPage.Controls[amountTextBoxName];
            string amountText = amountTextBox.Text;

            // Check if the amount field is empty
            if (string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please enter an amount.");
                return;
            }

            // Check if the amount field contains only numbers
            if (!long.TryParse(amountText, out long amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            // Get the operation from the ComboBox
            ComboBox operationComboBox = (ComboBox)tabPage.Controls[operationComboBoxName];
            string operation = operationComboBox.SelectedItem?.ToString();

            // Check if an operation is selected
            if (string.IsNullOrWhiteSpace(operation))
            {
                MessageBox.Show("Please select an operation.");
                return;
            }

            // Perform the operation
            try
            {
                Connection conn = new Connection();
                conn.Open();

                string query = "";
                switch (operation)
                {
                    case "Add":
                        query = $"UPDATE {tableName} SET stars = stars + @amount";
                        break;
                    case "Remove":
                        query = $"UPDATE {tableName} SET stars = CASE WHEN stars - @amount < 0 THEN 0 ELSE stars - @amount END";
                        break;
                    case "Set":
                        query = $"UPDATE {tableName} SET stars = @amount";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation.");
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                // Reset the controls and display a success message
                amountTextBox.Clear();
                operationComboBox.SelectedIndex = -1;
                MessageBox.Show("Operation completed successfully.");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        // MANAGE STARS FOR A SPECIFIC USER
        private void button2_Click(object sender, EventArgs e)
        {
            // Get tab control
            string tabControlName = "tabControl1";
            TabControl tabControl = (TabControl)this.Controls[tabControlName];

            // Access star's page
            TabPage tabPage = tabControl.TabPages[1];

            // Get the username from the TextBox
            TextBox usernameTextBox = (TextBox)tabPage.Controls["textBox2"];
            string username = usernameTextBox.Text;

            // Check if the username field is empty
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // Get the amount from the TextBox
            TextBox amountTextBox = (TextBox)tabPage.Controls["textBox3"];
            string amountText = amountTextBox.Text;

            // Check if the amount field is empty
            if (string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please enter an amount.");
                return;
            }

            // Check if the amount field contains only numbers
            if (!long.TryParse(amountText, out long amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            // Get the operation from the ComboBox
            ComboBox operationComboBox = (ComboBox)tabPage.Controls["comboBox2"];
            string operation = operationComboBox.SelectedItem?.ToString();

            // Check if an operation is selected
            if (string.IsNullOrWhiteSpace(operation))
            {
                MessageBox.Show("Please select an operation.");
                return;
            }

            // Perform the operation
            try
            {
                Connection conn = new Connection();
                conn.Open();

                // Check if the username exists in the database
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE username = @username", conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result == null || Convert.ToInt32(result) == 0)
                    {
                        MessageBox.Show("The username does not exist in the database.");
                        return;
                    }
                }

                // CHANGE 'stars' TO WHATEVVER FIELD U HAVE IN UR DATABASE
                string query = "";
                switch (operation)
                {
                    case "Add":
                        query = $"UPDATE {tableName} SET stars = stars + @amount WHERE username = @username";
                        break;
                    case "Remove":
                        query = $"UPDATE {tableName} SET stars = CASE WHEN stars - @amount < 0 THEN 0 ELSE stars - @amount END WHERE username = @username";
                        break;
                    case "Set":
                        query = $"UPDATE {tableName} SET stars = @amount WHERE username = @username";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation.");
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                // Reset the controls and display a success message
                usernameTextBox.Clear();
                amountTextBox.Clear();
                operationComboBox.SelectedIndex = -1;
                MessageBox.Show("Operation completed successfully.");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }




        // CHECK IF THE SERVER CONNECTION WITH THE TOOL IS ON OR OFF
        private void button5_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection();
            string result = conn.TestConnection();

            // Get the label from the TabPage's Controls collection
            string labelName = "label11";
            Label statusLabel = (Label)tabControl1.TabPages[0].Controls[labelName];

            if (result == "Connection successful.")
            {
                statusLabel.Text = "ON";
                statusLabel.ForeColor = Color.Green;
                RefreshData();
            }
            else
            {
                statusLabel.Text = "OFF";
                statusLabel.ForeColor = Color.Red;
            }

            MessageBox.Show(result);
        }

        // LOAD THE USERS TO THE TABLE...
        private void LoadData()
        {
            try
            {
                Connection conn = new Connection();
                conn.Open();

                // Modify the query to select only the id, username, and stars fields
                string query = $"SELECT id, username, stars FROM {tableName}";

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Set the DataGridView's DataSource to the DataTable
                        dataGridView1.DataSource = table;
                    }
                }

                conn.Close();

                // Adjust the column widths
                dataGridView1.Columns["id"].Width = 50; // Adjust as needed
                dataGridView1.Columns["username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["stars"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }



        // FUNCTIONS RELATED TO SILVER COINS --------------------------------------------------------------------



        // MANAGE SILVER FOR EVERYONE
        private void button8_Click(object sender, EventArgs e)
        {
            // Get tab control
            string tabControlName = "tabControl1";
            TabControl tabControl = (TabControl)this.Controls[tabControlName];

            // Access silver's page
            TabPage tabPage = tabControl.TabPages[2];

            // Get the amount from the TextBox
            TextBox amountTextBox = (TextBox)tabPage.Controls[amountTextBoxNameSilver];
            string amountText = amountTextBox.Text;

            // Check if the amount field is empty
            if (string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please enter an amount.");
                return;
            }

            // Check if the amount field contains only numbers
            if (!long.TryParse(amountText, out long amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            // Get the operation from the ComboBox
            ComboBox operationComboBox = (ComboBox)tabPage.Controls[operationComboBoxNameSilver];
            string operation = operationComboBox.SelectedItem?.ToString();

            // Check if an operation is selected
            if (string.IsNullOrWhiteSpace(operation))
            {
                MessageBox.Show("Please select an operation.");
                return;
            }

            // Perform the operation
            try
            {
                Connection conn = new Connection();
                conn.Open();

                // CHANGE 'silver' TO WHATEVVER FIELD U HAVE IN UR DATABASE
                string query = "";
                switch (operation)
                {
                    case "Add":
                        query = $"UPDATE {tableName} SET silver = silver + @amount";
                        break;
                    case "Remove":
                        query = $"UPDATE {tableName} SET silver = CASE WHEN silver - @amount < 0 THEN 0 ELSE silver - @amount END";
                        break;
                    case "Set":
                        query = $"UPDATE {tableName} SET silver = @amount";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation.");
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                // Reset the controls and display a success message
                amountTextBox.Clear();
                operationComboBox.SelectedIndex = -1;
                MessageBox.Show("Operation completed successfully.");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // MANAGE SILVER FOR A SPECIFIC USER
        private void button6_Click(object sender, EventArgs e)
        {
            // Get tab control
            string tabControlName = "tabControl1";
            TabControl tabControl = (TabControl)this.Controls[tabControlName];

            // Access silver's page
            TabPage tabPage = tabControl.TabPages[2];

            // Get the username from the TextBox
            TextBox usernameTextBox = (TextBox)tabPage.Controls["textBox5"];
            string username = usernameTextBox.Text;

            // Check if the username field is empty
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // Get the amount from the TextBox
            TextBox amountTextBox = (TextBox)tabPage.Controls["textBox4"];
            string amountText = amountTextBox.Text;

            // Check if the amount field is empty
            if (string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Please enter an amount.");
                return;
            }

            // Check if the amount field contains only numbers
            if (!long.TryParse(amountText, out long amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            // Get the operation from the ComboBox
            ComboBox operationComboBox = (ComboBox)tabPage.Controls["comboBox3"];
            string operation = operationComboBox.SelectedItem?.ToString();

            // Check if an operation is selected
            if (string.IsNullOrWhiteSpace(operation))
            {
                MessageBox.Show("Please select an operation.");
                return;
            }

            // Perform the operation
            try
            {
                Connection conn = new Connection();
                conn.Open();

                // Check if the username exists in the database
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE username = @username", conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result == null || Convert.ToInt32(result) == 0)
                    {
                        MessageBox.Show("The username does not exist in the database.");
                        return;
                    }
                }

                string query = "";
                switch (operation)
                {
                    case "Add":
                        query = $"UPDATE {tableName} SET silver = silver + @amount WHERE username = @username";
                        break;
                    case "Remove":
                        query = $"UPDATE {tableName} SET silver = CASE WHEN silver - @amount < 0 THEN 0 ELSE silver - @amount END WHERE username = @username";
                        break;
                    case "Set":
                        query = $"UPDATE {tableName} SET silver = @amount WHERE username = @username";
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation.");
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                // Reset the controls and display a success message
                usernameTextBox.Clear();
                amountTextBox.Clear();
                operationComboBox.SelectedIndex = -1;
                MessageBox.Show("Operation completed successfully.");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        // LOAD THE USERS TO THE TABLE...
        private void LoadData2()
        {
            try
            {
                Connection conn = new Connection();
                conn.Open();

                // Modify the query to select only the id, username, and silver fields
                string query = $"SELECT id, username, silver FROM {tableName}";

                using (MySqlCommand cmd = new MySqlCommand(query, conn.GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Set the DataGridView's DataSource to the DataTable
                        dataGridView2.DataSource = table;
                    }
                }

                conn.Close();

                // Adjust the column widths
                dataGridView2.Columns["id"].Width = 50; // Adjust as needed
                dataGridView2.Columns["username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns["silver"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SaveProperties()
        {
            // Save the settings
           Properties.Settings.Default.Server = serverField.Text;
           Properties.Settings.Default.Database = databaseField.Text;
           Properties.Settings.Default.UserId = userField.Text;
           Properties.Settings.Default.Password = passwordField.Text;

            // Save the changes
            Properties.Settings.Default.Save();

            // Display a success message
            MessageBox.Show("Settings saved successfully.");
            RefreshData();
        }


        private void LoadProperties()
        {
            // Access the tabPage3
            TabPage tabPage3 = tabControl1.TabPages[3];

            // Get the TextBoxes and CheckBox from tabPage3
            TextBox serverField = (TextBox)tabPage3.Controls["serverField"];
            TextBox databaseField = (TextBox)tabPage3.Controls["databaseField"];
            TextBox userField = (TextBox)tabPage3.Controls["userField"];
            TextBox passwordField = (TextBox)tabPage3.Controls["passwordField"];

            // Load the settings into the TextBoxes and CheckBox
            serverField.Text = SoccerStarClassicTool_remaster.Properties.Settings.Default.Server;
            databaseField.Text = SoccerStarClassicTool_remaster.Properties.Settings.Default.Database;
            userField.Text = SoccerStarClassicTool_remaster.Properties.Settings.Default.UserId;
            passwordField.Text = SoccerStarClassicTool_remaster.Properties.Settings.Default.Password;

        }


        // SAVE MY DB CONFIGS
        private void button9_Click(object sender, EventArgs e)
        {
            SaveProperties();
        }

    } //END
}
