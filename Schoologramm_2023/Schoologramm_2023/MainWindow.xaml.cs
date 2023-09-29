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
            ButtonEnable();
        }

        private void ButtonEnable()
        {
            aufgabe_Einschreiben.IsEnabled = false;
            prüfung_Einschreiben.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HausaufgabenInput hausaufgabenInput = new HausaufgabenInput(txtBox_Fach.Text, txtBox_Auftrag.Text, txtBox_Fälligkeit.Text);
            hausaufgabenInput.HausaufgabenUeberpruefung();

            if (hausaufgabenInput.Check == true)
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

            if (prüfungInput.Check == true)
            {
                txtBox_Prüfungsfach.Clear();
                txtBox_Prüfungsstoff.Clear();
                txtBox_Prüfungsdatum.Clear();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //---------------------------------------------
            WindowListen windowListen = new WindowListen();
            windowListen.Show();

            this.Close();
            // From Chat GPT-------------------------------
        }

        private void txtBox_Fälligkeit_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerAufgaben();
        }

        private void txtBox_Auftrag_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerAufgaben();
        }

        private void txtBox_Fach_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerAufgaben();
        }
        private void TextChangerAufgaben()
        {
            if (txtBox_Fach.Text != "" && txtBox_Auftrag.Text != "" && txtBox_Fälligkeit.Text != "")
            {
                aufgabe_Einschreiben.IsEnabled = true;
            }
            else
            {
                aufgabe_Einschreiben.IsEnabled = false;
            }
        }

        private void txtBox_Prüfungsdatum_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerPrüfung();
        }

        private void txtBox_Prüfungsfach_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerPrüfung();
        }

        private void txtBox_Prüfungsstoff_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChangerPrüfung();
        }
        private void TextChangerPrüfung()
        {
            if (txtBox_Prüfungsfach.Text != "" && txtBox_Prüfungsstoff.Text != "" && txtBox_Prüfungsdatum.Text != "")
            {
                prüfung_Einschreiben.IsEnabled = true;
            }
            else
            {
                prüfung_Einschreiben.IsEnabled = false;
            }
        }
    }
}
