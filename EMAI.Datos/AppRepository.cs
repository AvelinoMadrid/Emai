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
            EMAIConnection = "Data Source=LAPTOP-OM95FUOE\\SQLEXPRESS;Initial Catalog=EMAI;TrustServerCertificate=True;Integrated Security=True";
        }


        #region " Sección Alumnos --> "

        //MOSTAR
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

        #endregion



















        #region "dispose"
        public void Dispose()
        {
            GC.Collect();
        }

        #endregion


    }
}
