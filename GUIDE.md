# 📖 API Documentos - Guía del desarrollador

## 🔍 Descripción general
Esta guía proporciona una explicación en profundidad del sistema **API Documentos**, incluyendo detalles sobre su arquitectura, componentes y lógica.

---

## 🏛️ **Resumen de la arquitectura**
El proyecto está construido utilizando **.NET 8**, siguiendo una **arquitectura limpia y modular**:

- **Controladores**: Gestionan las peticiones a la API y devuelven las respuestas.
- **Servicios**: Contienen la lógica de negocio para la extracción de PDF y OCR.
- **Validación**: Garantiza que los archivos cargados cumplen los criterios necesarios.
- **Pruebas**: Se proporcionan pruebas unitarias para las funcionalidades básicas.

---

## Estructura del proyecto
```
api-documentos/
│── Controladores/
│ ├── PdfController.cs # Maneja la carga y extracción de PDF.
│ ├── OcrController.cs # Gestiona la extracción de imágenes OCR
│── Servicios/
│ ├── PdfService.cs # Extrae texto de los archivos PDF.
│ ├── OcrService.cs # Extrae texto de imágenes utilizando Tesseract
│── Validaciones/
│ ├── FileValidator.cs # Garantiza la validez de los archivos PDF y de imagen
│── Pruebas/
│ ├── PdfServiceTests.cs # Pruebas unitarias para la extracción de PDF.
│── Program.cs # Punto de entrada a la API y configuración de dependencias
│── appsettings.json # Archivo de configuración
│─── tessdata/ # Modelos de lenguaje OCR de Tesseract.
```

---

## 🔧 **Componentes funcionales**

### 📄 **Extracción de PDF (`PdfService.cs`)**
- Utiliza **iText7** para extraer texto de los PDF cargados.
- Lee **todas las páginas** y combina el texto extraído.
- Asegura que los archivos subidos son ** PDFs válidos** (no corruptos o vacíos).

#### 🔹 **Métodos clave**:
```csharp
public async Task<string> ExtraerTexto(IFormFile archivo)
```
- Toma un archivo **PDF** cargado.
- Lee todas las páginas usando **`PdfTextExtractor.GetTextFromPage()`**.
- Devuelve el **texto extraído como una cadena**.

---

### 🖼️ **Extracción de imágenes OCR (`OcrService.cs`)**
- Utiliza **Tesseract OCR** para extraer texto de **imágenes JPEG, PNG, TIFF**.
- Convierte las imágenes a **escala de grises** para una mayor precisión.
- Requiere un **modelo de lenguaje Tesseract entrenado** (`tessdata/eng.traineddata`).

#### 🔹 **Métodos clave**:
``csharp
public async Task<string> ExtraerTextoDeImagen(IFormFile file)
```
- Carga la imagen en **memoria**.
- Convierte a **escala de grises** antes del procesamiento OCR.
- Extrae el texto usando **`TesseractEngine.Process()`**.

---

## 🔍 **Reglas de Validación (`FileValidator.cs`)**
- **Los archivos PDF deben ser válidos** (formato `application/pdf`).
- Los archivos de imagen deben tener formatos válidos** (`jpeg`, `png`, `tiff`).
- Tamaño máximo del archivo**: **5 MB.

---

## 🛠️ **Pruebas (`PdfServiceTests.cs`)**
- Utiliza **Moq** para crear cargas de archivos simuladas.
- Valida la extracción de texto de **los PDF generados**.
- Asegura que **OCR extrae correctamente el texto de las imágenes**.

#### 🔹 **Ejecutar pruebas**:
```sh
dotnet test
```

---

## ⚙️ **Configuración (`appsettings.json`)**
Modifica configuraciones como:
```json
{
  «Logging": {
    «LogLevel": {
      «Predeterminado": «Información»,
      «Microsoft.AspNetCore": «Warning»
    }
  },
  «PdfProcessing": {
    «MaxFileSizeMB": 5
  }
}
```

---

## ❓ **¿Necesitas ayuda?**
Para cualquier problema, abre una incidencia en GitHub o ponte en contacto con los mantenedores.

---

## Licencia
Este proyecto está licenciado bajo **MIT License**.

