using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class CooperacionesServicio_Api : IServicioCooperaciones_Api
    {
        private static string _baseurl;

        public CooperacionesServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Cooperaciones>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Cooperaciones> lista = new List<Cooperaciones>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Cooperaciones/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Cooperaciones>>(jsonRespuesta);
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

        public async Task<Cooperaciones> Obtener(int IdCooperaciones)
        {
            Cooperaciones cooperacion = new Cooperaciones();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Cooperaciones/{IdCooperaciones}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Cooperaciones>(json_respuesta);
                cooperacion = resultado1;
            }

            return cooperacion;
        }

        public async Task<bool> Guardar(Cooperaciones Cooperaciones)
        {
            bool respuesta1 = false;

            var cooperacion1 = new HttpClient();
            cooperacion1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Cooperaciones), Encoding.UTF8, "application/json");
            var response = await cooperacion1.PostAsync($"api/Cooperaciones/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta1 = true;
            }

            return respuesta1;
        }

        public async Task<bool> Editar(Cooperaciones Cooperaciones)
        {
            bool respuesta = false;

            var cooperacion2 = new HttpClient();
            cooperacion2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Cooperaciones), Encoding.UTF8, "application/json");
            var response = await cooperacion2.PutAsync($"api/Cooperaciones/Put/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdCooperaciones)
        {
            bool respuesta = false;

            var cooperacion3 = new HttpClient();
            cooperacion3.BaseAddress = new Uri(_baseurl);

            var response = await cooperacion3.DeleteAsync($"api/Cooperaciones/{IdCooperaciones}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
