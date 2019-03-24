using CSharpKmaLab04PersonList.Models;
using System.Collections.Generic;


namespace CSharpKmaLab04PersonList.Tools.DataStorage
{
    internal interface IDataStorage
    {
       // bool UserExists(string login);

       // User GetUserByLogin(string login);

        void AddUser(Person person);
        List<Person> PersonList { get; }
    }
}
