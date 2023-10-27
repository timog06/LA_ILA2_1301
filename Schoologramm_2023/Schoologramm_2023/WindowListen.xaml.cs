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
        private string ConnectionString = new DatabaseManager(@".\Daten.sqlite", @".\DatenArchive.sqlite")._databasePath;
        private const string HausaufgabenDaten = "HausaufgabenDaten";
        private const string PrüfungsDaten = "PrüfungsDaten";

        private string tabelle;

        public WindowListen()
        {
            InitializeComponent();
            GenerateDataCheckBox();
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
            for (int i = 0; i < 2; i++)
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
                {
                    connection.Open();
                    if (i == 0) { tabelle = HausaufgabenDaten; }
                    else { tabelle = PrüfungsDaten; }
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM {tabelle}", connection))
                    {
                        //ChatGPT----------------------------------------------------------------------------------------
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Hinzufügen einer Spalte für die Auswahl per Checkbox
                        DataColumn selectColumn = new DataColumn("IsSelected", typeof(bool)) { DefaultValue = false };
                        dt.Columns.Add(selectColumn);

                        if (i == 0)
                        {
                            dataGrid.ItemsSource = dt.DefaultView;
                        }
                        else { dataGridPrüfung.ItemsSource = dt.DefaultView; }
                        //------------------------------------------------------------------------------------------------
                    }
                }
            }


        }

        private void dataGridPrüfung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridPrüfungArchiv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}



