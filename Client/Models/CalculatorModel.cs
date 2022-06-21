using Calculator.Enums;

namespace Calculator.Models
{
    public class CalculatorModel
    {
        public string Display { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public EnumOperations Operation { get; set; }
        public decimal Result { get; set; }
    }
}
