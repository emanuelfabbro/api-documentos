using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Tesseract;

namespace ApiDocumentos.Services
{
    public interface IOcrService
    {
        Task<string> ExtraerTextoDeImagen(IFormFile file);
    }

    public class OcrService : IOcrService
    {
        public async Task<string> ExtraerTextoDeImagen(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "Archivo inválido.";

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            string tessdataPath = Path.Combine(Directory.GetCurrentDirectory(), "tessdata");

            using var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default);
            using var img = Pix.LoadFromMemory(stream.ToArray());
            using var page = engine.Process(img);

            return page.GetText();
        }
    }
}
