using System.Windows;
using Lab01_Pyvovar.Tools;
using Lab01_Pyvovar.Tools.Managers;

namespace Lab01_Pyvovar
{
    class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
