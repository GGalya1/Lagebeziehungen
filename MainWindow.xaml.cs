using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //List<TextBox> textBoxesEingabeVektoren = new List<TextBox>();
        Vector3 vecA = Vector3.UnitX; //dasselbe wie new(1,0,0)
        Vector3 vecB = new Vector3(0, 1, 0);
        Vector3 vecC = new Vector3(0, 0, 1);

        public event PropertyChangedEventHandler PropertyChanged; //jedes mal, wenn Propertz geandert wird, ruf das hier und mach was hier steht

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float VekAX //Binding ruft VekAX, bzw ruft get. get hat jetzt (1,0,0) 
        {
            get { return vecA.X; }
            set
            {
                if (value == vecA.X) return;
                vecA.X = value;
                NotifyPropertyChanged(nameof(VekAX));
            }
        }

        public float VekAY
        {
            get { return vecA.Y; }
            set
            {
                if (value == vecA.Y) return;
                vecA.Y = value;
            }
        }

        public float VekAZ
        {
            get { return vecA.Z; }
            set
            {
                if (value == vecA.Z) return;
                vecA.Z = value;
            }
        }

        public float VekBX
        {
            get { return vecB.X; }
            set
            {
                if (value == vecB.X) return;
                vecB.X = value;
            }
        }

        public float VekBY
        {
            get { return vecB.Y; }
            set
            {
                if (value == vecB.Y) return;
                vecB.Y = value;
            }
        }

        public float VekBZ
        {
            get { return vecB.Z; }
            set
            {
                if (value == vecB.Z) return;
                vecB.Z = value;
            }
        }

        public float VekCX
        {
            get { return vecC.X; }
            set
            {
                if (value == vecC.X) return;
                vecC.X = value;
            }
        }

        public float VekCY
        {
            get { return vecC.Y; }
            set
            {
                if (value == vecC.Y) return;
                vecC.Y = value;
            }
        }

        public float VekCZ
        {
            get { return vecC.Z; }
            set
            {
                if (value == vecC.Z) return;
                vecC.Z = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //int zeile = 1;
            //int spalte = 0;
            //for (int i = 0; i < 9; i++)
            //{
            //    TextBox tb = new TextBox();
            //    tb.PreviewTextInput += ZahlenEingabePrüfung;
            //    Grid_Vektoren.Children.Add(tb);
            //    if (i < 3) { spalte = 1; }
            //    else if (i < 6) { spalte = 3; }
            //    else { spalte = 5; }

            //    Grid.SetColumn(tb, spalte);
            //    if (i % 3 == 0) zeile = 1;
            //    Grid.SetRow(tb, zeile++);

            //    textBoxesEingabeVektoren.Add(tb);
            //}


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
            //Tab 1 Vektoren
            //Beiträge berechnen
            TB_Ba.Text = vecA.Length().ToString();
            TB_Bb.Text = vecB.Length().ToString();
            TB_Bc.Text = vecC.Length().ToString();

            //Skalarprodukt
            TB_SP.Text = Vector3.Dot(vecA, vecB).ToString();

            //Kreuzprodukt
            Vector3 KP = Vector3.Cross(vecA, vecB);
            TB_VP.Text = KP.ToString(); // das hat man von F12 gekuckt

            //Spatprodukt
            TB_SPP.Text = Vector3.Dot(KP, vecC).ToString();


            //Tab2 Punkt-Gerade
            //Geradengleichung
            Vector3 Richtungsvektor = vecC - vecA;
            TB_g.Text = "g: x = " + vecA.ToString() + " r * " + Richtungsvektor.ToString();

            //Abstand P-g
            TB_Abstand.Text = (Vector3.Cross((vecA - vecB), (vecA - vecC)).Length() / (vecB-vecC).Length()).ToString();

            //    double[] vektor_a = new double[3];
            //    double[] vektor_b = new double[3];
            //    double[] vektor_c = new double[3];

            //    for (int i = 0; i < 3; i++)
            //    {
            //        if ((double.TryParse(textBoxesEingabeVektoren[i].Text, out vektor_a[i])) == false)
            //        {
            //            MessageBox.Show("falsche EIngabe", "Fehler");
            //        }
            //        if ((double.TryParse(textBoxesEingabeVektoren[i + 3].Text, out vektor_b[i])) == false)
            //        {
            //            MessageBox.Show("falsche EIngabe", "Fehler");
            //        }
            //        if ((double.TryParse(textBoxesEingabeVektoren[i + 6].Text, out vektor_c[i])) == false)
            //        {
            //            MessageBox.Show("falsche EIngabe", "Fehler");
            //        }
            //    }

            ////Beträge berechnen
            //double Ba, Bb, Bc;
            //Ba = Math.Sqrt(vektor_a[0] * vektor_a[0] + vektor_a[1] * vektor_a[1] + vektor_a[2] * vektor_a[2]);
            //Bb = Math.Sqrt(vektor_b[0] * vektor_b[0] + vektor_b[1] * vektor_b[1] + vektor_b[2] * vektor_b[2]);
            //Bc = Math.Sqrt(vektor_c[0] * vektor_c[0] + vektor_c[1] * vektor_c[1] + vektor_c[2] * vektor_c[2]);

            ////Skalarprodukt
            //double skalarproduktAB = vektor_a[0] * vektor_b[0] + vektor_a[1] * vektor_b[1] + vektor_a[2] * vektor_b[2];

            ////Kreuzprodukt
            //double[] kreuzproduktAB = new double[3];
            //kreuzproduktAB[0] = vektor_a[1] * vektor_b[2] - vektor_a[2] * vektor_b[1];
            //kreuzproduktAB[1] = vektor_a[2] * vektor_b[0] - vektor_a[0] * vektor_b[2];
            //kreuzproduktAB[2] = vektor_a[0] * vektor_b[1] - vektor_a[1] * vektor_b[0];

            ////Spatprodukt
            //double spatprodukt = vektor_c[0] * kreuzproduktAB[0] + vektor_c[1] * kreuzproduktAB[1] + vektor_c[2] * kreuzproduktAB[2];

            ////Ausgabe
            //TB_Ba.Text = Ba.ToString();
            //TB_Bb.Text = Bb.ToString();
            //TB_Bc.Text = Bc.ToString();
            //TB_SP.Text = skalarproduktAB.ToString();
            //TB_SPP.Text = spatprodukt.ToString();
            //TB_VP.Text = "( " + kreuzproduktAB[0] + "/" + kreuzproduktAB[1] + "/" + kreuzproduktAB[2] + ")";
        }

        //private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{

        //}
    }
}
