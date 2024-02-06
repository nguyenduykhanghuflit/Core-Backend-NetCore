using CoreBackend.Core.Model;

namespace CoreBackend.Helpers.Api
{
    public static class Response
    {

        public static ApiResponse Success(object data, string title = "OK", string msg = "OK")
        {
            ApiResponse response = new()
            {
                Success = true,
                StatusCode = 200,
                Title = title,
                Message = msg,
                DataResult = data
            };
            return response;
        }

        public static ApiResponse Error(Exception? ex, object? errDetail, string msg = "Error! An error occurred.", string title = "Error! An error occurred.")
        {
            ApiResponse response = new()
            {
                Success = false,
                StatusCode = 400,
                Title = title,
                Message = ex != null ? ex.Message : msg,
                ErrorDetail = ex != null ? ex.StackTrace : errDetail,
            };
            return response;
        }
    }
}
