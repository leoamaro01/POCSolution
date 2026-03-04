// <copyright file="MainPage.xaml.cs" company="POC NTSprint">
// Copyright (c) POC NTSprint. All rights reserved.
// </copyright>

namespace POCSolution
{
    using POCSolution.Services.Interfaces;
    using POCSolution.Utils;

    /// <summary>
    /// Application main page.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private readonly ICameraService cameraService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the user interface components for the main page. Call this
        /// constructor when creating a new MainPage object in your application.</remarks>
        public MainPage()
        {
            this.InitializeComponent();
            this.cameraService = ServiceHelper.GetService<ICameraService>();
        }

        /// <inheritdoc/>
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            try
            {
                this.LoadWebContent();
            }
            catch (Exception ex)
            {
                await this.DisplayAlertAsync("Error", $"Ocurrió un error: {ex.Message}", "OK");
                await Shell.Current.GoToAsync("///login");
            }
        }

        private void LoadWebContent()
        {
            this.LoadDefaultDashboard();
        }

        private void LoadDefaultDashboard()
        {
            string defaultHtml = """
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <title>Panel de Control</title>
    <style>
        body { font-family: sans-serif; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); min-height: 100vh; padding: 20px; margin: 0; }
        .header { background: white; padding: 20px; border-radius: 12px; box-shadow: 0 4px 15px rgba(0,0,0,0.1); margin-bottom: 20px; display: flex; justify-content: space-between; align-items: center; gap: 15px; }
        .username { color: #667eea; font-size: 18px; font-weight: 600; }
        .header-actions { display: flex; gap: 10px; flex-wrap: wrap; }
        .button { padding: 12px 24px; border: none; border-radius: 8px; font-size: 14px; font-weight: 600; cursor: pointer; transition: all 0.3s; }
        .button-success { background-color: #34c759; color: white; }
        .button-success:hover { background-color: #2daa4f; }
        .button-danger { background-color: #ff3b30; color: white; }
        .button-danger:hover { background-color: #e6342a; }
        .container { background: white; border-radius: 12px; box-shadow: 0 10px 40px rgba(0,0,0,0.2); padding: 40px; max-width: 800px; margin: 0 auto; }
        .welcome { color: #667eea; font-size: 28px; font-weight: bold; margin-bottom: 20px; }
        .section { margin-bottom: 30px; }
        .section-title { color: #333; font-size: 18px; font-weight: 600; margin-bottom: 15px; border-bottom: 2px solid #f0f0f0; padding-bottom: 10px; }
        .preview-image { max-width: 100%; margin-top: 15px; border-radius: 8px; }
        #imagePreview { margin-top: 20px; }
    </style>
</head>
<body>
    <div class='header'>
        <div class='username'>👤 Panel de Control</div>
        <div class='header-actions'>
            <!-- Input file exactamente como se requiere (no se usa en WebView, manejado por C#) -->
            <input style="display: none" type="file" id="ssncard_img" accept=".jpg, .jpeg, .png" capture="camera">
            
            <!-- Botón que invoca C# en lugar del input file -->
            <button class='button button-success' onclick='openCamera()'>📷 Abrir Cámara</button>
        </div>
    </div>
    <div class='container'>
        <div class='welcome'>¡Bienvenido!</div>
        <div class='section'>
            <div class='section-title'>📸 Captura de Fotos</div>
            <p>Haz clic en 'Abrir Cámara' para capturar una foto desde tu dispositivo.</p>
            <div id='imagePreview'></div>
        </div>
    </div>
    <script>
        function openCamera() {
            window.location = 'app://camera';
        }
        
        function performLogout() {
            if(confirm('¿Cerrar sesión?')) {
                window.location = 'app://logout';
            }
        }
        
        function showPhotoPreview(base64Data, filename) {
            const preview = document.getElementById('imagePreview');
            preview.innerHTML = '';
            
            const img = document.createElement('img');
            img.src = base64Data;
            img.className = 'preview-image';
            preview.appendChild(img);
            
            const info = document.createElement('div');
            info.style.marginTop = '10px';
            info.style.color = '#34c759';
            info.style.fontWeight = 'bold';
            info.innerHTML = '✓ Foto capturada: ' + filename;
            preview.appendChild(info);
        }
    </script>
</body>
</html>
""";

            this.MainWebView.Source = new HtmlWebViewSource { Html = defaultHtml };
            this.MainWebView.Navigating += this.OnWebViewNavigating;
        }

        private async void OnWebViewNavigating(object? sender, WebNavigatingEventArgs e)
        {
            if (e.Url.StartsWith("app://"))
            {
                // Prevenir que intente cargar esta URL
                e.Cancel = true;

                string action = e.Url.Replace("app://", string.Empty).Split('?')[0].ToLower();

                if (action == "camera")
                {
                    await this.CaptureAndDisplayPhoto();
                }
            }
        }

        private async Task CaptureAndDisplayPhoto()
        {
            try
            {
                var photoPath = await this.cameraService.TakePictureAsync();

                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    byte[] imageBytes = File.ReadAllBytes(photoPath);
                    string base64 = Convert.ToBase64String(imageBytes);
                    string mimeType = this.GetMimeType(photoPath);
                    string base64Data = $"data:{mimeType};base64,{base64}";

                    string filename = Path.GetFileName(photoPath);

                    string jsCommand = $"showPhotoPreview('{base64Data}', '{filename}')";

                    await this.MainWebView.EvaluateJavaScriptAsync(jsCommand);
                    await this.DisplayAlertAsync("Éxito", "Foto capturada correctamente", "OK");
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlertAsync("Error", $"Error al capturar foto: {ex.Message}", "OK");
            }
        }

        private string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                _ => "image/jpeg",
            };
        }
    }
}
