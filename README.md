# 📌 API Documentos - API de extracción de PDF y OCR

## 📝 Resumen del proyecto
**API Documentos** es una API RESTful construida con **.NET 8** que permite a los usuarios:
- Extraer texto de **archivos PDF**.
- Extraer texto de **imágenes** (OCR) utilizando **Tesseract OCR**.

## Características
- Extracción de texto de **PDF**: Sube un PDF y extrae su contenido de texto.
- **Procesamiento de imágenes OCR**: Subir una imagen y extraer texto legible.
- **Validación**: Garantiza que sólo se procesan archivos válidos.
- **Documentación Swagger**: La documentación de la API es auto-generada.
- Pruebas unitarias**: Incluye pruebas para la extracción de texto de PDFs.

---

## Configuración e instalación

### **1️⃣ Requisitos previos**
- Instalar **.NET 8 SDK** [Descargar aquí](https://dotnet.microsoft.com/download/dotnet/8.0)
- Instalar **Tesseract OCR**: Descargar modelos de datos entrenados
  ``sh
  mkdir tessdata
  curl -o tessdata/eng.traineddata https://github.com/tesseract-ocr/tessdata/raw/main/eng.traineddata
  ```

---

### **2️⃣ Clonar el repositorio**
```sh
git clone https://github.com/your-repo/api-documentos.git
cd api-documentos
```

---

### **3️⃣ Instalar dependencias**
``sh
dotnet restore
```

---

### **4️⃣ Ejecutar la API Localmente**
``sh
dotnet run
```
📌 **Swagger UI** estará disponible en:
```
https://localhost:5001/swagger
```

---

### **5️⃣ Ejecutar pruebas**
Para verificar la funcionalidad de extracción de texto PDF:
```sh
dotnet test
```

---

## 🖥️ Puntos finales de la API

### **📄 Extracción de PDF**
**Punto final:**
```
POST /api/pdf/upload
```
**Body (multipart/form-data):**
- Archivo Sube un archivo PDF.

**Response:**
```json
{
  «extractedText": «Este es un texto de muestra del PDF».
}
```

---

### **🖼️ Extracción de Imagen OCR**
**Endpoint:**
```
POST /api/ocr/extract
```
**Cuerpo (multipart/form-data):**
- `file`: Sube un archivo de imagen.

**Response:**
```json
{
  «extractedText": «Esto es texto de la imagen».
}
```

---

## ⚙️ Configuración
Modifique **`appsettings.json`** para configuraciones adicionales como tamaños de archivo permitidos y registro.

---

## Licencia
Este proyecto está licenciado bajo **MIT License**.