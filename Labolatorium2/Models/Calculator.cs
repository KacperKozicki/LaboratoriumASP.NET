namespace Laboratorium2.Models
    
{
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double? X { get; set; }  
        public double? Y { get; set; }


        public Dictionary<Operators,String>_opDict= new Dictionary<Operators, String>() { 
            { Operators.ADD, "+"},
            { Operators.SUB, "-"},
            { Operators.MUL, "&times;"},
            { Operators.DIV, "&divide"},

        };
         public string Op
            {
                get
                {
                    return _opDict[Operator??Operators.ADD];
                }
            }
        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double? Calc()
        {
            switch (Operator)
            {
                case Operators.ADD:
                    return X + Y;
                case Operators.SUB:
                    return X - Y;
                case Operators.MUL:
                    return X * Y;
                case Operators.DIV:
                    return X / Y;
            }
            return 0;

           
        }
    }
}
