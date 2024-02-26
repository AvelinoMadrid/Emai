using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class RepClaseServicio_Api : IServicioRepClase_Api
    {
    
            private static string _baseurl;


            public RepClaseServicio_Api()
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

            }

            public async Task<List<RepClase>> Lista()
            {
                if (string.IsNullOrEmpty(_baseurl))
                {
                    throw new ArgumentException("La URL base no puede ser nula o vacía");
                }

                List<RepClase> lista = new List<RepClase>();

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseurl);
                    var response = await httpClient.GetAsync($"api/RepClase/");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonRespuesta = await response.Content.ReadAsStringAsync();
                        lista = JsonConvert.DeserializeObject<List<RepClase>>(jsonRespuesta);
                    }
                    else
                    {
                        // Manejar el caso cuando la respuesta no es exitosa
                        // Puedes lanzar una excepción, registrar el error, etc.
                        throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                    }
                }

                return lista;
            }

            public async Task<RepClase> Obtener(int IdRepClase)
            {
            RepClase RepClase = new RepClase();

                var cliente1 = new HttpClient();
                cliente1.BaseAddress = new Uri(_baseurl);
                var response = await cliente1.GetAsync($"api/RepClase/{IdRepClase}");

                if (response.IsSuccessStatusCode)
                {
                    var json_respuesta = await response.Content.ReadAsStringAsync();
                    var resultado1 = JsonConvert.DeserializeObject<RepClase>(json_respuesta);
                RepClase = resultado1;
                }

                return RepClase;
            }

            public async Task<bool> Guardar(RepClase RepClase)
            {
                bool RepClase1 = false;

                var Rep1 = new HttpClient();
                Rep1.BaseAddress = new Uri(_baseurl);
                var content = new StringContent(JsonConvert.SerializeObject(RepClase), Encoding.UTF8, "application/json");
                var response = await Rep1.PostAsync($"api/RepClase/Insertar/", content);

                if (response.IsSuccessStatusCode)
                {
                RepClase1 = true;
                }

                return RepClase1;
            }

            public async Task<bool> Editar(RepClase RepClase)
            {
                bool resp = false;

                var RepClase2 = new HttpClient();
            RepClase2.BaseAddress = new Uri(_baseurl);
                var content = new StringContent(JsonConvert.SerializeObject(RepClase), Encoding.UTF8, "application/json");
                var response = await RepClase2.PutAsync($"api/RepClase/Actualizar/", content);

                if (response.IsSuccessStatusCode)
                {
                    resp = true;
                }

                return resp;
            }

            public async Task<bool> Eliminar(int IdRepClase)
            {
                bool respuesa = false;

                var RepClase3 = new HttpClient();
                RepClase3.BaseAddress = new Uri(_baseurl);

                var response = await RepClase3.DeleteAsync($"api/RepClase/Eliminar/{IdRepClase}");

                if (response.IsSuccessStatusCode)
                {
                    respuesa = true;
                }

                return respuesa;
            }

            public async Task<List<RepClase>> ObtenerTodos()
            {
                if (string.IsNullOrEmpty(_baseurl))
                {
                    throw new ArgumentException("La URL base no puede ser nula o vacía");
                }

                List<RepClase> lista = new List<RepClase>();

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_baseurl);
                    var response = await httpClient.GetAsync($"api/Clase/");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonRespuesta = await response.Content.ReadAsStringAsync();
                        lista = JsonConvert.DeserializeObject<List<RepClase>>(jsonRespuesta);
                    }
                    else
                    {
                        // Manejar el caso cuando la respuesta no es exitosa
                        // Puedes lanzar una excepción, registrar el error, etc.
                        throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                    }
                }

                return lista;
            }
    }
}
