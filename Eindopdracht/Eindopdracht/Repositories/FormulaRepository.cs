using Eindopdracht.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eindopdracht.Repositories
{
    public class FormulaRepository
    {
        private const string _URL = "https://ergast.com/api/f1";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        //Seizoenen ophalen
        public static async Task<RootObject> GetSeasonsAsync()
        {
            using (HttpClient client = GetClient())
            {
                //URL toevoegen
                string url = $"{_URL}/seasons.json?limit=100";

                //API opvragen en resultaten bijhouden in JSON
                string json = await client.GetStringAsync(url);
                if (json != null)
                {
                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
                else
                {
                    return null;
                }
            }
        }


        //Circuits per seizoen ophalen
        public static async Task<RootObject> GetCircuitsBySeason(string seizoen)
        {
            try
            {
                using (HttpClient client = GetClient())
                {

                    //URL toevoegen
                    string url = $"{_URL}/{seizoen}.json";

                    //API opvragen en resultaten bijhouden in JSON
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<RootObject>(json);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Resultaat per ronde per seizoen ophalen
        //Ophalen resultaten
        public static async Task<RootObject> GetResultsByRoundBySeason(string seizoen, string round)
        {
            using (HttpClient client = GetClient())
            {

                //URL toevoegen
                string url = $"{_URL}/{seizoen}/{round}/results.json";

                //API opvragen en resultaten bijhouden in JSON
                string json = await client.GetStringAsync(url);
                if (json != null)
                {
                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
                else
                {
                    return null;
                }
            }
        }

        //Circuits ophalen
        public static async Task<RootObject> GetCircuitsAsync()
        {
            using (HttpClient client = GetClient())
            {

                //URL toevoegen
                string url = $"{_URL}/circuits.json?limit=100";

                //API opvragen en resultaten bijhouden in JSON
                string json = await client.GetStringAsync(url);
                if (json != null)
                {
                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
                else
                {
                    return null;
                }
            }
        }

        //Favoriete circuits ophalen
        public static async Task<List<RootObject>> GetFavoriteCircuitsAsync()
        {
            FavoriteCircuit fav = new FavoriteCircuit();

            using (HttpClient client = GetClient())
            {

                //URL toevoegen
                string url = $"https://favoritesapi.azurewebsites.net/api/favorites/circuits";

                //API opvragen en resultaten bijhouden in JSON
                string json = await client.GetStringAsync(url);
                json = json.Insert(0, "{'favorites':");
                json = json.Insert(json.Length, "}");


                if (json != null)
                {
                    fav = JsonConvert.DeserializeObject<FavoriteCircuit>(json);
                }

                List<RootObject> lijst = new List<RootObject>();

                foreach (var item in fav.favorites)
                {
                    url = $"{_URL}/circuits/{item.circuitId}.json";

                    //API opvragen en resultaten bijhouden in JSON
                    json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        lijst.Add(JsonConvert.DeserializeObject<RootObject>(json));
                    }
                }

                return lijst;
            }
        }

        public static async Task<string> IsFavorite(string circuit)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"https://favoritesapi.azurewebsites.net/api/favorites/{circuit}";

                return await client.GetStringAsync(url);
            }
        }


        //Circuit toevoegen aan favorieten
        public async static Task AddFavoriteCircuit(string id)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    string url = $"https://favoritesapi.azurewebsites.net/api/favorites/circuits/{id}";

                    HttpContent content = new StringContent("", Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, content); ;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Tis nie gulukt, programeer wa beter e de volgende keer");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Circuit verwijderen aan favorieten

        public async static Task DeleteFavoriteCircuit(string id)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    string url = $"https://favoritesapi.azurewebsites.net/api/favorites/circuits/{id}";

                    var response = await client.DeleteAsync(url); ;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Tis nie gulukt, programeer wa beter e de volgende keer");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Drivers ophalen
        public static async Task<RootObject> GetDriversAsync()
        {
            using (HttpClient client = GetClient())
            {

                //URL toevoegen
                string url = $"{_URL}/drivers.json?limit=853";

                //API opvragen en resultaten bijhouden in JSON
                string json = await client.GetStringAsync(url);
                if (json != null)
                {
                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
                else
                {
                    return null;
                }
            }
        }

        //Favoriete Drivers ophalen

        //Driver toevoegen aan favorieten

        //Driver verwijderen aan favorieten

    }
}
