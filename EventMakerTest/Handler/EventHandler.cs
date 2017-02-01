using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerTest.ViewModel;
using EventMakerTest.Model;
using EventMakerTest.Converter;

namespace EventMakerTest.Handler
{
    public class MyEventHandler
    {
        private EventViewModel EVM { get; set; }
        public MyEventHandler(EventViewModel eventViewModel)
        {
            this.EVM = eventViewModel;
        }
        public void CreateEvent()
        {
            Event NyEvent = new Event();
            NyEvent.Id = EVM.Id;
            NyEvent.Name = EVM.Name;
            NyEvent.Description = EVM.Description;
            NyEvent.Place = EVM.Place;
            NyEvent.DateTime = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EVM.Date, EVM.Time);

            EVM.AddNewEvent();

            
            
        }
    }
}
