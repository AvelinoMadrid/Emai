using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class EventoServicio_Api : IServicioEvento_Api
    {
        private static string _baseurl;

        public EventoServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Evento>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Evento> lista = new List<Evento>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Eventos/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Evento>>(jsonRespuesta);
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

        public async Task<Evento> Obtener(int IdEvento)
        {
            Evento Evento = new Evento();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Eventos/{IdEvento}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Evento>(json_respuesta);
                Evento = resultado1;
            }

            return Evento;
        }

        public async Task<bool> Guardar(Evento evento)
        {
            bool evento1 = false;

            var Cole1 = new HttpClient();
            Cole1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(evento), Encoding.UTF8, "application/json");
            var response = await Cole1.PostAsync($"/api/Evento/Insertar", content);

            if (response.IsSuccessStatusCode)
            {
                evento1 = true;
            }

            return evento1;
        }

        public async Task<bool> Editar(Evento evento)
        {
            bool respuesta = false;

            var evento2 = new HttpClient();
            evento2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(evento), Encoding.UTF8, "application/json");
            var response = await evento2.PutAsync($"api/Evento/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdEvento)
        {
            bool respuesta = false;

            var even3 = new HttpClient();
            even3.BaseAddress = new Uri(_baseurl);

            var response = await even3.DeleteAsync($"api/Eventos/Eliminar/{IdEvento}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
