using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerTest.Model;
using System.Windows.Input;

namespace EventMakerTest.ViewModel
{
    public class EventViewModel
    {
        public EventCatalogSingleton Instance { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        // Konstruktør
        public EventViewModel()
        {
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
            Instance = EventCatalogSingleton.Instance;

            CreateEventCommand = new Common.RelayCommand(AddNewEvent);
            LoadList = new Common.RelayCommand();
            SaveList = new Common.RelayCommand(Persistency.PersistencyService.SaveEventsAsJsonAsync);
           
        }

        public void AddNewEvent()
        {
            Instance.UpcommingEvents.Add(new Event());
        }

        public ICommand CreateEventCommand { get; set; }
        public ICommand LoadList { get; set; }
        public ICommand SaveList { get; set; }

    }
}
