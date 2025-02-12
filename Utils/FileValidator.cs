using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ApiDocumentos.Utils
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(file => file)
                .NotNull().WithMessage("No se subieron archivos")
                .Must(file => file.ContentType == "application/pdf")
                .WithMessage("Solo se permiten archivos PDF.")
                .Must(file => file.Length > 0 && file.Length <= 5 * 1024 * 1024)
                .WithMessage("El archivo no debe exceder 5MB.");
        }
    }
}