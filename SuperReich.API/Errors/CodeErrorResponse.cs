namespace SuperReich.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores",
                403 => "No tienes autorización para este recurso",
                404 => "No se encontró el recurso solicitado",
                500 => "Se producieron errores en el servidor",
                _ => string.Empty
            };
        }
    }
}
