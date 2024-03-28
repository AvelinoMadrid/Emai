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

        /*optener la lista de los inactivos*/
        public async Task<List<Libro>> ListaInactivo()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Libro> lista = new List<Libro>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"/api/LibrosInactivo");

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

        public async Task<Libro> Obtener(int idActivo)
        {
            Libro libroA = new Libro();

            var libroActivo = new HttpClient();
            libroActivo.BaseAddress = new Uri(_baseurl);
            var response = await libroActivo.GetAsync($"/api/Libro/{idActivo}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Libro>(json_respuesta);
                libroA = resultado1;
            }

            return libroA;
        }
        /*listado de los inactivos*/
        public async Task<Libro> ObtenerInactivo(int idInactivo, string Estado)
        {
            Libro libroI = new Libro();

            var libroInactivo = new HttpClient();
            libroInactivo.BaseAddress = new Uri(_baseurl);
            var response = await libroInactivo.GetAsync($"/api/LibroInactivo/{idInactivo}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Libro>(json_respuesta);
                libroI = resultado1;
            }

            return libroI;
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
            var response = await Libro2.PutAsync($"/api/Libros/Actualizar", content);

            if (response.IsSuccessStatusCode)
            {
                Lib = true;
            }

            return Lib;
        }

        public async Task<bool> ActivarLibro(Libro Libro)
        {
            bool respuesta = false;

            var activar = new HttpClient();
            activar.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Libro), Encoding.UTF8, "application/json");
            var response = await activar.PutAsync($"/api/Libros/Activar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


    }
}
