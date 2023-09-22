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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Schoologramm_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HausaufgabenInput hausaufgabenInput = new HausaufgabenInput(txtBox_Fach.Text, txtBox_Auftrag.Text, txtBox_Fälligkeit.Text);
            hausaufgabenInput.HausaufgabenUeberpruefung();

            if(hausaufgabenInput.Check == true)
            {
                txtBox_Fach.Clear();
                txtBox_Auftrag.Clear();
                txtBox_Fälligkeit.Clear();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrüfungInput prüfungInput = new PrüfungInput(txtBox_Prüfungsfach.Text, txtBox_Prüfungsstoff.Text, txtBox_Prüfungsdatum.Text);
            prüfungInput.PrüfungsUeberpruefung();

            if(prüfungInput.Check == true)
            {
                txtBox_Prüfungsfach.Clear();
                txtBox_Prüfungsstoff.Clear();
                txtBox_Prüfungsdatum.Clear();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Pagenavigation fertig stellen fffffasdasdasdasafasfsafasf
            Page_List.Navigate(new MyPage());
        }
    }
}
