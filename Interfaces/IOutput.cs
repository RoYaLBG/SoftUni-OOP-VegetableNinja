namespace VegetableNinja.Interfaces
{
    public interface IOutput
    {
        void WriteLine(string line);

        void WriteLine(string line, params object[] args);
    }
}
