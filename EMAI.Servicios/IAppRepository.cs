using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


using System.Threading.Tasks;
using EMAI.Comun.Models;
using EMAI.DTOS.Dtos.Request;
using EMAI.DTOS.Dtos.Response;
using static EMAI.Comun.Models.EventosIDModel;
using static EMAI.Comun.Models.RepClaseModel;



namespace EMAI.Servicios
{
    public interface IAppRepository : IDisposable
    {

        string ErrorMessageSp { get; set; }
        bool Respuesta { get; set; }

        #region 
        Task<List<AdicionalesModel>> GetAdicionales();
        Task<AdicionalesIDModel> GetAdicionalesID(int IdAdicional);
        Task<bool> InsertarAdicional(AdicionalesInsertarModel value);
        Task<bool> ActualizarAdicional(int IdAdicional, int IdAlumno, int IdClase, int IdHorario, DateTime Fecha);
        Task<bool> EliminarAdicional(int IdAdicional);
        #endregion

        #region "Alumnos"  
        Task<bool> InsertarAlumnoTwo(InsertarAlumnoModelV1 request);
        Task<bool> EditarAlumnoV1(InsertarAlumnoModelV1 request);
        Task<ListFolioResponse[]> GetListFolio();
        Task<List<InsertarAlumnoModelV1>> GetListAlumnosTotalV1();
        Task<List<SelectClasesHorarioResponse>> SelectClasesHorario(string nameProcedure, int idClase);
        Task<InsertarAlumnoModelV1> GetListAlumnoByIdV1(int IdAlumno);
        Task<bool> ReactivarByIdAlumnoV1(int IdAlumno);
        Task<bool> DeleteByIdAlumnoV1(int IdAlumno);
      


 



        #endregion

        #region "Asistencia"

        Task<List<AsistenciaModel>> GetAllAsistencias();
        Task<AsistenciaModel> GetAsistenciaByID(int id);

        Task<bool> InsertarAlumnoAsistencia(InsertAsistenciaModel value);
        Task<bool> DeleteAsistenciabyID(int id);
        Task<bool> UpdateAsistencia(int id, int IdAlumno, int IdClase, DateTime Fecha, bool Asistencia);

        #endregion

        #region "Cooperaciones"

        Task<List<CooperacionesModel>> GetAllCooperaciones();
        Task<CooperacionesModel> GetCooperacionesByID(int id);

        Task<bool> InsertarCooperaciones(InsertCooperacionModel value);
        Task<bool> DeleteCooperacionesbyId(int id);
        Task<bool> UpdateCooperaciones(int id, DateTime Fecha, string NoPedido, string Proveedor, decimal cantidad, string img);

        #endregion

        #region "Colegiatura"
        Task<List<ColegiaturaModel>> GetColegiatura();

        // Mostrar Clases
        Task<List<ListaClases>> GetNombreClases();

        Task<ColegiaturaIDModel> GetColegiaturaID(int IdColegiatura);
        Task<bool> InsertarColegiatura(ColegiaturaInsertarModel value);
        Task<bool> ActualizarColegiatura(int IdColegiatura, DateTime Fecha,  string Descripcion, decimal Cantidad,string img);
        Task<bool> EliminarColegiatura(int IdColegiatura);
        #endregion

        #region "Clases"
        Task<List<ClasesModel>> GetClases();
        Task<ClasesIdModel> GetClasesId(int IdClase);
        Task<bool> InsertarClase(ClasesModelInsertar value);
        Task<bool> ActualizarClase(int IdClase, string Nombre, string CNormal, string CVerano, string Dia, string Dia2, string Dia3, decimal Costo);
        Task<bool> EliminarClase(int IdClase);

        Task<List<SelectClasesUnique>> GetListaUniqueHorario();

        #endregion

        #region "DotacionDia"
        Task<List<DotacionDiaModel>> GetAllDotacionDia();
        Task<DotacionDiaModel> GetDotacionDiaById(int id);
        Task<bool> InsertarDotacionDia(InsertDotacionDiaModel value);
        Task<bool> UpdateDotacionDia(int id, DateTime fecha, string NoPedido, string Descripcion, decimal cantidad, string img);
        Task<bool> DeleteDotacionDiabyID(int id);

