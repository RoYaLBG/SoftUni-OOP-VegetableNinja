namespace VegetableNinja.Controls.IO
{
    using System;
    using Interfaces;

    public class StandardInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
