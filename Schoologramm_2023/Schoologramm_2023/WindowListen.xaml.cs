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

namespace Schoologramm_2023
{
    /// <summary>
    /// Interaktionslogik für WindowListen.xaml
    /// </summary>
    public partial class WindowListen : Window
    {
        private const string ConnectionString = "C:\\Users\\pasca\\OneDrive\\Dokumente\\GitHub\\LA_ILA2_1301\\Schoologramm_2023\\Schoologramm_2023\\_data\\Daten.sqlite";

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

        public void GenerateDataCheckBox()
        {
            using (SQLiteConnection connection = new SQLiteConnection($"Data Source={ConnectionString}; Version=3;"))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM HausaufgabenDaten", connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        //ChatGPT-----------------------------------------------
                        while (reader.Read())
                        {
                            CheckBox checkBox = new CheckBox
                            {
                                Content = reader["Datum"].ToString(),
                                Margin = new Thickness(5)
                            };

                            checkBoxPanel.Children.Add(checkBox);
                        }
                        //--------------------------------------------------------
                    }
                }
            }

        }
    }
}
