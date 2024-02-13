using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Comun.Models
{
    public class GoogleSheetModel
    {
        public int CountRow { get; set; }
        public int CountColumn { get; set; }
        public string [][] DataSheetHoja { get; set; }
        public bool isPermisoAccess { get; set; }
        public int posicionRow { get; set; }    
        public char posicionColumn { get; set; }
        //public string MayorDimensión { get; set; }
        //public string valueRenderOption { get; set; }
        //public string dateTimeRenderOption { get; set; }



    }
}
