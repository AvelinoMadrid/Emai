using EMAI.DTOS.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.Servicios
{
    public interface IContendorImagenes
    {
        Task<string> GuadarImagen(byte[] file, string contentType, string extension, string container, string name);
        Task<string> FileUpload(string host, string carpeta, string prefijoEntidad, IFormFile arcxhivo);

    }
}
