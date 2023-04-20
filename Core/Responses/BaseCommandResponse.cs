namespace Core.Responses
{
    public class BaseCommandResponse<T> where T : class
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T ResponseObject { get; set; }
    }

}