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

namespace Rusu_Daria_lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += new
                DoughnutMachine.DoughnutCompleteDelegate(DoughnutCompleteHandler);
        }

        private void uncheckAllFlavours() 
        {
            glazedMenuItem.IsChecked = false;
            sugarMenuItem.IsChecked = false;
            lemonMenuItem.IsChecked = false;
            chocolateMenuItem.IsChecked = false;
            vanillaMenuItem.IsChecked = false;
        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            uncheckAllFlavours();
            glazedMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }
        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            uncheckAllFlavours();
            sugarMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void lemonToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            uncheckAllFlavours();
            lemonMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Lemon);
        }

        private void chocolateToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            uncheckAllFlavours();
            chocolateMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Chocolate);
        }

        private void vanillaToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            uncheckAllFlavours();
            vanillaMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Vanilla);
        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised_.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;

                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled__.Text = mFilledLemon.ToString();
                    break;

                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled_.Text = mFilledChocolate.ToString();
                    break;

                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled_.Text = mFilledVanilla.ToString();
                    break;

                default:
                    break;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            frmMain_Loaded(sender, e);
        }
    }
}
