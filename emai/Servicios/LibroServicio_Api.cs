using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class LibroServicio_Api : IServicioLibro_Api
    {
        private static string _baseurl;


        public LibroServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Libro>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Libro> lista = new List<Libro>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Libro/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Libro>>(jsonRespuesta);
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

        public async Task<Libro> Obtener(int IdLibro)
        {
            Libro libro = new Libro();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Libro/{IdLibro}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Libro>(json_respuesta);
                libro = resultado1;
            }

            return libro;
        }

        public async Task<bool> Guardar(Libro Libro)
        {
            bool respuesta1 = false;

            var libro1 = new HttpClient();
            libro1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
            var response = await libro1.PostAsync($"api/Libro/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta1 = true;
            }

            return respuesta1;
        }

        public async Task<bool> Editar(Libro Libro)
        {
            bool Lib = false;

            var Libro2 = new HttpClient();
            Libro2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
            var response = await Libro2.PutAsync($"api/Libros/ActualizarCosto/", content);

            if (response.IsSuccessStatusCode)
            {
                Lib = true;
            }

            return Lib;
        }

        public async Task<bool> EditarDes(Libro Libro)
        {
            bool Libr = false;

            var Libro3 = new HttpClient();
            Libro3.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
            var response = await Libro3.PutAsync($"api/Libros/Desactivar/", content);

            if (response.IsSuccessStatusCode)
            {
                Libr = true;
            }

            return Libr;
        }


        public async Task<bool> EditarActivar(Libro Libro)
        {
            bool Libroo = false;

            var Libro4 = new HttpClient();
            Libro4.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
            var response = await Libro4.PutAsync($"api/Libros/Activar/", content);

            if (response.IsSuccessStatusCode)
            {
                Libroo = true;
            }

            return Libroo;
        }
    }
}
