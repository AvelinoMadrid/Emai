using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class Programa5sServicio_Api : IServicioPrograma5s_Api
    {
        private static string _baseurl;


        public Programa5sServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Programa5s>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Programa5s> lista = new List<Programa5s>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Programa5s/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Programa5s>>(jsonRespuesta);
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

        public async Task<Programa5s> Obtener(int Id)
        {
            Programa5s programa5s = new Programa5s();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Programa5s/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Programa5s>(json_respuesta);
                programa5s = resultado;
            }

            return programa5s;
        }




        public async Task<bool> Guardar(Programa5s programa5s)
        {
            bool respuesta = false;

            var programa5s1 = new HttpClient();
            programa5s1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(programa5s), Encoding.UTF8, "application/json");
            var response = await programa5s1.PostAsync($"api/Programa5s/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<bool> Editar(Programa5s programa5s)
        {
            bool respuesta = false;

            var programa5s1 = new HttpClient();
            programa5s1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(programa5s), Encoding.UTF8, "application/json");
            var response = await programa5s1.PutAsync($"api/Programa5s/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }






 




    }

}