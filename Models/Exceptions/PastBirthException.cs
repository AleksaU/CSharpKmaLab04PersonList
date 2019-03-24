using System;

namespace CSharpKmaLab04PersonList.Models.Exceptions
{
    class PastBirthException : Exception
    {
        private string _message;
        private DateTime _birthDate;

        //Принимает сообщение с описание ошибки
        public PastBirthException(string message, DateTime birthDate)

        {

            _message = message;
            _birthDate = birthDate;
        }


        public string Message
        {

            get
            {
                return _message + "Error in your birthDate \nIt seems like you are too old to be real! \nYou entered: " + _birthDate;
            }
        }
    }
}