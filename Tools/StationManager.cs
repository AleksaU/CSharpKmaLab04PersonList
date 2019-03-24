using CSharpKmaLab04PersonList.Models;
using CSharpKmaLab04PersonList.Tools.DataStorage;
using System.Collections.ObjectModel;

namespace CSharpKmaLab04PersonList.Tools
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }


        internal static Person CurrentUser { get; set; }
        public static ObservableCollection<Person> UsersList { get; }
    }
}

