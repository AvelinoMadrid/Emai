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
                using (SqlCommand cmd = new SqlCommand("usp_MunicipioObtenerPorId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IDMunicipio", Id));
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
                NombrePapa = reader["NombrePapas"].ToString(),
                TelefonoPapa = reader["Celularpapas"].ToString(),
                FacebookPapa = reader["FacebookPapas"].ToString(),
                EmailPapa = reader["E-mail"].ToString(),
                TutorRecoger = reader["TutorRecoger"].ToString(),
                CelularTR = reader["CelularTR"].ToString(),
                NumEmergencia = reader["NumEmergencia"].ToString(),
                Estudios = (bool)reader["Estudios"],
                GradoEstudios = reader["GradoEstudios"].ToString(),
                EscuelaActual = reader["EscuelaActual"].ToString(),
                Trabajo = (bool)reader["Trabajas"],
                LugarTrabajo = reader["LugarTrabajo"].ToString(),
                conActual = reader["ConActual"].ToString(),
                instrumentoMusical = reader["Instrumento"].ToString(),
                InstrumentoCasa = (bool)reader["InstrumentoCasa"],
                NoInstrumentoMusical = reader["NoInstrumento"].ToString(),
                EntersteEsc = reader["EnterasteEsc"].ToString(),
                interesGnroMusical = (bool)reader["InteresGnroMusical"],
                interesgros = reader["Cuales"].ToString(),
                interes = reader["lectura"].ToString(), // verificar en la base de daatos 
                classOpcional = (bool)reader["ClaOpcional"],
                Descuento = (bool)reader["DescuentoP"],
                amable = (bool)reader["Amable"],
                IDRecepcionista = (int)reader["Recepcionista"],
                NombreRecepcionista = reader["Nombre"].ToString()
            };
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



        #endregion

        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion

    }
}
