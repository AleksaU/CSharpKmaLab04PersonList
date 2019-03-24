using CSharpKmaLab04PersonList.Models.Exceptions;
using System;


namespace CSharpKmaLab04PersonList.Models
{
   [Serializable]
    class Person
    {

        #region Fields

        private string _name;
        private string _surName;
        private string _email;
        private DateTime _birthDate;

        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        #endregion


        #region Constructors


            public Person(string name, string surName, string email, DateTime birthDate)
        {
            emailValidation(email);
            futureBirthValidation(birthDate);
            pastBirthValidation(birthDate);

           
            _name = name;
            _surName = surName;
            _email = email;
            _birthDate = birthDate;

            _isAdult = CheckAdult();
            _sunSign = CalcSunSign();
            _chineseSign = CalcChineseSign();
            _isBirthday = CheckBirthday();


        }

        public Person(string name, string surName, string email) : this(name, surName, email, DateTime.MaxValue) { }
        public Person(string name, string surName, DateTime birthDate) : this(name, surName, "noemail", birthDate) { }


        #endregion


        #region Properties


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;



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

            }
        }
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }


        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }
        #endregion



        #region Calculations

        public int CalculateAge()
        {

            DateTime today = DateTime.Today;
            int ageNow = today.Year - _birthDate.Year;

            if (today.Day < _birthDate.Day && today.Month == _birthDate.Month || today.Month < _birthDate.Month)
            {
                ageNow--;
            }

            return ageNow;
        }


        public bool CheckAdult()
        {

            if (CalculateAge() >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string CalcSunSign()
        {
            if (((_birthDate.Month == 3) && (_birthDate.Day >= 21 && _birthDate.Day <= 31)) || ((_birthDate.Month == 4) && (_birthDate.Day >= 01 && _birthDate.Day <= 20)))
            {
                return "Aires";
            }
            if (((_birthDate.Month == 4) && (_birthDate.Day >= 21 && _birthDate.Day <= 31)) || ((_birthDate.Month == 5) && (_birthDate.Day >= 01 && _birthDate.Day <= 21)))
            {
                return "Taurus";
            }

            if (((_birthDate.Month == 5) && (_birthDate.Day >= 21 && _birthDate.Day <= 31)) || ((_birthDate.Month == 6) && (_birthDate.Day >= 01 && _birthDate.Day <= 21)))
            {
                return "Gemini";
            }
            if (((_birthDate.Month == 6) && (_birthDate.Day >= 22 && _birthDate.Day <= 31)) || ((_birthDate.Month == 7) && (_birthDate.Day >= 01 && _birthDate.Day <= 22)))
            {
                return "Cancer";
            }
            if (((_birthDate.Month == 7) && (_birthDate.Day >= 23 && _birthDate.Day <= 31)) || ((_birthDate.Month == 8) && (_birthDate.Day >= 01 && _birthDate.Day <= 22)))
            {
                return "leo";
            }
            if (((_birthDate.Month == 8) && (_birthDate.Day >= 23 && _birthDate.Day <= 31)) || ((_birthDate.Month == 9) && (_birthDate.Day >= 01 && _birthDate.Day <= 21)))
            {
                return "Virgo";
            }
            if (((_birthDate.Month == 9) && (_birthDate.Day >= 22 && _birthDate.Day <= 30)) || ((_birthDate.Month == 10) && (_birthDate.Day >= 01 && _birthDate.Day <= 22)))
            {
                return "Libra";
            }
            if (((_birthDate.Month == 10) && (_birthDate.Day >= 23 && _birthDate.Day <= 31)) || ((_birthDate.Month == 11) && (_birthDate.Day >= 01 && _birthDate.Day <= 21)))
            {
                return "Scorpio";
            }
            if (((_birthDate.Month == 11) && (_birthDate.Day >= 22 && _birthDate.Day <= 30)) || ((_birthDate.Month == 12) && (_birthDate.Day >= 01 && _birthDate.Day <= 21)))
            {
                return "Sagittarius";
            }
            if (((_birthDate.Month == 12) && (_birthDate.Day >= 22 && _birthDate.Day <= 31)) || ((_birthDate.Month == 1) && (_birthDate.Day >= 01 && _birthDate.Day <= 20)))
            {
                return "Capricorn";
            }
            if (((_birthDate.Month == 1) && (_birthDate.Day >= 21 && _birthDate.Day <= 30)) || ((_birthDate.Month == 2) && (_birthDate.Day >= 01 && _birthDate.Day <= 19)))
            {
                return "Aquarius";
            }
            if (((_birthDate.Month == 2) && (_birthDate.Day >= 20 && _birthDate.Day <= 31)) || ((_birthDate.Month == 3) && (_birthDate.Day >= 01 && _birthDate.Day <= 20)))
            {
                return "Pisces";
            }
            else
            {
                return "";
            }
        }

        public string CalcChineseSign()
        {
            switch ((_birthDate.Year - 4) % 12)
            {
                case 0:
                    return "Rat";
                    break;
                case 1:
                    return "Ox";
                    break;
                case 2:
                    return "Tiger";
                    break;
                case 3:
                    return "Rabbit";
                    break;
                case 4:
                    return "Dragon";
                    break;
                case 5:
                    return "Snake";
                    break;
                case 6:
                    return "Horse";
                    break;
                case 7:
                    return "Goat";
                    break;
                case 8:
                    return "Monkey";
                    break;
                case 9:
                    return "Rooster";
                    break;
                case 10:
                    return "Do";
                    break;
                case 11:
                    return "Pig";
                    break;

                default:
                    return " ";
                    break;
            }
        }



        public bool CheckBirthday()
        {
            if (_birthDate.Day == DateTime.Today.Day && _birthDate.Month == DateTime.Today.Month)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        
            

        private void emailValidation(string email)
        {
            if (IsEmailSyntaxValid(email) != true)
            {
                throw new EmailException("Incorrect email format! It should be 'david.jones@proseware.com'. But you have: " + email);
            }

        }

        private void futureBirthValidation(DateTime birthDate)
        {
            
            if (birthDate > DateTime.Now)
            {

                throw new FutureBirthException("", birthDate);
            }

        }

        private void pastBirthValidation(DateTime birthDate)
        {
            if (birthDate.Year < 1899)
            {

                throw new PastBirthException("", birthDate);
            }

        }






        private bool IsEmailSyntaxValid(string emailToValidate)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        #endregion

    }
}
