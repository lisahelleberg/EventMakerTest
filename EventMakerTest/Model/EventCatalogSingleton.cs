using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerTest.Model;
using System.Collections.ObjectModel;

namespace EventMakerTest.Model
{
    public sealed class EventCatalogSingleton
    {
        public static EventCatalogSingleton Instance { get; set; } = new EventCatalogSingleton();
        public ObservableCollection<Event> UpcommingEvents { get; set; } //= new ObservableCollection<Event>();

        private EventCatalogSingleton()
        {
            UpcommingEvents = new ObservableCollection<Event>();
            UpcommingEvents.Add(new Event() { Id = 001, Name = "Kim Larsen", Description = "Koncert med Kim Larsen og Kjukken", Place = "Forum", });
            UpcommingEvents.Add(new Event() { Id = 002, Name = "Jeff Dunham", Description = "Standup med Jeff Dunham", Place = "Royal Arena" });
            UpcommingEvents.Add(new Event() { Id = 003, Name = "Ed Sheeran", Description = "Koncert med Ed Sheeran", Place = "Jyske Bank Boksen" });
        }
        
        public void AddEvent()
        {
            UpcommingEvents.Add(new Event());
        }
    }
}
