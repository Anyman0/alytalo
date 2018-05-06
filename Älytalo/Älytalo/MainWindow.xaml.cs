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


namespace Älytalo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Valaisimet valaisimet = new Valaisimet();
        Sauna saunaKytkin = new Sauna();
        Lämpötila lämpöjä = new Lämpötila();

        public MainWindow()
        {
            InitializeComponent();
        }

        public string valoTeksti;
        public string termoTila;
        
        private void Himmennin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Himmennin.Value >= 2 && Himmennin.Value < 4)
            {
                valaisimet.Hämärä();
                Valotekstit();
                Valotila.Foreground = new SolidColorBrush(Colors.LightYellow);
            }

            else if (Himmennin.Value >= 4 && Himmennin.Value < 6)
            {
                valaisimet.Puolivalot();
                Valotekstit();
                Valotila.Foreground = new SolidColorBrush(Colors.GreenYellow);
            }
            
            else if (Himmennin.Value >= 6)
            {
                valaisimet.Kirkas();
                Valotekstit();
                Valotila.Foreground = new SolidColorBrush(Colors.Yellow);
                
            }
            
            else
            {
                valaisimet.ValoPoisPäältä();
                Valostatus.Content = "Valot ovat pois päältä";
                Valostatus.Background = new SolidColorBrush(Colors.Red);
                Valotila.Foreground = new SolidColorBrush(Colors.Red);
                Valokirkkaus.Opacity = 0.01;
            }
        }




        private void Valotekstit()
        {
            Valokirkkaus.Opacity = 100;

            if (Himmennin.Value >= 2 && Himmennin.Value < 4)
            {
                Valokirkkaus.Content = "Valotila: Hämärä";
                
            }
            else if (Himmennin.Value >= 4 && Himmennin.Value < 6)
            {
                Valokirkkaus.Content = "Valotila: Puolivalot";
            }
            else if (Himmennin.Value >= 6)
            {
                Valokirkkaus.Content = "Valotila: Kirkas";
            }
            
            Valostatus.Content = valoTeksti;
            valoTeksti = "Valot ovat päällä";
            Valostatus.Background = new SolidColorBrush(Colors.Green);
        }

        private void Valotila_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


        
            private void SaunaOn(object sender, RoutedEventArgs e)
            {
            if (saunaKytkin.saunanLämmöt != 90)
            {
                saunaKytkin.SaunaPäällä();
            }
                Sauna.Text = "Sauna lämpenee...";
                Sauna.Background = new SolidColorBrush(Colors.Yellow);
            }

            private void SaunaPois(object sender, RoutedEventArgs e)
            {
            if (saunaKytkin.saunanLämmöt != 0)
            {
                saunaKytkin.SaunaPoisPäältä();
            }
                Sauna.Text = "Sauna on pois.";
                Sauna.Background = new SolidColorBrush(Colors.Red);

            }
        

        private void Lämpötilatermo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            
            if (Lämpötilatermo.Value >= 11 && Lämpötilatermo.Value < 15)
            {
                
                Termostaatti.Foreground = new SolidColorBrush(Colors.SandyBrown);
            }

            else if (Lämpötilatermo.Value >= 15  && Lämpötilatermo.Value < 20)
            {
                Termostaatti.Foreground = new SolidColorBrush(Colors.Orange);
            }

            else if (Lämpötilatermo.Value >= 20 && Lämpötilatermo.Value < 25 )
            {
                Termostaatti.Foreground = new SolidColorBrush(Colors.LightSalmon);
            }

            else if (Lämpötilatermo.Value >= 25)
            {
                Termostaatti.Foreground = new SolidColorBrush(Colors.Red);
            }

           
        }
        private void TermoOnPäällä()
        {
            termoTila = "Termo on päällä";
            lämpöjä.TermostaattiOn();
            TermonTila.Content = termoTila;          
            TermonTila.Background = new SolidColorBrush(Colors.Green);
            Termolämpöjä.Opacity = 100;
        }

        private void TermoOnPois()
        {
            termoTila = "Termo on pois päältä!";
            lämpöjä.TermostaattiOff();
            TermonTila.Content = termoTila;
            TermonTila.Background = new SolidColorBrush(Colors.Red);
            Termolämpöjä.Opacity = 0.01;
        }
        private void Termostaatti_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

       

        private void Lämpäällä_Click(object sender, RoutedEventArgs e)
        {
            
            TermoOnPäällä();
            
        }

        private void Lämpois_Click(object sender, RoutedEventArgs e)
        {
            TermoOnPois();
        }

        private void Kuumuus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SAUNAN LÄMPÖTILA ON: " + saunaKytkin.saunanLämmöt);
            if (saunaKytkin.saunanLämmöt == 90)
            {
                Sauna.Text = "Sauna on valmis! 90 astetta.";
                Sauna.Background = new SolidColorBrush(Colors.Green);
            }
        }

        private void Termolämpöjä_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Sauna_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
