namespace VegetableNinja.Controls.IO
{
    using System;
    using Interfaces;

    public class StandardOutput : IOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteLine(string line, params object[] args)
        {
            Console.WriteLine(line, args);
        }
    }
}
