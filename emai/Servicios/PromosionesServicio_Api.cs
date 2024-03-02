using emai.Models;
using emai.Servicios.Commons;
using Email.Utiilities.Static;
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


        public async Task<BaseResponseV3<PromocionesModelV1>> ListarAllPromosiones()
        {
            //var response = new BaseResponseV1<AlumnoModel>();
            var MyData = new BaseResponseV3<PromocionesModelV1>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var httpResponse = await httpClient.GetAsync("api/Promosiones/GetAllPromociones/");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var responseData = JsonConvert.DeserializeObject<BaseResponseV3<PromocionesModelV1>>(jsonResponse);

                    if (responseData != null)
                    {
                        MyData.IsSuccess = responseData.IsSuccess;
                        MyData.Data = responseData.Data;
                        MyData.Message = responseData.Message;
                    }
                    else
                    {
                        MyData.IsSuccess = false;
                        MyData.Message = StaticVariable.MESSAGE_NOT_ACCEDER;
                    }
                }
                else
                {
                    MyData.IsSuccess = false;
                    MyData.Message = StaticVariable.MESSAGE_NOT_ACCEDER;
                }
            }
            return MyData;
        }

        public async Task<List<PromocionesModelV1>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<PromocionesModelV1> lista = new List<PromocionesModelV1>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Promosiones/GetAllPromociones");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<PromocionesModelV1>>(jsonRespuesta);
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


        public async Task<PromocionesModelV1> Obtener(int IdPromociones)
        {
            PromocionesModelV1 cooperacion = new PromocionesModelV1();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Promosiones/GetAllPromociones/{IdPromociones}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<PromocionesModelV1>(json_respuesta);
                cooperacion = resultado1;
            }

            return cooperacion;
        }


        public async Task<bool> Editar(PromocionesModelV1 PromocionesModelV1)
        {
            bool respuesta = false;

            var promosion = new HttpClient();
            promosion.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(PromocionesModelV1), Encoding.UTF8, "application/json");
            var response = await promosion.PutAsync($"https://localhost:7265/api/Promosiones/Update/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<bool> Guardar(PromocionesModelV1 PromocionesModelV1)
        {
            bool respuesta1 = false;

            var promosion1 = new HttpClient();
            promosion1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(PromocionesModelV1), Encoding.UTF8, "application/json");
            var response = await promosion1.PostAsync($"https://localhost:7265/api/Promosiones/RegitarPromocionV1", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta1 = true;
            }

            return respuesta1;
        }




        public async Task<bool> Eliminar(int IdPromociones)
        {
            bool respuesta = false;

            var promocion3 = new HttpClient();
            promocion3.BaseAddress = new Uri(_baseurl);

            var response = await promocion3.DeleteAsync($"api/Promosiones/Delete/{IdPromociones}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }




        public async Task<BaseResponseV4<bool>> EliminarPromosionV1(int IdPromociones)
        {
            var response = new BaseResponseV4<bool>();

            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(_baseurl);

                var httpResponse = await httpClient.DeleteAsync($"https://localhost:7265/api/Promosiones/Delete/{IdPromociones}");


                if (httpResponse.IsSuccessStatusCode)
                {

                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var responseData = JsonConvert.DeserializeObject<BaseResponseV4<bool>>(jsonResponse);

                    response.IsSuccess = responseData.IsSuccess;
                    response.Data = responseData.Data;
                    response.Message = responseData.Message;

                    return response;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = StaticVariable.MESSAGE_NOT_ACCEDER;
                }
            }
            return response;

        }


    }
}