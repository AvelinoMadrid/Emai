using EMAI.DTOS.Dtos.Base;
using EMAI.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMAI.LND
{
    public class ContendorImagenes : IContendorImagenes
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _htpContextAccessor;
        public ContendorImagenes(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor htpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _htpContextAccessor = htpContextAccessor;
        }
        public async Task<string> GuadarImagen(byte[] file, string contentType, string extension, string container, string name)
        {
            string response = "";

            string wwwrootPath = _webHostEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }
            if (string.IsNullOrEmpty(container))
            {
                throw new ArgumentException("El nombre de la carpeta contenedora no puede estar vacío.");
            }
            string carpetaArchivo = Path.Combine(wwwrootPath, container);



            if(!Directory.Exists(carpetaArchivo)) {
            
                Directory.CreateDirectory(carpetaArchivo);

            }
            string nombreFinal = $"{name}{extension}";
            string rutaFinal = Path.Combine(carpetaArchivo,nombreFinal);

            await File.WriteAllBytesAsync(rutaFinal, file);

            //deovler el url hacia el suario 
            string urlActual = $"{_htpContextAccessor.HttpContext.Request.Scheme}://{_htpContextAccessor.HttpContext.Request.Host}";
            string dbUrl = Path.Combine(urlActual, container, nombreFinal).Replace("\\", "/");
            response = dbUrl;

            return response;

        }
    }
}
