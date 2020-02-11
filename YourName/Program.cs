using System;

namespace YourName
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Phone phone = new Phone();
        }
    }

    public class Phone
    {
        // prop tab tab
        public int Number { get; set; }

        public string Color { get; set; }

        public string Manufacturer { get; set; }

        public Phone()
        {
            Number = 262378902;
            Color = "black";
            Manufacturer = "Samsung";
        }

        public Phone (int number, string color, string manu)
        {
            Number = number;
            Color = color;
            Manufacturer = manu;
        }


        // prop full
/*        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }*/

    }
}
