using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;
using Domain.ApiKey;

namespace Persistence.JSON
{
    public class RepositorioApiKeyJSON:IRepositorioApiKey
    {
        private String path = @"";

        public RepositorioApiKeyJSON()
        {
            var main = ConfigurationManager.AppSettings["main"];
            if (main == "test")
            {
                path = @"..\..\..\..\CoreAMTest\repos\apis_keys.json";
            }
            else
            {

                path = @"..\CoreAMTest\repos\apis_keys.json";
            }
        }

        private List<ApiKey> leerApisKeys()
        {
            List<ApiKey> conferencias;
            String jsonString = "";
            try
            {
                jsonString = File.ReadAllText(path);
                conferencias = System.Text.Json.JsonSerializer.Deserialize<List<ApiKey>>(jsonString);
                return conferencias;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de apis_keys.");
            }
        }

        public ApiKey consultar(string key_value)
        {
            List<ApiKey> apis_keys = leerApisKeys();
            try
            {
                ApiKey api_key;
                api_key = apis_keys
                    .Find(a =>
                    {
                        return a.key == key_value;
                    });

                if (api_key == null)
                {
                    throw new ApiKeyNoEncontradaException("La apikey no es valida.");
                }
                return api_key;
            }
            catch (JsonException)
            {
                throw new Exception("El formato del archivo JSON es invalido.");
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un porblema al acceder al repositorio de apis_keys.");
            }
        }

        public ApiKey crear(int usuarioId)
        {
            List<ApiKey> apis_keys = leerApisKeys();
            Guid g = Guid.NewGuid();
            string key_value = Convert.ToBase64String(g.ToByteArray());
            key_value = key_value.Replace("=", "");
            key_value = key_value.Replace("+", "");
            key_value = key_value.Replace("/", "");

            ApiKey api_key = new ApiKey();
            api_key.key = key_value;
            api_key.usuarioId = usuarioId;

            apis_keys.Add(api_key);

            try
            {
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(apis_keys,
                               Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception)
            {
                throw new Exception("Ocurrió un problema al al generar la apikey.");
            }
            return api_key;
        }
    }
}
