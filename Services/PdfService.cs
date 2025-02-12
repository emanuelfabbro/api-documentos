using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.AspNetCore.Http;

namespace ApiDocumentos.Services
{
    public interface IPdfService
    {
        Task<string> ExtraerTexto(IFormFile file);
    }

    public class PdfService : IPdfService
    {
        public async Task<string> ExtraerTexto(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            using var reader = new PdfReader(stream);
            using var pdfDoc = new PdfDocument(reader);

            string textoExtraido = "";
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                textoExtraido += PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i));
            }
            return await Task.FromResult(textoExtraido);
        }
    }
}