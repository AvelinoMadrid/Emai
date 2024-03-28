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
        Task<List<LibrosModel>> GetAllLibrosInactivos();
        Task<LibrosModel> GetLibrobyId(int id);
        Task<LibrosModel> GetLibrobyIdInactivos(int idInactivo);
        Task<bool> InsertLibro(InsertLibrosModel value);
        Task<bool> UpdateLibro(int IdLibro, string NombreLibro, string DescripcionLibro, decimal Costo, string Estado);
        //  Task<bool> ActivarDesactivarLibro(int IdLibro,string Estado);

        Task<bool> ActivarLibro(int IdLibro, string Estado);
        //Task<bool> DesactivarLibro(int IdLibro);


    }
}
