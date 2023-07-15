using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMAI.Comun.Models;

namespace EMAI.Servicios
{
    public interface ILibrosOperaciones
    {

        Task<List<LibrosModel>> GetAllLibros();
        Task<LibrosModel> GetLibrobyId(int id);
        Task<bool> InsertLibro(InsertLibrosModel value);
        Task<bool> UpdateLibro(int IDLibro, decimal costo);
        Task<bool> StatusDesactivadoLibro(int IdLibro);
        Task<bool> StatusActivadorLibro(int IdLibro);
       

    }
}
