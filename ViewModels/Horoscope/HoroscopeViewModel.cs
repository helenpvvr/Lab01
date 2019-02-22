using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab01_Pyvovar.Tools;
using Lab01_Pyvovar.Tools.Managers;

namespace Lab01_Pyvovar.ViewModels
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    internal class HoroscopeViewModel : BaseViewModel
    {
        #region Fields
        private DateTime? _birthday;
        private int _age;
        private string _western;
        private string _chinese;

        #region Commands
        private RelayCommand<object> _countAgeCommand;
        private RelayCommand<object> _closeCommand;
        #endregion
        #endregion

        #region Properties
        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string Western
        {
            get { return _western; }
            set
            {
                _western = value;
                OnPropertyChanged();
            }
        }

        public string Chinese
        {
            get { return _chinese; }
            set
            {
                _chinese = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public RelayCommand<object> CountAgeCommand
        {
            get
            {
                return _countAgeCommand ?? (_countAgeCommand = new RelayCommand<object>(
                           HoroscopeImplementation));
            }
        }

        public RelayCommand<Object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        #endregion
        #endregion

        private async void HoroscopeImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(500));
            LoaderManager.Instance.HideLoader();
            
            CalculateAndDisplay(Convert.ToDateTime(Birthday));
        }

        private void CalculateAndDisplay(DateTime birthday)
        {
            var nowDate = DateTime.Today;
            var age = nowDate.Year - birthday.Year;
            if (nowDate.Month < birthday.Month ||
                (nowDate.Month == birthday.Month && nowDate.Day < birthday.Day))
                age--;

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Wrong date. Please enter correct information");
                return;
            }

            Age = age;
            Western = FindWesternSing(birthday);
            Chinese = FindChineseSing(birthday.Year);

            if (nowDate.Month == birthday.Month && nowDate.Day == birthday.Day)
                MessageBox.Show("Happy Birthday!!!");
        }

        private string FindWesternSing(DateTime birthday)
        {
            switch (birthday.Month)
            {
                case 1:
                    if (birthday.Day <= 19)
                        return "Capricorn";
                    return "Aquarius";
                case 2:
                    if (birthday.Day <= 19)
                        return "Aquarius";
                    return "Pisces";
                case 3:
                    if (birthday.Day <= 21)
                        return "Pisces";
                    return "Aries";
                case 4:
                    if (birthday.Day <= 20)
                        return "Aries";
                    return "Taurus";
                case 5:
                    if (birthday.Day <= 21)
                        return "Taurus";
                    return "Gemini";
                case 6:
                    if (birthday.Day <= 21)
                        return "Gemini";
                    return "Cancer";
                case 7:
                    if (birthday.Day <= 22)
                        return "Cancer";
                    return "Leo";
                case 8:
                    if (birthday.Day <= 21)
                        return "Leo";
                    return "Virgo";
                case 9:
                    if (birthday.Day <= 23)
                        return "Virgo";
                    return "Libra";
                case 10:
                    if (birthday.Day <= 23)
                        return "Libra";
                    return "Scorpio";
                case 11:
                    if (birthday.Day <= 22)
                        return "Scorpio";
                    return "Sagittarius";
                default:
                    if (birthday.Day <= 22)
                        return "Sagittarius";
                    return "Capricorn";
            }
        }

        private string FindChineseSing(int birthdayYear) => Enum.GetName(typeof(ChineseSing), birthdayYear % 12);

    }
}
