using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpftTask19.Models;

namespace WpftTask19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double dlina;
        public double Dlina
        {
            get => dlina;
            set
            {
                dlina = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcLengthCommand { get; }
        private void OnCalcLengthCommandExecute(object p)
        {
            Dlina = Circle.CalcLength(Radius);
        }
        private bool CanCalcLengthCommandExecuted(object p)
        {
            if (Radius != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public MainWindowViewModel()
        {
            CalcLengthCommand = new RelayCommand(OnCalcLengthCommandExecute, CanCalcLengthCommandExecuted);
        }
    }
}
