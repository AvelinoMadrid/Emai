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
            //EMAIConnection = "Data Source=baseemai.cdljyong6xcl.us-east-1.rds.amazonaws.com;Initial Catalog=EMAI;TrustServerCertificate=True;User ID=admin;Password=admin007";
            EMAIConnection = "Data Source=DESKTOP-6HI2H4T;Initial Catalog=EMAI;Integrated Security=True;TrustServerCertificate=True;";
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
                //IdClase = (int)reader["IdClase"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"],
                Tag = reader["Tag"].ToString(),
                NoClasesDia = (int)reader["NoDiaClases"],
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"],
                //FechaFinClaseGratis = (DateTime)reader["FechaFinClaseGratis"],
                Nombre = reader["Nombre"].ToString(),
                //ApPaterno = reader["ApellidoP"].ToString(),
                //ApMaterno = reader["ApellidoM"].ToString(),
                Edad = (int) reader["Edad"],
                FechaNacimiento = (DateTime) reader["FechaNacimiento"],
                Telefono = reader["TelCasa"].ToString(),
                Celular = reader["Celular"].ToString(),
                Facebook = reader["Facebook"].ToString(),
                Email = reader["E-mail"].ToString(),
                Enfermedades = reader["Enfermedades"].ToString(),
                //Discapacidad = reader["Discapacidad"] == DBNull.Value ? false : (bool)reader["Discapacidad"],
                InstrumentoBase = reader["InstrumentoBase"].ToString(),
                Diayhora = reader["Dia"].ToString(),
                //Hora = reader["Hora"].ToString(),
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(),
                DiaOpcional = reader["DiaOpcio"].ToString(),
                //HoraOpcional = reader["HoraOpcio"].ToString(),

                // tabla papas
                //IdPapas = (int)reader["IdPapas"],
                NombrePapa = reader["NombrePapas"].ToString(),
                TelefonoPapa = reader["CelularPapas"].ToString(),
                FacebookPapa = reader["FacebookPapas"].ToString(),
                Emailpapas = reader["E-mail"].ToString(),
                TutorRecoger = reader["TutorRecoger"].ToString(),
                CelularTR = reader["CelularTR"].ToString(),
                NumEmergencia = reader["NumEmergencia"].ToString(),

                // tabla estudios
                //IdEstudios = (int)reader["IdEstudio"],
                Estudios = reader["Estudios"] == DBNull.Value ? false : (bool)reader["Estudios"],
                GradoEstudios = reader["GradoEstudios"].ToString(),
                EscuelaActual = reader["EscuelaActual"].ToString(),
                Trabajo = reader["Trabajas"] == DBNull.Value ? false : (bool)reader["Trabajas"],
                LugarTrabajo = reader["LugarTrabajo"].ToString(),

                // tabla conocimientos actuales
                //IdConocimientoMusicales = (int)reader["ID"],
                conActual = reader["ConActual"].ToString(),
                instrumentoMusical = reader["Instrumento"].ToString(),
                InstrumentoCasa = reader["InstrumentoCasa"] == DBNull.Value ? false : (bool)reader["Estudios"],
                NoInstrumentoMusical = reader["NoInstrumento"].ToString(),
                EntersteEsc = reader["EnterasteEsc"].ToString(),
                interesGnroMusical = reader["InteresGnroMusical"] == DBNull.Value ? false : (bool)reader["Estudios"],
                interesgros = reader["Cuales"].ToString(),
                interes = reader["Otro"].ToString(), // verificar en la base de daatos 
                classOpcional = reader["ClasOpcional"] == DBNull.Value ? false : (bool)reader["Estudios"],
                Descuento = reader["DescuentoP"] == DBNull.Value ? false : (bool)reader["Estudios"],
                Amable = reader["Amable"] == DBNull.Value ? false : (bool)reader["Estudios"],

                //IdInteresInstrumento = (int)reader["IDInteres"], //
                //otro = reader["Otro"].ToString(),
                //Idpersonal = (int)reader["IDPersonal"],


                //IDRecepcionista = (int)reader["IdRecepcionista"],
                //NombreRecepcionista = reader["NombreRecepcionista"].ToString(); nora no modificar en el proyecto de angel
                NombreRecepcionista = reader["Nombre"].ToString()

            };
        }

        // MOSTRAR POR ID AÑADIENDO LAS DEMAS TABLAS
        public async Task<ObtenerAlumno> GetAlumnosbyID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerAlumnoPorId", sql))
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


        // mostrar usando inner join 

        // MOSTRAR POR ID AÑADIENDO LAS DEMAS TABLAS
        public async Task<AlumnosbyIDModel> ObtenerAlumnosporID(int Id)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerAlumnoPorId", sql))
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
                IdClase = (int)reader["IdClase"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"],
                Tag = reader["Tag"].ToString(),
                NoClasesDia = (int)reader["NoDiaClases"],
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"],
                //FechaFinClaseGratis = (DateTime)reader["FechaFinClaseGratis"],
                Nombre = reader["Nombre"].ToString(),
                //ApPaterno = reader["ApellidoP"].ToString(),
                //ApMaterno = reader["ApellidoM"].ToString(),
                Edad = (int)reader["Edad"],
                FechaNacimiento = (DateTime)reader["FechaNacimiento"],
                Telefono = reader["TelCasa"].ToString(),
                Celular = reader["Celular"].ToString(),
                Facebook = reader["Facebook"].ToString(),
                Email = reader["E-mail"].ToString(),
                Enfermedades = reader["Enfermedades"].ToString(),
                //Discapacidad = (bool)reader["Discapacidad"],
                InstrumentoBase = reader["InstrumentoBase"].ToString(),
                Diayhora = reader["Dia"].ToString(),
                //Hora = reader["Hora"].ToString(),
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(),
                DiaOpcional = reader["DiaOpcio"].ToString(),
                //HoraOpcional = reader["HoraOpcio"].ToString(),
                Img = reader["Imagen"].ToString(),


                // tabla papas
                IdPapas = (int)reader["IdPapas"],
                NombrePapas = reader["NombrePapas"].ToString(),
                TelefonoPapa = reader["CelularPapas"].ToString(),
                FacebookPapa = reader["FacebookPapas"].ToString(),
                EmailPapa = reader["E-mail"].ToString(),
                TutorRecoger = reader["TutorRecoger"].ToString(),
                CelularTR = reader["CelularTR"].ToString(),
                NumEmergencia = reader["NumEmergencia"].ToString(),

                // tabla estudios
                IdEstudios = (int)reader["IdEstudio"],
                Estudios = (bool)reader["Estudios"],
                GradoEstudios = reader["GradoEstudios"].ToString(),
                EscuelaActual = reader["EscuelaActual"].ToString(),
                Trabajo = (bool)reader["Trabajas"],
                LugarTrabajo = reader["LugarTrabajo"].ToString(),

                // tabla conocimientos actuales
                IdConocimientoMusicales = (int)reader["ID"],
                conActual = reader["ConActual"].ToString(),
                instrumentoMusical = reader["Instrumento"].ToString(),
                InstrumentoCasa = (bool)reader["InstrumentoCasa"],
                NoInstrumentoMusical = reader["NoInstrumento"].ToString(),
                EntersteEsc = reader["EnterasteEsc"].ToString(),
                interesGnroMusical = (bool)reader["InteresGnroMusical"],
                interesgros = reader["Cuales"].ToString(),
                interes = reader["Otro"].ToString(), // verificar en la base de daatos 
                classOpcional = (bool)reader["ClasOpcional"],
                Descuento = (bool)reader["DescuentoP"],
                amable = (bool)reader["Amable"],
               
                IdInteresInstrumento = (int)reader["IDInteres"], //
                otro = reader["Otro"].ToString(),
                Idpersonal = (int)reader["IDPersonal"],


                IDRecepcionista = (int)reader["IdRecepcionista"],
                NombreRecepcionista = reader["NombreRecepcionista"].ToString()
            };
        }

        private ObtenerAlumno MapToAlumnosTodo (SqlDataReader reader)
        {

            return new ObtenerAlumno()
            {

                // TABLA DE ALUMNO
                IDAlumno = (int)reader["IdAlumno"], //1
                IdClase = (int)reader["IdClase"],
                FechaInscripcion = (DateTime)reader["FechaInscripcion"], //2
                Tag = reader["Tag"].ToString(), //3
                NoDiaClases = (int)reader["NoDiaClases"], //4
                FechaInicioClaseGratis = (DateTime)reader["FechaInicioClaseGratis"], //5
                FechaFinClaseGratis = (DateTime)reader["FechaFinClaseGratis"], //6
                Nombre = reader["Nombre"].ToString(),//7
                ApellidoP = reader["ApellidoP"].ToString(), //8
                ApellidoM = reader["ApellidoM"].ToString(), //9
                Edad = (int)reader["Edad"], //10
                FechaNaciminto = (DateTime)reader["FechaNacimiento"], //11
                TelCasa = reader["TelCasa"].ToString(), //12
                Celular = reader["Celular"].ToString(), //13
                Facebook = reader["Facebook"].ToString(), //14
                Email = reader["E-mail"].ToString(), //15
                Enfermedades = reader["Enfermedades"].ToString(), //16
                Discapacidad = (bool)reader["Discapacidad"], //17
                Instrumentobase = reader["InstrumentoBase"].ToString(), //18
                Dia = reader["Dia"].ToString(), //19
                Hora = reader["Hora"].ToString(), //30
                InstrumentoOpcional = reader["InstrumentoOpcio"].ToString(), //21
                DiaOpcional = reader["DiaOpcio"].ToString(), //22
                HoraOpcional = reader["HoraOpcio"].ToString(), //23

                // TABLA PAPAS 

                NombrePapas = reader["NombrePapas"].ToString(), //24
                CelularPapas = reader["CelularPapas"].ToString(), //25
                FacebookPaps = reader["FacebookPapas"].ToString(), //26
                EmailPapas = reader["E-mail"].ToString(), //27
                TutorRecoger = reader["TutorRecoger"].ToString(), //28
                CelularTR = reader["CelularTR]"].ToString(),//29
                NumeroEmergencia = reader["NumEmergencia"].ToString(), //30  

                // TABLA ESTUDIOS 
                Estudios = (bool) reader["Estudios"], //31
                GradoEstudios = reader["GradoEstudios"].ToString(), //32
                EscuelaActual = reader["EscuelaActual"].ToString(), //33
                Trabajas = (bool)reader["Trabajas"], //34
                LugarTrabajo = reader["LugarTrabajo"].ToString(), //35  

                // TABLA CONOCIMIENTOS 
                ConActual = reader["ConActual"].ToString(), //36
                Instrumento = reader["Instrumento"].ToString(), //37
                InstrumentoCasa = (bool)reader["InstrumentoCasa"], //38
                NoInstrumento = reader["InstrumentoCasa"].ToString(), //39
                EnterasteESc = reader["EnterasteEsc"].ToString(), //40
                InteresGroMusical = (bool)reader["InteresGnroMusical"], //41 
                Cuales = reader["Cuales"].ToString(), //42 

                // TABLA INTEREES 
                Otro = reader["Otro"].ToString(), //43

                // TABLA PERSONAL
                ClasOpcional = (bool)reader["ClasOpcional"], //44
                Descuento = (bool)reader["DescuentoP"], //45
                Amable = (bool)reader["Amable"], //46

                // TABLA RECEPCIONISTA
                NombreRecepcionista = reader["Nombre"].ToString()  //47
                
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
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
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

        public async Task<bool> UpdateAlumnos(int IdAlumno,int IdClase, string Tag, int NoDiaClases, DateTime FechaInicioClaseGratis, DateTime FechaFinClaseGratis, string Nombre, string ApellidoP, string ApellidoM, int Edad, DateTime FechaNacimiento, string TelefonoCasa, string Celular, string Facebook, string Email, string Enfermedades, bool Discapacidad, string InstrumentoBase, string Dia, string Hora, string InstrumentoOpcional, string DiaOpcional, string HoraOpcional, string CelularPapas, string EmailPapas, string RecogerPapas, string CelularTR, string NumEmergencia)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnosActualizar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
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

        // nuevos requirimientos 

        // insert Alumno 

        public async Task<bool> InsertarAlumnosParteI(AlumnosNuevo value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AlumnoInsertarI", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@FechaInscripcion",value.FechaInsctipcion ));
                    cmd.Parameters.Add(new SqlParameter("@Tag", value.Tag));
                    cmd.Parameters.Add(new SqlParameter("@NoDiaClases", value.Dias));
                    cmd.Parameters.Add(new SqlParameter("@FechaInicioClaseGratis", value.FechaInicioClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@FechaFinClaseGratis", value.FechaFinClaseGratis));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoBase", value.InstrumentoBase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@Hora", value.Hora));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoOpcional", value.InstrumentoOpcional));
                    cmd.Parameters.Add(new SqlParameter("@DiaOpcional", value.DiaOpcional));
                    cmd.Parameters.Add(new SqlParameter("@HoraOpcional", value.HoraOpcional));
                    cmd.Parameters.Add(new SqlParameter("@NombreCompleto", value.NombreCompleto));
                    cmd.Parameters.Add(new SqlParameter("@Edad", value.Edad));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento",value.FechaNacimientoAlumno));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", value.TelefonoCasa));
                    cmd.Parameters.Add(new SqlParameter("@Celular", value.Celular));
                    cmd.Parameters.Add(new SqlParameter("@Facebook", value.Facebook));
                    cmd.Parameters.Add(new SqlParameter("@Email", value.Email));
                    cmd.Parameters.Add(new SqlParameter("@Enfermedades", value.Enfermedades));
                   

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }



        public async Task<bool> InsertarPapas(PapasNuevo value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PapasInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@Nombrepapa", value.NombrePapa));
                    cmd.Parameters.Add(new SqlParameter("@Celular", value.CelularPapa));
                    cmd.Parameters.Add(new SqlParameter("@FacebookPapa", value.FacebookPapas));
                    cmd.Parameters.Add(new SqlParameter("@Email", value.Email));
                    cmd.Parameters.Add(new SqlParameter("@NombredelTutorRecoger", value.NombreTutorRecoger));
                    cmd.Parameters.Add(new SqlParameter("@CelularTutorRecoger", value.CelularTutorRecoger));
                    cmd.Parameters.Add(new SqlParameter("@NumeroEmergencia", value.NumeroEmergencia));
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
         
            }
        }

        public async Task<bool> InsertarEstudios(EstudiosNuevo value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_EstudiosInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@Estudios", value.Estudios));
                    cmd.Parameters.Add(new SqlParameter("@GradoEstudios", value.GradoEstuidos));
                    cmd.Parameters.Add(new SqlParameter("@NombreEscuela", value.NombreEscuelaActual));
                    cmd.Parameters.Add(new SqlParameter("@Trabajas", value.trabajas));
                    cmd.Parameters.Add(new SqlParameter("@LugarTrabajo", value.LugarTrabajo));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> InsertarConocimientosMusicales(ConocimientosMusicales value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ConocimientosInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@ConMusical", value.ConMusical));
                    cmd.Parameters.Add(new SqlParameter("@Instrumento", value.InstrumentoMusicalConocimiento));
                    cmd.Parameters.Add(new SqlParameter("@InstrumentoCasa", value.IntrumentoCasa));
                    cmd.Parameters.Add(new SqlParameter("@NoInstrumento", value.NombreInstrumentoCasa));
                    cmd.Parameters.Add(new SqlParameter("@EnterasteEsc", value.EnterasteEsc));
                    cmd.Parameters.Add(new SqlParameter("@InteresGnroMusical", value.GeneroMusical));
                    cmd.Parameters.Add(new SqlParameter("@Cuales", value.Cuales));
                  
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> InsertarHobbys(Hoobys value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ConocimientosInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // para tabla de alumnos 
                    cmd.Parameters.Add(new SqlParameter("@Hobby", value.Hooby));
                    cmd.Parameters.Add(new SqlParameter("@Otro", value.Otro));
                    cmd.Parameters.Add(new SqlParameter("@ClaseOpcional", value.ClaseOpcional));
                    cmd.Parameters.Add(new SqlParameter("@DescuentoP", value.DescuentoP));
                    cmd.Parameters.Add(new SqlParameter("Amable", value.Amable));
                    cmd.Parameters.Add(new SqlParameter("NombreRecepcionista", value.NombreRecepcionista));

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
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                Dia = (string)reader["Dia"],
                Fecha = (DateTime)reader["Fecha"],
                HoraInicio = (DateTime)reader["HoraInicio"],
                HoraFin = (DateTime)reader["HoraFin"]

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
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                Dia = (string)reader["Dia"],
                Fecha = (DateTime)reader["Fecha"],
                HoraInicio = (DateTime)reader["HoraInicio"],
                HoraFin = (DateTime)reader["HoraFin"],
            };
        }

        public async Task<bool> InsertarHorario(HorariosInsertarModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("InsertarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", value.HoraInicio));
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", value.HoraFin));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarHorario(int IdHorario,int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarHorarios", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorario", IdHorario));
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", HoraInicio));
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", HoraFin));

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
                IdMaestro = (int)reader["IdMaestro"],
                IdClase = (int)reader["IdClase"],
                Dia = reader["Dia"].ToString(),
                Fecha = (DateTime)reader["Fecha"],
                HoraInicio = (DateTime)reader["HoraInicio"],
                HoraFin = (DateTime)reader["HoraFin"]
            };
        }


        public async Task<bool> InsertHorarioVerano(HorariosVeranoInsertModel value)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorarioVeranoInsertar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", value.IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", value.Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", value.Fecha));
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", value.HoraInicio));
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", value.HoraFin));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateHorarioVerano(int IdHorarioVerano,int IdMaestro, int IdClase, string Dia, DateTime Fecha, DateTime HoraInicio, DateTime HoraFin)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("usp_HorarioVeranoActualizar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdHorarioVerano", IdHorarioVerano));
                    cmd.Parameters.Add(new SqlParameter("@IdMaestro", IdMaestro));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", IdClase));
                    cmd.Parameters.Add(new SqlParameter("@Dia", Dia));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@HoraInicio", HoraInicio));
                    cmd.Parameters.Add(new SqlParameter("@HoraFin", HoraFin));


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
          
                Status = (bool)reader["Status"],
              
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
         
                Status = (bool)reader["Status"],
              
                
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
               
                    cmd.Parameters.Add(new SqlParameter("@Status", value.Status));
                 
                    cmd.Parameters.Add(new SqlParameter("@Pago", value.Pago));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, bool Status, decimal Pago)
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
            return new EventosModel()
            {

                IdEvento = (int)reader["IdEvento"],
                NombreEvento = (string)reader["NombreEvento"],
                Fecha = (DateTime)reader["Fecha"],
                Hora = (DateTime)reader["Hora"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
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
            return new EventosIDModel()
            {

                IdEvento = (int)reader["IdEvento"],
                NombreEvento = (string)reader["NombreEvento"],
                Fecha = (DateTime)reader["Fecha"],
                Hora = (DateTime)reader["Hora"],
                IdAlumno = (int)reader["IdAlumno"],
                IdClase = (int)reader["IdClase"],
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
                    cmd.Parameters.Add(new SqlParameter("@Hora", value.Hora));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", value.IdAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdClase", value.IdClase));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, DateTime Fecha, DateTime Hora, int IdAlumno, int IdClase)
        {
            using (SqlConnection sql = new SqlConnection(EMAIConnection))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarEvento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdEvento", IdEvento));
                    cmd.Parameters.Add(new SqlParameter("@NombreEvento", NombreEvento));
                    cmd.Parameters.Add(new SqlParameter("@fecha", Fecha));
                    cmd.Parameters.Add(new SqlParameter("@hora", Hora));
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

        #region "Seccion ---> Clases"

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

        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion

    }
}
