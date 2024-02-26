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
        public List<Dictionary<int, List<string>>>? DataSheetHoja { get; set; }
        public List<List<Object>>? GetValues {  get; set; }
        public bool isPermisoAccess { get; set; }
        //public string MayorDimensión { get; set; }
        //public string valueRenderOption { get; set; }
        //public string dateTimeRenderOption { get; set; }



    }
}
