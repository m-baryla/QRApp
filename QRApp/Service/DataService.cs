using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QRApp.Interface;
using QRApp.Model;

namespace QRApp.Service
{

    public class DataService : IDataService
    {
        public async Task<List<T>> GetAsync<T>(HttpClient httpClient,string url)
        {
            try
            {
                var json = await httpClient.GetStringAsync(Constants.Url + url);
                var result = JsonConvert.DeserializeObject<List<T>>(json);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> PostAsync<T>(HttpClient httpClient,string url,T obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.Url + url, content);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> PustAsync<T>(HttpClient httpClient, string url, T obj,int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PutAsync(Constants.Url + url + id + "/", content);
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
