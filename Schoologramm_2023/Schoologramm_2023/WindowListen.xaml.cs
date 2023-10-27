using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;

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

        /* public void GenerateDataCheckBox()
         {
             using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
             {
                 connection.Open();
                 using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM HausaufgabenDaten", connection))
                 {
                     using (SQLiteDataReader Attribute = cmd.ExecuteReader())
                     {
                         //ChatGPT-----------------------------------------------
                         while (Attribute.Read())
                         {
                             CheckBox checkBox = new CheckBox
                             {
                                 Content = Attribute["Datum"].ToString() + ", " +
                                           Attribute["Fach"].ToString() + ", " +
                                           Attribute["Auftrag"].ToString(),

                                 Margin = new Thickness(5)
                             };

                             checkBoxPanel.Children.Add(checkBox);
                         }
                         //--------------------------------------------------------
                     }
                 }
             }

             using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
             {
                 connection.Open();
                 using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM PrüfungsDaten", connection))
                 {
                     using (SQLiteDataReader Attribute = cmd.ExecuteReader())
                     {
                         //ChatGPT-----------------------------------------------
                         while (Attribute.Read())
                         {
                             CheckBox checkBox = new CheckBox
                             {
                                 Content = Attribute["Datum"].ToString() + ", " +
                                           Attribute["Fach"].ToString() + ", " +
                                           Attribute["Stoff"].ToString(),

                                 Margin = new Thickness(5)
                             };

                             checkBoxPanelPrüfung.Children.Add(checkBox);
                         }
                         //--------------------------------------------------------
                     }
                 }

             }
        */
        private void GenerateDataCheckBox()
        {
            for (int i = 0; i < 3; i++)
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
            for (int i = 0; i < 3; i++)
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionArchiveString}; Version=3;"))
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

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentDataConnection = @".\Daten.sqlite";
            string archiveDataConnection = @".\DatenArchiv.sqlite";

            using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
            using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
            {
                currentConnection.Open();
                archiveConnection.Open();

                DataTable selectedRows = ((DataView)dataGrid.ItemsSource).Table;

                using (SQLiteTransaction transaction = currentConnection.BeginTransaction())
                {
                    using (SQLiteCommand updateCommand = new SQLiteCommand("UPDATE HausaufgabenDaten SET IsSelected = 1 WHERE IsSelected = 0", currentConnection, transaction))
                    {
                        updateCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM HausaufgabenDaten WHERE IsSelected = 1", currentConnection, transaction))
                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO HausaufgabenDaten (Datum, Fach, Auftrag, IsSelected) VALUES (@Datum, @Fach, @Auftrag, 0)", archiveConnection))
                            {
                                insertCommand.Parameters.AddWithValue("@Datum", reader.GetString(reader.GetOrdinal("Datum")));
                                insertCommand.Parameters.AddWithValue("@Fach", reader.GetString(reader.GetOrdinal("Fach")));
                                insertCommand.Parameters.AddWithValue("@Auftrag", reader.GetString(reader.GetOrdinal("Auftrag")));
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM HausaufgabenDaten WHERE IsSelected = 1", currentConnection, transaction))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }


        private void dataGridArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentDataConnection = @".\Daten.sqlite";
            string archiveDataConnection = @".\DatenArchiv.sqlite";

            using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
            using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
            {
                currentConnection.Open();
                archiveConnection.Open();

                DataTable selectedRows = ((DataView)dataGridArchiv.ItemsSource).Table;

                using (SQLiteTransaction transaction = archiveConnection.BeginTransaction())
                {
                    using (SQLiteCommand updateCommand = new SQLiteCommand("UPDATE HausaufgabenDaten SET IsSelected = 0 WHERE IsSelected = 1", archiveConnection, transaction))
                    {
                        updateCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM HausaufgabenDaten WHERE IsSelected = 0", archiveConnection, transaction))
                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO HausaufgabenDaten (IsSelected, Datum, Fach, Auftrag) VALUES (0, @Datum, @Fach, @Auftrag)", currentConnection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@Datum", reader.GetString(reader.GetOrdinal("Datum")));
                                insertCommand.Parameters.AddWithValue("@Fach", reader.GetString(reader.GetOrdinal("Fach")));
                                insertCommand.Parameters.AddWithValue("@Auftrag", reader.GetString(reader.GetOrdinal("Auftrag")));
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM HausaufgabenDaten WHERE IsSelected = 0", archiveConnection, transaction))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

        }


        private void dataGridPrüfung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentDataConnection = @".\Daten.sqlite";
            string archiveDataConnection = @".\DatenArchiv.sqlite";

            using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
            using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
            {
                currentConnection.Open();
                archiveConnection.Open();

                DataTable selectedRows = ((DataView)dataGrid.ItemsSource).Table;

                using (SQLiteTransaction transaction = currentConnection.BeginTransaction())
                {
                    using (SQLiteCommand updateCommand = new SQLiteCommand("UPDATE PrüfungsDaten SET IsSelected = 1 WHERE IsSelected = 0", currentConnection, transaction))
                    {
                        updateCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM PrüfungsDaten WHERE IsSelected = 1", currentConnection, transaction))
                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO PrüfungsDaten (Datum, Fach, Stoff, IsSelected) VALUES (@Datum, @Fach, @Stoff, 0)", archiveConnection))
                            {
                                insertCommand.Parameters.AddWithValue("@Datum", reader.GetString(reader.GetOrdinal("Datum")));
                                insertCommand.Parameters.AddWithValue("@Fach", reader.GetString(reader.GetOrdinal("Fach")));
                                insertCommand.Parameters.AddWithValue("@Stoff", reader.GetString(reader.GetOrdinal("Stoff")));
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM PrüfungsDaten WHERE IsSelected = 1", currentConnection, transaction))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }


        private void dataGridPrüfungArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentDataConnection = @".\Daten.sqlite";
            string archiveDataConnection = @".\DatenArchiv.sqlite";

            using (SQLiteConnection currentConnection = new SQLiteConnection($"Data Source={currentDataConnection}; Version=3;"))
            using (SQLiteConnection archiveConnection = new SQLiteConnection($"Data Source={archiveDataConnection}; Version=3;"))
            {
                currentConnection.Open();
                archiveConnection.Open();

                DataTable selectedRows = ((DataView)dataGridArchiv.ItemsSource).Table;

                using (SQLiteTransaction transaction = archiveConnection.BeginTransaction())
                {
                    using (SQLiteCommand updateCommand = new SQLiteCommand("UPDATE PrüfungsDaten SET IsSelected = 0 WHERE IsSelected = 1", archiveConnection, transaction))
                    {
                        updateCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand selectCommand = new SQLiteCommand("SELECT * FROM PrüfungsDaten WHERE IsSelected = 0", archiveConnection, transaction))
                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO PrüfungsDaten (IsSelected, Datum, Fach, Stoff) VALUES (0, @Datum, @Fach, @Stoff)", currentConnection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@Datum", reader.GetString(reader.GetOrdinal("Datum")));
                                insertCommand.Parameters.AddWithValue("@Fach", reader.GetString(reader.GetOrdinal("Fach")));
                                insertCommand.Parameters.AddWithValue("@Stoff", reader.GetString(reader.GetOrdinal("Stoff")));
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    using (SQLiteCommand deleteCommand = new SQLiteCommand("DELETE FROM PrüfungsDaten WHERE IsSelected = 0", archiveConnection, transaction))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

        }

    }
}



