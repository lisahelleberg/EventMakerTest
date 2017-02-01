using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using EventMakerTest.Model;
using System.Collections.ObjectModel;
using EventMakerTest.ViewModel;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace EventMakerTest.Persistency
{
    class PersistencyService
    {
        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        public EventCatalogSingleton Instance { get; set; }
        public async void GemDataTilDiskAsync()
        {
            string jsonText = EventCatalogSingleton.Instance.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }
        public async void HentDataFraDiskAsync()
        {

            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);

                string jsonText = await FileIO.ReadTextAsync(file);

                Instance.UpcommingEvents.Clear();

                EventCatalogSingleton.Instance.GetJson();



                // Try og catch for at fange en exception for at undgå grimme fejlmeddelser
            }
            catch (Exception)
            {
                //Popup vindue til at fortælle brugeren at filen ikke blev fundet. 
                MessageDialog messageDialog = new MessageDialog("Filen ikke fundet. Har du fjernet den?");
                await messageDialog.ShowAsync();
                //throw;
            }
        }






































        //static StorageFolder localfolder = null;

        //private static readonly string EventFileList = "JsonEventList";
        //public static async void SaveEventsAsJsonAsync()
        //{
        //    StorageFile file = await localfolder.CreateFileAsync(EventFileList, CreationCollisionOption.ReplaceExisting);
        //    string jsonText = JsonConvert.SerializeObject(file);

        //    await FileIO.WriteTextAsync(file, jsonText);

        //}

        //public static async void LoadEevntsFromJsonAsync()
        //{

        //    StorageFile file = await localfolder.GetFileAsync(EventFileList);

        //    string jsonText = await FileIO.ReadTextAsync(file);

        //    EventCatalogSingleton.Instance.UpcommingEvents.Clear();

        //    List<EventCatalogSingleton> UpcomingEvents = JsonConvert.DeserializeObject<List<EventCatalogSingleton>>(jsonText);










        //}


        //public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        //{

        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{

        //}
    }
}
