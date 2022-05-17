using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Lagebeziehungen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ZahlenEingabePrüfung(object sender, TextCompositionEventArgs e) //ist aus Eigenschaften genommen "PreviewTextInput"
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[+-]?[0-9]*(\\.|\\,)?$");
            //e.Handled = !Regex.IsMatch(e.Text, "^[+-]?[0-9]*(\\.|\\,)?$");
            //^ Anfang
            //$ Ende
            //| oder
            //
            //? 0 oder 1
            //+ 0 oder beliebig
            //* 1 oder beliebig (viel Zeichen)
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Vector3 a = new Vector3(); //besteht aus drei Daten mit dem Datentyp "float"
            Vector3 b = new Vector3();
            Vector3 c = new Vector3();

            //versuht wird string zu float übersetzen. Wenn gelingt, dann speichern in Variable. Wenn nicht, dann false als rückgabe
            if ((float.TryParse(tb_ax.Text, out a.X))==false) MessageBox.Show("Eingabefehler in ax");
             
        }
    }
}
