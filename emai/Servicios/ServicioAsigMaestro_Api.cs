using emai.Models;
using Newtonsoft.Json;
using System.Text;

namespace emai.Servicios
{
    public class ServicioAsigMaestro_Api : IServicioAsigMaestro_Api
    {
        private static string _baseurl;

        public ServicioAsigMaestro_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<AsigMaestro>> ListaAsigMaestro()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<AsigMaestro> listaMaestro = new List<AsigMaestro>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/AsignacionMaestro");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    listaMaestro = JsonConvert.DeserializeObject<List<AsigMaestro>>(jsonRespuesta);
                }
                else
                {
                    // Manejar el caso cuando la respuesta no es exitosa
                    // Puedes lanzar una excepción, registrar el error, etc.
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }

            return listaMaestro;
        }
        /*OBTENER ID*/
        public async Task<AsigMaestro> Obtener(int AsgnId)
        {
            AsigMaestro asigMaestro = new AsigMaestro();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/AsignacionMaestro/{AsgnId}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<AsigMaestro>(json_respuesta);
                asigMaestro = resultado1;
            }

            return asigMaestro;
        }

        /*ASIGNAR MAESTRO*/
        public async Task<bool> AsignarAsigMaestro(AsigMaestro AsigMaestro)
        {
            bool asigMaestro = false;

            var asi1 = new HttpClient();
            asi1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(AsigMaestro), Encoding.UTF8, "application/json");
            var response = await asi1.PostAsync($"/api/Maestro/Asignar", content);

            if (response.IsSuccessStatusCode)
            {
                asigMaestro = true;
            }

            return asigMaestro;
        }

        /*ELIMMINAR*/
        public async Task<bool> EliminarAsignacion(int AsgnId)
        {
            
            bool respuesta = false;

            var asig3 = new HttpClient();
            asig3.BaseAddress = new Uri(_baseurl);

            var response = await asig3.DeleteAsync($"api/AsignacionMaestro/Eliminar/{AsgnId}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> ActualizarAsigMaestro(AsigMaestro AsigMaestro)
        {
            bool respuesta = false;

            var maestro2 = new HttpClient();
            maestro2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(AsigMaestro), Encoding.UTF8, "application/json");
            var response = await maestro2.PutAsync($"api/AsignacionMaestro/Actualizar", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }



    }
}
