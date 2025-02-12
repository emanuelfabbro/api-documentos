using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiDocumentos.Services;
using ApiDocumentos.Utils;

namespace ApiDocumentos.Controllers
{
    [ApiController]
    [Route("api/pdf")]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly FileValidator _validator;

        public PdfController(IPdfService pdfService, FileValidator validator)
        {
            _pdfService = pdfService;
            _validator = validator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> SubirPdf(IFormFile file)
        {
            var validarResultado = _validator.Validate(file);
            if (!validarResultado.IsValid)
                return BadRequest(validarResultado.Errors);

            var text = await _pdfService.ExtraerTexto(file);
            return Ok(new { textoExtraido = text });
        }
    }
}