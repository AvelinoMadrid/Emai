using EMAI.Comun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IMaestrosOperaciones
    {
        Task<List<MaestrosModel>> GetMaestros();

        Task<MaestrosIDModel> GetMaestrosID(int IdMaestro);
        Task<bool> InsertarMaestro(MaestrosInsertarModel value);

        Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, int IdClase, int IdHorario, int IdAlumno, bool Status, bool Base, string Suplente, decimal Pago);

        Task<bool> EliminarMaestro(int IdMaestro);
    }
}