        #endregion

        #region "Gastos"
        Task<List<GastosModel>> GetGastos();
        Task<GastosIDModel> GetGastosID(int IdGasto);
        Task<bool> InsertarGastos(GastosInsertarModel value);
        Task<bool> ActualizarGastos(int IdGasto, DateTime Fecha, string NoPedidoE_S, string Proveedor, decimal Cantidad, string img);
        Task<bool> EliminarGastos(int IdGasto);

        #endregion

        #region "GastosDia"
        Task<List<GastosDiaModel>> GetGastosDia();
        Task<GastosDiaIDModel> GetGastosDiaID(int IdGastoDia);
        Task<bool> InsertarGastosDia(GastosDiaInsertarModel value);
        Task<bool> ActualizarGastosDia(int IdGastoDia, DateTime Fecha, string NoPedido, string Proveedor,
            decimal Cantidad, string img);
        Task<bool> EliminarGastosDia(int IdGastoDia);

        #endregion



        #region "Horarios"
        Task<List<HorariosModel>> GetHorarios();
        Task<HorariosIDModel> GetHorariosID(int IdHorario);
        Task<bool> InsertarHorario(HorariosInsertarModel value);
        Task<bool> ActualizarHorario(int IdHorario, string dia);
        Task<bool> EliminarHorario(int IdHorario);
        #endregion

        #region "HorariosVerano"
        Task<List<HorariosVeranoModel>> GetAllHorariosVerano();
        Task<HorariosVeranoModel> GetHorariosVeranoById(int Id);
        Task<bool> InsertHorarioVerano(HorariosVeranoInsertModel value);
        Task<bool> UpdateHorarioVerano(int IdHorario,string Dia,string Hora);
        Task<bool> DeleteHorarioVerano(int Id);

        #endregion

        #region "Libros"
        Task<List<LibrosModel>> GetAllLibros();
        Task<LibrosModel> GetLibrobyId(int id);
        Task<bool> InsertLibro(InsertLibrosModel value);
        Task<bool> UpdateLibro(int IDLibro, decimal costo);
        Task<bool> StatusDesactivadoLibro(int IdLibro);
        Task<bool> StatusActivadorLibro(int IdLibro);
        #endregion

        #region "Maestros" 
        Task<List<MaestrosModel>> GetMaestros();

        Task<MaestrosIDModel> GetMaestrosID(int IdMaestro);
        Task<bool> InsertarMaestro(MaestrosInsertarModel value);

        Task<bool> ActualizarMaestro(int IdMaestro, string Nombre, string ApellidoP, string ApellidoM, string Direccion, string Telefono, DateTime FechaNacimiento, string Status, decimal Pago, decimal PagoSemanal, decimal PagoHora, string Area);
        Task<bool> EliminarMaestro(int IdMaestro);
        #endregion

        #region "Nomina"
        Task<List<NominaModel>> GetAllNomina();
        Task<NominaModel> GetByIDNomina(int id);

        Task<bool> InsertarNomina(InsertNominaModel value);
        Task<bool> ActualizarNomina(int IdNomina, DateTime Fecha, string NoPedido, string Proveedor, decimal Cantidad, string img);

        Task<bool> EliminarNomina(int id);

        #endregion

        #region "Pagos"
        Task<List<PagosModel>> GetPagos();
        Task<PagosIDModel> GetPagosID(int IdPago);
        Task<bool> InsertarPagos(PagosInsertarModel value);

        Task<bool> ActualizarPagos(int IdPago, int IdPromosiones, int IdAdicionales, DateTime Fecha, string Folio, DateTime FechaPago, decimal SaldoPendiente, string Mes, int IdHorario, string Dia, int IdClase, int IdRecepcionista, decimal Costo, string Autorizacion,
            decimal Subtotal, decimal Iva, decimal Total);
        Task<bool> EliminarPago(int IdPago);
        #endregion

