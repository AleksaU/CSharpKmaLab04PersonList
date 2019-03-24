using CSharpKmaLab04PersonList.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpKmaLab04PersonList.Tools.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _people;

        internal SerializedDataStorage()
        {
            try
            {
                _people = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _people = new List<Person>();
            }
        }


        public void AddUser(Person person)
        {
            _people.Add(person);
            SaveChanges();
        }

        public List<Person> PersonList
        {
            get { return _people.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_people, FileFolderHelper.StorageFilePath);
        }

    }
}

