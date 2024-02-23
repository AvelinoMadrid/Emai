using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class MaestroServicio_Api : IServicioMaestro_Api
    {
        private static string _baseurl; 

        public MaestroServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Maestro>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Maestro> lista = new List<Maestro>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Maestros/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Maestro>>(jsonRespuesta);
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

        public async Task<Maestro> Obtener(int IdMaestro)
        {
            Maestro Maestro = new Maestro();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Maestros/{IdMaestro}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Maestro>(json_respuesta);
                Maestro = resultado1;
            }

            return Maestro;
        }

        public async Task<bool> Guardar(Maestro Maestro)
        {
            bool maestro1 = false;

            var Clase1 = new HttpClient();
            Clase1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Maestro), Encoding.UTF8, "application/json");
            var response = await Clase1.PostAsync($"api/Maestro/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                maestro1 = true;
            }

            return maestro1;
        }

        public async Task<bool> Editar(Maestro Maestro)
        {

            bool respuesta = false;

            var maestro2 = new HttpClient();
            maestro2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Maestro), Encoding.UTF8, "application/json");
            var response = await maestro2.PutAsync($"api/Maestros/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdMaestro)
        {
            bool respuesta = false;

            var maestro3 = new HttpClient();
            maestro3.BaseAddress = new Uri(_baseurl);

            var response = await maestro3.DeleteAsync($"api/Maestros/{IdMaestro}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<Maestro>> ObtenerTodos()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Maestro> lista = new List<Maestro>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Maestros/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Maestro>>(jsonRespuesta);
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
