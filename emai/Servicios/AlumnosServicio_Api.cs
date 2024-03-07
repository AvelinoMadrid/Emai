using emai.Models;
using emai.Servicios.Commons;
using emai.Servicios.Dtos.Response;
using Email.Utiilities.Static;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
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
        public async Task<BaseResponseV2<bool>> InsertarAlumnoV1(Alumnos entity)
        {

            var dataFinal = new BaseResponseV2<bool>();

            try
            {
                var json = JsonConvert.SerializeObject(entity);
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var requestUrl = new Uri("https://localhost:7265/api/Alumnos/RegistarAlumnoV1");

                //var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUrl, requestContent).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var resp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    dataFinal = JsonConvert.DeserializeObject<BaseResponseV2<bool>>(resp);
                }
                else
                {
                    dataFinal.IsSuccess = false;
                    dataFinal.Message = $"Error al Ingresar Alumno {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {

                dataFinal.IsSuccess = false;
                dataFinal.Message = $"Error al Ingresar Alumno {ex.Message}";
            }

            return dataFinal;
        }

        public async Task<BaseResponseV1<Promosiones>> ListSelectPromocion()
        {
            var response = new BaseResponseV1<Promosiones>();

            using(HttpClient httpSelectPromocion = new HttpClient()) {
                httpSelectPromocion.BaseAddress = new Uri(_baseurl);
                var httpResponse = await httpSelectPromocion.GetAsync("api/Promosiones/GetSelectPromociones/");

                if (httpResponse.IsSuccessStatusCode) { 

                    var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<BaseResponseV1<Promosiones>>(jsonResponse);

                    if(responseData != null)
                    {
                        response.IsSuccess = responseData.IsSuccess;
                        response.Data= responseData.Data;
                        response.Message= responseData.Message;
                    }
                    else
                    {
                        response.IsSuccess= false;
                        response.Message = StaticVariable.MESSAGE_NOT_ACCEDER;
                    }
                }
                else
                {
                    response.IsSuccess= false;
                    response.Message= StaticVariable.MESSAGE_NOT_ACCEDER;
                }
            }
            return response;
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
        public async Task<BaseResponseV2<bool>> ReactivarAlumnoV1(int IdAlumno)
        {
            var response = new BaseResponseV2<bool>();


            using (var httpClient = new HttpClient())
            {
                //httpClient.BaseAddress = new Uri(_baseurl);

                var httpResponse = await httpClient.DeleteAsync($"https://localhost:7265/api/Alumnos/ReactivarAlumno/{IdAlumno}");


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


        public async Task<List<HorarioResponse>> ListarHorarioSelect()
        {
            List<HorarioResponse> listaHorario = new List<HorarioResponse>();

            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Horarios/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    listaHorario = JsonConvert.DeserializeObject<List<HorarioResponse>>(jsonRespuesta);

                    if (listaHorario != null)
                    {
                        return listaHorario;
                    }
                    else
                    {
                        throw new Exception("Lista De Horario Vacia");

                    }
                }
                else
                {
                    throw new Exception($"No se cumple la peticion de GET {response.StatusCode}");
                }
            }

        }


        public async Task<List<MesesModel>> ListarMesesSelect()
        {
            List<MesesModel> lista = new List<MesesModel>();
            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Meses/SelectMeses/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<MesesModel>>(jsonRespuesta);

                    if (lista != null)
                    {
                        return lista;
                    }
                    else
                    {
                        throw new Exception("Lista De Meses Vacia");

                    }
                }
                else
                {
                    throw new Exception($"No se cumple la peticion de GET {response.StatusCode}");
                }
            }
        }

        public async Task<List<ClasesResponse>> ListarClasesSelect()
        {
            List<ClasesResponse> lista = new List<ClasesResponse>();

            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_baseurl);
                var response = await httpClient.GetAsync($"api/Clase/");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();
                    var claseoriginal = JsonConvert.DeserializeObject<List<Clase>>(jsonRespuesta);

                    //mapearla 
                    foreach(var claseV in claseoriginal)
                    {
                        ClasesResponse classFormateada = new ClasesResponse
                        {
                            idClase = claseV.idClase,
                            Nombre = claseV.Nombre
                        };
                        lista.Add(classFormateada);
                    }
                }
                else
                {
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }
            return lista;
        }

        public async Task<string> GenerarFolio()
        {
            //var response = new FolioGenerado();

            if (string.IsNullOrEmpty(_baseurl))
            {
                throw new ArgumentException("La URL base no puede ser nula o vacía");
            }

            using (var httpClient = new HttpClient())
            {
              
                var response = await httpClient.GetAsync("https://localhost:7265/api/Alumnos/Folio/GenerarFolio");

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = await response.Content.ReadAsStringAsync();

                    var folioV = JsonConvert.DeserializeObject<FolioGenerado>(jsonRespuesta);
                    if (folioV != null && !string.IsNullOrEmpty(folioV.Folio))
                    {
                        // Retorna el valor del folio si no es null o vacío
                        return folioV.Folio;
                    }
                    else
                    {
                        // Maneja el caso en que el valor del folio sea null o vacío
                        throw new Exception("El valor del folio es nulo o vacío");
                    }

                }
                else
                {
                    // Manejar el caso cuando la respuesta no es exitosa
                    // Puedes lanzar una excepción, registrar el error, etc.
                    throw new Exception($"La solicitud GET no fue exitosa. Código de estado: {response.StatusCode}");
                }
            }
        }

      
    }
}

