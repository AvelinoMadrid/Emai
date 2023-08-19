using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class HorarioServicio_Api : IServicioHorario_Api
    {
        private static string _baseurl;


        public HorarioServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Horario>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Horario> lista = new List<Horario>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Horarios/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Horario>>(jsonRespuesta);
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

        public async Task<Horario> Obtener(int IdHorario)
        {
            Horario horario = new Horario();

            var cliente1 = new HttpClient();
            cliente1.BaseAddress = new Uri(_baseurl);
            var response = await cliente1.GetAsync($"api/Horarios/{IdHorario}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Horario>(json_respuesta);
                horario = resultado1;
            }

            return horario;
        }

        public async Task<bool> Guardar(Horario horario)
        {
            bool hor1 = false;

            var horario1 = new HttpClient();
            horario1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(horario), Encoding.UTF8, "application/json");
            var response = await horario1.PostAsync($"api/Horario/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                hor1 = true;
            }

            return hor1;
        }

        public async Task<bool> Editar(Horario horario)
        {
            bool resp = false;

            var horario2 = new HttpClient();
            horario2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(horario), Encoding.UTF8, "application/json");
            var response = await horario2.PutAsync($"api/Horarios/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }

            return resp;
        }

        public async Task<bool> Eliminar(int IdHorario)
        {
            bool respuesa = false;

            var horario3 = new HttpClient();
            horario3.BaseAddress = new Uri(_baseurl);

            var response = await horario3.DeleteAsync($"api/Horarios/Eliminar/{IdHorario}");

            if (response.IsSuccessStatusCode)
            {
                respuesa = true;
            }

            return respuesa;
        }

        public async Task<List<Horario>> ObtenerTodos()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Horario> lista = new List<Horario>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Clase/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Horario>>(jsonRespuesta);
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
