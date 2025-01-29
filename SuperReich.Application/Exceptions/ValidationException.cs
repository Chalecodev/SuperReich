namespace SuperReich.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException(Dictionary<string, string[]> errors)
            : base("Se produjeron errores de validación.")
        {
            Errors = errors;
        }
    }
}
