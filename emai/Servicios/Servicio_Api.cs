using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class Servicio_Api : IServicio_Api
    {
        private static string _baseurl;


        public Servicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;
        }


        public async Task<List<Usuarios>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Usuarios> lista = new List<Usuarios>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Usuarios/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Usuarios>>(jsonRespuesta);
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

        public async Task<Usuarios> Obtener(int idUsuario)
        {
            Usuarios usuarios = new Usuarios();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Usuarios/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Usuarios>(json_respuesta);
                usuarios = resultado;
            }

            return usuarios;
        }

        public async Task<bool> Guardar(Usuarios usuario)
        {
            bool respuesta = false;

            var usuario1 = new HttpClient();
            usuario1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(usuario),Encoding.UTF8, "application/json");
            var response = await usuario1.PostAsync($"api/Usuario/Insertar/",content);

            if(response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Editar(Usuarios usuario)
        {
            bool respuesta = false;

            var usuario1 = new HttpClient();
            usuario1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await usuario1.PutAsync($"api/Usuarios/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int idUsuario)
        {
            bool respuesta = false;

            var usuario1 = new HttpClient();
            usuario1.BaseAddress = new Uri(_baseurl);
            
            var response = await usuario1.DeleteAsync($"api/Usuarios/Eliminar/{idUsuario}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    }
}
