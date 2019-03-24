using System;

namespace CSharpKmaLab04PersonList.Models.Exceptions
{
    class FutureBirthException : Exception
    {
        private string _message;
        private DateTime _birthDate;

        //Принимает сообщение с описание ошибки
        public FutureBirthException(string message, DateTime birthDate)

        {

            _message = message;
            _birthDate = birthDate;
        }


        public string Message
        {

            get
            {
                return _message + "Error in your birthDate \nIt seems like you are not born yet! \nYou entered: " + _birthDate;
            }
        }

    }
}
