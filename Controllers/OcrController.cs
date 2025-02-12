using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiDocumentos.Services;
using System.Threading.Tasks;

namespace ApiDocumentos.Controllers
{
    [ApiController]
    [Route("api/ocr")]
    public class OcrController : ControllerBase
    {
        private readonly IOcrService _ocrService;

        public OcrController(IOcrService ocrService)
        {
            _ocrService = ocrService;
        }

        [HttpPost("extract")]
        public async Task<IActionResult> ExtraerTextoDeImagen(IFormFile file)
        {
            if (file == null)
                return BadRequest("No se subieron archivos.");

            var text = await _ocrService.ExtraerTextoDeImagen(file);
            return Ok(new { extractedText = text });
        }
    }
}
