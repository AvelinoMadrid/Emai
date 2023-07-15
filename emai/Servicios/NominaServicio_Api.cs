using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class NominaServicio_Api : IServicioNomina_Api
    {
        private static string _baseurl;

        public NominaServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<Nomina>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Nomina> lista = new List<Nomina>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Nomina/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Nomina>>(jsonRespuesta);
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

        public async Task<Nomina> Obtener(int IdNomina)
        {
            Nomina clase = new Nomina();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Nomina/{IdNomina}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Nomina>(json_respuesta);
                clase = resultado1;
            }

            return clase;
        }

        public async Task<bool> Guardar(Nomina Nomina)
        {
            bool Nomin = false;

            var Nomina1 = new HttpClient();
            Nomina1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Nomina), Encoding.UTF8, "application/json");
            var response = await Nomina1.PostAsync($"api/Nomina/", content);

            if (response.IsSuccessStatusCode)
            {
                Nomin = true;
            }

            return Nomin;
        }

        public async Task<bool> Editar(Nomina Nomina)
        {
            bool Nom = false;

            var Nomina2 = new HttpClient();
            Nomina2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Nomina), Encoding.UTF8, "application/json");
            var response = await Nomina2.PutAsync($"api/Nomina/Put/", content);

            if (response.IsSuccessStatusCode)
            {
                Nom = true;
            }

            return Nom;
        }

        public async Task<bool> Eliminar(int IdNomina)
        {
            bool Noomi = false;

            var Nomina3 = new HttpClient();
            Nomina3.BaseAddress = new Uri(_baseurl);

            var response = await Nomina3.DeleteAsync($"api/Nomina/{IdNomina}");

            if (response.IsSuccessStatusCode)
            {
                Noomi = true;
            }

            return Noomi;
        }
    }

}
