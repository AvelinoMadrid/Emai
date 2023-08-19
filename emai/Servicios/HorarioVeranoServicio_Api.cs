using emai.Controllers;
using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class HorarioVeranoServicio_Api : IServicioHorarioVerano_Api
    {
        private static string _baseurl;


        public HorarioVeranoServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<HorarioVerano>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<HorarioVerano> lista = new List<HorarioVerano>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/HorarioVerano/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<HorarioVerano>>(jsonRespuesta);
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

        public async Task<HorarioVerano> Obtener(int IdHorarioVerano)
        {
            HorarioVerano horarioVr = new HorarioVerano();

            var cliente1 = new HttpClient();
            cliente1.BaseAddress = new Uri(_baseurl);
            var response = await cliente1.GetAsync($"api/HorarioVerano/{IdHorarioVerano}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<HorarioVerano>(json_respuesta);
                horarioVr = resultado1;
            }

            return horarioVr;
        }

        public async Task<bool> Guardar(HorarioVerano horarioVerano)
        {
            bool horV1 = false;

            var horarioVr1 = new HttpClient();
            horarioVr1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(horarioVerano), Encoding.UTF8, "application/json");
            var response = await horarioVr1.PostAsync($"api/HorarioVerano/", content);

            if (response.IsSuccessStatusCode)
            {
                horV1 = true;
            }

            return horV1;
        }

        public async Task<bool> Editar(HorarioVerano horarioVerano)
        {
            bool resp = false;

            var horarioVr2 = new HttpClient();
            horarioVr2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(horarioVerano), Encoding.UTF8, "application/json");
            var response = await horarioVr2.PutAsync($"api/HorarioVerano/", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }

            return resp;
        }

        public async Task<bool> Eliminar(int IdHorarioVerano)
        {
            bool respuesa = false;

            var horarioVr3 = new HttpClient();
            horarioVr3.BaseAddress = new Uri(_baseurl);

            var response = await horarioVr3.DeleteAsync($"api/HorarioVerano/{IdHorarioVerano}");

            if (response.IsSuccessStatusCode)
            {
                respuesa = true;
            }

            return respuesa;
        }

        public async Task<List<HorarioVerano>> ObtenerTodos()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<HorarioVerano> lista = new List<HorarioVerano>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Clase/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<HorarioVerano>>(jsonRespuesta);
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
