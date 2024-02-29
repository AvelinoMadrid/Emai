using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class PromosionesServicio_Api : IServicioPromosiones_Api
    {
        private static string _baseurl;

        public PromosionesServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Promosiones>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Promosiones> lista = new List<Promosiones>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Promosiones/GetAllPromociones/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Promosiones>>(jsonRespuesta);
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

        public async Task<Promosiones> Obtener(int IdPromociones)
        {
            Promosiones Promociones = new Promosiones();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Promosiones/GetAllPromociones/{IdPromociones}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Promosiones>(json_respuesta);
                Promociones = resultado1;
            }

            return Promociones;
        }

        public async Task<bool> Guardar(Promosiones Promociones)
        {
            bool Promociones1 = false;

            var Clase1 = new HttpClient();
            Clase1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Promociones), Encoding.UTF8, "application/json");
            var response = await Clase1.PostAsync($"api/Promosiones/RegistrarPromocionV1/", content);

            if (response.IsSuccessStatusCode)
            {
                Promociones1 = true;
            }

            return Promociones1;
        }

        public async Task<bool> Editar(Promosiones Promociones)
        {

            bool respuesta = false;

            var Promociones2 = new HttpClient();
            Promociones2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Promociones), Encoding.UTF8, "application/json");
            var response = await Promociones2.PutAsync($"api/Promosiones/Update/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdPromociones)
        {
            bool respuesta = false;

            var Promociones3 = new HttpClient();
            Promociones3.BaseAddress = new Uri(_baseurl);

            var response = await Promociones3.DeleteAsync($"api/Promosiones/Delete/{IdPromociones}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<List<Promosiones>> ObtenerTodos()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Promosiones> lista = new List<Promosiones>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Promosiones/GetAllPromociones/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Promosiones>>(jsonRespuesta);
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
