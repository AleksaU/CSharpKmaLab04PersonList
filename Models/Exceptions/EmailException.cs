using System;

namespace CSharpKmaLab04PersonList.Models.Exceptions
{
    class EmailException : Exception
    {
        private string _message;

        //Принимает сообщение с описание ошибки
        public EmailException(string message)

        {

            _message = message;

        }


        public string Message
        {

            get
            {
                return _message;// + "Error in your email adress";
            }
        }


    }
}
