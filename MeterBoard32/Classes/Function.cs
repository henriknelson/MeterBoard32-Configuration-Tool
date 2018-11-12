namespace MeterBoard32.Classes
{
    public enum Function : byte
    {
        Instantaneous = 0x0,
        Maximum = 0x1,
        Minimum = 0x2,
        ValueDuringError = 0x3
    }
}