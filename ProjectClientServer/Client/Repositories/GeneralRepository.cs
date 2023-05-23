using Client.Base;
using Client.Repositories.Interface;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Client.Repositories
{
    public class GeneralRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly Url linkUrl;
        private readonly string request;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly HttpClient httpClient;
        public GeneralRepository(string request, Url linkUrl)
        {
            this.linkUrl = linkUrl;
            this.request = request;
            httpContextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(linkUrl.url)
            };
        }

        public HttpStatusCode Delete(TKey key)
        {
            var result = httpClient.DeleteAsync(request + "Delete?id=" + key).Result;
            return result.StatusCode;
        }

        public async Task<List<TEntity>> Get()
        {
            List<TEntity> result = new List<TEntity>();
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<TEntity>>(apiResponse);
            } ;
            return result;
        }

        public Task<TEntity> Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Post(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Put(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
