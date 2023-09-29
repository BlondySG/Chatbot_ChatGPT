namespace chatbot.Data
{
    public class GPTResponse
    {
        public string? Id { get; set; }
        public string? Object { get; set; }
        public string? Created { get; set; }
        public string? Model { get; set; }
        public Choice[]? Choices { get; set; }
    }

    public class Choice
    {
        public int Index { get; set; }
        public Message? Message { get; set; }
        public string? Finish_reason { get; set; }
    }

    public class Message
    {
        public string? Role { get; set; }
        public string? Content { get; set; }
    }
}
