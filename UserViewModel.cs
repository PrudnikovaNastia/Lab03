using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth = DateTime.Today;
        private string Name;
        private string Surname;
        private string Email;
       private RelayCommand _signUpCommand;
        private readonly Action _signUpSuccessAction;

        public string name
        {
            get => Name;
            set
            {
                Name = value;
                OnPropertyChanged();
            }
        }

        public string surname
        {
            get => Surname;
            set
            {
                Surname = value;
                OnPropertyChanged();
            }
        }

        public string email
        {
            get => Email;
            set
            {
                Email = value;
                OnPropertyChanged();
            }
        }

        public DateTime dateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand ProceedCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand(SignUpImpl, k => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(Email)));
            }
        }
        
        public UserViewModel(Action signUpSuccessAction)
        {
            _signUpSuccessAction = signUpSuccessAction;
        }

        private void SignUpImpl(object k)
        {
            _signUpSuccessAction.Invoke();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

