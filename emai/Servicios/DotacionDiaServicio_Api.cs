using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class DotacionDiaServicio_Api : IServicioDotacionDia_Api
    {
        private static string _baseurl;

        public DotacionDiaServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<DotacionDia>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<DotacionDia> lista = new List<DotacionDia>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/DotacionDia/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<DotacionDia>>(jsonRespuesta);
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

        public async Task<DotacionDia> Obtener(int IdDotacion)
        {
            DotacionDia Dotacion = new DotacionDia();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/DotacionDia/{IdDotacion}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<DotacionDia>(json_respuesta);
                Dotacion = resultado1;
            }

            return Dotacion;
        }

        public async Task<bool> Guardar(DotacionDia Dotacion)
        {
            bool Dotacion1 = false;

            var Cole1 = new HttpClient();
            Cole1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Dotacion), Encoding.UTF8, "application/json");
            var response = await Cole1.PostAsync($"/api/DotacionDia/Insertar", content);

            if (response.IsSuccessStatusCode)
            {
                Dotacion1 = true;
            }

            return Dotacion1;
        }

        public async Task<bool> Editar(DotacionDia Dotacion)
        {
            bool respuesta = false;

            var dota2 = new HttpClient();
            dota2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Dotacion), Encoding.UTF8, "application/json");
            var response = await dota2.PutAsync($"api/DotacionDia/Put/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdDotacion)
        {
            bool respuesta = false;

            var dota3 = new HttpClient();
            dota3.BaseAddress = new Uri(_baseurl);

            var response = await dota3.DeleteAsync($"api/DotacionDia/{IdDotacion}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }
    }
}
