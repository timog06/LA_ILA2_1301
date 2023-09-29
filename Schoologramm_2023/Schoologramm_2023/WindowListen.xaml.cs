using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HausaufgabenDaten", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
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
