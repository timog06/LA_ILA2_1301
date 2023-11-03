using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Schoologramm_2023
{
    /// <summary>
    /// Interaktionslogik für WindowListen.xaml
    /// </summary>
    public partial class WindowListen : Window
    {
        private string ConnectionString = new DatabaseManager(@".\Daten.sqlite", @".\DatenArchiv.sqlite")._databasePath;
        private string ConnectionArchiveString = new DatabaseManager(@".\Daten.sqlite", @".\DatenArchiv.sqlite")._databaseArchivePath;

        private const string HausaufgabenDaten = "HausaufgabenDaten";
        private const string PrüfungsDaten = "PrüfungsDaten";



        private string tabelle;

        public WindowListen()
        {
            InitializeComponent();
            GenerateDataCheckBox();
            GenerateDataArchiveCheckBox();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //----------------------------------------
            MainWindow mainWindows = new MainWindow();
            mainWindows.Show();

            this.Close();
            //From Chat GPT---------------------------
        }

        private void GenerateDataCheckBox()
        {
            for (int i = 0; i < 2; i++)
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
                {
                    connection.Open();
                    if (i == 0) { tabelle = HausaufgabenDaten; }
                    else { tabelle = PrüfungsDaten; }

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM {tabelle}", connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (i == 0)
                        {
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        else
                        {
                            dataGridPrüfung.ItemsSource = dt.DefaultView;
                        }

                    }

                }
            }
        }
        private void GenerateDataArchiveCheckBox()
        {
            for (int i = 0; i < 2; i++)
            {
                using (SQLiteConnection archiveconnection = new SQLiteConnection($"Data Source={ConnectionArchiveString}; Version=3;"))
                {
                    archiveconnection.Open();
                    if (i == 0) { tabelle = HausaufgabenDaten; }
                    else { tabelle = PrüfungsDaten; }

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM {tabelle}", archiveconnection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (i == 0)
                        {
                            dataGridArchiv.ItemsSource = dt.DefaultView;
                        }
                        else
                        {
                            dataGridPrüfungArchiv.ItemsSource = dt.DefaultView;
                        }
                    }

                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                string currentDataConnection = @".\Daten.sqlite";
                string archiveDataConnection = @".\DatenArchiv.sqlite";

                using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
                using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
                {
                    currentConnection.Open();
                    archiveConnection.Open();

                    DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                    int selectedItemId = Convert.ToInt32(selectedRow["ID"]);

                    using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO HausaufgabenDaten (Datum, Fach, Auftrag) VALUES (@Datum, @Fach, @Auftrag)", archiveConnection))
                    {
                        insertCommand.Parameters.AddWithValue("@Datum", selectedRow["Datum"]);
                        insertCommand.Parameters.AddWithValue("@Fach", selectedRow["Fach"]);
                        insertCommand.Parameters.AddWithValue("@Auftrag", selectedRow["Auftrag"]);
                        insertCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM HausaufgabenDaten WHERE ID = @ID", currentConnection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", selectedItemId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
        }


        private void dataGridArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridArchiv.SelectedItem != null)
            {
                string currentDataConnection = @".\Daten.sqlite";
                string archiveDataConnection = @".\DatenArchiv.sqlite";

                using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
                using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
                {
                    currentConnection.Open();
                    archiveConnection.Open();

                    DataRowView selectedRow = (DataRowView)dataGridArchiv.SelectedItem;
                    int selectedItemId = Convert.ToInt32(selectedRow["ID"]);

                    using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO HausaufgabenDaten (Datum, Fach, Auftrag) VALUES (@Datum, @Fach, @Auftrag)", currentConnection))
                    {
                        insertCommand.Parameters.AddWithValue("@Datum", selectedRow["Datum"]);
                        insertCommand.Parameters.AddWithValue("@Fach", selectedRow["Fach"]);
                        insertCommand.Parameters.AddWithValue("@Auftrag", selectedRow["Auftrag"]);
                        insertCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM HausaufgabenDaten WHERE ID = @ID", archiveConnection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", selectedItemId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
        }



        private void dataGridPrüfung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPrüfung.SelectedItem != null)
            {
                string currentDataConnection = @".\Daten.sqlite";
                string archiveDataConnection = @".\DatenArchiv.sqlite";

                using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
                using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
                {
                    currentConnection.Open();
                    archiveConnection.Open();

                    DataRowView selectedRow = (DataRowView)dataGridPrüfung.SelectedItem;
                    int selectedItemId = Convert.ToInt32(selectedRow["ID"]);

                    using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO PrüfungsDaten (Datum, Fach, Stoff) VALUES (@Datum, @Fach, @Stoff)", archiveConnection))
                    {
                        insertCommand.Parameters.AddWithValue("@Datum", selectedRow["Datum"]);
                        insertCommand.Parameters.AddWithValue("@Fach", selectedRow["Fach"]);
                        insertCommand.Parameters.AddWithValue("@Stoff", selectedRow["Stoff"]);
                        insertCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM PrüfungsDaten WHERE ID = @ID", currentConnection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", selectedItemId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
        }



        private void dataGridPrüfungArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPrüfungArchiv.SelectedItem != null)
            {
                string currentDataConnection = @".\Daten.sqlite";
                string archiveDataConnection = @".\DatenArchiv.sqlite";

                using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
                using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
                {
                    currentConnection.Open();
                    archiveConnection.Open();

                    DataRowView selectedRow = (DataRowView)dataGridPrüfungArchiv.SelectedItem;
                    int selectedItemId = Convert.ToInt32(selectedRow["ID"]);

                    using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO PrüfungsDaten (Datum, Fach, Stoff) VALUES (@Datum, @Fach, @Stoff)", currentConnection))
                    {
                        insertCommand.Parameters.AddWithValue("@Datum", selectedRow["Datum"]);
                        insertCommand.Parameters.AddWithValue("@Fach", selectedRow["Fach"]);
                        insertCommand.Parameters.AddWithValue("@Stoff", selectedRow["Stoff"]);
                        insertCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM PrüfungsDaten WHERE ID = @ID", archiveConnection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ID", selectedItemId);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
