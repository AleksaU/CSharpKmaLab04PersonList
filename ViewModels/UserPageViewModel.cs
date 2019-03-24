using CSharpKmaLab04PersonList.Models;
using CSharpKmaLab04PersonList.Models.Exceptions;
using CSharpKmaLab04PersonList.Tools;
using CSharpKmaLab04PersonList.Tools.DataStorage;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpKmaLab04PersonList.ViewModels
{
    internal class UserPageViewModel : INotifyPropertyChanged
    {

        private string _name;
        private string _surName;
        private string _email;
        private DateTime _birthDate;

        private Thread _workingThread;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;


        /*
         private bool _isAdult;
         private string _sunSign;
         private string _chineseSign;
         private bool _isBirthday;
        
*/

        private RelayCommand<object> _proceedCommand;


        private ObservableCollection<Person> _people;



        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return (_birthDate);
            }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }








        public ObservableCollection<Person> People
        {
            get => _people;
            private set
            {
                _people = value;
                OnPropertyChanged();
            }
        }




        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                      CreatePerson, o => CanExecuteCommand()));
            }
        }

        private void CreatePerson(object o)
        {


            try
            {
                StationManager.CurrentUser = new Person(_name, _surName, _email, _birthDate);



                MessageBox.Show(



                                                                                  $"Your First name is: {StationManager.CurrentUser.Name}\n" +
                                                                                  $"Your Surname is: {StationManager.CurrentUser.Surname}\n" +
                                                                                  $"Your Email is: {StationManager.CurrentUser.Email}\n" +
                                                                                  $"Your Date of birth is: {StationManager.CurrentUser.BirthDate}\n" +
                                                                                  $"Are you an Adult: {StationManager.CurrentUser.IsAdult}\n" +
                                                                                  $"You are: {StationManager.CurrentUser.CalculateAge()} years old\n" +
                                                                                  $"Your SunSign is: {StationManager.CurrentUser.SunSign}\n" +
                                                                                  $"Your Chinese Sign is: {StationManager.CurrentUser.ChineseSign}\n"

                                                                              );




                _people.Add(StationManager.CurrentUser);



            }
            // Person person = new Person(_name, _surName, _email, _birthDate);


            catch (EmailException ex)
            {

                MessageBox.Show("" + ex.Message);

            }

            catch (FutureBirthException e)
            {

                MessageBox.Show("" + e.Message);

            }

            catch (PastBirthException e)
            {

                //MessageBox.Show("Произошла ошибка: " + ex.Message);
                MessageBox.Show("" + e.Message);

            }



            if (_birthDate.Day == DateTime.Today.Day && _birthDate.Month == DateTime.Today.Month)
            {
                MessageBox.Show("Happy b-day to you!");


            }

            //, o => CanExecuteCommand()));
        

        

    }


        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surName) && !string.IsNullOrWhiteSpace(_email) && !(_birthDate == new DateTime(0001, 01, 01, 00, 00, 0));
            ;

        }



        /*
            internal UserPageViewModel()
            {
            Random rnd = new Random();
            // _people = new ObservableCollection<Person>(StationManager.DataStorage.PersonList);
            _people = new ObservableCollection<Person>(PersonListHelper.Persons);
            _people.Add(new Person("A", "AA", "a@i.ua", new DateTime(rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 30))));

 }
             */
            internal UserPageViewModel()
            {
            _people = new ObservableCollection<Person>(PersonListHelper.Persons);
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;

            StartWorkingThread();
            StationManager.StopThreads += StopWorkingThread;

        }


        private void StartWorkingThread()
        {
            _workingThread = new Thread(WorkingThreadProcess);
            _workingThread.Start();
        }


        private void WorkingThreadProcess()
        {
            int i = 0;
            while (!_token.IsCancellationRequested)
            {
                var people = _people.ToList();
                //people.Add(new Person("FirstNAme" + i, "LastNAme" + i, "Email" + i, "Login" + i, "Password" + i));
                //LoaderManager.Instance.ShowLoader();
              //  people.Add(new Person(_name, _surName, _email, _birthDate));


                People = new ObservableCollection<Person>(people);
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(500);
                    if (_token.IsCancellationRequested)
                        break;
                }
                if (_token.IsCancellationRequested)
                    break;
                //LoaderManager.Instance.HideLoader();
                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(500);
                    if (_token.IsCancellationRequested)
                        break;
                }
                if (_token.IsCancellationRequested)
                    break;
                i++;
            }
        }




        internal void StopWorkingThread()
        {
            _tokenSource.Cancel();
            _workingThread.Join(2000);
            _workingThread.Abort();
            _workingThread = null;
        }



















        public event PropertyChangedEventHandler PropertyChanged;

           // [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
