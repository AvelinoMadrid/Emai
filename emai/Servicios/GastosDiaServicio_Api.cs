using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class GastosDiaServicio_Api : IServicioGastosDia_Api
    {
        private static string _baseurl;

        public GastosDiaServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<GastosDia>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<GastosDia> lista = new List<GastosDia>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/GastosDia/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<GastosDia>>(jsonRespuesta);
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

        public async Task<GastosDia> Obtener(int IdGastoDia)
        {
            GastosDia Gastodia = new GastosDia();

            var cliente1 = new HttpClient();
            cliente1.BaseAddress = new Uri(_baseurl);
            var response = await cliente1.GetAsync($"api/GastosDia/{IdGastoDia}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<GastosDia>(json_respuesta);
                Gastodia = resultado1;
            }

            return Gastodia;
        }

        public async Task<bool> Guardar(GastosDia GastosDia)
        {
            bool Gas2 = false;

            var Gas1 = new HttpClient();
            Gas1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(GastosDia), Encoding.UTF8, "application/json");
            var response = await Gas1.PostAsync($"api/GastoDia/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                Gas2 = true;
            }

            return Gas2;
        }

        public async Task<bool> Editar(GastosDia GastosDia)
        {
            bool respuesta = false;

            var cole2 = new HttpClient();
            cole2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(GastosDia), Encoding.UTF8, "application/json");
            var response = await cole2.PutAsync($"api/GastosDia/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdGastoDia)
        {
            bool respuesta = false;

            var cole3 = new HttpClient();
            cole3.BaseAddress = new Uri(_baseurl);

            var response = await cole3.DeleteAsync($"api/GastosDia/Eliminar/{IdGastoDia}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
