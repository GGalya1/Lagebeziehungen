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
        List<TextBox> textBoxesEingabeVektoren = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
            int zeile = 1;
            int spalte = 0;
            for (int i = 0; i < 9; i++)
            {
                TextBox tb = new TextBox();
                tb.PreviewTextInput += ZahlenEingabePrüfung;
                Grid_Vektoren.Children.Add(tb);
                if (i < 3) { spalte = 1; }
                else if (i < 6) { spalte = 3; }
                else { spalte = 5; }

                Grid.SetColumn(tb, spalte);
                if (i % 3 == 0) zeile = 1;
                Grid.SetRow(tb, zeile++);

                textBoxesEingabeVektoren.Add(tb);
            }


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

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    Vector3 a = new Vector3(); //besteht aus drei Daten mit dem Datentyp "float"
        //    Vector3 b = new Vector3();
        //    Vector3 c = new Vector3();

        //    //versuht wird string zu float übersetzen. Wenn gelingt, dann speichern in Variable. Wenn nicht, dann false als rückgabe
        //    //if ((float.TryParse(tb_ax.Text, out a.X))==false) MessageBox.Show("Eingabefehler in ax");

        //}

        private void V_berechnen_Click(object sender, RoutedEventArgs e)
        {
            double[] vektor_a = new double[3];
            double[] vektor_b = new double[3];
            double[] vektor_c = new double[3];

            for (int i = 0; i < 3; i++)
            {
                if ((double.TryParse(textBoxesEingabeVektoren[i].Text, out vektor_a[i])) == false)
                {
                    MessageBox.Show("falsche EIngabe", "Fehler");
                }
                if ((double.TryParse(textBoxesEingabeVektoren[i + 3].Text, out vektor_b[i])) == false)
                {
                    MessageBox.Show("falsche EIngabe", "Fehler");
                }
                if ((double.TryParse(textBoxesEingabeVektoren[i + 6].Text, out vektor_c[i])) == false)
                {
                    MessageBox.Show("falsche EIngabe", "Fehler");
                }
            }

            //Beträge berechnen
            double Ba, Bb, Bc;
            Ba = Math.Sqrt(vektor_a[0] * vektor_a[0] + vektor_a[1] * vektor_a[1] + vektor_a[2] * vektor_a[2]);
            Bb = Math.Sqrt(vektor_b[0] * vektor_b[0] + vektor_b[1] * vektor_b[1] + vektor_b[2] * vektor_b[2]);
            Bc = Math.Sqrt(vektor_c[0] * vektor_c[0] + vektor_c[1] * vektor_c[1] + vektor_c[2] * vektor_c[2]);

            //Skalarprodukt
            double skalarproduktAB = vektor_a[0] * vektor_b[0] + vektor_a[1] * vektor_b[1] + vektor_a[2] * vektor_b[2];

            //Kreuzprodukt
            double[] kreuzproduktAB = new double[3];
            kreuzproduktAB[0] = vektor_a[1] * vektor_b[2] - vektor_a[2] * vektor_b[1];
            kreuzproduktAB[1] = vektor_a[2] * vektor_b[0] - vektor_a[0] * vektor_b[2];
            kreuzproduktAB[2] = vektor_a[0] * vektor_b[1] - vektor_a[1] * vektor_b[0];

            //Spatprodukt
            double spatprodukt = vektor_c[0] * kreuzproduktAB[0] + vektor_c[1] * kreuzproduktAB[1] + vektor_c[2] * kreuzproduktAB[2];

            //Ausgabe
            TB_Ba.Text = Ba.ToString();
            TB_Bb.Text = Bb.ToString();
            TB_Bc.Text = Bc.ToString();
            TB_SP.Text = skalarproduktAB.ToString();
            TB_SPP.Text = spatprodukt.ToString();
            TB_VP.Text = "( " + kreuzproduktAB[0] + "/" + kreuzproduktAB[1] + "/" + kreuzproduktAB[2] + ")";
        }
    }
}
