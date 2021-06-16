using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QRApp.Interface
{
    public interface IDataService
    {

        Task<List<T>> GetAsync<T>(HttpClient httpClient, string url);
        Task<bool> PostAsync<T>(HttpClient httpClient, string url, T obj);
        Task<bool> PustAsync<T>(HttpClient httpClient, string url, T obj, int id);
    }
}
