using System.Windows.Controls;
using Lab01_Pyvovar.ViewModels;

namespace Lab01_Pyvovar.Horoscope
{
    /// <summary>
    /// Interaction logic for HoroscopeControl.xaml
    /// </summary>
    public partial class HoroscopeControl : UserControl
    {
        internal HoroscopeControl()
        {
            InitializeComponent();
            DataContext = new HoroscopeViewModel();
        }
    }
}
