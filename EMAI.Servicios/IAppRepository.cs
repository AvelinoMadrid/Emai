using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


using System.Threading.Tasks;
using EMAI.Comun.Models;



namespace EMAI.Servicios
{
    public interface IAppRepository : IDisposable
    {

        string ErrorMessageSp { get; set; }
        bool Respuesta { get; set; }

        #region "Alumnos"  

        Task<List<AlumnosModel>> GetAlumnos();

        Task<AlumnosbyIDModel> GetAlumnosbyID(int id);

        //Task<bool> InsertarAlumno(AlumnosModel value);


        #endregion

        #region "Clases"
        Task<List<ClasesModel>> GetClases();
       #endregion







    }
}
