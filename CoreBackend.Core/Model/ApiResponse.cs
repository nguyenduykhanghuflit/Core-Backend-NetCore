namespace CoreBackend.Core.Model
{

    public class ApiResponse
    {
        public string? Title { get; set; }

        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public object? ErrorDetail { get; set; }

        public object? DataResult { get; set; }

        // public string? Code { get; set; } // code for developers
    }

}
