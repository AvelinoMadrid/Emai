using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace emai.Servicios
{
    public class PlanEstudiosServicio_Api : IServicioPlanEstudios_Api
    {
        private static string _baseurl;

        public PlanEstudiosServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<PlanEstudios>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<PlanEstudios> lista = new List<PlanEstudios>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Clase/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<PlanEstudios>>(jsonRespuesta);
                }
                else
                {
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }

            return lista;
        }


    }
}
