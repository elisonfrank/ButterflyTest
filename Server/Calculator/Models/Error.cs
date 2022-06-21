namespace Calculator.Models
{
    public class Error
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

        public Error(int code, string message)
        {
            Code = Convert.ToString(code);
            Message = message;
        }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
