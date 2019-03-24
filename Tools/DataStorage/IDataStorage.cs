using CSharpKmaLab04PersonList.Models;
using System.Collections.Generic;


namespace CSharpKmaLab04PersonList.Tools.DataStorage
{
    internal interface IDataStorage
    {

        void AddUser(Person person);
        List<Person> PersonList { get; }
    }
}
