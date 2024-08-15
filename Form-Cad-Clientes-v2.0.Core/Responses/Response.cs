namespace Formulario.Core
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public Response()
        {
        }

        public Response(bool isSuccess, T? data, string? errorMessage = null, int statusCode = 200)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }
    }
}
