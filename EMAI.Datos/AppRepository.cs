using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using EMAI.Comun.DTOs;
//using EMAI.Comun.Models;
//using EMAI.Entiddes;

using System;
using System.Collections.Generic;
using EMAI.Servicios;
using EMAI.Helpers;
using EMAI.Comun.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Metrics;

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
            EMAIConnection = "Data Source=baseemai.cdljyong6xcl.us-east-1.rds.amazonaws.com;Initial Catalog=EMAI;TrustServerCertificate=True;User ID=admin;Password=admin007";
        }


        #region " Sección Alumnos --> "

        //MOSTAR TODO
        public async Task<List<AlumnosModel>> GetAlumnos()
        {
            using (SqlConnection  sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAlumnos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<AlumnosModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToAlumnos(reader));//2
                        }
                    }
                    return response;
                }
            }
        }

         
        private AlumnosModel MapToAlumnos(SqlDataReader reader)
        {
            return new AlumnosModel()
            {

                IdAlumno = (int)reader["IdAlumno"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"],
                Tag = reader["Tag"].ToString(),
                NoClasesDia = (int)reader["NoDiaClases"],
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"],
                FechaFinClaseGratis = (DateTime)reader["FechaFinClaseGratis"],
                Nombre = reader["Nombre"].ToString(),
                ApPaterno = reader["ApellidoP"].ToString(),
                ApMaterno = reader["ApellidoM"].ToString(),
                Edad = (int) reader["Edad"],
                FechaNacimiento = (DateTime) reader["FechaNacimiento"],
                Telefono = reader["TelCasa"].ToString(),
                Celular = reader["Celular"].ToString(),
                Facebook = reader["Facebook"].ToString(),
                Email = reader["E-mail"].ToString(),
                Enfermedades = reader["Enfermedades"].ToString(),
                Discapacidad = (bool)reader["Discapacidad"],
                InstrumentoBase = reader["InstrumentoBase"].ToString(),
                Dia = reader["Dia"].ToString(),
                Hora = reader["Hora"].ToString(),
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(),
                DiaOpcional = reader["DiaOpcio"].ToString(),
                HoraOpcional = reader["HoraOpcio"].ToString()
            };
        }

        // MOSTRAR POR ID AÑADIENDO LAS DEMAS TABLAS
        public async Task<ObtenerAlumno> GetAlumnosbyID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAlumnosCompleto", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", Id));
                    ObtenerAlumno response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToAlumnosTodo(reader);//3
                        }
                    }

                    return response;
                }
            }
        }


        private AlumnosbyIDModel MaptoAlumnosbyID (SqlDataReader reader)
        {
            return new AlumnosbyIDModel()
            {
                IdAlumno = (int)reader["IdAlumno"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"],
                Tag = reader["Tag"].ToString(),
                NoClasesDia = (int)reader["NoDiaClases"],
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"],
                FechaFinClaseGratis = (DateTime) reader ["FechaFinClaseGratis"],
                Nombre = reader["Nombre"].ToString(),
                ApPaterno = reader["ApellidoP"].ToString(), 
                ApMaterno = reader["ApellidoM"].ToString(),
                Edad = (int)reader["Edad"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                Telefono = reader["TelCasa"].ToString(),
                Celular = reader["Celular"].ToString(),
                Facebook = reader["Facebook"].ToString(),
                Email = reader["E-mail"].ToString(),
                Enfermedades = reader["Enfermedades"].ToString(),
                Discapacidad = (bool)reader["Discapacidad"],
                InstrumentoBase = reader["InstrumentoBase"].ToString(),
                Dia = reader["Dia"].ToString(),
                Hora = reader["Hora"].ToString(),
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(),
                DiaOpcional = reader["DiaOpcio"].ToString(),
                HoraOpcional = reader["HoraOpcio"].ToString(),

                // tabla papas
                NombrePapas = reader["NombrePapas"].ToString(),
                TelefonoPapa = reader["CelularPapas"].ToString(),
                FacebookPapa = reader["FacebookPapas"].ToString(),
                EmailPapa = reader["E-mail"].ToString(),
                TutorRecoger = reader["TutorRecoger"].ToString(),
                CelularTR = reader["CelularTR"].ToString(),
                NumEmergencia = reader["NumEmergencia"].ToString(),

                // tabla estudios
                Estudios = (bool)reader["Estudios"],
                GradoEstudios = reader["GradoEstudios"].ToString(),
                EscuelaActual = reader["EscuelaActual"].ToString(),
                Trabajo = (bool)reader["Trabajas"],
                LugarTrabajo = reader["LugarTrabajo"].ToString(),

                // tabla conocimientos actuales
                conActual = reader["ConActual"].ToString(),
                instrumentoMusical = reader["Instrumento"].ToString(),
                InstrumentoCasa = (bool)reader["InstrumentoCasa"],
                NoInstrumentoMusical = reader["NoInstrumento"].ToString(),
                EntersteEsc = reader["EnterasteEsc"].ToString(),
                interesGnroMusical = (bool)reader["InteresGnroMusical"],
                interesgros = reader["Cuales"].ToString(),
                interes = reader["Otro"].ToString(), // verificar en la base de daatos 
                classOpcional = (bool)reader["ClaOpcional"],
                Descuento = (bool)reader["DescuentoP"],
                amable = (bool)reader["Amable"],


                IDRecepcionista = (int)reader["Recepcionista"],
                NombreRecepcionista = reader["Nombre"].ToString()
            };
        }

        private ObtenerAlumno MapToAlumnosTodo (SqlDataReader reader)
        {

            return new ObtenerAlumno()
            {

                // TABLA DE ALUMNO
                IDAlumno = (int)reader["IdAlumno"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"],
                Tag = reader["Tag"].ToString(),
                NoDiaClases = (int)reader["NoDiaClases"],
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"],
                FechaFinClaseGratis = (DateTime)reader["FechaFinClaseGratis"],
                Nombre = reader["Nombre"].ToString(),
                ApellidoP = reader["ApellidoP"].ToString(),
                ApellidoM = reader["ApellidoM"].ToString(),
                Edad = (int)reader["Edad"],
                FechaNaciminto = (DateTime)reader["FechaNacimiento"],
                TelCasa = reader["TelCasa"].ToString(),
                Celular = reader["Celular"].ToString(),
                Facebook = reader["Facebook"].ToString(),
                Email = reader["E-mail"].ToString(),
                Enfermedades = reader["Enfermedades"].ToString(),
                Discapacidad = (bool)reader["Discapacidad"],
                Instrumentobase = reader["InstrumentoBase"].ToString(),
                Dia = reader["Dia"].ToString(), 
                Hora = reader["Hora"].ToString(), 
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(), 
                DiaOpcional = reader["DiaOpcio"].ToString(), 
                HoraOpcional = reader["HoraOpcio"].ToString(),

                // TABLA PAPAS 
                NombrePapas = reader["NombrePapas"].ToString(), 
                CelularPapas = reader["CelularPapas"].ToString(), 
                FacebookPaps = reader["FacebookPapas"].ToString(), 
                EmailPapas = reader["E-mail"].ToString(), 
                TutorRecoger = reader["TutorRecoger"].ToString(),
                CelularTR = reader["CelularTR]"].ToString(),
                NumeroEmergencia = reader["NumEmergencia"].ToString(), 

                // TABLA ESTUDIOS 
                Estudios = (bool) reader["Estudios"], 
                GradoEstudios = reader["GradoEstudios"].ToString(),
                EscuelaActual = reader["EscuelaActual"].ToString(), 
                Trabajas = (bool)reader["Trabajas"], 
                LugarTrabajo = reader["LugarTrabajo"].ToString(), 

                // TABLA CONOCIMIENTOS 
                ConActual = reader["ConActual"].ToString(), 
                Instrumento = reader["Instrumento"].ToString(), 
                InstrumentoCasa = (bool)reader["InstrumentoCasa"], 
                NoInstrumento = reader["InstrumentoCasa"].ToString(), 
                EnterasteESc = reader["EnterasteEsc"].ToString(), 
                InteresGroMusical = (bool)reader["InteresGnroMusical"], 
                Cuales = reader["Cuales"].ToString(), 

                // TABLA INTEREES 
                Otro = reader["Otro"].ToString(),

                // TABLA PERSONAL
                ClasOpcional = (bool)reader["ClasOpcional"],
                Descuento = (bool)reader["DescuentoP"],
                Amable = (bool)reader["Amable"],

                // TABLA RECEPCIONISTA
                NombreRecepcionista = reader["Nombre"].ToString()
                
            };
        }


        // insert Alumno 

        public async Task<bool> InsertarAlumno(InsertAlumnoModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_usp_AlumnoInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@FechaInscripcion", value.FechaInscripcion));
                    cmd.Parameters.Add(new SqlParameter("@Tag", value.Tag));
                    cmd.Parameters.Add(new SqlParameter("@NoDiaClases", value.NoDiaClases));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicioClaseGratis", value.FechaInicioClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@FechaFinClaseGratis", value.FechaFinClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", value.Nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoP", value.ApPaterno));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoM", value.ApMaterno));
                    cmd.Parameters.Add(new SqlParameter("@Edad", value.Edad));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", value.FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", value.TelefonoCasa));
                    cmd.Parameters.Add(new SqlParameter("@Celular", value.Celular));
                    cmd.Parameters.Add(new SqlParameter("@Facebook", value.Facebook));
                    cmd.Parameters.Add(new SqlParameter("@EmailAluno", value.Email));
                    cmd.Parameters.Add(new SqlParameter("@Enfermedades", value.Enfermedades));
                    cmd.Parameters.Add(new SqlParameter("@Discapacidad", value.Discapacidad));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoBase", value.InstrumentoBase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoOpcional", value.InstrumentoOpcional));
                    cmd.Parameters.Add(new SqlParameter("@DiaOpcional", value.DiaOpcio));
                    cmd.Parameters.Add(new SqlParameter("@HoraDiaOpcional", value.HoraOpcio));

                    // para tabla papas
                    cmd.Parameters.Add(new SqlParameter("@NombrePapas",value.NombrePapa));
                    cmd.Parameters.Add(new SqlParameter("@CelularPapas", value.CelularPapas));
                    cmd.Parameters.Add(new SqlParameter("@FacebookPapas", value.FacebookPapas));
                    cmd.Parameters.Add(new SqlParameter("@EmailPapas", value.EmailPapas));
                    cmd.Parameters.Add(new SqlParameter("@TutorRecoger", value.TutorRecoger));
                    cmd.Parameters.Add(new SqlParameter("@CelularTR", value.CelularTR));
                    cmd.Parameters.Add(new SqlParameter("@NumEmergencia", value.NumEmergencia));

                    // Tabla Estudios

                    cmd.Parameters.Add(new SqlParameter("@Estudios", value.Estudios));
                    cmd.Parameters.Add(new SqlParameter("@GradoEstudios", value.GradoEstudios));
                    cmd.Parameters.Add(new SqlParameter("@EscuelaActuales", value.EscuelaActuales));
                    cmd.Parameters.Add(new SqlParameter("@Trabajas", value.Trabajas));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajo",value.LugarTrabajo));

                    // conocimientos Actuales
                    cmd.Parameters.Add(new SqlParameter("@ConActual",value.ConActual));
                    cmd.Parameters.Add(new SqlParameter("@Instrumento", value.Instrumento));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoCasa", value.InstrumentoCasa));
                    cmd.Parameters.Add(new SqlParameter("@NoInstrumento", value.NoInstrumento));
                    cmd.Parameters.Add(new SqlParameter("@EnterasteEsc", value.EnterasteEscuela));
                    cmd.Parameters.Add(new SqlParameter("@InteresGnroMusical", value.InteresGnroMusical));
                    cmd.Parameters.Add(new SqlParameter("@Cuales", value.Cuales));

                    // tabla interes 
                    cmd.Parameters.Add(new SqlParameter("@Otro", value.Otro));

                    // Tabla personal 
                    cmd.Parameters.Add(new SqlParameter("@ClaseOpcional", value.ClaseOpcional));
                    cmd.Parameters.Add(new SqlParameter("@DescuentoP",value.DescuentoP));
                    cmd.Parameters.Add(new SqlParameter("@Amables", value.amable));

                    // tabla rececpcionista
                    cmd.Parameters.Add(new SqlParameter("@NombreRecepcionista", value.NombreRecepcionista));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        // eliminar Alumno 

        public async Task<bool> DeleteByIdAlumno(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnosEliminar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDAlumnos", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }


        // Actualizar Alumno 

        public async Task<bool> UpdateAlumnos(int IdAlumno, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM, int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia, string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnosActualizar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("Tag", Tag));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicioClaseGratis", FechaFinClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@FechaFinClaseGratis", FechaFinClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoP", ApellidoP));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoM", ApellidoM));
                    cmd.Parameters.Add(new SqlParameter("@Edad", Edad));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", FechaNacimiento));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", TelefonoCasa));
                    cmd.Parameters.Add(new SqlParameter("@Celular", Celular));
                    cmd.Parameters.Add(new SqlParameter("@Facebook", Facebook));
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cmd.Parameters.Add(new SqlParameter("@Enfermedades", Enfermedades));
                    cmd.Parameters.Add(new SqlParameter("@Discapacidad", Discapacidad));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoBase", InstrumentoBase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    cmd.Parameters.Add(new SqlParameter("@Hora", Hora));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoOpcional", InstrumentoOpcional));
                    cmd.Parameters.Add(new SqlParameter("@DiaOpcional", DiaOpcional));
                    cmd.Parameters.Add(new SqlParameter("@HoraOpcional", HoraOpcional));

                    // tabla Papas

                    cmd.Parameters.Add(new SqlParameter("@CelularPapas", CelularPapas));
                    cmd.Parameters.Add(new SqlParameter("@EmailPapas", EmailPapas));
                    cmd.Parameters.Add(new SqlParameter("@RecogerPapas", RecogerPapas));
                    cmd.Parameters.Add(new SqlParameter("@CelularTR", CelularTR));
                    cmd.Parameters.Add(new SqlParameter("@NumEmergencia", NumEmergencia));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
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

        private ClasesModel MapToClases(SqlDataReader reader)
        {
            return new ClasesModel()
            {

                idClase = (int)reader["IdClase"],
                Nombre = (string)reader["Nombre"],
                CNormal = (string)reader["CNormal"],
                CVerano = (string)reader["CVerano"],
                Dia = (string)reader["Dia"],
                Horario = (string)reader["Horario"],
                Dia2 = (string)reader["Dia2"],
                Horario2 = (string)reader["Horario2"],
                Dia3 = (string)reader["Dia3"],
                Horario3 = (string)reader["Horario3"],
                Costo = (decimal)reader["Costo"],
                ClaseOpc = (string)reader["ClaseOpc"].ToString(),
                HorarioOpc = (string)reader["HorarioOpc"].ToString(),
                DiaOpc = (string)reader["DiaOpc"].ToString(),

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

                IdClase = (int)reader["IdClase"],
                Nombre = (string)reader["Nombre"],
                CNormal = (string)reader["CNormal"],
                CVerano = (string)reader["CVerano"],
                Dia = (string)reader["Dia"],
                Horario = (string)reader["Horario"],
                Dia2 = (string)reader["Dia2"],
                Horario2 = (string)reader["Horario2"],
                Dia3 = (string)reader["Dia3"],
                Horario3 = (string)reader["Horario3"],
                Costo = (decimal)reader["Costo"],
                ClaseOpc = (string)reader["ClaseOpc"].ToString(),
                HorarioOpc = (string)reader["HorarioOpc"].ToString(),
                DiaOpc = (string)reader["DiaOpc"].ToString(),

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
                    cmd.Parameters.Add(new SqlParameter("@Horario", value.Horario));
                    cmd.Parameters.Add(new SqlParameter("@Dia2", value.Dia2));
                    cmd.Parameters.Add(new SqlParameter("@Horario2", value.Horario2));
                    cmd.Parameters.Add(new SqlParameter("@Dia3", value.Dia3));
                    cmd.Parameters.Add(new SqlParameter("@Horario3", value.Horario3));
                    cmd.Parameters.Add(new SqlParameter("@Costo", value.Costo));
                    cmd.Parameters.Add(new SqlParameter("@ClaseOpc", value.ClaseOpc));
                    cmd.Parameters.Add(new SqlParameter("@HorarioOpc", value.HorarioOpc));
                    cmd.Parameters.Add(new SqlParameter("@DiaOpc", value.DiaOpc));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Horario, string Dia2, string Horario2, string Dia3, string Horario3, decimal Costo, string ClaseOpc, string HorarioOpc, string DiaOpc)
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
                    cmd.Parameters.Add(new SqlParameter("@Horario", Horario));
                    cmd.Parameters.Add(new SqlParameter("@Dia2", Dia2));
                    cmd.Parameters.Add(new SqlParameter("@Horario2", Horario2));
                    cmd.Parameters.Add(new SqlParameter("@Dia3", Dia3));
                    cmd.Parameters.Add(new SqlParameter("@Horario3", Horario3));
                    cmd.Parameters.Add(new SqlParameter("@Costo", Costo));
                    cmd.Parameters.Add(new SqlParameter("@ClaseOpc", ClaseOpc));
                    cmd.Parameters.Add(new SqlParameter("@HorarioOpc", HorarioOpc));
                    cmd.Parameters.Add(new SqlParameter("@DiaOpc", DiaOpc));

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
                Descripcion = reader["Descripcion"].ToString(), 
                Cantidad = (decimal)reader["Cantidad"], 
                SubTotal = (decimal)reader["SubTotal"], 
                Total = (decimal)reader["Total"]
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.SubTotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

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


        public async Task<bool> UpdateCooperaciones(int id, DateTime Fecha, string NoPedido, string Proveedor, string Descripcion, decimal cantidad, decimal Subtotal, decimal Total)
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));
                    
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

                IdColegiatura = (int)reader["IdColegiatura"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedido = (string)reader["NoPedido"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                Subtotal = (decimal)reader["Subtotal"],
                Total = (decimal)reader["Total"]
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

                IdColegiatura = (int)reader["IdColegiatura"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedido = (string)reader["NoPedido"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                Subtotal = (decimal)reader["Subtotal"],
                Total = (decimal)reader["Total"]
            };
        }

        public async Task<bool> InsertarColegiatura(ColegiaturaInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", value.NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarColegiatura(int IdColegiatura, DateTime Fecha, string NoPedido, string Descripcion, decimal Cantidad, decimal Subtotal, decimal Total)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarColegiatura", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", IdColegiatura));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedido", NoPedido));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));


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
                Subtotal = (decimal) reader["Subtotal"], 
                Total = (decimal)reader["Total"]
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
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateDotacionDia(int id, DateTime fecha, string NoPedido, string Descripcion, decimal cantidad, decimal subtotal, decimal Total)
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
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));

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
                IdColegiatura = (int)reader["IdColegiatura"],
                IdCooperaciones = (int)reader["IdCooperaciones"],
                IdDotacion = (int)reader["IdDotacion"],
                IdGastosDia = (int)reader["IdGastosDia"],
                IdNomina = (int)reader["IdNomina"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedidoE_S = (string)reader["NoPedidoE_S"],
                Proveedor = (string)reader["Proveedor"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
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
                IdColegiatura = (int)reader["IdColegiatura"],
                IdCooperaciones = (int)reader["IdCooperaciones"],
                IdDotacion = (int)reader["IdDotacion"],
                IdGastosDia = (int)reader["IdGastosDia"],
                IdNomina = (int)reader["IdNomina"],
                Fecha = (DateTime)reader["Fecha"],
                NoPedidoE_S = (string)reader["NoPedidoE_S"],
                Proveedor = (string)reader["Proveedor"],
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
            };
        }

        public async Task<bool> InsertarGastos(GastosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarGasto", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", value.IdColegiatura));
                    cmd.Parameters.Add(new SqlParameter("@IdCooperaciones", value.IdCooperaciones));
                    cmd.Parameters.Add(new SqlParameter("@IdDotacion", value.IdDotacion));
                    cmd.Parameters.Add(new SqlParameter("@IdGastosDia", value.IdGastosDia));
                    cmd.Parameters.Add(new SqlParameter("@IdNomina", value.IdNomina));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedidoE_S", value.NoPedidoE_S));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", value.Proveedor));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarGastos(int IdGasto, int IdCooperaciones, int IdDotacion, int IdGastosDia, int IdNomina, DateTime Fecha, string NoPedidoE_S,
          string Proveedor, string Descripcion, decimal Cantidad)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarGastos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdGasto", IdGasto));
                    cmd.Parameters.Add(new SqlParameter("@IdColegiatura", IdCooperaciones));
                    cmd.Parameters.Add(new SqlParameter("@IdCooperaciones", IdDotacion));
                    cmd.Parameters.Add(new SqlParameter("@IdDotacion", IdGastosDia));
                    cmd.Parameters.Add(new SqlParameter("@IdGastosDia", IdNomina));
                    cmd.Parameters.Add(new SqlParameter("@IdNomina", IdNomina));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@NoPedidoE_S", NoPedidoE_S));
                    cmd.Parameters.Add(new SqlParameter("@Proveedor", Proveedor));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
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
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                Subtotal = (decimal)reader["Subtotal"],
                Total = (decimal)reader["Total"],
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
                Descripcion = (string)reader["Descripcion"],
                Cantidad = (decimal)reader["Cantidad"],
                Subtotal = (decimal)reader["Subtotal"],
                Total = (decimal)reader["Total"],
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarGastosDia(int IdGastoDia, DateTime Fecha, string NoPedido, string Proveedro, string Descripcion,
            decimal Cantidad, decimal Subtotal, decimal Total)
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));

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
                IdAlumno = (int)reader["IdAlumno"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                Dia = (string)reader["Dia"],
                Fecha = (DateTime)reader["Fecha"],

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

                IdHorario = (int)reader["IdMaestro"],
                IdAlumno = (int)reader["IdAlumno"],
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                Dia = (string)reader["Dia"],
                Fecha = (DateTime)reader["Fecha"],

            };
        }

        public async Task<bool> InsertarHorario(HorariosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarHorario(int IdHorario, int IdAlumno, int IdMaestro, int IdClase, string Dia, DateTime Fecha)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));

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
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                IdAlumno = (int)reader["IdAlumno"],
                Status = (bool)reader["Status"],
                Base = (bool)reader["Base"],
                Suplente = (string)reader["Suplente"].ToString(),
                Pago = (decimal)reader["Pago"],

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
                IdClase = (int)reader["IdClase"],
                IdHorario = (int)reader["IdHorario"],
                IdAlumno = (int)reader["IdAlumno"],
                Status = (bool)reader["Status"],
                Base = (bool)reader["Base"],
                Suplente = (string)reader["Suplente"],
                Pago = (decimal)reader["Pago"],

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
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", value.IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@Status", value.Status));
                    cmd.Parameters.Add(new SqlParameter("@Base", value.Base));
                    cmd.Parameters.Add(new SqlParameter("@Suplente", value.Suplente));
                    cmd.Parameters.Add(new SqlParameter("@Pago", value.Pago));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, int IdClase, int IdHorario, int IdAlumno, bool Status, bool Base, string Suplente, decimal Pago)
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
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@Status", Status));
                    cmd.Parameters.Add(new SqlParameter("@Base", Base));
                    cmd.Parameters.Add(new SqlParameter("@Suplente", Suplente));
                    cmd.Parameters.Add(new SqlParameter("@Pago", Pago));

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
                Descripcion = reader["Descripcion"].ToString(),
                Cantidad = (decimal)reader["Cantidad"], 
                Subtotal = (decimal)reader["Subtotal"], 
                Total = (decimal)reader["Total"]
               
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", value.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", value.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.SubTotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        // ACTUALIZAR 

        public async Task<bool> ActualizarNomina(int IdNomina, DateTime Fecha, string NoPedido, string Proveedor, string Descripcion, decimal Cantidad, decimal Subtotal, decimal Total)
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
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@Total", Total));
              
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
        public async Task<List<PromosionesModel>> GetPromosiones()
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerPromosiones", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<PromosionesModel>(); //1
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToPromosiones(reader));//2
                        }
                    }

                    return response;
                }
            }
        }

        private PromosionesModel MapToPromosiones(SqlDataReader reader)
        {
            return new PromosionesModel()
            {

                IdPromosion = (int)reader["IdPromosion"],
                IdAlumno = (int)reader["IdAlumno"],
                Porcentaje = (int)reader["Porcentaje"],
                Fecha = (DateTime)reader["Fecha"],
            };
        }

        public async Task<PromosionesIDModel> GetPromosionesID(int IdColegiatura)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("BuscarPorIDPromosiones", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPromosiones", IdColegiatura));
                    PromosionesIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToPromosionesId(reader);//3
                        }
                    }

                    return response;
                }
            }
        }

        private PromosionesIDModel MapToPromosionesId(SqlDataReader reader)
        {
            return new PromosionesIDModel()
            {

                IdPromosion = (int)reader["IdPromosion"],
                IdAlumno = (int)reader["IdAlumno"],
                Porcentaje = (int)reader["Porcentaje"],
                Fecha = (DateTime)reader["Fecha"],
            };
        }

        public async Task<bool> InsertarPromosiones(PromosionesInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarPromosiones", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@Porcentaje", value.Porcentaje));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarPromosiones", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPromosion", IdPromosion));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@Porcentaje", Porcentaje));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> EliminarPromosiones(int IdPromosion)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarPromosiones", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPromosion", IdPromosion));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
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
                Email = (string)reader["Email"],
                Direccion = (string)reader["Direccion"],
                Telefono = (string)reader["Telefono"],
            };
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
                IdPromosiones = (int)reader["IdPromosiones"],
                IdAdicionales = (int)reader["IdAdicionales"],
                Fecha = (DateTime)reader["Fecha"],
                Folio = (string)reader["Folio"],
                FechaPago = (DateTime)reader["FechaPago"],
                SaldoPendiente = (decimal)reader["SaldoPendiente"],
                Mes = (string)reader["Mes"],
                IdHorario = (int)reader["IdHorario"],
                Dia = (string)reader["Dia"],
                IdClase = (int)reader["IdClase"],
                IdRecepcionista = (int)reader["IdRecepcionista"],
                Costo = (decimal)reader["Costo"],
                Autorizacion = (string)reader["Autorizacion"],
                Subtotal = (decimal)reader["Subtotal"],
                Iva = (decimal)reader["IVA"],
                Total = (decimal)reader["Total"],

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
                IdPromosiones = (int)reader["IdPromosiones"],
                IdAdicionales = (int)reader["IdAdicionales"],
                Fecha = (DateTime)reader["Fecha"],
                Folio = (string)reader["Folio"],
                FechaPago = (DateTime)reader["FechaPago"],
                SaldoPendiente = (decimal)reader["SaldoPendiente"],
                Mes = (string)reader["Mes"],
                IdHorario = (int)reader["IdHorario"],
                Dia = (string)reader["Dia"],
                IdClase = (int)reader["IdClase"],
                IdRecepcionista = (int)reader["IdRecepcionista"],
                Costo = (decimal)reader["Costo"],
                Autorizacion = (string)reader["Autorizacion"],
                Subtotal = (decimal)reader["Subtotal"],
                Iva = (decimal)reader["IVA"],
                Total = (decimal)reader["Total"],
            };
        }

        public async Task<bool> InsertarPagos(PagosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarPago", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdPromosiones", value.IdPromosiones));
                    cmd.Parameters.Add(new SqlParameter("@IdAdicionales", value.IdAdicionales));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@Folio", value.Folio));
                    cmd.Parameters.Add(new SqlParameter("@FechaPago", value.FechaPago));
                    cmd.Parameters.Add(new SqlParameter("@SaldoPendiente", value.SaldoPendiente));
                    cmd.Parameters.Add(new SqlParameter("@Mes", value.Mes));
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", value.IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@IdRecepcionista", value.IdRecepcionista));
                    cmd.Parameters.Add(new SqlParameter("@Costo", value.Costo));
                    cmd.Parameters.Add(new SqlParameter("@Autorizacion", value.Autorizacion));
                    cmd.Parameters.Add(new SqlParameter("@Subtotal", value.Subtotal));
                    cmd.Parameters.Add(new SqlParameter("@IVA", value.Iva));
                    cmd.Parameters.Add(new SqlParameter("@Total", value.Total));

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

        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion

    }
}
