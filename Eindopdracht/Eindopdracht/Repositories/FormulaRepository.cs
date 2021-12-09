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
        private const string _URL = "http://ergast.com/api/f1";

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        //Seizoenen ophalen
        public static async Task<RootObject> GetSeasonsAsync()
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    //URL toevoegen
                    string url = $"{_URL}/seasons.json";

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
                string url = $"{_URL}/circuits.json";

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
    }
}
