namespace VegetableNinja.Controls
{
    using System;
    using Interfaces;

    public class InputArrowKeyReader : IKeyReader
    {
        private readonly IInput input;
        private string lastLine;
        private int charAt;

        public InputArrowKeyReader(IInput input)
        {
            this.input = input;
            this.lastLine = null;
            this.charAt = 0;
        }

        public Key ReadKey()
        {
            if (this.lastLine == null || this.charAt >= this.lastLine.Length)
            {
                this.lastLine = this.input.ReadLine();
                this.charAt = 0;
                if (string.IsNullOrEmpty(this.lastLine))
                {
                    return Key.None;
                }
            }

            char currentChar = this.lastLine[this.charAt++];
            switch (currentChar)
            {
                case 'U':
                    return Key.Up;
                case 'D':
                    return Key.Down;
                case 'R':
                    return Key.Right;
                case 'L':
                    return Key.Left;
                default:
                    throw new NotSupportedException("The key is not supported by the current reader");
            }
        }
    }
}
