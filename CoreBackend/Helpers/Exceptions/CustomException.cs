using CoreBackend.Core.Model;

namespace CoreBackend.Helpers.Exceptions
{
    public class CustomException : Exception
    {
        public ApiResponse ErrorResult { get; set; }

        public CustomException(ApiResponse errorResult)
        {
            ErrorResult = errorResult;
        }
    }
}
