using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Response;
//using EMAI.Comun.DTOs;
//using EMAI.Comun.Models;
//using EMAI.Entiddes;

using EMAI.Servicios;
using Microsoft.Data.SqlClient;
using System.Data;
using static EMAI.Comun.Models.EventosIDModel;
using static EMAI.Comun.Models.RepClaseModel;

namespace EMAI.Datos
{
    public class AppRepository : IAppRepository
    {

        private readonly bool _isUnitOfWork;

        public string EMAIConnection { get; set; }

        public string ErrorMessageSp { get; set; }

        public bool Respuesta { get; set; }

        public AppRepository(bool isUnitOfWork = false)
        {
            _isUnitOfWork = isUnitOfWork;
            EMAIConnection = "Data Source=.;initial Catalog=22marzo;User Id=sa;Password=admin123;Integrated Security=True;TrustServerCertificate=True;";

        }

        #region " Sección Alumnos --> "

       


        public async Task<InsertarAlumnoModelV1> GetListAlumnoByIdV1(int IdAlumno)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("MostrarAlumnoTotalbyIdV1", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IAlumnoBuscar", IdAlumno));
                    InsertarAlumnoModelV1 response = null;//3
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAlumnoTotalV1(reader);
                        }
                    }

                    return response;
                }
            }
        }
        private InsertarAlumnoModelV1 MapToAlumnoTotalV1(SqlDataReader reader)
        {
            return new InsertarAlumnoModelV1()
            {
                IdAlumno = (int)reader["codigoAlumno"],
                Tag = (string)reader["Tag"],
                FechaInscripcion = (string)reader["FechaInscripcion"],
                NoDiaClases = (int)reader["NoDiaClases"],
                FechaInicioClase = (string)reader["FechaInicioClase"],
                NombreCompleto = (string)reader["NombreCompleto"],
                Edad = (int)reader["Edad"],
                FechaNacimiento = (string)reader["FechaNacimiento"],
                TelefonoCasa = (string)reader["TelCasa"],
                Celular = (string)reader["Celular"],
                Facebook = (string)reader["Facebook"],
                Email = (string)reader["Email"],
                Enfermedades = (string)reader["Enfermedades"],
                SeleccionarClase1 = (int)reader["SeleccionarClase1"],
                DiaAndHoraClase = (string)reader["DiaAndHoraClase"],
                SeleccionarClase2 = (int)reader["SeleccionarClase2"],
                DiaAndHoraClaseOpcional = (string)reader["DiaAndHoraClaseOpcional"],
                NombrePapas = (string)reader["NombrePapas"],
                CelularPapas = (string)reader["CelularPapas"],
                EmailPapas = (string)reader["EmailPapa"],//checar esta parte
                TutorRecoger = (string)reader["TutorRecoger"],
                CelularTR = (string)reader["CelularTR"],
                NumEmergencia = (string)reader["NumEmergencia"],
                Estudios = reader.GetBoolean(reader.GetOrdinal("Estudios")),
                EscuelaActuales = (string)reader["EscuelaActual"],
                Trabajas = reader.GetBoolean(reader.GetOrdinal("Trabajas")),
                LugarTrabajo = (string)reader["LugarTrabajo"],

                ConConocimiento = reader.GetBoolean(reader.GetOrdinal("ConConocimiento")),
                Instrumento = (string)reader["InstrumentoOne"],
                InstrumentoCasa = reader.GetBoolean(reader.GetOrdinal("InstrumentoCasa")),
                InstrumentotTwo = (string)reader["InstrumentotTwo"],
                EnterasteEsc = (string)reader["EnterasteEsc"],
                InteresGnroMusical = reader.GetBoolean(reader.GetOrdinal("InteresGnroMusical")),
                CualesMusicales = (string)reader["CualesGenroMusicalV"],

                ClaseOpcional = reader.GetBoolean(reader.GetOrdinal("ClasOpcional")),
                DescuentoP = reader.GetBoolean(reader.GetOrdinal("DescuentoP")),
                Amables = reader.GetBoolean(reader.GetOrdinal("Amablebilidad")),
                NombreRecepcionista = (string)reader["NombreRecepcionista"],

                Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
            };
        }

        public async Task<List<InsertarAlumnoModelV1>> GetListAlumnosTotalV1()
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("MostrarAlumnoTotalV1", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<InsertarAlumnoModelV1>(); //1
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToAlumnoTotalV1(reader));//2
                            }
                        }
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }

        }




        public async Task<ListFolioResponse[]> GetListFolio()
        {
            try
            {
                //List<string> res = new List<string>()
                //https://es.stackoverflow.com/questions/47992/convertir-sqldatareader-en-lista-generica
                List<ListFolioResponse> FolioArray = new List<ListFolioResponse>();
                ListFolioResponse objData = new ListFolioResponse();

                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("ListFolio", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        await sql.OpenAsync();

                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            //tomar el valor de fila 
                            string valueFila = reader["Folio"].ToString();
                            objData.Folio = valueFila;
                            FolioArray.Add(objData);
                        }
                    }
                }
                return FolioArray.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }
        public async Task<bool> ReactivarByIdAlumnoV1(int IdAlumno)
        {
            bool response = false;

            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                await sql.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("ReactivarAlumnoTotalV1", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdReactivar", IdAlumno));

                    SqlParameter paramSalida = new SqlParameter("@RowAffect", SqlDbType.Int);
                    paramSalida.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramSalida);

                    await cmd.ExecuteNonQueryAsync();

                    int valorDevuelto = (int)paramSalida.Value;

                    if (valorDevuelto > 0)
                    {
                        response = true;
                    }
                }
            }
            return response;
        }

        public async Task<bool> DeleteByIdAlumnoV1(int IdAlumno)
        {
            bool response = false;
            //https://codigowolf.blogspot.com/2020/04/parametros-de-salida-c-y-sql-server.html difere3wnciar para hacerla mas corta posible
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                await sql.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("EliminarAlumnoTotalV1", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdEliminar", IdAlumno));

                    SqlParameter paramSalida = new SqlParameter("@RowAffect", SqlDbType.Int);
                    paramSalida.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramSalida);

                    await cmd.ExecuteNonQueryAsync();

                    int valorDevuelto = (int)paramSalida.Value;

                    if (valorDevuelto > 0)
                    {
                        response = true;
                    }
                }
            }

            return response;
        }
        public async Task<bool> EditarAlumnoV1(InsertarAlumnoModelV1 request)
        {
          bool success = false;

            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    await sql.OpenAsync();
                    using (SqlTransaction transaction = sql.BeginTransaction(System.Data.IsolationLevel.Serializable))
                    {
               try
               {
                    using (SqlCommand cmd = new SqlCommand("UpdateAlumnoV1", sql, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new SqlParameter("@IdAlumno", request.IdAlumno));
                                cmd.Parameters.Add(new SqlParameter("@FechaInscripcion", request.FechaInscripcion));
                                cmd.Parameters.Add(new SqlParameter("@Tag", request.Tag));
                                cmd.Parameters.Add(new SqlParameter("@NoDiaClases", request.NoDiaClases));
                                cmd.Parameters.Add(new SqlParameter("@FechaInicioClase", request.FechaInicioClase));
                                cmd.Parameters.Add(new SqlParameter("@NombreCompleto", request.NombreCompleto));

                                cmd.Parameters.Add(new SqlParameter("@Edad", request.Edad));
                                cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", request.FechaNacimiento));
                                cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", request.TelefonoCasa));
                                cmd.Parameters.Add(new SqlParameter("@Celular", request.Celular));
                                cmd.Parameters.Add(new SqlParameter("@Facebook", request.Facebook));

                                cmd.Parameters.Add(new SqlParameter("@Email", request.Email));
                                cmd.Parameters.Add(new SqlParameter("@Enfermedades", request.Enfermedades));
                                cmd.Parameters.Add(new SqlParameter("@SeleccionarClase1", request.SeleccionarClase1));
                                cmd.Parameters.Add(new SqlParameter("@DiaAndHoraClase", request.DiaAndHoraClase));
                                cmd.Parameters.Add(new SqlParameter("@SeleccionarClase2", request.SeleccionarClase2));
                                cmd.Parameters.Add(new SqlParameter("@DiaAndHoraClaseOpcional", request.DiaAndHoraClaseOpcional));
                                cmd.Parameters.Add(new SqlParameter("@Activo", request.Activo));

                                cmd.Parameters.Add(new SqlParameter("@NombrePapas", request.NombrePapas));
                                cmd.Parameters.Add(new SqlParameter("@CelularPapas", request.Celular));
                                cmd.Parameters.Add(new SqlParameter("@FacebookPapas", request.FacebookPapas));
                                cmd.Parameters.Add(new SqlParameter("@EmailPapas", request.EmailPapas));
                                cmd.Parameters.Add(new SqlParameter("@TutorRecoger", request.TutorRecoger));
                                cmd.Parameters.Add(new SqlParameter("@CelularTR", request.CelularTR));
                                cmd.Parameters.Add(new SqlParameter("@NumEmergencia", request.NumEmergencia));

                                cmd.Parameters.Add(new SqlParameter("@Estudios", request.Estudios));
                                cmd.Parameters.Add(new SqlParameter("@GradoEstudios", request.GradoEstudios));
                                cmd.Parameters.Add(new SqlParameter("@EscuelaActuales", request.EscuelaActuales));
                                cmd.Parameters.Add(new SqlParameter("@Trabajas", request.Trabajas));
                                cmd.Parameters.Add(new SqlParameter("@LugarTrabajo", request.LugarTrabajo));


                                cmd.Parameters.Add(new SqlParameter("@ConConocimiento", request.ConConocimiento));
                                cmd.Parameters.Add(new SqlParameter("@Instrumento", request.Instrumento));
                                cmd.Parameters.Add(new SqlParameter("@InstrumentoCasa", request.InstrumentoCasa));
                                cmd.Parameters.Add(new SqlParameter("@InstrumentotTwo", request.InstrumentotTwo));
                                cmd.Parameters.Add(new SqlParameter("@EnterasteEsc", request.EnterasteEsc));
                                cmd.Parameters.Add(new SqlParameter("@InteresGnroMusical", request.InteresGnroMusical));
                                cmd.Parameters.Add(new SqlParameter("@CualesMusicales", request.CualesMusicales));


                                cmd.Parameters.Add(new SqlParameter("@TipoInteres", request.TipoInteres));
                                cmd.Parameters.Add(new SqlParameter("@OtroOpcional", request.OtroOpcional));
                                cmd.Parameters.Add(new SqlParameter("@MusicalInteres", request.MusicalInteres));
                                cmd.Parameters.Add(new SqlParameter("@ClaseOpcional", request.ClaseOpcional));
                                cmd.Parameters.Add(new SqlParameter("@DescuentoP", request.DescuentoP));
                                cmd.Parameters.Add(new SqlParameter("@Amables", request.Amables));
                                cmd.Parameters.Add(new SqlParameter("@NombreRecepcionista", request.NombreRecepcionista));

                            

                                SqlParameter salidaInt = new SqlParameter("@IntResult", SqlDbType.Int);
                                salidaInt.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(salidaInt);

                                await cmd.ExecuteNonQueryAsync();

                                if (Convert.ToInt32(salidaInt.Value) == 1)
                                {
                                    success = true;
                                }
                                transaction.Commit();
                            }
                        }
                        catch(Exception ex)
                {
                            transaction.Rollback();
                            throw new Exception("Error al ejecutar el procedimiento almacenado", ex);

                        }
             }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Se presentó un problema de conexión con la base de datos", ex);

            }
            return success;
        }

        public async Task<bool> InsertarAlumnoTwo(InsertarAlumnoModelV1 request)
        {

            bool success = false;

            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistroTotalAlumno", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //cmd.Parameters.Add(new SqlParameter("@IdAlumno", 0));
                        cmd.Parameters.Add(new SqlParameter("@FechaInscripcion", request.FechaInscripcion));
                        cmd.Parameters.Add(new SqlParameter("@Tag", request.Tag));
                        cmd.Parameters.Add(new SqlParameter("@NoDiaClases", request.NoDiaClases));
                        cmd.Parameters.Add(new SqlParameter("@FechaInicioClase", request.FechaInicioClase));
                        cmd.Parameters.Add(new SqlParameter("@NombreCompleto", request.NombreCompleto));

                        cmd.Parameters.Add(new SqlParameter("@Edad", request.Edad));
                        cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", request.FechaNacimiento));
                        cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", request.TelefonoCasa));
                        cmd.Parameters.Add(new SqlParameter("@Celular", request.Celular));
                        cmd.Parameters.Add(new SqlParameter("@Facebook", request.Facebook));

                        cmd.Parameters.Add(new SqlParameter("@Email", request.Email));
                        cmd.Parameters.Add(new SqlParameter("@Enfermedades", request.Enfermedades));
                        cmd.Parameters.Add(new SqlParameter("@SeleccionarClase1", request.SeleccionarClase1));
                        cmd.Parameters.Add(new SqlParameter("@DiaAndHoraClase", request.DiaAndHoraClase));
                        cmd.Parameters.Add(new SqlParameter("@SeleccionarClase2", request.SeleccionarClase2));
                        cmd.Parameters.Add(new SqlParameter("@DiaAndHoraClaseOpcional", request.DiaAndHoraClaseOpcional));
                        cmd.Parameters.Add(new SqlParameter("@Activo", request.Activo));

                        cmd.Parameters.Add(new SqlParameter("@NombrePapas", request.NombrePapas));
                        cmd.Parameters.Add(new SqlParameter("@CelularPapas", request.Celular));
                        cmd.Parameters.Add(new SqlParameter("@FacebookPapas", request.FacebookPapas));
                        cmd.Parameters.Add(new SqlParameter("@EmailPapas", request.EmailPapas));
                        cmd.Parameters.Add(new SqlParameter("@TutorRecoger", request.TutorRecoger));
                        cmd.Parameters.Add(new SqlParameter("@CelularTR", request.CelularTR));
                        cmd.Parameters.Add(new SqlParameter("@NumEmergencia", request.NumEmergencia));

                        cmd.Parameters.Add(new SqlParameter("@Estudios", request.Estudios));
                        cmd.Parameters.Add(new SqlParameter("@GradoEstudios", request.GradoEstudios));
                        cmd.Parameters.Add(new SqlParameter("@EscuelaActuales", request.EscuelaActuales));
                        cmd.Parameters.Add(new SqlParameter("@Trabajas", request.Trabajas));
                        cmd.Parameters.Add(new SqlParameter("@LugarTrabajo", request.LugarTrabajo));


                        cmd.Parameters.Add(new SqlParameter("@ConConocimiento", request.ConConocimiento));
                        cmd.Parameters.Add(new SqlParameter("@Instrumento", request.Instrumento));
                        cmd.Parameters.Add(new SqlParameter("@InstrumentoCasa", request.InstrumentoCasa));
                        cmd.Parameters.Add(new SqlParameter("@InstrumentotTwo", request.InstrumentotTwo));
                        cmd.Parameters.Add(new SqlParameter("@EnterasteEsc", request.EnterasteEsc));
                        cmd.Parameters.Add(new SqlParameter("@InteresGnroMusical", request.InteresGnroMusical));
                        cmd.Parameters.Add(new SqlParameter("@CualesMusicales", request.CualesMusicales));


                        cmd.Parameters.Add(new SqlParameter("@TipoInteres", request.TipoInteres));
                        cmd.Parameters.Add(new SqlParameter("@OtroOpcional", request.OtroOpcional));
                        cmd.Parameters.Add(new SqlParameter("@MusicalInteres", request.MusicalInteres));
                        cmd.Parameters.Add(new SqlParameter("@ClaseOpcional", request.ClaseOpcional));
                        cmd.Parameters.Add(new SqlParameter("@DescuentoP", request.DescuentoP));
                        cmd.Parameters.Add(new SqlParameter("@Amables", request.Amables));
                        cmd.Parameters.Add(new SqlParameter("@NombreRecepcionista", request.NombreRecepcionista));


                        cmd.Parameters.Add(new SqlParameter("@Folio", request.Folio));
                        cmd.Parameters.Add(new SqlParameter("@IdPromosion", request.IdPromosion));
                        cmd.Parameters.Add(new SqlParameter("@IdMes", request.IdMes));
                        cmd.Parameters.Add(new SqlParameter("@FechaPago", request.FechaPago));
                        cmd.Parameters.Add(new SqlParameter("@CostoLibro", request.CostoLibro));
                        cmd.Parameters.Add(new SqlParameter("@NombreLibro", request.NombreLibro));
                        cmd.Parameters.Add(new SqlParameter("@Atendio", request.Atendio));
                        //cmd.Parameters.Add(new SqlParameter("@Costo", request.Costo));
                        //cmd.Parameters.Add(new SqlParameter("@Subtotal", request.Subtotal));
                        //cmd.Parameters.Add(new SqlParameter("@IVA", request.IVA));
                        cmd.Parameters.Add(new SqlParameter("@Total", request.Total));
                        cmd.Parameters.Add(new SqlParameter("@Inscripcion", request.Inscripcion));
                        cmd.Parameters.Add(new SqlParameter("@Mensualidad", request.Mensualidad));

                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Registrar AlumnoNuevo {ex.Message}");
                return false;
            }
        }
        #endregion

        #region "Secciones ---> Adicionales"
        public async Task<List<AdicionalesModel>> GetAdicionales()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAdicional", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<AdicionalesModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAdicional(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private AdicionalesModel MapToAdicional(SqlDataReader reader)
        {
            return new AdicionalesModel()
            {

                IdAdicional = (int)reader["IdAdicional"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                Fecha = (DateTime)reader["Fecha"],
            };
        }

        public async Task<AdicionalesIDModel> GetAdicionalesID(int IdUsuario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDAdicionales", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAdicional", IdUsuario));
                    AdicionalesIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAdicionalId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private AdicionalesIDModel MapToAdicionalId(SqlDataReader reader)
        {
            return new AdicionalesIDModel()
            {

                IdAdicional = (int)reader["IdAdicional"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                Fecha = (DateTime)reader["Fecha"],
            };
        }

        public async Task<bool> InsertarAdicional(AdicionalesInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarAdicional", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", value.IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> ActualizarAdicional(int IdAdicional, int IdAlumno, int IdClase, int IdHorario, DateTime Fecha)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarAdicionales", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAdicional", IdAdicional));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarAdicional(int IdUsuario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarAdicional", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAdicional", IdUsuario));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion Asistencia -->"
        //MOSTAR TODAS LAS ASISTENCIAS 
        public async Task<List<AsistenciaModel>> GetAllAsistencias()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AsistenciaObtenerTodo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<AsistenciaModel>(); 
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAsistencia(reader));
                        }
                    }
                    return response;
                }
            }
        }

        //obtener Asistencia por ID
        public async Task<AsistenciaModel> GetAsistenciaByID(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AsistenciaObtenerporID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAsistencia", id));
                    AsistenciaModel response = null;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAsistencia(reader);//3
                        }
                    }

                    return response;



                }
            }
        }

        private AsistenciaModel MapToAsistencia(SqlDataReader reader)
        {
            return new AsistenciaModel()
            {
                IdAsistencia = (int)reader["IdAsistencia"],
                IdAlumno = (int) reader["IdAlumno"], 
                IdClase = (int)reader["IdClase"], 
                FechaAsistencia = (DateTime)reader["Fecha"],
                Asistecia = (bool)reader["Asistencia"]
            };
        }

        // insertar Asistencia

        public async Task<bool> InsertarAlumnoAsistencia(InsertAsistenciaModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AsistenciaAlumnoInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsistencia", value.FechaAsistencia));
                    cmd.Parameters.Add(new SqlParameter("@Asistencia", value.Asistecia));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        // Eliminar Asistencia
        public async Task<bool> DeleteAsistenciabyID(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnoAsistenciaEliminar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDAsistencia", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task <bool> UpdateAsistencia(int id, int IdAlumno, int IdClase, DateTime Fecha, bool Asistencia)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnoAsistenciaActualizar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDAsistencia", id));
                    cmd.Parameters.Add(new SqlParameter("@IDAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IDClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Asistencia", Asistencia));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }













        #endregion

        #region "Seccion ---> Clases"
        public async Task<List<ClasesModel>> GetClases()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerClases", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ClasesModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToClases(reader));//2
                        }
                    }

                    return response;
                }
            }
        }
        public async Task<List<SelectClasesUnique>> GetListaUniqueHorario()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("MostrarClasesUnica", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<SelectClasesUnique>(); 
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToClasesUnique(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<List<SelectClasesHorarioResponse>> SelectClasesHorario(string nameProcedure, int idClase)
        {
            var response = new List<SelectClasesHorarioResponse>();

            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(nameProcedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdClase", idClase));
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToClasesHorario(reader));
                            }
                        }
                        return response;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }
         private SelectClasesHorarioResponse MapToClasesHorario(SqlDataReader reader)
        {
            return new SelectClasesHorarioResponse()
            {
                IdClase = (int)reader["CodigoClase"],
                IdHorario= (int)reader["CodigHorario"],
                Dia = (string)reader["TheDay"]
            };
        }


        private ListaClases MapToClasesNombre(SqlDataReader reader)
        {
            return new ListaClases()
            {
                NombreClase = (string)reader["Nombre"]

            };
        }

        public async Task<List<ListaClases>> GetNombreClases()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerClasesNombre", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ListaClases>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToClasesNombre(reader));//2
                        }
                    }

                    return response;
                }
            }
        }


        private SelectClasesUnique MapToClasesUnique(SqlDataReader reader)
        {
            return new SelectClasesUnique()
            {

                IdClase = (int)reader["IdClase"],
                Nombre = (string)reader["Nombre"],

            };
        }

        private ClasesModel MapToClases(SqlDataReader reader)
        {
            return new ClasesModel()
            {

                idClase = (int)reader["IdClase"],
                Nombre = (string)reader["Nombre"],
                CNormal = (string)reader["CNormal"],
                CVerano = (string)reader["CVerano"],
                Dia = (string)reader["Dia"],

                Dia2 = (string)reader["Dia2"],
                /*Horario2 = (string)reader["Horario2"]*/
                Dia3 = (string)reader["Dia3"],
                //Horario3 = (string)reader["Horario3"],
                Costo = (decimal)reader["Costo"],

                //DiaOpc = (string)reader["DiaOpc"].ToString(),

            };
        }

        public async Task<ClasesIdModel> GetClasesId(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdClase", Id));
                    ClasesIdModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToClasesId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private ClasesIdModel MapToClasesId(SqlDataReader reader)
        {
            return new ClasesIdModel()
            {

                idClase = (int)reader["IdClase"],
                Nombre = (string)reader["Nombre"],
                CNormal = (string)reader["CNormal"],
                CVerano = (string)reader["CVerano"],
                Dia = (string)reader["Dia"],

                Dia2 = (string)reader["Dia2"],
                /*Horario2 = (string)reader["Horario2"]*/
                Dia3 = (string)reader["Dia3"],
                //Horario3 = (string)reader["Horario3"],
                Costo = (decimal)reader["Costo"],

                //DiaOpc = (string)reader["DiaOpc"].ToString(),
            };
        }

        public async Task<bool> InsertarClase(ClasesModelInsertar value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombre", value.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@CNormal", value.CNormal));
                    cmd.Parameters.Add(new SqlParameter("@Cverano", value.CVerano));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));

                    cmd.Parameters.Add(new SqlParameter("@Dia2", value.Dia2));

                    cmd.Parameters.Add(new SqlParameter("@Dia3", value.Dia3));

                    cmd.Parameters.Add(new SqlParameter("@Costo", value.Costo));
                    ;


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Dia2, string Dia3, decimal Costo)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@CNormal", CNormal));
                    cmd.Parameters.Add(new SqlParameter("@Cverano", CVerano));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));

                    cmd.Parameters.Add(new SqlParameter("@Horario2", Dia2));

                    cmd.Parameters.Add(new SqlParameter("@Dia3", Dia3));

                    cmd.Parameters.Add(new SqlParameter("@Costo", Costo));



                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> EliminarClase(int IdClase)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdClase", IdClase));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }



        #endregion


        #region "Seccion --> Cooperacion"

        public async Task<List<CooperacionesModel>> GetAllCooperaciones()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CooperacionesObtenerTodo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<CooperacionesModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToCooperaciones(reader));//2
                        }
                    }

                    return response;
                }
            }
        }


        public async Task<CooperacionesModel> GetCooperacionesByID(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("uspp_CooperacionesObtenerporId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCooperacion", id));
                    CooperacionesModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToCooperaciones(reader);//3
                        }
                    }

                    return response;
                }
            }
        }


        private CooperacionesModel MapToCooperaciones(SqlDataReader reader)
        {
            return new CooperacionesModel()
            {
                IdCooperacion = (int)reader["IdCooperacion"], 
                Fecha = (DateTime)reader["Fecha"], 
                NoPedido = reader["NoPedido"].ToString(), 
                Proveedor = reader["Proveedor"].ToString(), 
                //Descripcion = reader["Descripcion"].ToString(), 
                Cantidad = (decimal)reader["Cantidad"], 
                Img = reader["Img"].ToString()
                //SubTotal = (decimal)reader["SubTotal"], 
                //Total = (decimal)reader["Total"]
            };
        }

        public async Task<bool> InsertarCooperaciones(InsertCooperacionModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("uspp_CooperacionesInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", value.NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", value.Proveedor));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", value.SubTotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", value.Total));
                    cmd.Parameters.Add(new SqlParameter("@Img", value.Img));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteCooperacionesbyId(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CooperacionesEliminarporId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCooperacion", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> UpdateCooperaciones(int id, DateTime Fecha, string NoPedido, string Proveedor,  decimal cantidad,string img)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CooperacionesActualizarporId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdCooperacion", id));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedor));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", Total));
                    cmd.Parameters.Add(new SqlParameter("@Img",img));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }



        #endregion

        #region "Secciones ---> Colegiatura"
        public async Task<List<ColegiaturaModel>> GetColegiatura()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<ColegiaturaModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToColegiatura(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private ColegiaturaModel MapToColegiatura(SqlDataReader reader)
        {
            return new ColegiaturaModel()
            {

                IdColegiatura = (int)reader["IdColegiiatura"],
                Fecha = (DateTime)reader["Fecha"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                //Subtotal = (decimal)reader["Subtotal"],
                //Total = (decimal)reader["Total"]
                Img = reader["Img"].ToString()
            };
        }

        public async Task<ColegiaturaIDModel> GetColegiaturaID(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", IdColegiatura));
                    ColegiaturaIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToColegiaturaId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private ColegiaturaIDModel MapToColegiaturaId(SqlDataReader reader)
        {
            return new ColegiaturaIDModel()
            {

                IdColegiatura = (int)reader["IdColegiiatura"],
                Fecha = (DateTime)reader["Fecha"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                //Subtotal = (decimal)reader["Subtotal"],
                //Total = (decimal)reader["Total"]
                Img = reader["Img"].ToString()
            };
        }

        public async Task<bool> InsertarColegiatura(ColegiaturaInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertarColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", value.Total));
                    cmd.Parameters.Add(new SqlParameter("@Img", value.Img));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarColegiatura(int IdColegiatura, DateTime Fecha, string Descripcion, decimal Cantidad,string img)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", IdColegiatura));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    //cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", Total));
                    cmd.Parameters.Add(new SqlParameter("@Img", img));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> EliminarColegiatura(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", IdColegiatura));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        #endregion

        #region "Seccion --> DotacionDia"


        public async Task<List<DotacionDiaModel>> GetAllDotacionDia()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DotacionesObtenerTodo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<DotacionDiaModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToDotacionDia(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private DotacionDiaModel MapToDotacionDia(SqlDataReader reader)
        {
            return new DotacionDiaModel()
            {
                IdDotacion = (int)reader["IdDotacion"], 
                Fecha = (DateTime)reader["Fecha"], 
                NoPedido = reader["NoPedido"].ToString(),
                Descripcion = reader["Descripcion"].ToString(),
                Cantidad = (decimal)reader["Cantidad"],
                Img = reader["Img"].ToString()
            };
        }


        public async Task<DotacionDiaModel> GetDotacionDiaById(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DotacionesObtenerporId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdDotacionDia", id));
                    DotacionDiaModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToDotacionDia(reader);//3
                        }
                    }

                    return response;
                }
            }
        }


        public async Task<bool> InsertarDotacionDia(InsertDotacionDiaModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DotacionesDiaInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", value.NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Img", value.Img));
                  

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateDotacionDia(int id, DateTime fecha, string NoPedido, string Descripcion, decimal cantidad, string img)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DotacionesDiaUpdate", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdDotacionDia", id));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
          
                    cmd.Parameters.Add(new SqlParameter("@Img", img));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        // para eliminar 

        public async Task<bool> DeleteDotacionDiabyID(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DotacionesDiaEliminar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdDotacionDia", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;


                }
            }
        }



        #endregion

        #region "Secciones ---> Gastos"
        public async Task<List<GastosModel>> GetGastos()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerGastos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<GastosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToGastos(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private GastosModel MapToGastos(SqlDataReader reader)
        {
            return new GastosModel()
            {

                IdGasto = (int)reader["IdGasto"],

                Fecha = (DateTime)reader["Fecha"],
                NoPedidoE_S = (string)reader["NoPedidoE_S"],
                Proveedor = (string)reader["Proveedor"],

                Cantidad = (decimal)reader["Cantidad"],
                //imagen = reader["GastosImg"].ToString()

            };
        }

        public async Task<GastosIDModel> GetGastosID(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDGastos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGasto", IdColegiatura));
                    GastosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToGastosId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private GastosIDModel MapToGastosId(SqlDataReader reader)
        {
            return new GastosIDModel()
            {

                IdGasto = (int)reader["IdGasto"],

                Fecha = (DateTime)reader["Fecha"],
                NoPedidoE_S = (string)reader["NoPedidoE_S"],
                Proveedor = (string)reader["Proveedor"],

                Cantidad = (decimal)reader["Cantidad"],
               // imagen = reader["GastosImg"].ToString()
            };
        }

        public async Task<bool> InsertarGastos(GastosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarGasto", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedidoE_S", value.NoPedidoE_S));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", value.Proveedor));

                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                   // cmd.Parameters.Add(new SqlParameter("@Img", value.imagen));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarGastos(int IdGasto, DateTime Fecha, string NoPedidoE_S,
          string Proveedor, decimal Cantidad, string Imagen)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarGastos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGasto", IdGasto));

                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedidoE_S", NoPedidoE_S));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedor));
                    cmd.Parameters.Add(new SqlParameter("@Img", Imagen));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));



                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarGastos(int IdGasto)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarGastos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGasto", IdGasto));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Secciones ---> GastosDia"
        public async Task<List<GastosDiaModel>> GetGastosDia()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerGastosDia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<GastosDiaModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToGastosDia(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private GastosDiaModel MapToGastosDia(SqlDataReader reader)
        {
            return new GastosDiaModel()
            {

                IdGastoDia = (int)reader["IdGastoDia"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedido = (string)reader["NoPedido"],
                Proveedor = (string)reader["Proveedor"],
                //Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                //img = reader["Img"].ToString()


                //Total = (decimal)reader["Total"],
            };
        }

        public async Task<GastosDiaIDModel> GetGastosDiaID(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDGastosDia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGastoDia", IdColegiatura));
                    GastosDiaIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToGastosDiaId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private GastosDiaIDModel MapToGastosDiaId(SqlDataReader reader)
        {
            return new GastosDiaIDModel()
            {

                IdGastoDia = (int)reader["IdGastoDia"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedido = (string)reader["NoPedido"],
                Proveedor = (string)reader["Proveedor"],
                //Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                //img = reader["Img"].ToString()
                //Subtotal = (decimal)reader["Subtotal"],
                //Total = (decimal)reader["Total"],
                img = reader["Img"].ToString()
            };
        }

        public async Task<bool> InsertarGastosDia(GastosDiaInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarGastoDia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", value.NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", value.Proveedor));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    // cmd.Parameters.Add(new SqlParameter("@Img", value.img));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", value.Total));
                    cmd.Parameters.Add(new SqlParameter("@Img", value.img));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarGastosDia(int IdGastoDia, DateTime Fecha, string NoPedido, string Proveedro,
            decimal Cantidad, string img)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarGastosDia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGastoDia", IdGastoDia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedro));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Img", img));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    //cmd.Parameters.Add(new SqlParameter("@Total", Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarGastosDia(int IdGastoDia)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarGastoDia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGastoDia", IdGastoDia));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> Horarios"
        public async Task<List<HorariosModel>> GetHorarios()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<HorariosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToHorarios(reader));//2
                        }
                    }

                    return response;
                }
            }
        }


        private HorariosModel MapToHorarios(SqlDataReader reader)
        {
            return new HorariosModel()
            {
                IdHorario = (int)reader["IdHorario"],
                Dia = (string)reader["Dia"],
                //Hora = (string)reader["Hora"],

            };
        }

        public async Task<HorariosIDModel> GetHorariosID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDHorario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", Id));
                    HorariosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToHorariosId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private HorariosIDModel MapToHorariosId(SqlDataReader reader)
        {
            return new HorariosIDModel()
            {
                IdHorario = (int)reader["IdHorario"],
                Dia = (string)reader["Dia"],
                //Hora = (string)reader["Hora"],
            };
        }

        public async Task<bool> InsertarHorario(HorariosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@IdHorario", value.idHorario));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    //cmd.Parameters.Add(new SqlParameter("@Hora", value.Hora));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarHorario(int IdHorario, string Dia)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    //cmd.Parameters.Add(new SqlParameter("@Hora", Hora));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarHorario(int IdHorario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarHorario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdHorario", IdHorario));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion


        #region "Seccion ---> HorariosVerano"
        public async Task<List<HorariosVeranoModel>> GetAllHorariosVerano()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorariosVeranoObtenerTodo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<HorariosVeranoModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToHorariosVerano(reader));//2
                        }
                    }

                    return response;
                }
            }
        }


        public async Task<HorariosVeranoModel> GetHorariosVeranoById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorariosVeranoObtenerByID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorarioVerano", Id));
                    HorariosVeranoModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToHorariosVerano(reader);//3
                        }
                    }

                    return response;
                }
            }
        }


        private HorariosVeranoModel MapToHorariosVerano(SqlDataReader reader)
        {
            return new HorariosVeranoModel()
            {
                IdHorarioVerano = (int)reader["IdHorarioVerano"],
                Dia = reader["Dia"].ToString(),
                Hora = reader["Hora"].ToString(),
                
            };
        }


        public async Task<bool> InsertHorarioVerano(HorariosVeranoInsertModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorarioVeranoInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                   
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    
                    cmd.Parameters.Add(new SqlParameter("@Hora", value.Hora));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateHorarioVerano(int IdHorarioVerano,string Dia, string Hora)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorarioVeranoActualizar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorarioVerano", IdHorarioVerano));
                
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    
                    cmd.Parameters.Add(new SqlParameter("@Hora", Hora));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteHorarioVerano(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorarioVeranoEliminar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorarioVerano", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> Libros"
        private LibrosModel MapToLibros(SqlDataReader reader)
        {
            return new LibrosModel()
            {
                IdLibro = (int)reader["IdLibro"],
                NombreLibro = reader["NombreLibro"].ToString(),
                costo = (decimal)reader["Costo"],
                Status = (bool)reader["Status"]
            };
        }

        public async Task<List<LibrosModel>> GetAllLibros()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerLibros", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<LibrosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToLibros(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<LibrosModel> GetLibrobyId(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_LibroObtenerByID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Libro", id));
                    LibrosModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToLibros(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<bool> InsertLibro(InsertLibrosModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertarLibro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NombreLibro", value.NombreLibro));
                    cmd.Parameters.Add(new SqlParameter("@Costo", value.costo));
                    cmd.Parameters.Add(new SqlParameter("@Status", value.Status));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> StatusDesactivadoLibro(int IdLibro)
        {
            int status = 0;
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DesactivadorLibro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdLibro", IdLibro));
                    cmd.Parameters.Add(new SqlParameter("@Status", status));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> StatusActivadorLibro(int IdLibro)
        {
            int status = 1;
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ActivadorLibro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdLibro", IdLibro));
                    cmd.Parameters.Add(new SqlParameter("@Status", status));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> UpdateLibro(int IDLibro, decimal costo)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateLibroLibro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdLibro", IDLibro));
                    cmd.Parameters.Add(new SqlParameter("@Costo", costo));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> Maestros"
        public async Task<List<MaestrosModel>> GetMaestros()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerMaestros", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<MaestrosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToMaestros(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private MaestrosModel MapToMaestros(SqlDataReader reader)
        {
            return new MaestrosModel()
            {

                IdMaestro = (int)reader["IdMaestro"],
                Nombre = (string)reader["Nombre"],
                ApellidoP = (string)reader["ApellidoP"],
                ApellidoM = (string)reader["ApellidoM"],
                Direccion = (string)reader["Direccion"],
                Telefono = (string)reader["Telefono"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],

                Estatus = (string)reader["Estatus"],


                Pago = (decimal)reader["Pago"],
                PagoSemanal = (decimal)reader["PagoSemanal"],
                PagoHora = (decimal)reader["PagoHora"],
                Area = (string)reader["Area"]

            };
        }

        public async Task<MaestrosIDModel> GetMaestrosID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", Id));
                    MaestrosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToMaestrosId(reader);//3
                        }
                    }
                    return response;

                }
            }
        }

        private MaestrosIDModel MapToMaestrosId(SqlDataReader reader)
        {
            return new MaestrosIDModel()
            {

                IdMaestro = (int)reader["IdMaestro"],
                Nombre = (string)reader["Nombre"],
                ApellidoP = (string)reader["ApellidoP"],
                ApellidoM = (string)reader["ApellidoM"],
                Direccion = (string)reader["Direccion"],
                Telefono = (string)reader["Telefono"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],

                Estatus = (string)reader["Estatus"],


                Pago = (decimal)reader["Pago"],
                PagoSemanal = (decimal)reader["PagoSemanal"],
                PagoHora = (decimal)reader["PagoHora"],

                Area = (string)reader["Area"]

            };
        }

        public async Task<bool> InsertarMaestro(MaestrosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombre", value.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoP", value.ApellidoP));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoM", value.ApellidoM));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", value.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", value.Telefono));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", value.FechaNacimiento));

                    cmd.Parameters.Add(new SqlParameter("@Status", value.Estatus));

                    cmd.Parameters.Add(new SqlParameter("@Pago", value.Pago));
                    cmd.Parameters.Add(new SqlParameter("@PagoSemanal", value.PagoSemanal));
                    cmd.Parameters.Add(new SqlParameter("@PagoHora", value.PagoHora));
                    cmd.Parameters.Add(new SqlParameter("@Area", value.Area));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, string Status, decimal Pago, decimal PagoSemanal, decimal PagoHora, string Area)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarMaestros", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdMaestro", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoP", ApellidoP));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoM", ApellidoM));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));

                    cmd.Parameters.Add(new SqlParameter("@Status", Status));

                    cmd.Parameters.Add(new SqlParameter("@Pago", Pago));
                    cmd.Parameters.Add(new SqlParameter("@PagoSemanal", PagoSemanal));
                    cmd.Parameters.Add(new SqlParameter("@PagoHora", PagoHora));
                    cmd.Parameters.Add(new SqlParameter("@Area", Area));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarMaestro(int IdMaestro)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdMaestro", IdMaestro));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        #endregion

        #region "Seccion --> Nomina"
        public async Task<List<NominaModel>> GetAllNomina()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerNominas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<NominaModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToNomina(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        public async Task<NominaModel> GetByIDNomina(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerNominasbyId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdNomina", id));
                    NominaModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToNomina(reader);//3
                        }
                    }

                    return response;


                }


            }
        }


        private NominaModel MapToNomina(SqlDataReader reader)
        {
            return new NominaModel()
            {
                IdNomina = (int)reader["IdNomina"],
                Fecha = (DateTime)reader["Fecha"], 
                NoPedido = reader["NoPedido"].ToString(),
                Proveedor = reader["Proveedor"].ToString(),
                //Descripcion = reader["Descripcion"].ToString(),
                Cantidad = (decimal)reader["Cantidad"], 
                //Img = reader["Img"].ToString()
                //Subtotal = (decimal)reader["Subtotal"], 
                //Total = (decimal)reader["Total"]

            };
        }

        public async Task<bool> InsertarNomina(InsertNominaModel value)
        {
            
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertarNominas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", value.NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", value.Proveedor));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", value.SubTotal));
                    cmd.Parameters.Add(new SqlParameter("@Img", value.Img));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        // ACTUALIZAR 

        public async Task<bool> ActualizarNomina(int IdNomina, DateTime Fecha, string NoPedido, string Proveedor,  decimal Cantidad, string img)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateNominas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdNominas", IdNomina));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedor));
                    //cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    //cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Img", img));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        // ELIMINAR 
        public async Task<bool> EliminarNomina(int id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteNominas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdNominas", id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Secciones ---> Promosiones"
        public async Task<bool> InsertarPromocionesV1(PromocionesModelV1 request)
        {
            bool success = false;
            int Valor_Retornado = 0;
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    await sql.OpenAsync();

                   using (SqlTransaction trasasaccion = sql.BeginTransaction(System.Data.IsolationLevel.Serializable))
                   {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("PromocionesInsertarV1",sql, trasasaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@NombrePromocion", request.NombrePromocion));
                                cmd.Parameters.Add(new SqlParameter("@Porcentaje", request.Porcentaje));
                                cmd.Parameters.Add(new SqlParameter("@Activo", request.Activo));

                                SqlParameter paramSalida = new SqlParameter("@IntResult", SqlDbType.Int);
                                paramSalida.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(paramSalida);


                                await cmd.ExecuteNonQueryAsync();
                                int valorDevuelto = (int)paramSalida.Value;


                                if (valorDevuelto==1)
                                {
                                    success = true;
                                }
                                trasasaccion.Commit();
                               

                            }
                        }
                        catch (Exception ex) {

                            trasasaccion.Rollback();
                            return success = false;
                        }

                    } 
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
            return success;
        }
        public async Task<bool> UpdatePromocionesV1(PromocionesModelV1 request)
        {
            bool success = false;

            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    await sql.OpenAsync();

                    using (SqlTransaction transaction = sql.BeginTransaction(System.Data.IsolationLevel.Serializable))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("UpdatePromocionesv1", sql, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new SqlParameter("@NombrePromocion", request.NombrePromocion));
                                cmd.Parameters.Add(new SqlParameter("@Porcentaje", request.Porcentaje));
                                cmd.Parameters.Add(new SqlParameter("@Activo", request.Activo));
                                cmd.Parameters.Add(new SqlParameter("@IdPromociones", request.IdPromociones));

                                SqlParameter salidaInt = new SqlParameter("@IntResult", SqlDbType.Int);

                                salidaInt.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(salidaInt);
                                cmd.Parameters.Add("@IntResult",SqlDbType.Int).Direction = ParameterDirection.Output;

                                await cmd.ExecuteNonQueryAsync();

                            
                                if (Convert.ToInt32(salidaInt.Value) == 1)
                                {
                                    success = true;
                                }

                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error al ejecutar el procedimiento almacenado", ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presentó un problema de conexión con la base de datos", ex);
            }

            return success;
        }


        public async Task<bool> EliminarPromocionesV1(int IdPromocion)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarPromocionesV1", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdPromociones", IdPromocion));
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }
        private PromocionesModelV1 MapToPromocionV1(SqlDataReader reader)
        {
            return new PromocionesModelV1()
            {
                IdPromociones = (int)reader["IdPromociones"],
                NombrePromocion = (string)reader["NombrePromocion"],
                Porcentaje = Convert.ToDecimal((double)reader["Porcentaje"]),
                Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
            };
        }
        public async Task<List<PromocionesModelV1>> GetSelectPromocionesV1()
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("MostrarPromocionesV1", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<PromocionesModelV1>(); //1
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToPromocionV1(reader));//2
                            }
                        }
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }
  
        public async Task<List<PromocionesModelV1>> GetPromocionesV1()
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("MostrarPromocionesV1", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<PromocionesModelV1>(); //1
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToPromocionV1(reader));//2
                            }
                        }
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }
        public async Task<PromocionesModelV1> GetPromocionById(int IdPromocion)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SelectByIdPromocionesV1", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdPromociones ", IdPromocion));
                        PromocionesModelV1 response = null;//3
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response = MapToPromocionV1(reader);//3
                            }
                        }   
                        return response!;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);

            }
        }

        #endregion

        #region "Seccion ---> Usuarios"
        public async Task<List<UsuariosModel>> GetUsuarios()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerUsuarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<UsuariosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToUsuarios(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private UsuariosModel MapToUsuarios(SqlDataReader reader)
        {
            return new UsuariosModel()
            {

                IdUsuario = (int)reader["IdUsuario"],
                Usuario = (string)reader["Usuario"],
                Contraseña = (string)reader["Contraseña"],
                Email = (string)reader["E-mail"],
                Direccion = (string)reader["Direccion"],
                Telefono = (string)reader["Telefono"],
            };
        }

        public async Task<UsuariosModel> Loggeo(string usuario, string contraseña)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("Loggeo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Usuario", usuario));
                    cmd.Parameters.Add(new SqlParameter("@Password", contraseña));
                    UsuariosModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToUsuarios(reader);//3
                        }
                    }

                    return response;
                }
            }
        }



        public async Task<UsuariosIDModel> GetUsuariosID(int IdUsuario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", IdUsuario));
                    UsuariosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToUsuariosId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private UsuariosIDModel MapToUsuariosId(SqlDataReader reader)
        {
            return new UsuariosIDModel()
            {

                IdUsuario = (int)reader["IdUsuario"],
                Usuario = (string)reader["Usuario"],
                Contraseña = (string)reader["Contraseña"],
                Email = (string)reader["Email"],
                Direccion = (string)reader["Direccion"],
                Telefono = (string)reader["Telefono"],

            };
        }

        public async Task<bool> InsertarUsuario(UsuariosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Usuario", value.Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Contraseña", value.Contraseña));
                    cmd.Parameters.Add(new SqlParameter("@Email", value.Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", value.Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", value.Telefono));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarUsuario(int IdUsuario, string Usuario, string Contraseña, string Email, string Direccion, string Telefono)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", IdUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Usuario", Usuario));
                    cmd.Parameters.Add(new SqlParameter("@Contraseña", Contraseña));
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", Direccion));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", Telefono));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarUsuario(int IdUsuario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", IdUsuario));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> MostrarMeses"
        public async Task<List<MesesModelV1>> GetSelectMeses()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("MostrarMeses", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<MesesModelV1>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToMeses(reader));//2
                        }
                    }
                    return response;
                }
            }
        }
        private MesesModelV1 MapToMeses(SqlDataReader reader)
        {
            return new MesesModelV1()
            {
                IdMeses = (int)reader["IdMeses"],
                NombreMes = (string)reader["NombreMes"],
            };
        }

        #endregion

        #region "Secciones ---> Pagos"
        public async Task<List<PagosModel>> GetPagos()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerPagos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PagosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToPagos(reader));//2
                        }
                    }
                    return response;
                }
            }
        }

        private PagosModel MapToPagos(SqlDataReader reader)
        {
            return new PagosModel()
            {
                IdPago = (int)reader["IdPago"],
                Folio = (string)reader["Folio"],
                //FechaPago = (DateTime)reader["FechaPago"],
                IdPromosionales = (int)reader["IdPromosiones"],
                Mes = (string)reader["Mes"],
                IdClasePago = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                DiaAlumnoPago = (string)reader["Dia"],
                InstrumentoAlimnoPago = (string)reader["Instrumento"],
                CostoLibro = (decimal)reader["CostoLibro"],
                NombreLibro = (string)reader["NombreLibro"],
                Costo = (decimal)reader["Costo"],
                Subtotal = (decimal)reader["Subtotal"],
                IVA = (decimal)reader["IVA"],
                Total = (decimal)reader["Total"],
                IdAlumno = (int)reader["IdAlumno"]
            };
        }

        public async Task<PagosIDModel> GetPagosID(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDPagos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPagos", IdColegiatura));
                    PagosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToPagoId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private PagosIDModel MapToPagoId(SqlDataReader reader)
        {
            return new PagosIDModel()
            {
                IdPago = (int)reader["IdPago"],
                Folio = (string)reader["Folio"],
                //FechaPago = (DateTime)reader["FechaPago"],
                IdPromosionales = (int)reader["IdPromosiones"],
                Mes = (string)reader["Mes"],
                IdClasePago = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                DiaAlumnoPago = (string)reader["Dia"],
                InstrumentoAlimnoPago = (string)reader["Instrumento"],
                CostoLibro = (decimal)reader["CostoLibro"],
                NombreLibro = (string)reader["NombreLibro"],
                Costo = (decimal)reader["Costo"],
                Subtotal = (decimal)reader["Subtotal"],
                IVA = (decimal)reader["IVA"],
                Total = (decimal)reader["Total"],
                IdAlumno = (int)reader["IdAlumno"]
            };
        }

        public async Task<bool> InsertarPagos(PagosInsertarModel value)
        {
            Random rnd = new Random();
            long folio = rnd.NextInt64(100000000000, 1000000000000);
            folio.ToString("D12");

            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarPago", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Folio", folio));
                    cmd.Parameters.Add(new SqlParameter("@IdPromosionales", value.IdPromosionales));
                    cmd.Parameters.Add(new SqlParameter("@Mes", value.Mes));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClasePago));   
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", value.IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.DiaAlumnoPago));
                    cmd.Parameters.Add(new SqlParameter("@Instrumento", value.InstrumentoAlimnoPago));
                    cmd.Parameters.Add(new SqlParameter("@CostoLibro", value.CostoLibro));
                    cmd.Parameters.Add(new SqlParameter("@NombreLibro", value.NombreLibro));
                    cmd.Parameters.Add(new SqlParameter("@Costo", value.Costo));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@IVA", value.IVA));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarPagos(int IdPago, int IdPromosiones, int IdAdicionales, DateTime Fecha, string Folio, DateTime FechaPago,
            decimal SaldoPendiente, string Mes, int IdHorario, string Dia, int IdClase, int IdRecepcionista, decimal Costo, string Autorizacion,
            decimal Subtotal, decimal Iva, decimal Total)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarPagos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPago", IdPago));
                    cmd.Parameters.Add(new SqlParameter("@IdPromosiones", IdPromosiones));
                    cmd.Parameters.Add(new SqlParameter("@IdAdicionales", IdAdicionales));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Folio", Folio));
                    cmd.Parameters.Add(new SqlParameter("@FechaPago", FechaPago));
                    cmd.Parameters.Add(new SqlParameter("@SaldoPendiente", SaldoPendiente));
                    cmd.Parameters.Add(new SqlParameter("@Mes", Mes));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdRecepcionista", IdRecepcionista));
                    cmd.Parameters.Add(new SqlParameter("@Costo", Costo));
                    cmd.Parameters.Add(new SqlParameter("@Autorizacion", Autorizacion));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@IVA", Iva));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarPago(int IdPago)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarPagos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPago", IdPago));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> Horas"

        public async Task<List<HorasModel>> GetHoras()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerHoras", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<HorasModel>(); //1
                    await sql.OpenAsync();
                    using (var reader = await  cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync()) {
                        
                            response.Add(MapToHoras(reader));
                            
                        }
                    }
                    return response;
                }
            }

        }
        public async Task<bool> InsertarHoras(HorasInsertarModel value)
        {

            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarHoras", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NameHora", value.NameHora));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;

                }

            }
        }



        private HorasModel MapToHoras(SqlDataReader reader)
        {
            return new HorasModel()
            {
                IdHora = (int)reader["IdHora"],
                NameHora = (string)reader["NameHora"],
            };
        }

        #endregion

        #region "Seccion ---> Eventos"
        public async Task<List<EventosModel>> GetEventos()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerEventos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<EventosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToEventos(reader));//2
                        }
                    }

                    return response;
                }
            }
        }
   

        private EventosModel MapToEventos(SqlDataReader reader)
        {
            DateTime fecha1 = (DateTime)reader["Fecha"];
            string fechaForma = fecha1.ToString("yyyy-MM-dd");

            return new EventosModel()
            {
             
                IdEvento = (int)reader["IdEvento"],
                NombreEvento = (string)reader["NombreEvento"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                NameHora = (string)reader["NameHora"],
                Fecha= fechaForma,
                IdHora=(int)reader["IdHora"],
                NombreAlumno = (string)reader["nombreAlumno"],
                ApellidoP = (string)reader["ApellidoP"],
                ApellidoM = (string)reader["ApellidoM"],
                NombreClase = (string)reader["nombreClase"]
            };
        }

        public async Task<EventosIDModel> GetEventosID(int IdEvento)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDEventos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdEvento", IdEvento));
                    EventosIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToEventoId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private EventosIDModel MapToEventoId(SqlDataReader reader)
        {
            DateTime fecha1 = (DateTime)reader["Fecha"];
            string fechaForma = fecha1.ToString("yyyy-MM-dd");

            return new EventosIDModel()
            {

                IdEvento = (int)reader["IdEvento"],
                NombreEvento = (string)reader["NombreEvento"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                NameHora = (string)reader["NameHora"],
                Fecha = fechaForma,
                IdHora = (int)reader["IdHora"],
            };
        }

        public async Task<bool> InsertarEvento(EventoInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarEvento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NombreEvento", value.NombreEvento));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@IdHora", value.IdHora));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, string Fecha, int IdHora, int IdAlumno, int IdClase)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarEvento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdEvento", IdEvento));
                    cmd.Parameters.Add(new SqlParameter("@NombreEvento", NombreEvento));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@IdHora",IdHora));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        

        public async Task<bool> EliminarEvento(int IdEvento)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarEvento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdEvento", IdEvento));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        #endregion

        #region "Seccion ---> AsignacionClase"
        public async Task<List<AsigClaseModel>> GetAsigClase()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAsigClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<AsigClaseModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAsigClase(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private AsigClaseModel MapToAsigClase(SqlDataReader reader)
        {
            return new AsigClaseModel()
            {

                AsgnId = (int)reader["AsgnId"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                IdClaseOpc = (int)reader["IdClaseOpc"],
                FechaAsignacion = (DateTime)reader["FechaAsignacion"],
            };
        }

        public async Task<AsigClaseId> GetAsigClaseId(int IdEvento)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDAsigClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AsgnId", IdEvento));
                    AsigClaseId response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAsigClaseId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private AsigClaseId MapToAsigClaseId(SqlDataReader reader)
        {
            return new AsigClaseId()
            {

                AsgnId = (int)reader["AsgnId"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                IdClaseOpc = (int)reader["IdClaseOpc"],
                FechaAsignacion = (DateTime)reader["FechaAsignacion"],
            };
        }

        public async Task<bool> AsignarClase(AsigClaseAsignar value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("AsignarClaseAMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MaestroId", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@ClaseId", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@ClaseIdOpc", value.IdClaseOpc));
                    cmd.Parameters.Add(new SqlParameter("@FechaAsignacion", value.FechaAsignacion));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarAsignacion(int AsgnId)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarAsigClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AsgClase", AsgnId));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        #endregion

        #region "Seccion -----> AsignacionMaestro"
        /*Mostrar todo*/
        
        public async Task<AsigMaestroId> GetAsigMaestroId(int IdEvento)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDAsigMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AsgnId", IdEvento));
                    AsigMaestroId response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAsigMaestroId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private AsigMaestroId MapToAsigMaestroId(SqlDataReader reader)
        {
            return new AsigMaestroId()
            {

                AsgnId = (int)reader["AsgnId"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"]
            };
        }
        public async Task<List<AsigMaestroModel>> GetAsigMaestro1()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAsigMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<AsigMaestroModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAsigMaestro1(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private AsigMaestroModel MapToAsigMaestro1(SqlDataReader reader)
        {
            return new AsigMaestroModel()
            {

                AsgnId = (int)reader["AsgnId"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"]
            };
        }


        public async Task<bool> AsignarMaestro(AsigMaestro1Asignar value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("AsignarMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@MaestroId", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@ClaseId", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@HorarioId", value.IdHorario));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        /*ELIMINAR ASIGNACION MAESTRO*/
        public async Task<bool> EliminarAsignacionMaestro(int AsgnId)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarAsigMaestro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AsgMaestro", AsgnId));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        /*ACTUALIZAR ASIGNACION DE MAESTRO*/
        public async Task<bool> ActualizarAsigMaestro(int AsgnId, int IdMaestro, int IdClase, int IdHorario)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AsigMaestroUpdate", sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@AsgnId", AsgnId));
                    cmd.Parameters.Add(new SqlParameter("MaestroId", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@ClaseId", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@HorarioId", IdHorario));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }

        }
        #endregion "Seccion --------->Asignacion de maestro"

        #region "Seccion ---> Programa5s"

        public async Task<List<Programa5sModel>> GetPrograma5s()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerPrograma5s", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Programa5sModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToPrograma5s(reader));//2
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<List<Programa5ModelV1>> GetAllPrograma5sV1(string nameProducedure) {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(nameProducedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<Programa5ModelV1>(); 
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToPrograma5sById(reader));
                            }
                        }
                        return response;
                    }
                }
            }
            catch (Exception ex) {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }

        }

        private Programa5sModel MapToPrograma5s(SqlDataReader reader)
        {
            return new Programa5sModel()
            {

                Id = (int)reader["Id"],
                Area = (string)reader["Area"],
                Supervisor = (string)reader["Supervisor"],
                FechaAntes = (DateTime)reader["FechaAntes"],
                FechaInicio = (DateTime)reader["FechaInicio"],
                ImagenAntes = (string)reader["ImagenAntes"],
                ImagenDespues = (string)reader["ImagenDespues"],
                Detalles = (string)reader["Detalles"]
            };
        }
        public async Task<Programa5ModelV1> GetPrograma5sById(string nameProducedure, int IdPrograma)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(nameProducedure, sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdPrograma", IdPrograma));
                        Programa5ModelV1 response = null;
                        await sql.OpenAsync();

                        using(var reader= await cmd.ExecuteReaderAsync())
                        {
                            while(await reader.ReadAsync())
                            {
                                response = MapToPrograma5sById(reader);
                            }
                        }
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);
            }
        }

        public async Task<Programa5sIdModel> GetPrograma5sId(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDPrograma5s", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    Programa5sIdModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToPrograma5sId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private Programa5sIdModel MapToPrograma5sId(SqlDataReader reader)
        {
            return new Programa5sIdModel()
            {

                Id = (int)reader["Id"],
                Area = (string)reader["Area"],
                Supervisor = (string)reader["Supervisor"],
                FechaAntes = (DateTime)reader["FechaAntes"],
                FechaInicio = (DateTime)reader["FechaInicio"],
                ImagenAntes = (string)reader["ImagenAntes"],
                ImagenDespues = (string)reader["ImagenDespues"],
                Detalles = (string)reader["Detalles"]

            };
        }

        public async Task<bool> InsertarPrograma5sV1(string nameProducedure, Programa5ModelV1 entity)
        {

            bool respuestas = false;
            int valor_Retrono;
            try
            {
                using (SqlConnection sql = new SqlConnection(EMAIConnection))
                {
                    await sql.OpenAsync();

                    using (SqlTransaction trasaction = sql.BeginTransaction(System.Data.IsolationLevel.Serializable))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(nameProducedure, sql, trasaction))
                            {

                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add(new SqlParameter("@Area", entity.Area));
                                cmd.Parameters.Add(new SqlParameter("@Supervisor", entity.Supervisor));
                                cmd.Parameters.Add(new SqlParameter("@ImagenAntes", entity.ImagenAntes));
                                cmd.Parameters.Add(new SqlParameter("@FechaSubidaAntes", entity.FechaSubidaAntes));
                                cmd.Parameters.Add(new SqlParameter("@ImagenDespues", entity.ImagenDespues));
                                cmd.Parameters.Add(new SqlParameter("@FechaSubidaDespues", entity.@FechaSubidaDespues));
                                cmd.Parameters.Add(new SqlParameter("@Detalles", entity.Detalles));
                                
                                SqlParameter paramOut= new SqlParameter("@Resultado",SqlDbType.Int);
                                paramOut.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(paramOut);

                                await cmd.ExecuteNonQueryAsync();
                                valor_Retrono = (int)paramOut.Value;

                                if(valor_Retrono == 1)
                                {
                                    respuestas = true;
                                }
                                trasaction.Commit();
                            }
                        }
                        catch (Exception e)
                        {
                            trasaction.Rollback();
                            return respuestas = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Se presento problema Conexion de la Base de Datos", ex);

            }
            return respuestas;
        }

        public async Task<bool> InsertarPrograma5s(Programa5sInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarPrograma5s", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Area", value.Area));
                    cmd.Parameters.Add(new SqlParameter("@Supervisor", value.Supervisor));
                    cmd.Parameters.Add(new SqlParameter("@FechaAntes", value.FechaAntes));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", value.FechaInicio));
                    string imagenAntes = value.ImagenAntes.Replace("'", "''"); // Escapar comillas simples
                    cmd.Parameters.Add(new SqlParameter("@ImagenAntes", imagenAntes));
                    string imagenDespues = value.ImagenDespues.Replace("'", "''"); // Escapar comillas simples
                    cmd.Parameters.Add(new SqlParameter("@ImagenDespues", imagenDespues));
                    cmd.Parameters.Add(new SqlParameter("@Detalles", value.Detalles));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        private Programa5ModelV1 MapToPrograma5sById(SqlDataReader reader)
        {
            return new Programa5ModelV1()
            {

                Id = (int)reader["IdPrograma"],
                Area = (string)reader["Area"],
                Supervisor = (string)reader["Supervisor"],
                ImagenAntes = (string)reader["ImagenAntes"],
                FechaSubidaAntes = (DateTime)reader["FechaSubidaAntes"],
                ImagenDespues= (string)reader["ImagenDespues"],
                FechaSubidaDespues= (DateTime)reader["FechaSubidaAntes"],
                Detalles = (string)reader["Detalles"],
            };
        }

        public async Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarPrograma5s", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@Area", Area));
                    cmd.Parameters.Add(new SqlParameter("@Supervisor", Supervisor));
                    cmd.Parameters.Add(new SqlParameter("@FechaAntes", FechaAntes));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicio", FechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@Detalles", Detalles));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        #endregion

        #region "Seccion ---> ReposicionClase"
        public async Task<List<RepClaseModel>> GetRepClase()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerRepClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<RepClaseModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToRepClase(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private RepClaseModel MapToRepClase(SqlDataReader reader)
        {
            return new RepClaseModel()
            {

                IdRepClase = (int)reader["IdRepClase"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                IdMaestro = (int)reader["IdMaestro"],
                DiaRep = (string)reader["DiaRep"].ToString(),

            };
        }

        public async Task<RepClaseIDModel> GetRepClaseID(int IdRepClase)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RepClaseObtenerByID", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdRepClase", IdRepClase));
                    RepClaseIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToRepClaseId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private RepClaseIDModel MapToRepClaseId(SqlDataReader reader)
        {
            return new RepClaseIDModel()
            {

                IdRepClase = (int)reader["IdRepClase"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
                IdMaestro = (int)reader["IdMaestro"],
                DiaRep = (string)reader["DiaRep"].ToString(),

            };
        }

        public async Task<bool> InsertarRepClase(RepClaseInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarRepClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@DiaRep", value.DiaRep));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarRepClase(int IdRepClase, int IdClase, int IdMaestro, string DiaRep)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarRepClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdRepClase", IdRepClase));
                    //cmd.Parameters.Add(new SqlParameter("IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("IdMaestro", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@DiaRep", DiaRep));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        public async Task<bool> EliminarRepClase(int IdRepClase)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarRepClase", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("IdRepClase", IdRepClase));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
        #endregion

        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

   


























        #endregion



    }
}
