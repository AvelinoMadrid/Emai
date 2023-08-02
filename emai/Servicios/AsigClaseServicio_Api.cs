using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class AsigClaseServicio_Api : IServicioAsigClase_Api
    {
        private static string _baseurl;

        public AsigClaseServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<AsigClase>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<AsigClase> lista = new List<AsigClase>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/AsignacionClase/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<AsigClase>>(jsonRespuesta);
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

        public async Task<AsigClase> Obtener(int AsgnId)
        {
            AsigClase asigclase = new AsigClase();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/AsignacionClase/{AsgnId}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<AsigClase>(json_respuesta);
                asigclase = resultado1;
            }

            return asigclase;
        }

        public async Task<bool> Asignar(AsigClase AsigClase)
        {
            bool asigclase1 = false;

            var asi1 = new HttpClient();
            asi1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(AsigClase), Encoding.UTF8, "application/json");
            var response = await asi1.PostAsync($"/api/Clases/Asignar", content);

            if (response.IsSuccessStatusCode)
            {
                asigclase1 = true;
            }

            return asigclase1;
        }

        public async Task<bool> Eliminar(int AsgnId)
        {
            bool respuesta = false;

            var asig3 = new HttpClient();
            asig3.BaseAddress = new Uri(_baseurl);

            var response = await asig3.DeleteAsync($"api/AsignacionClase/Eliminar/{AsgnId}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
