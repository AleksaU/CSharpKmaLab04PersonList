using CSharpKmaLab04PersonList.Models;
using System.Collections.ObjectModel;

namespace CSharpKmaLab04PersonList.Tools
{
    class StationManager
    {
        internal static Person CurrentUser { get; set; }
        public static ObservableCollection<Person> UsersList { get; }
    }
}

