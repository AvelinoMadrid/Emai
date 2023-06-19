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
        public async Task<AlumnosbyIDModel> GetAlumnosbyID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ObtenerAlumnosCompleto", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", Id));
                    AlumnosbyIDModel response = null;//3
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MaptoAlumnosbyID(reader);//3
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
                NombrePapa = reader["NombrePapas"].ToString(),
                TelefonoPapa = reader["Celularpapas"].ToString(),
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



        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion

    }
}
