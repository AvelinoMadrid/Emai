using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAI.Comun.Models;
using EMAI.Entidades;
using EMAI.Servicios;


namespace EMAI.Servicios
{
    public interface IAlumnosOperaciones
    {
        // obtener todos los datos 
        Task<List<AlumnosModel>> GetAlumnos();
        Task<AlumnosbyIDModel> GetAlumnosbyID(int id);





    }
}
