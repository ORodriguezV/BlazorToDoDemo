using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorToDoDemo.Client.Helpers
{
    public static class IHttpServiceExtensionMethods
    {
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if (!response.Success)
                throw new Exception(await response.GetBody());
            
            return response.Response;
        }
        public static async Task PostHelper<T>(this IHttpService httpService, string url, T entity)
        {
            var response = await httpService.Post(url, entity);
            if (!response.Success)
                throw new Exception(await response.GetBody());
        }
        public static async Task PutHelper<T>(this IHttpService httpService, string url, T entity)
        {
            var response = await httpService.Put(url, entity);
            if (!response.Success)
                throw new Exception(await response.GetBody());
        }
        public static async Task DeleteHelper(this IHttpService httpService, string url)
        {
            var response = await httpService.Delete(url);
            if (!response.Success)
                throw new Exception(await response.GetBody());
        }
    }
}
