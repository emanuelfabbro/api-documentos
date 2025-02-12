using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Moq;
using ApiDocumentos.Services;
using Xunit;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace ApiDocumentos.Tests
{

    public class PdfServiceTest
    {
        [Fact]
        public async Task ExtractTextAsync_ShouldReturnText_WhenValidPdf()
        {
       
            var pdfService = new PdfService();
            var mockFile = new Mock<IFormFile>();
            var stream = new MemoryStream();

            var pdfWriter = new PdfWriter(stream, new WriterProperties());
            using (var pdfDoc = new PdfDocument(pdfWriter))
            {
                var page = pdfDoc.AddNewPage();
                var canvas = new PdfCanvas(page);
                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                canvas.BeginText().SetFontAndSize(font, 12).MoveText(50, 750).ShowText("Test PDF Content").EndText();
            }

            stream.Position = 0;

            mockFile.Setup(_ => _.OpenReadStream()).Returns(() => new MemoryStream(stream.ToArray()));
            mockFile.Setup(_ => _.ContentType).Returns("application/pdf");

            var result = await pdfService.ExtraerTexto(mockFile.Object);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Test PDF Content", result);
        }
    }
}