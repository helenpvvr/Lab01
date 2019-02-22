using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab01_Pyvovar.Tools.Managers;

namespace Lab01_Pyvovar
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
