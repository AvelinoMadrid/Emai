using EMAI.DTOS.Dtos.Request;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace EMAI.LND.Validators
{
    public class Programa5sValidators : AbstractValidator<Programas5Request>
    {
 
        public Programa5sValidators()
        {
            int tam_picture = 5000;

            RuleFor(x => x.Area).NotNull().WithMessage("El campo Area No debe estar Nulo").
                                 NotEmpty().WithMessage("El campo Area No debe estar Vacia");

            RuleFor(x => x.Supervisor).NotNull().WithMessage("El campo Supervisor No debe estar Nulo").
                                NotEmpty().WithMessage("El campo Supervisor No debe estar Vacia");

            RuleFor(x => x.Detalles).NotNull().WithMessage("El campo Detalles No debe estar Nulo").
                                NotEmpty().WithMessage("El campo Detalles No debe estar Vacia");

            //RuleFor(x => x.ImagenAntes).NotNull().WithMessage("Favor de Inserta la Imagen No puede ser Nula")
            //    .Must(HavePictureLength).WithMessage($"La Imagen Antes No puede ser Vacia y Debe tener Maximo Peso {tam_picture / 1024 / 1024} MB ");
        }
        //private bool HavePictureLength(IFormFile formFile)
        //{
        //    int tam_picture = 5000;
        //    return formFile != null && formFile.Length <= tam_picture && formFile.Length > 0;
        //}
    }
}