        #region "Promosiones"

        //Task<bool> ActualizarPromosiones(int IdPromosion, int IdAlumno, int Porcentaje, DateTime Fecha);
        Task<bool> EliminarPromocionesV1(int IdPromocion);
        Task<bool> InsertarPromocionesV1(PromocionesModelV1 request);
        Task<List<PromocionesModelV1>> GetPromocionesV1();
        Task<List<PromocionesModelV1>> GetSelectPromocionesV1();
        Task<PromocionesModelV1> GetPromocionById(int IdPromocion);
        Task<bool> UpdatePromocionesV1(PromocionesModelV1 request);

        #endregion

        #region "Usuarios"

        Task<List<UsuariosModel>> GetUsuarios();
        Task<UsuariosIDModel> GetUsuariosID(int IdUsuario);
        Task<bool> InsertarUsuario(UsuariosInsertarModel value);
        Task<bool> ActualizarUsuario(int IdUsuario, string Usuario, string Contraseña, string Email, string Direccion, string Telefono);
        Task<bool> EliminarUsuario(int IdUsuario);

        Task<UsuariosModel> Loggeo(string usuario, string contraseña);


        #endregion

        #region "Horas"

        Task<List<HorasModel>>GetHoras();
        Task<bool>InsertarHoras(HorasInsertarModel value);

        #endregion


        #region "Eventos"

        Task<List<EventosModel>> GetEventos();
        
        Task<EventosIDModel> GetEventosID(int IdEvento);

        Task<bool> InsertarEvento(EventoInsertarModel value);

        Task<bool> ActualizarEvento(int IdEvento, string NombreEvento, string Fecha,int IdHora, int IdAlumno, int IdClase);

        Task<bool> EliminarEvento(int IdEvento);
        #endregion

        #region "AsinacionClase"

        Task<List<AsigClaseModel>> GetAsigClase();

        Task<AsigClaseId> GetAsigClaseId(int AsgnId);

        Task<bool> AsignarClase(AsigClaseAsignar value);

        Task<bool> EliminarAsignacion(int AsgnId);
        #endregion

        #region "AsigancionMaestro"

        Task<List<AsigMaestroModel>> GetAsigMaestro1();

        Task<AsigMaestroId> GetAsigMaestroId(int AsgnId);

        Task<bool> AsignarMaestro(AsigMaestro1Asignar value);

        Task<bool> EliminarAsignacionMaestro(int AsgnId);


        Task<bool> ActualizarAsigMaestro(int AsgnId, int IdMaestro, int IdClase, int IdHorario);
        #endregion

        #region "Programa5s"

        Task<List<Programa5sModel>> GetPrograma5s();

        Task<Programa5sIdModel> GetPrograma5sId(int Id);

        //Estrucracion Propia
        Task<bool> InsertarPrograma5sV1(string nameProducedure,Programa5ModelV1 entity);
        Task<Programa5ModelV1> GetPrograma5sById(string nameProducedure, int IdPrograma);
        Task<List<Programa5ModelV1>> GetAllPrograma5sV1(string nameProducedure); 
        //Estrucracion Propia
        Task<bool> InsertarPrograma5s(Programa5sInsertarModel value);

        Task<bool> ActualizarPrograma5s(int Id, string Area, string Supervisor, DateTime FechaAntes, DateTime FechaInicio, string Detalles);

        #endregion

        #region "Meses"
        Task<List<MesesModelV1>> GetSelectMeses();
        #endregion

        #region "RepClase"

        Task<List<RepClaseModel>> GetRepClase();
        Task<RepClaseIDModel> GetRepClaseID(int IdRepClase);
        Task<bool> InsertarRepClase(RepClaseInsertarModel value);
        Task<bool> ActualizarRepClase(int IdRepClase, int IdClase, int IdMaestro, /*int IdAlumno,*/ string DiaRep);
        Task<bool> EliminarRepClase(int IdRepClase);
        #endregion

    }
}
