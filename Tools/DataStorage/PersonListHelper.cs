using CSharpKmaLab04PersonList.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpKmaLab04PersonList.Tools.DataStorage
{
    class PersonListHelper
    {
        private static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string AppFolderPath = Path.Combine(AppDataPath, "CSharp_Lab4");


        internal static readonly string StorageFilePath = "data.dat";


        private static ObservableCollection<Person> _people;

        public static ObservableCollection<Person> People
        {
            get => _people;
            private set
            {
                _people = value;
            }
        }

        static PersonListHelper()
        {
            {
                if (File.Exists(StorageFilePath))
                {
                    MessageBox.Show("File exists!");

                    try
                    {
                        People = SerializationManager.Deserialize<ObservableCollection<Person>>(StorageFilePath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to get users from file.{Environment.NewLine}{ex.Message}");
                        throw;
                    }
                }
                else
                {
                    People = new ObservableCollection<Person>();

                    Random rnd = new Random();
                  for (int i = 0; i < 50; i++)
                          People.Add(new Person("Jack"+i, "Black"+i, "al@i.ua", new DateTime(rnd.Next(DateTime.Today.Year - 100, DateTime.Today.Year - 1), rnd.Next(1, 13), rnd.Next(1, 30))));   
                }

            }
        }

        internal static void SaveData()
        {
           
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("data.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter.Serialize(fs, People);


            }
        }

        internal static Person AddPerson(string lastName, string firstName, string email, DateTime date)
        {
            Person person = new Person(firstName, lastName, email, date);
            People.Add(person);
            return person;
        }
    }
}
