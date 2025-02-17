namespace Blog.API.Utilidad
{
    public class Response<T>
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }
    }

}
