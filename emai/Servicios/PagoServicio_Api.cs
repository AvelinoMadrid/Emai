using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class PagoServicio_Api : IServicioPago_Api
    {
        private static string _baseurl;


        public PagoServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<Pago>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Pago> lista1 = new List<Pago>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Pagos/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista1 = JsonConvert.DeserializeObject<List<Pago>>(jsonRespuesta);
                }
                else
                {
                    // Manejar el caso cuando la respuesta no es exitosa
                    // Puedes lanzar una excepción, registrar el error, etc.
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }

            return lista1;
        }

        public async Task<Pago> Obtener(int IdPago)
        {
            Pago pago = new Pago();

            var pagoos = new HttpClient();
            pagoos.BaseAddress = new Uri(_baseurl);
            var response = await pagoos.GetAsync($"api/Pagos/{IdPago}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Pago>(json_respuesta);
                pago = resultado1;
            }

            return pago;
        }

        public async Task<bool> Guardar(Pago Pago)
        {
            bool pagoo = false;

            var pago1 = new HttpClient();
            pago1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Pago), Encoding.UTF8, "application/json");
            var response = await pago1.PostAsync($"api/Pagos/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                pagoo = true;
            }

            return pagoo;
        }

        public async Task<bool> Editar(Pago Pago)
        {
            bool pagoss = false;

            var pago2 = new HttpClient();
            pago2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Pago), Encoding.UTF8, "application/json");
            var response = await pago2.PutAsync($"api/Gasto/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                pagoss = true;
            }

            return pagoss;
        }

        public async Task<bool> Eliminar(int IdPago)
        {
            bool paggos = false;

            var pago3 = new HttpClient();
            pago3.BaseAddress = new Uri(_baseurl);

            var response = await pago3.DeleteAsync($"api/Pagos/Eliminar/{IdPago}");

            if (response.IsSuccessStatusCode)
            {
                paggos = true;
            }

            return paggos;
        }

        
    }
}
