using emai.Models;
using emai.Servicios.Commons;
using Email.Utiilities.Static;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace emai.Servicios
{
    public class AlumnosServicio_Api : IServicioAlumnos_Api
    {
        private static string _baseurl;

        public AlumnosServicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSetting:baseUrl").Value;

        }
        public async Task<BaseResponseV1<AlumnoModel>> ListarAllAlumnos()
        {
            //var response = new BaseResponseV1<AlumnoModel>();
            var MyData = new BaseResponseV1<AlumnoModel>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var httpResponse = await httpClient.GetAsync("api/Alumnos/GetListAlumnosTotal/");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var responseData = JsonConvert.DeserializeObject<BaseResponseV1<AlumnoModel>>(jsonResponse);

                    if (responseData != null)
                    {
                        MyData.IsSuccess = responseData.IsSuccess;
                        MyData.Data = responseData.Data;
                        MyData.Message= responseData.Message;
                    }
                    else
                    {
                            MyData.IsSuccess  = false;
                            MyData.Message= StaticVariable.MESSAGE_NOT_ACCEDER;
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

        public async Task<List<Alumnos>> Lista()
        {
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            List<Alumnos> lista = new List<Alumnos>();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Alumnos/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Alumnos>>(jsonRespuesta);
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

        public async Task<Alumnos> ObtenerAlu(int IdAlumno)
        {
            Alumnos cooperacion = new Alumnos();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            var response = await cliente.GetAsync($"api/Alumnos/{IdAlumno}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado1 = JsonConvert.DeserializeObject<Alumnos>(json_respuesta);
                cooperacion = resultado1;
            }

            return cooperacion;
        }

        public async Task<bool> GuardarAlu(Alumnos Alumno)
        {
            bool respuesta1 = false;

            var alumno1 = new HttpClient();
            alumno1.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Alumno), Encoding.UTF8, "application/json");
            var response = await alumno1.PostAsync($"api/Alumnos/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta1 = true;
            }

            return respuesta1;
        }

        public async Task<bool> EditarAlu(Alumnos Alumno)
        {
            bool respuesta = false;

            var alumno = new HttpClient();
            alumno.BaseAddress = new Uri(_baseurl);
            var content = new StringContent(JsonConvert.SerializeObject(Alumno), Encoding.UTF8, "application/json");
            var response = await alumno.PutAsync($"api/Alumnos/Put/", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> EliminarAlu(int IdAlumno)
        {
            bool respuesta = false;

            var alumno3 = new HttpClient();
            alumno3.BaseAddress = new Uri(_baseurl);

            var response = await alumno3.DeleteAsync($"api/Alumnos/{IdAlumno}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public Task<bool> RegistrarAlumnos(Alumnos Alumno)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseV2<bool>> EliminarAlumnoV1(int IdAlumno)
        {
            var response = new BaseResponseV2<bool>();

            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(_baseurl);
                   
                var httpResponse = await httpClient.DeleteAsync($"https://localhost:7265/api/Alumnos/DeleteAlumno/{IdAlumno}");
                

                if (httpResponse.IsSuccessStatusCode)
                {
                    
                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    var responseData = JsonConvert.DeserializeObject<BaseResponseV2<bool>>(jsonResponse);

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

        //public async Task<BaseResponseV2<bool>> InsertarAlumno(AlumnoModeInsertV1 entity)
        //{
        //    var response = new BaseResponseV2<bool>();

        //    var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

        //    var alumno1 = new HttpClient();
        //    var dataEnvio = await alumno1.PostAsync("https://localhost:7265/api/Alumnos/RegistarAlumnoV1", content);

        //    if (dataEnvio.IsSuccessStatusCode)
        //    {
        //        response.IsSuccess= true;
        //        response.Data = true;
        //    }
        //    else
        //    {
        //        response.IsSuccess = false;
        //        response.Data = false;
        //    }
        //    return response
  

        //}
    }
}

