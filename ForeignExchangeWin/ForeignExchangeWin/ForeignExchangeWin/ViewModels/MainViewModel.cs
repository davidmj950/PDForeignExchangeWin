using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ForeignExchangeWin.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributies
        string _dollars;
        string _euros;
        string _pounds;
        #endregion

        #region properties

        public string Pesos
        {
            get;
            set;
        }
        public string Dollars
        {
            get { return _dollars; }
            set
            {
                if (value != _dollars)
                {
                    _dollars = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dollars)));
                }
            }
        }
        public string Euros
        {
            get { return _euros; }
            set
            {
                if (value != _euros)
                {
                    _euros = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Euros)));
                }
            }
        }
        public string Pounds
        {
            get { return _pounds; }
            set
            {
                if (value != _pounds)
                {
                    _pounds = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pounds)));
                }
            }
        }
        #endregion

        #region constructors
        public MainViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(Convert); }
        }

        #endregion

        async private void Convert()
        {
            if (string.IsNullOrEmpty(Pesos))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a value in pesos", "Accept");
                return;
            }

            decimal pesos = 0;
            if (!decimal.TryParse(Pesos,out pesos))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must enter a value numeric in pesos", "Accept");
                return;
            }

            var dollars = pesos / 2994.01m;
            var euros = pesos / 3514.95m;
            var pounds = pesos / 3894.5m;

            Dollars = String.Format("{0:N2}", dollars);
            Euros = String.Format("{0:N2}", euros);
            Pounds = String.Format("{0:N2}", pounds);
        }
    }
}
