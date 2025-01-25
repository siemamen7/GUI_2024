using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfApp001.EntityFramework;

namespace WpfApp001.Data
{
    /// <summary>
    /// Klasa służąca do przechowywania elementów w aplikacji 
    /// </summary>
    public class Storage
    {
        private static Storage? _instance;
        public static Storage Instance => _instance ??= new Storage();
        public ObservableCollection<Leczenium>? Leczenia { get; set; }

        public ObservableCollection<Leki>? Lekis { get; set; }

        public ObservableCollection<Pacjenci>? Pacjencis { get; set; }

        public ObservableCollection<Pomieszczenium>? Pomieszczenia { get; set; }

        public ObservableCollection<Pracownicy>? Pracownicies { get; set; }

        public ObservableCollection<SpecPrac>? SpecPracs { get; set; }

        public ObservableCollection<Specjalizacje>? Specjalizacjes { get; set; }

        public ObservableCollection<TypyPom>? TypyPoms { get; set; }

        public ObservableCollection<TypyWyd>? TypyWyds { get; set; }

        public ObservableCollection<Urlopy>? Urlopies { get; set; }

        public ObservableCollection<Uzytkownicy>? Uzytkownicies { get; set; }

        public ObservableCollection<WydPacj>? WydPacjs { get; set; }

        public ObservableCollection<WydPrac>? WydPracs { get; set; }

        public ObservableCollection<Wydarzenium>? Wydarzenia { get; set; }

        public ObservableCollection<Zabiegi>? Zabiegis { get; set; }


        public Storage()
        {
            using (var context = new szpitalContext())
            {
                Leczenia = new ObservableCollection<Leczenium>(context.Leczenia.ToList());
                Lekis = new ObservableCollection<Leki>(context.Lekis.ToList());
                Pacjencis = new ObservableCollection<Pacjenci>(context.Pacjencis.ToList());
                Pomieszczenia = new ObservableCollection<Pomieszczenium>(context.Pomieszczenia.ToList());
                Pracownicies = new ObservableCollection<Pracownicy>(context.Pracownicies.ToList());
                SpecPracs = new ObservableCollection<SpecPrac>(context.SpecPracs.ToList());
                Specjalizacjes = new ObservableCollection<Specjalizacje>(context.Specjalizacjes.ToList());
                TypyPoms = new ObservableCollection<TypyPom>(context.TypyPoms.ToList());
                TypyWyds = new ObservableCollection<TypyWyd>(context.TypyWyds.ToList());
                Urlopies = new ObservableCollection<Urlopy>(context.Urlopies.ToList());
                Uzytkownicies = new ObservableCollection<Uzytkownicy>(context.Uzytkownicies.ToList());
                WydPacjs = new ObservableCollection<WydPacj>(context.WydPacjs.ToList());
                WydPracs = new ObservableCollection<WydPrac>(context.WydPracs.ToList());
                Wydarzenia = new ObservableCollection<Wydarzenium>(context.Wydarzenia.ToList());
                Zabiegis = new ObservableCollection<Zabiegi>(context.Zabiegis.ToList());
            }

        }

        /// <summary>
        /// Funkcja do zmiany lub dodawania elementów do bazy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// Klasa elementu
        /// <param name="element"></param>
        /// Element kolekcji do zmiany lub wstawienia
        /// <exception cref="ArgumentException"></exception>
        /// Wyjątek wyrzucony kiedy nie ma w Storage kolekcji takich elementów
        public void UpdateElement<T>(T element) where T : class
        {
            using (var context = new szpitalContext())
            {
                // Find the DbSet for the given type
                var dbSet = context.Set<T>();
                if (dbSet == null)
                {
                    throw new ArgumentException($"No DbSet found for type {typeof(T).Name}");
                }

                // Find the existing element in the database using the "Id" property
                var elementIdProperty = typeof(T).GetProperty("Id");
                if (elementIdProperty == null)
                {
                    throw new ArgumentException($"Type {typeof(T).Name} does not have a property named 'Id'");
                }

                var elementId = elementIdProperty.GetValue(element);
                var existingElement = dbSet.Find(elementId);

                if (existingElement != null)
                {
                    // Update the existing entity in the database
                    context.Entry(existingElement).CurrentValues.SetValues(element);
                }
                else
                {
                    // Add the new entity to the database
                    dbSet.Add(element);
                }

                // Save changes to the database
                context.SaveChanges();
            }

            // Update the ObservableCollection in the Storage class
            var collectionProperty = this.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>) &&
                                     p.PropertyType.GenericTypeArguments[0] == typeof(T));

            if (collectionProperty != null)
            {
                // Get the ObservableCollection<T>
                var collection = collectionProperty.GetValue(this) as ObservableCollection<T>;
                if (collection != null)
                {
                    // Find and update the element in the collection
                    var elementIdProperty = typeof(T).GetProperty("Id");
                    if (elementIdProperty != null)
                    {
                        var elementId = elementIdProperty.GetValue(element);
                        var existingElement = collection.FirstOrDefault(e =>
                            elementIdProperty.GetValue(e)?.Equals(elementId) == true);

                        if (existingElement != null)
                        {
                            // Update the existing element in the ObservableCollection
                            var index = collection.IndexOf(existingElement);
                            collection[index] = element;
                        }
                        else
                        {
                            // Add the new element to the ObservableCollection
                            collection.Add(element);
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException($"No ObservableCollection found for type {typeof(T).Name}");
            }
        }

    }
}
