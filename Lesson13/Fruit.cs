using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson13
{
    public class Fruit
    {
        private string name = string.Empty;
        private string color = string.Empty;


        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(Name));
        }
        public string Color
        {
            get => color;
            set => color = value ?? throw new ArgumentNullException(nameof(Color));
        }

        public Fruit() { }

        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public virtual void Input()
        {
            Console.Write("Enter fruit name: ");
            Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter fruit color: ");
            Color = Console.ReadLine() ?? string.Empty;
        }

        public virtual void Print()
        {
            Console.WriteLine(this);
        }
        public virtual void Input(StreamReader reader)
        {
            Name = reader.ReadLine() ?? string.Empty;
            Color = reader.ReadLine() ?? string.Empty;
        }

        public virtual void Print(StreamWriter writer)
        {
            writer.WriteLine(ToString());
        }

        public override string ToString()
            => $"Fruit: {Name}, Color: {Color}";
    }
}
