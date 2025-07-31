using System.Globalization;

namespace Lesson13
{
    public class Citrus : Fruit
    {
        private double vitaminC;

        public double VitaminC
        {
            get => vitaminC;
            set => vitaminC = value < 0 ? 0 : value;
        }

        public Citrus() { }

        public Citrus(string name, string color, double vitaminC)
            : base(name, color)
        {
            VitaminC = vitaminC;
        }

        public override void Input()
        {
            base.Input();
            Console.Write("Enter vitamin C content (grams): ");
            double v = double.TryParse(Console.ReadLine(), out v) ? v : 0;
            VitaminC = v;
        }

        public override void Print()
        {
            Console.WriteLine(this);
        }

        public override void Input(StreamReader reader)
        {
            base.Input(reader);
            VitaminC = double.TryParse(reader.ReadLine(), out double v) ? v : 0;
        }

        public override void Print(StreamWriter writer)
        {
            writer.WriteLine(ToString());
        }

        public override string ToString()
            => $"Citrus: {Name}, Color: {Color}, Vitamin C: {VitaminC.ToString("0.###", CultureInfo.InvariantCulture)}g";
    }
}
