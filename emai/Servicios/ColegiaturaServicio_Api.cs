using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using emai.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class ColegiaturaServicio_Api : IServicioColegiatura_Api
    {
        private static string _baseurl;

        public ColegiaturaServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }

        public async Task<List<GastosColegiatura>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<GastosColegiatura> lista = new List<GastosColegiatura>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Colegiatura/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<GastosColegiatura>>(jsonRespuesta);
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

        public async Task<GastosColegiatura> Obtener(int IdColegiatura)
        {
            GastosColegiatura Colegiatura = new GastosColegiatura();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Colegiatura/{IdColegiatura}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<GastosColegiatura>(json_respuesta);
                Colegiatura = resultado1;
            }

            return Colegiatura;
        }

        public async Task<bool> Guardar(GastosColegiatura Colegiatura)
        {
            bool colegiatura1 = false;

            var Cole1 = new HttpClient();
            Cole1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Colegiatura), Encoding.UTF8, "application/json");
            var response = await Cole1.PostAsync($"api/Colegiatura/Insertar/", content);

            if (response.IsSuccessStatusCode)
            {
                colegiatura1 = true;
            }

            return colegiatura1;
        }

        public async Task<bool> Editar(GastosColegiatura Colegiatura)
        {
            bool respuesta = false;

            var cole2 = new HttpClient();
            cole2.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Colegiatura), Encoding.UTF8, "application/json");
            var response = await cole2.PutAsync($"api/Colegiatura/Actualizar/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Eliminar(int IdColegiatura)
        {
            bool respuesta = false;

            var cole3 = new HttpClient();
            cole3.BaseAddress = new Uri(_baseurl);

            var response = await cole3.DeleteAsync($"api/Colegiatura/Eliminar/{IdColegiatura}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

    //    public List<GastosColegiatura> GetDataForPDF()
    //    {
    //        // Aquí debes implementar la lógica para obtener los datos de alguna fuente
    //        // Por ejemplo, desde una base de datos, una lista en memoria, etc.
    //        List<GastosColegiatura> data = new List<GastosColegiatura>
    //        {
    //    new GastosColegiatura { IdColegiatura = 1, Fecha = DateTime.Now,NoPedido = "04",Descripcion = "pago colegiatura",Cantidad = 100.00M, Subtotal = 100.00M, Total = 150.00M },
    //    new GastosColegiatura { IdColegiatura = 2, Fecha = DateTime.Now.AddDays(1),NoPedido = "04",Descripcion = "pago colegiatura2",Cantidad = 100.00M, Subtotal = 100.00M, Total = 150.00M }
    //    // Agregar más datos aquí...
    //};

    //        return data;
    //    }

    }
}
