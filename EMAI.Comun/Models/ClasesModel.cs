using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class ClasesModel
    {
        public int idClase { get; set; }
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        // dia normal de clase 
        public string DiaHorario { get; set; }
        //public string Horario { get; set; }  sufre modificiaciones

        // segundo dia
        public string Diahorario2 { get; set; }
        //public string Horario2 { get; set; } sufre modificaciones

        // tercer dia
        public string DiaHorario3 { get; set; }
        // public string Horario3 { get; set; } sufre modificaciones
        public decimal Costo { get; set; }


        public string ClaseOpc { get; set; }
        // dia opcional 
        public string HorarioOpc { get; set; }

       // public string DiaOpc { get; set; sufre modificaciones
    }

    // Clases Insert
    public class ClasesIdModel
    {
        public int idClase { get; set; }
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        // dia normal de clase 
        public string DiaHorario { get; set; }
       

        // segundo dia
        public string Diahorario2 { get; set; }
        //public string Horario2 { get; set; } sufre modificaciones

        // tercer dia
        public string DiaHorario3 { get; set; }
        // public string Horario3 { get; set; } sufre modificaciones
        public decimal Costo { get; set; }


        public string ClaseOpc { get; set; }
        // dia opcional 
        public string HorarioOpc { get; set; }

        // public string DiaOpc { get; set; sufre modificaciones
    }

    public class ClasesModelInsertar
    {
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        public string Dia { get; set; }
     
        public string Dia2 { get; set; }
        
        public string Dia3 { get; set; }
      
        public decimal Costo { get; set; }
        public string ClaseOpc { get; set; }
        public string HorarioOpc { get; set; }
       
    }

    public class ClasesModelActualizar
    {
        public int IdClase { get; set; }
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        public string Dia { get; set; }

        public string Dia2 { get; set; }

        public string Dia3 { get; set; }

        public decimal Costo { get; set; }
        public string ClaseOpc { get; set; }
        public string HorarioOpc { get; set; }
    }

    public class ClasesModelEliminar
    {
        public int IdClase { get; set; }
        public string Nombre { get; set; }
        public string CNormal { get; set; }
        public string CVerano { get; set; }
        public string Dia { get; set; }
        public string Horario { get; set; }
        public string Dia2 { get; set; }
        public string Horario2 { get; set; }
        public string Dia3 { get; set; }
        public string Horario3 { get; set; }
        public decimal Costo { get; set; }
        public string ClaseOpc { get; set; }
        public string HorarioOpc { get; set; }
        public string DiaOpc { get; set; }
    }

    public class ListaClases
    {
        public string NombreClase { get; set; }
    }




}
