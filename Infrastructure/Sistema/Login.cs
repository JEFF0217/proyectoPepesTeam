using Domain.Common;
using Domain.Usuario;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Sistema
{
    public class Login
    {
        private static string url_api = ConfigurationManager.AppSettings["url_api"];
        public static Usuario GetUsuario(string api_key)
        {
            var client = new RestClient(url_api);
            var request = new RestRequest("api/autenticarsesistema/validarapikey/{value}", Method.GET);

            request.AddUrlSegment("value", api_key);
            var response = client.Execute(request);
            Usuario user = null;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(response);
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                Respuesta res = System.Text.Json.JsonSerializer.Deserialize<Respuesta>(response.Content, options);
                if (res.respuesta)
                {
                    string data = res.Data.ToString();
                    user = System.Text.Json.JsonSerializer.Deserialize<Usuario>(data, options);
                }

            }
            return user;
        }
    }
}
