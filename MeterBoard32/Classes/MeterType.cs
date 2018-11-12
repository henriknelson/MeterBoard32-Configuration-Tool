namespace MeterBoard32.Classes
{
    public enum MeterType: byte
    {
        Other = 0x0,
        Oil = 0x1,
        Electricity = 0x2,
        Gas = 0x3,
        Heat = 0x4,
        Steam = 0x5,
        WarmWater = 0x6,
        Water = 0x7,
        HCA = 0x8,
        CompressedAir = 0x9,
        HotWater = 0x15,
        ColdWater = 0x16,
        Pressure = 0x18
    }
}