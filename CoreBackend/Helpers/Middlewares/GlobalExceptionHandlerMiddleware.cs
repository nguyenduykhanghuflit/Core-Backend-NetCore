using CoreBackend.Core.Model;
using CoreBackend.Helpers.ActionFilters;
using CoreBackend.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CoreBackend.Helpers.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CustomException customEx)
            {

                _logger.LogError($"CustomException occurred, ErrorResult: {customEx.ErrorResult}");

                // Tạo đối tượng ApiResponse từ ErrorResult của CustomException
                var apiResponse = new ApiResponse()
                {
                    Title = customEx.ErrorResult.Title,
                    Success = false,
                    StatusCode = customEx.ErrorResult.StatusCode,
                    Message = customEx.ErrorResult.Message,
                    ErrorDetail = customEx.ErrorResult.ErrorDetail,
                    DataResult = customEx.ErrorResult.DataResult,
                };

                // Trả về ApiResponse
                context.Response.StatusCode = apiResponse.StatusCode;
                await context.Response.WriteAsJsonAsync(apiResponse);
            }
            catch (Exception ex)
            {
                var traceId = Guid.NewGuid();
                _logger.LogError($"Error occurred while processing the request, TraceId: {traceId}, Message: {ex.Message}, StackTrace: {ex.StackTrace}");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var apiResponse = new ApiResponse()
                {
                    Title = "Internal Server Error, TraceId: " + traceId,
                    Success = false,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    ErrorDetail = ex.StackTrace,
                    DataResult = null,
                };
                await context.Response.WriteAsJsonAsync(apiResponse);
            }
        }
    }
}
