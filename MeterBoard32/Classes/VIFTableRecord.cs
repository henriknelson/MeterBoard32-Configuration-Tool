using System;
namespace MeterBoard32.Classes
{
    public enum VIFType
    {
        PrimaryVIF,             // E000 0000b .. E111 1011b     - The unit and multiplier is taken from the table for primary VIF (chapter 8.4.3).
        PlainTextVIF,           // E111 1100b                   - In case of VIF = 7Ch / FCh the true VIF is represented by the following ASCII string with the length given in the first byte.
        LinearVIFExtensionFD,   // FDh and FBh
        LinearVIFExtensionFB,   // FDh and FBh                  - In case of VIF = FDh and VIF = FBh the true VIF is given by the next byte and the coding is taken from the table for secondary VIF (chapter 8.4.4)
        AnyVIF,                 // 7Eh / FEh                    - This VIF-Code can be used in direction master to slave for readout selection of all VIF�s.See chapter 6.4.3.
        ManufacturerSpecific,   // 7Fh / FFh
    }

    public enum VariableDataRecordType : byte
    {
        MBUS_DIB_DIF_WITHOUT_EXTENSION = 0x7F,
        MBUS_DIB_DIF_EXTENSION_BIT = 0x80,
        MBUS_DIB_VIF_WITHOUT_EXTENSION = 0x7F,
        MBUS_DIB_VIF_EXTENSION_BIT = 0x80,
        MBUS_DIB_DIF_MANUFACTURER_SPECIFIC = 0x0F,
        MBUS_DIB_DIF_MORE_RECORDS_FOLLOW = 0x1F,
        MBUS_DIB_DIF_IDLE_FILLER = 0x2F,
    }

    public enum VariableDataQuantityUnit
    {
        Undefined,
        EnergyWh,
        EnergyJ,
        Volume_m3,
        Mass_kg,
        OnTime,
        OperatingTime,
        PowerW,
        PowerJ_per_h,
        VolumeFlowM3_per_h,
        VolumeFlowExtM3_per_min,
        VolumeFlowExtM3_per_s,
        MassFlowKg_per_h,
        FlowTemperatureC,
        ReturnTemperatureC,
        TemperatureDifferenceK,
        ExternalTemperatureC,
        PressureBar,
        TimePoint,
        UnitsForHCA,
        Reserved,
        AveragingDuration,
        ActualityDuration,
        FabricationNo,
        EnhancedIdentification,
        BusAddress,
        Extension_7B,
        VIF_string, // (length in first byte)
        Extension_7D,
        AnyVIF,
        CustomVIF,
        ManufacturerSpecific,
        // VIFE
        ErrorCodesVIFE, // Reserved for object actions (master to slave): see table on page 75 or for error codes (slave to master): see table on page 74"
        Per_second,
        Per_minute,
        Per_hour,
        Per_day,
        Per_week,
        Per_month,
        Per_year,
        Per_RevolutionMeasurement,
        Increment_per_inputPulseOnInputChannel0,
        Increment_per_inputPulseOnInputChannel1,
        Increment_per_outputPulseOnOutputChannel0,
        Increment_per_outputPulseOnOutputChannel1,
        Per_liter,
        Per_m3,
        Per_kg,
        Per_Kelvin,
        Per_kWh,
        Per_GJ,
        Per_kW,
        Per_KelvinLiter,
        Per_Volt,
        Per_Ampere,
        MultipliedBySek,
        MultipliedBySek_per_V,
        MultipliedBySek_per_A,
        StartDateTimeOf,
        UncorrectedUnit, //VIF contains uncorrected unit instead of corrected unit
        AccumulationPositive, //Accumulation only if positive contributions
        AccumulationNegative, //Accumulation of abs value only if negative contributions
        ReservedVIFE_3D, // 0x3d..0x3f - ReservedVIFE
        LimitValue,
        NrOfLimitExceeds,
        DateTimeOfLimitExceed,
        DurationOfLimitExceed,
        DurationOfLimitAbove,
        ReservedVIFE_68,
        DateTimeOfLimitAbove,
        MultiplicativeCorrectionFactor,
        AdditiveCorrectionConstant,
        ReservedVIFE_7C,
        MultiplicativeCorrectionFactor1000,
        ReservedVIFE_7E,
        //ManufacturerSpecific,
        // VIFE_FB
        EnergyMWh,
        ReactiveEnergykVARh,
        ApparentEnergykVAh,
        EnergyGJ,
        ReservedVIFE_FB_0a,
        EnergyMCal,
        //Volume_m3,
        ReservedVIFE_FB_12,
        ReactivePowerkVAR,
        Mass_t,
        RelativeHumidityPercent,
        ReservedVIFE_FB_1a,
        Volume_feet3,
        Volume_american_gallon,
        Volume_flow_american_gallon_per_min,
        Volume_flow_american_gallon_per_h,
        ReservedVIFE_FB_27,
        Power_MW,
        ReservedVIFE_FB_2a,
        FrequencyHz,
        Power_GJ_per_h,
        ApparentPowerkVA,
        ReservedVIFE_FB_32,
        FlowTemperature_F,
        ReturnTemperature_F,
        TemperatureDifference_F,
        ExternalTemperature_F,
        ReservedVIFE_FB_68,
        ColdWarmTemperatureLimit_F,
        ColdWarmTemperatureLimit_C,
        CumulCountMaxPower_W,
        // VIFE_FD
        Credit, // Credit of 10nn-3 of the nominal local legal currency units
        Debit, // Debit of 10nn-3 of the nominal local legal currency units
        AccessNumber, // Access Number (transmission count)
        Medium, // Medium (as in fixed header)
        Manufacturer, // Manufacturer (as in fixed header)
                      //EnhancedIdentification, // Parameter set identification
        ModelVersion, // Model / Version
        HardwareVersionNr,
        FirmwareVersionNr,
        SoftwareVersionNr,
        CustomerLocation,
        Customer,
        AccessCodeUser,
        AccessCodeOperator,
        AccessCodeSystemOperator,
        AccessCodeDeveloper,
        Password,
        ErrorFlags, // (binary)
        ErrorMask,
        ReservedVIFE_FD_19,
        DigitalOutput, // (binary)
        DigitalInput, // (binary)
        Baudrate, // [Baud]
        ResponseDelayTime, // [bittimes]
        Retry,
        ReservedVIFE_FD_1f,
        FirstStorageNr, // for cyclic storage
        LastStorageNr, // for cyclic storage
        SizeOfStorage, // Size of storage block
        ReservedVIFE_FD_23,
        StorageInterval, // [sec(s)..day(s)]
        StorageIntervalMmnth, // month(s)
        StorageIntervalYear, // year(s)
        ReservedVIFE_FD_2a,
        ReservedVIFE_FD_2b,
        DurationSinceLastReadout, // [sec(s)..day(s)]
        StartDateTimeOfTariff,
        DurationOfTariff, // (nn = 01..11: min to days)
        PeriodOfTariff, // [sec(s) to day(s)]
        PeriodOfTariffMonths, // months(s)
        PeriodOfTariffYear, // year(s)
        Dimensionless, // no VIF
        Reserved_FD_3b,
        Reserved_FD_3c,
        Volts, // 10nnnn-9 
        Ampers, // 10nnnn-12
        ResetCounter,
        CumulationCounter,
        ControlSignal,
        DayOfWeek,
        WeekNumber,
        TimePointOfDayChange,
        StateOfParameterActivation,
        SpecialSupplierInformation,
        DurationSinceLastCumulation, // [hour(s)..years(s)]
        OperatingTimeBattery, // [hour(s)..years(s)]
        DateTimeOfBatteryChange,
        Reserved_FD_71,
    }

    public static class UnitPrefix
    {
        public static string GetUnitPrefix(int magnitude)
        {
            switch (magnitude)
            {
                case 0: return string.Empty;
                case -3: return "m";
                case -6: return "my";
                case 1: return "10 ";
                case 2: return "100 ";
                case 3: return "k";
                case 4: return "10 k";
                case 5: return "100 k";
                case 6: return "M";
                case 9: return "T";
                default: return $"1e {magnitude}";
            }
        }
    }

    public class VIFTableRecord
    {
        public byte VIF { get; }
        public double Exponent { get; }
        public string Quantity { get; }
        public string Unit { get; set; }
        public VariableDataQuantityUnit Units { get; }
        public VIFType Type { get; }
        public Func<byte, int> Magnitude { get; }
        public Func<int, string> Name { get; }

        public VIFTableRecord(byte vif, double exponent, string unit, string quantity, VariableDataQuantityUnit units, VIFType type, Func<byte, int> magnitude, Func<int, string> name)
        {
            VIF = vif;
            Exponent = exponent;
            Quantity = quantity;
            Unit = unit;
            Units = units;
            Type = type;
            Magnitude = magnitude;
            Name = name;
        }

        public override string ToString()
        {
            return Name(Magnitude(VIF));
        }

        public static readonly VIFTableRecord[] VifFixedTable =
        {
            /* 00, 01 left out */
            new VIFTableRecord(0x02, 1.0e0, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x03, 1.0e1, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x04, 1.0e2, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x05, 1.0e3, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x06, 1.0e4, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x07, 1.0e5, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x08, 1.0e6, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x09, 1.0e7, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0A, 1.0e8, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0B, 1.0e3, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0C, 1.0e4, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0D, 1.0e5, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0E, 1.0e6, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x0F, 1.0e7, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x10, 1.0e8, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x11, 1.0e9, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x12, 1.0e10,"J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x13, 1.0e11,"J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x14, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x15, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x16, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x17, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x18, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x19, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1A, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1B, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1C, 1.0e0, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1D, 1.0e3, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1E, 1.0e4, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x1F, 1.0e5, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x20, 1.0e6, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x21, 1.0e7, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x22, 1.0e8, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x23, 1.0e9, "J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x24, 1.0e10,"J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x25, 1.0e11,"J/h", "Energy", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x26, 1.0e-6,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x27, 1.0e-5,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x28, 1.0e-4,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x29, 1.0e-3,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2A, 1.0e-2,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2B, 1.0e-1,"m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2C, 1.0e0, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2D, 1.0e1, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2E, 1.0e2, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x2F, 1.0e-5,"m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x31, 1.0e-4,"m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x32, 1.0e-3,"m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x33, 1.0e-2,"m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x34, 1.0e-1,"m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x35, 1.0e0, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x36, 1.0e1, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x37, 1.0e2, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x38, 1.0e-3, "°C", "Temperature", VariableDataQuantityUnit.ReturnTemperatureC, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x39, 1.0e0, "Units for H.C.A.", "H.C.A.", VariableDataQuantityUnit.UnitsForHCA, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3A, 0.0, "Reserved", "Reserved", VariableDataQuantityUnit.Reserved, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3B, 0.0, "Reserved", "Reserved", VariableDataQuantityUnit.Reserved, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3C, 0.0, "Reserved", "Reserved", VariableDataQuantityUnit.Reserved, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3D, 0.0, "Reserved", "Reserved", VariableDataQuantityUnit.Reserved, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3E, 1.0e0, "", "historic", VariableDataQuantityUnit.Undefined, VIFType.PrimaryVIF, b => 0, n => $""),
            new VIFTableRecord(0x3F, 1.0e0, "", "No units", VariableDataQuantityUnit.Undefined, VIFType.PrimaryVIF, b => 0, n => $""),
        };

        public static readonly VIFTableRecord[] VifVariableTable =
        {
            /*  Primary VIFs (main table), range 0x00 - 0xFF */

            /*  E000 0nnn    Energy Wh (0.001Wh to 10000Wh) */
            new VIFTableRecord ( 0x00, 1.0e-3, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x01, 1.0e-2, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x02, 1.0e-1, "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x03, 1.0e0,  "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x04, 1.0e1,  "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x05, 1.0e2,  "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x06, 1.0e3,  "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),
            new VIFTableRecord ( 0x07, 1.0e4,  "Wh", "Energy", VariableDataQuantityUnit.EnergyWh, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}Wh)"),

            /* E000 1nnn    Energy  J (0.001kJ to 10000kJ) */
            new VIFTableRecord ( 0x08, 1.0e0, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x09, 1.0e1, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0A, 1.0e2, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0B, 1.0e3, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0C, 1.0e4, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0D, 1.0e5, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0E, 1.0e6, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),
            new VIFTableRecord ( 0x0F, 1.0e7, "J", "Energy", VariableDataQuantityUnit.EnergyJ, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Energy ({UnitPrefix.GetUnitPrefix(n)}J)"),

            /* E001 0nnn    Volume m^3 (0.001l to 10000l) */
            new VIFTableRecord ( 0x10, 1.0e-6, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x11, 1.0e-5, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x12, 1.0e-4, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x13, 1.0e-3, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x14, 1.0e-2, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x15, 1.0e-1, "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x16, 1.0e0,  "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),
            new VIFTableRecord ( 0x17, 1.0e1,  "m^3", "Volume", VariableDataQuantityUnit.Volume_m3, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)}m^3)"),

            /* E001 1nnn    Mass kg (0.001kg to 10000kg) */
            new VIFTableRecord ( 0x18, 1.0e-3, "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x19, 1.0e-2, "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1A, 1.0e-1, "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1B, 1.0e0,  "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1C, 1.0e1,  "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1D, 1.0e2,  "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1E, 1.0e3,  "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),
            new VIFTableRecord ( 0x1F, 1.0e4,  "kg", "Mass", VariableDataQuantityUnit.Mass_kg, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)}kg)"),

            /* E010 00nn    On Time s */
            new VIFTableRecord ( 0x20,     1.0, "s", "On time", VariableDataQuantityUnit.OnTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "On Time (seconds)"),  /* seconds */
            new VIFTableRecord ( 0x21,    60.0, "s", "On time", VariableDataQuantityUnit.OnTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "On Time (minutes)"),  /* minutes */
            new VIFTableRecord ( 0x22,  3600.0, "s", "On time", VariableDataQuantityUnit.OnTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "On Time (hours)"),  /* hours   */
            new VIFTableRecord ( 0x23, 86400.0, "s", "On time", VariableDataQuantityUnit.OnTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "On Time (days)"),  /* days    */

            /* E010 01nn    Operating Time s */
            new VIFTableRecord ( 0x24,     1.0, "s", "Operating time", VariableDataQuantityUnit.OperatingTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "Operating Time (seconds)"),  /* seconds */
            new VIFTableRecord ( 0x25,    60.0, "s", "Operating time", VariableDataQuantityUnit.OperatingTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "Operating Time (minutes)"),  /* minutes */
            new VIFTableRecord ( 0x26,  3600.0, "s", "Operating time", VariableDataQuantityUnit.OperatingTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "Operating Time (hours)"),  /* hours   */
            new VIFTableRecord ( 0x27, 86400.0, "s", "Operating time", VariableDataQuantityUnit.OperatingTime, VIFType.PrimaryVIF, b => (b & 0x03), n => "Operating Time (days)"),  /* days    */

            /* E010 1nnn    Power W (0.001W to 10000W) */
            new VIFTableRecord ( 0x28, 1.0e-3, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x29, 1.0e-2, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2A, 1.0e-1, "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2B, 1.0e0,  "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2C, 1.0e1,  "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2D, 1.0e2,  "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2E, 1.0e3,  "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),
            new VIFTableRecord ( 0x2F, 1.0e4,  "W", "Power", VariableDataQuantityUnit.PowerW, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Power ({UnitPrefix.GetUnitPrefix(n)}W)"),

            /* E011 0nnn    Power J/h (0.001kJ/h to 10000kJ/h) */
            new VIFTableRecord ( 0x30, 1.0e0, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x31, 1.0e1, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x32, 1.0e2, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x33, 1.0e3, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x34, 1.0e4, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x35, 1.0e5, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x36, 1.0e6, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),
            new VIFTableRecord ( 0x37, 1.0e7, "J/h", "Power", VariableDataQuantityUnit.PowerJ_per_h, VIFType.PrimaryVIF, b => (b & 0x07), n => $"Power ({UnitPrefix.GetUnitPrefix(n)}J/h)"),

            /* E011 1nnn    Volume Flow m3/h (0.001l/h to 10000l/h) */
            new VIFTableRecord ( 0x38, 1.0e-6, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x39, 1.0e-5, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3A, 1.0e-4, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3B, 1.0e-3, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3C, 1.0e-2, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3D, 1.0e-1, "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3E, 1.0e0,  "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),
            new VIFTableRecord ( 0x3F, 1.0e1,  "m^3/h", "Volume flow", VariableDataQuantityUnit.VolumeFlowM3_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 6, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/h)"),

            /* E100 0nnn     Volume Flow ext.  m^3/min (0.0001l/min to 1000l/min) */
            new VIFTableRecord ( 0x40, 1.0e-7, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x41, 1.0e-6, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x42, 1.0e-5, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x43, 1.0e-4, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x44, 1.0e-3, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x45, 1.0e-2, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x46, 1.0e-1, "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),
            new VIFTableRecord ( 0x47, 1.0e0,  "m^3/min", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_min, VIFType.PrimaryVIF, b => (b & 0x07) - 7, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/min)"),

            /* E100 1nnn     Volume Flow ext.  m^3/s (0.001ml/s to 10000ml/s) */
            new VIFTableRecord ( 0x48, 1.0e-9, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x49, 1.0e-8, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4A, 1.0e-7, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4B, 1.0e-6, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4C, 1.0e-5, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4D, 1.0e-4, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4E, 1.0e-3, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),
            new VIFTableRecord ( 0x4F, 1.0e-2, "m^3/s", "Volume flow", VariableDataQuantityUnit.VolumeFlowExtM3_per_s, VIFType.PrimaryVIF, b => (b & 0x07) - 9, n => $"Volume flow ({UnitPrefix.GetUnitPrefix(n)} m^3/s)"),

            /* E101 0nnn     Mass flow kg/h (0.001kg/h to 10000kg/h) */
            new VIFTableRecord ( 0x50, 1.0e-3, "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x51, 1.0e-2, "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x52, 1.0e-1, "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x53, 1.0e0,  "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x54, 1.0e1,  "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x55, 1.0e2,  "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x56, 1.0e3,  "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),
            new VIFTableRecord ( 0x57, 1.0e4,  "kg/h", "Mass flow", VariableDataQuantityUnit.MassFlowKg_per_h, VIFType.PrimaryVIF, b => (b & 0x07) - 3, n => $"Mass flow ({UnitPrefix.GetUnitPrefix(n)} kg/h)"),

            /* E101 10nn     Flow Temperature °C (0.001°C to 1°C) */
            new VIFTableRecord ( 0x58, 1.0e-3, "°C", "Flow temperature", VariableDataQuantityUnit.FlowTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Flow temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x59, 1.0e-2, "°C", "Flow temperature", VariableDataQuantityUnit.FlowTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Flow temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x5A, 1.0e-1, "°C", "Flow temperature", VariableDataQuantityUnit.FlowTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Flow temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x5B, 1.0e0,  "°C", "Flow temperature", VariableDataQuantityUnit.FlowTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Flow temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),

            /* E101 11nn Return Temperature °C (0.001°C to 1°C) */
            new VIFTableRecord ( 0x5C, 1.0e-3, "°C", "Return temperature", VariableDataQuantityUnit.ReturnTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Return temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x5D, 1.0e-2, "°C", "Return temperature", VariableDataQuantityUnit.ReturnTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Return temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x5E, 1.0e-1, "°C", "Return temperature", VariableDataQuantityUnit.ReturnTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Return temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),
            new VIFTableRecord ( 0x5F, 1.0e0,  "°C", "Return temperature", VariableDataQuantityUnit.ReturnTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Return temperature ({UnitPrefix.GetUnitPrefix(n)}deg C)"),

            /* E110 00nn    Temperature Difference  K   (mK to  K) */
            new VIFTableRecord ( 0x60, 1.0e-3, "K", "Temperature difference", VariableDataQuantityUnit.TemperatureDifferenceK, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Temperature Difference ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x61, 1.0e-2, "K", "Temperature difference", VariableDataQuantityUnit.TemperatureDifferenceK, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Temperature Difference ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x62, 1.0e-1, "K", "Temperature difference", VariableDataQuantityUnit.TemperatureDifferenceK, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Temperature Difference ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x63, 1.0e0,  "K", "Temperature difference", VariableDataQuantityUnit.TemperatureDifferenceK, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Temperature Difference ({UnitPrefix.GetUnitPrefix(n)} deg C)"),

            /* E110 01nn     External Temperature °C (0.001°C to 1°C) */
            new VIFTableRecord ( 0x64, 1.0e-3, "°C", "External temperature", VariableDataQuantityUnit.ExternalTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"External temperature ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x65, 1.0e-2, "°C", "External temperature", VariableDataQuantityUnit.ExternalTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"External temperature ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x66, 1.0e-1, "°C", "External temperature", VariableDataQuantityUnit.ExternalTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"External temperature ({UnitPrefix.GetUnitPrefix(n)} deg C)"),
            new VIFTableRecord ( 0x67, 1.0e0,  "°C", "External temperature", VariableDataQuantityUnit.ExternalTemperatureC, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"External temperature ({UnitPrefix.GetUnitPrefix(n)} deg C)"),

            /* E110 10nn     Pressure bar (1mbar to 1000mbar) */
            new VIFTableRecord ( 0x68, 1.0e-3, "bar", "Pressure", VariableDataQuantityUnit.PressureBar, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Pressure ({UnitPrefix.GetUnitPrefix(n)} bar)"),
            new VIFTableRecord ( 0x69, 1.0e-2, "bar", "Pressure", VariableDataQuantityUnit.PressureBar, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Pressure ({UnitPrefix.GetUnitPrefix(n)} bar)"),
            new VIFTableRecord ( 0x6A, 1.0e-1, "bar", "Pressure", VariableDataQuantityUnit.PressureBar, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Pressure ({UnitPrefix.GetUnitPrefix(n)} bar)"),
            new VIFTableRecord ( 0x6B, 1.0e0,  "bar", "Pressure", VariableDataQuantityUnit.PressureBar, VIFType.PrimaryVIF, b => (b & 0x03) - 3, n => $"Pressure ({UnitPrefix.GetUnitPrefix(n)} bar)"),

            /* E110 110n     Time Point */
            new VIFTableRecord ( 0x6C, 1.0e0, "-", "Time point (date)", VariableDataQuantityUnit.TimePoint, VIFType.PrimaryVIF, b => b & 0x01, n => "Time point (date)"),            /* n = 0        date, data type G */
            new VIFTableRecord ( 0x6D, 1.0e0, "-", "Time point (date & time)", VariableDataQuantityUnit.TimePoint, VIFType.PrimaryVIF, b => b & 0x01, n => "Time point (date & time)"),     /* n = 1 time & date, data type F */

            /* E110 1110     Units for H.C.A. dimensionless */
            new VIFTableRecord ( 0x6E, 1.0e0,  "Units for H.C.A.", "H.C.A.", VariableDataQuantityUnit.UnitsForHCA, VIFType.PrimaryVIF, b => 0, n => "Units for H.C.A."),

            /* E110 1111     Reserved */
            new VIFTableRecord ( 0x6F, 0.0,  "Reserved", "Reserved", VariableDataQuantityUnit.Reserved, VIFType.PrimaryVIF, b => 0, n => "Reserved"),

            /* E111 00nn     Averaging Duration s */
            new VIFTableRecord ( 0x70,     1.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (seconds)"),  /* seconds */
            new VIFTableRecord ( 0x71,    60.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (minutes)"),  /* minutes */
            new VIFTableRecord ( 0x72,  3600.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (hours)"),  /* hours   */
            new VIFTableRecord ( 0x73, 86400.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (days)"),  /* days    */

            /* E111 01nn     Actuality Duration s */
            new VIFTableRecord ( 0x74,     1.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (seconds)"),  /* seconds */
            new VIFTableRecord ( 0x75,    60.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (minutes)"),  /* minutes */
            new VIFTableRecord ( 0x76,  3600.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (hours)"),  /* hours   */
            new VIFTableRecord ( 0x77, 86400.0, "s", "Averaging Duration", VariableDataQuantityUnit.AveragingDuration, VIFType.PrimaryVIF, b => (b & 0x03), n => "Averaging Duration (days)"),  /* days    */

            /* Fabrication No */
            new VIFTableRecord ( 0x78, 1.0, "", "Fabrication No", VariableDataQuantityUnit.FabricationNo, VIFType.PrimaryVIF, b => 0, n => "Fabrication No"),

            /* E111 1001 (Enhanced) Identification */
            new VIFTableRecord ( 0x79, 1.0, "", "(Enhanced) Identification", VariableDataQuantityUnit.EnhancedIdentification, VIFType.PrimaryVIF, b => 0, n => "(Enhanced) Identification"),

            /* E111 1010 Bus Address */
            new VIFTableRecord ( 0x7a, 1.0, "", "Bus Address", VariableDataQuantityUnit.BusAddress, VIFType.PrimaryVIF, b => 0, n => "Bus Address"),

            new VIFTableRecord ( 0xfb, 1.0, "", "Extension FB", VariableDataQuantityUnit.Extension_7B, VIFType.LinearVIFExtensionFB, b => 0, n => "Extension FB"),

            new VIFTableRecord ( 0xfd, 1.0, "", "Extension FD", VariableDataQuantityUnit.Extension_7D, VIFType.LinearVIFExtensionFD, b => 0, n => "Extension FD"),

            new VIFTableRecord ( 0xfc, 1.0, "", "Custom VIF", VariableDataQuantityUnit.CustomVIF, VIFType.PlainTextVIF, b => 0, n => "Custom VIF"),
            /* Any VIF: 7Eh */
            new VIFTableRecord ( 0xfe, 1.0, "", "Any VIF", VariableDataQuantityUnit.AnyVIF, VIFType.AnyVIF, b => 0, n => "Any VIF"),

            /* Manufacturer specific: 7Fh */
            new VIFTableRecord ( 0xff, 1.0, "", "Manufacturer specific", VariableDataQuantityUnit.ManufacturerSpecific, VIFType.ManufacturerSpecific, b => 0, n => "Manufacturer specific"),
        };
    }

    public class VifeFbTableRecord
    {
        public byte VIFFB { get; }
        public double Exponent { get; }
        public VariableDataQuantityUnit Units { get; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public Func<byte, int> Magnitude { get; }
        public Func<int, string> Name { get; }

        public VifeFbTableRecord(byte viffb, double exponent, VariableDataQuantityUnit units, Func<byte, int> magnitude, Func<int,string> name)
        {
            VIFFB = viffb;
            Exponent = exponent;
            Units = units;
            Magnitude = magnitude;
            Name = name;
        }

        public override string ToString()
        {
            return Name(Magnitude(VIFFB));
        }

        public static readonly VifeFbTableRecord[] VifeFbTable =
        {
            new VifeFbTableRecord(0x00, 1.0e-1, VariableDataQuantityUnit.EnergyMWh, b => (b & 0x01) - 1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MWh)"),
            new VifeFbTableRecord(0x01, 1.0e0,  VariableDataQuantityUnit.EnergyMWh, b => (b & 0x01) - 1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MWh)"),
            new VifeFbTableRecord(0x02, 1.0e0, VariableDataQuantityUnit.ReactiveEnergykVARh, b => (b & 0x01), n => $"Reactive Energy ({UnitPrefix.GetUnitPrefix(n)} kVARh)"),
            new VifeFbTableRecord(0x03, 1.0e0, VariableDataQuantityUnit.ReactiveEnergykVARh, b => (b & 0x01), n => $"Reactive Energy ({UnitPrefix.GetUnitPrefix(n)} kVARh)"),
            new VifeFbTableRecord(0x04, 1.0e0, VariableDataQuantityUnit.ApparentEnergykVAh, b => (b & 0x01), n => $"Apparent Energy ({UnitPrefix.GetUnitPrefix(n)} kVAh)"),
            new VifeFbTableRecord(0x05, 1.0e0, VariableDataQuantityUnit.ApparentEnergykVAh, b => (b & 0x01), n => $"Apparent Energy ({UnitPrefix.GetUnitPrefix(n)} kVAh)"),
            //new VifeFbTableRecord(0x06, VariableDataQuantityUnit.ReservedVIFE_FB_04, b => (b & 0x01)),
            //new VifeFbTableRecord(0x07, VariableDataQuantityUnit.ReservedVIFE_FB_04, b => (b & 0x01)),
            new VifeFbTableRecord(0x08, 1.0e-1, VariableDataQuantityUnit.EnergyGJ, b => (b & 0x01) - 1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} GJ)"),
            new VifeFbTableRecord(0x09, 1.0e0,  VariableDataQuantityUnit.EnergyGJ, b => (b & 0x01) - 1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} GJ)"),
            //new VifeFbTableRecord(0x0a, VariableDataQuantityUnit.ReservedVIFE_FB_0a, b => (b & 0x01)),
            //new VifeFbTableRecord(0x0b, VariableDataQuantityUnit.ReservedVIFE_FB_0a, b => (b & 0x01)),
            new VifeFbTableRecord(0x0c, 1.0e-1,VariableDataQuantityUnit.EnergyMCal, b => (b & 0x03) -1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            new VifeFbTableRecord(0x0d, 1.0e0, VariableDataQuantityUnit.EnergyMCal, b => (b & 0x03) -1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            new VifeFbTableRecord(0x0e, 1.0e1, VariableDataQuantityUnit.EnergyMCal, b => (b & 0x03) -1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            new VifeFbTableRecord(0x0f, 1.0e2, VariableDataQuantityUnit.EnergyMCal, b => (b & 0x03) -1, n => $"Energy ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            new VifeFbTableRecord(0x10, 1.0e2, VariableDataQuantityUnit.Volume_m3, b => (b & 0x01) + 2, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            new VifeFbTableRecord(0x11, 1.0e3, VariableDataQuantityUnit.Volume_m3, b => (b & 0x01) + 2, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)} MCal)"),
            //new VifeFbTableRecord(0x12, VariableDataQuantityUnit.ReservedVIFE_FB_12, b => (b & 0x01)),
            //new VifeFbTableRecord(0x13, VariableDataQuantityUnit.ReservedVIFE_FB_12, b => (b & 0x01)),
            new VifeFbTableRecord(0x14, 1.0e-3, VariableDataQuantityUnit.ReactivePowerkVAR, b => (b & 0x03) -3, n => $"Reactive Power ({UnitPrefix.GetUnitPrefix(n)} kVAR)"),
            new VifeFbTableRecord(0x15, 1.0e-2, VariableDataQuantityUnit.ReactivePowerkVAR, b => (b & 0x03) -3, n => $"Reactive Power ({UnitPrefix.GetUnitPrefix(n)} kVAR)"),
            new VifeFbTableRecord(0x16, 1.0e-1, VariableDataQuantityUnit.ReactivePowerkVAR, b => (b & 0x03) -3, n => $"Reactive Power ({UnitPrefix.GetUnitPrefix(n)} kVAR)"),
            new VifeFbTableRecord(0x17, 1.0e0,  VariableDataQuantityUnit.ReactivePowerkVAR, b => (b & 0x03) -3, n => $"Reactive Power ({UnitPrefix.GetUnitPrefix(n)} kVAR)"),
            new VifeFbTableRecord(0x18, 1.0e2, VariableDataQuantityUnit.Mass_t, b => (b & 0x01) + 2, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)} t)"),
            new VifeFbTableRecord(0x19, 1.0e3, VariableDataQuantityUnit.Mass_t, b => (b & 0x01) + 2, n => $"Mass ({UnitPrefix.GetUnitPrefix(n)} t)"),
            new VifeFbTableRecord(0x1a, 1.0e-1, VariableDataQuantityUnit.RelativeHumidityPercent, b => (b & 0x01) -1, n => $"Relative Humidity ({UnitPrefix.GetUnitPrefix(n)} %)"),
            new VifeFbTableRecord(0x1b, 1.0e0,  VariableDataQuantityUnit.RelativeHumidityPercent, b => (b & 0x01) -1, n => $"Relative Humidity ({UnitPrefix.GetUnitPrefix(n)} %)"),
            //new VifeFbTableRecord(0x1c, VariableDataQuantityUnit.ReservedVIFE_FB_1a, b => (b - 0x1a)),
            //new VifeFbTableRecord(0x1d, VariableDataQuantityUnit.ReservedVIFE_FB_1a, b => (b - 0x1a)),
            //new VifeFbTableRecord(0x1e, VariableDataQuantityUnit.ReservedVIFE_FB_1a, b => (b - 0x1a)),
            //new VifeFbTableRecord(0x1f, VariableDataQuantityUnit.ReservedVIFE_FB_1a, b => (b - 0x1a)),
            new VifeFbTableRecord(0x20,1.0e0, VariableDataQuantityUnit.Volume_feet3, b => 0, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)} feet^3)"),
            new VifeFbTableRecord(0x21,1.0e0, VariableDataQuantityUnit.Volume_feet3, b => -1, n => $"Volume ({UnitPrefix.GetUnitPrefix(n)} feet^3)"),
            /*new VifeFbTableRecord(0x22, VariableDataQuantityUnit.Volume_american_gallon, b => (b - 0x23)),
            new VifeFbTableRecord(0x23, VariableDataQuantityUnit.Volume_american_gallon, b => (b - 0x23)),
            new VifeFbTableRecord(0x24, VariableDataQuantityUnit.Volume_flow_american_gallon_per_min, b => -3),
            new VifeFbTableRecord(0x25, VariableDataQuantityUnit.Volume_flow_american_gallon_per_min, b => 0),
            new VifeFbTableRecord(0x26, VariableDataQuantityUnit.Volume_flow_american_gallon_per_h, b => 0),
            new VifeFbTableRecord(0x27, VariableDataQuantityUnit.ReservedVIFE_FB_27, b => 0),
            new VifeFbTableRecord(0x28, VariableDataQuantityUnit.Power_MW, b => (b & 0x01) - 1),
            new VifeFbTableRecord(0x29, VariableDataQuantityUnit.Power_MW, b => (b & 0x01) - 1),
            new VifeFbTableRecord(0x2a, VariableDataQuantityUnit.ReservedVIFE_FB_2a, b => (b & 0x01)),
            new VifeFbTableRecord(0x2b, VariableDataQuantityUnit.ReservedVIFE_FB_2a, b => (b & 0x01)),*/
            new VifeFbTableRecord(0x2c, 1.0e-3, VariableDataQuantityUnit.FrequencyHz, b => (b & 0x03) -3, n => $"Frequency ({UnitPrefix.GetUnitPrefix(n)} Hz)"),
            new VifeFbTableRecord(0x2d, 1.0e-2, VariableDataQuantityUnit.FrequencyHz, b => (b & 0x03) -3, n => $"Frequency ({UnitPrefix.GetUnitPrefix(n)} Hz)"),
            new VifeFbTableRecord(0x2e, 1.0e-1, VariableDataQuantityUnit.FrequencyHz, b => (b & 0x03) -3, n => $"Frequency ({UnitPrefix.GetUnitPrefix(n)} Hz)"),
            new VifeFbTableRecord(0x2f, 1.0e0,  VariableDataQuantityUnit.FrequencyHz, b => (b & 0x03) -3, n => $"Frequency ({UnitPrefix.GetUnitPrefix(n)} Hz)"),
            new VifeFbTableRecord(0x30, 1.0e-1, VariableDataQuantityUnit.Power_GJ_per_h, b => (b & 0x01) - 1, n => $"Power ({UnitPrefix.GetUnitPrefix(n)} GJ/h)"),
            new VifeFbTableRecord(0x31, 1.0e0,  VariableDataQuantityUnit.Power_GJ_per_h, b => (b & 0x01) - 1, n => $"Power ({UnitPrefix.GetUnitPrefix(n)} GJ/h)"),
            //new VifeFbTableRecord(0x32, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            //new VifeFbTableRecord(0x33, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x34, 1.0e-3, VariableDataQuantityUnit.ApparentPowerkVA, b => (b & 0x03) -3, n => $"Apparent Power ({UnitPrefix.GetUnitPrefix(n)} kVA)"),
            new VifeFbTableRecord(0x35, 1.0e-2, VariableDataQuantityUnit.ApparentPowerkVA, b => (b & 0x03) -3, n => $"Apparent Power ({UnitPrefix.GetUnitPrefix(n)} kVA)"),
            new VifeFbTableRecord(0x36, 1.0e-1, VariableDataQuantityUnit.ApparentPowerkVA, b => (b & 0x03) -3, n => $"Apparent Power ({UnitPrefix.GetUnitPrefix(n)} kVA)"),
            new VifeFbTableRecord(0x37, 1.0e0,  VariableDataQuantityUnit.ApparentPowerkVA, b => (b & 0x03) -3, n => $"Apparent Power ({UnitPrefix.GetUnitPrefix(n)} kVA)"),
            /*new VifeFbTableRecord(0x38, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x39, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3a, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3b, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3c, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3d, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3e, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x3f, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x40, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x41, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x42, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x43, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x44, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x45, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x46, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x47, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x48, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x49, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4a, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4b, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4c, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4d, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4e, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x4f, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x50, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x51, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x52, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x53, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x54, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x55, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x56, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x57, VariableDataQuantityUnit.ReservedVIFE_FB_32, b => (b - 0x32)),
            new VifeFbTableRecord(0x58, VariableDataQuantityUnit.FlowTemperature_F, b => (b - 0x32)),
            new VifeFbTableRecord(0x59, VariableDataQuantityUnit.FlowTemperature_F, b => (b - 0x32)),
            new VifeFbTableRecord(0x5a, VariableDataQuantityUnit.FlowTemperature_F, b => (b - 0x32)),
            new VifeFbTableRecord(0x5b, VariableDataQuantityUnit.FlowTemperature_F, b => (b - 0x32)),
            new VifeFbTableRecord(0x5c, VariableDataQuantityUnit.ReturnTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x5d, VariableDataQuantityUnit.ReturnTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x5e, VariableDataQuantityUnit.ReturnTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x5f, VariableDataQuantityUnit.ReturnTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x60, VariableDataQuantityUnit.TemperatureDifference_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x61, VariableDataQuantityUnit.TemperatureDifference_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x62, VariableDataQuantityUnit.TemperatureDifference_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x63, VariableDataQuantityUnit.TemperatureDifference_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x64, VariableDataQuantityUnit.ExternalTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x65, VariableDataQuantityUnit.ExternalTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x66, VariableDataQuantityUnit.ExternalTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x67, VariableDataQuantityUnit.ExternalTemperature_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x68, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x69, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6a, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6b, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6c, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6d, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6e, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x6f, VariableDataQuantityUnit.ReservedVIFE_FB_68, b => (b & 0x07)),
            new VifeFbTableRecord(0x70, VariableDataQuantityUnit.ColdWarmTemperatureLimit_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x71, VariableDataQuantityUnit.ColdWarmTemperatureLimit_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x72, VariableDataQuantityUnit.ColdWarmTemperatureLimit_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x73, VariableDataQuantityUnit.ColdWarmTemperatureLimit_F, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x74, VariableDataQuantityUnit.ColdWarmTemperatureLimit_C, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x75, VariableDataQuantityUnit.ColdWarmTemperatureLimit_C, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x76, VariableDataQuantityUnit.ColdWarmTemperatureLimit_C, b => (b & 0x03) - 3),
            new VifeFbTableRecord(0x77, VariableDataQuantityUnit.ColdWarmTemperatureLimit_C, b => (b & 0x03) - 3),*/
            new VifeFbTableRecord(0x78, 1.0e-3, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x79, 1.0e-2, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7a, 1.0e-1, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7b, 1.0e0, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7c, 1.0e1, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7d, 1.0e2, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7e, 1.0e3, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
            new VifeFbTableRecord(0x7f, 1.0e4, VariableDataQuantityUnit.CumulCountMaxPower_W, b => (b & 0x07) - 3, n => $"Cumulative Max of Active Power ({UnitPrefix.GetUnitPrefix(n)} W)"),
        };
    }

    public class VifeFdTableRecord
    {
        public byte VIFFD { get; }
        public VariableDataQuantityUnit Units { get; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public Func<byte, int> Magnitude { get; }

        public VifeFdTableRecord(byte viffd, VariableDataQuantityUnit units, Func<byte, int> magnitude)
        {
            VIFFD = viffd;
            Units = units;
            Magnitude = magnitude;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Enum.GetName(typeof(VariableDataQuantityUnit), Units), Magnitude(VIFFD));
        }

        public static readonly VifeFdTableRecord[] VifeFdTable =
        {
            new VifeFdTableRecord(0x00, VariableDataQuantityUnit.Credit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x01, VariableDataQuantityUnit.Credit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x02, VariableDataQuantityUnit.Credit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x03, VariableDataQuantityUnit.Credit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x04, VariableDataQuantityUnit.Debit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x05, VariableDataQuantityUnit.Debit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x06, VariableDataQuantityUnit.Debit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x07, VariableDataQuantityUnit.Debit, b => (b & 0x03) - 3),
            new VifeFdTableRecord(0x08, VariableDataQuantityUnit.AccessNumber, b => 0),
            new VifeFdTableRecord(0x09, VariableDataQuantityUnit.Medium, b => 0),
            new VifeFdTableRecord(0x0a, VariableDataQuantityUnit.Manufacturer, b => 0),
            new VifeFdTableRecord(0x0b, VariableDataQuantityUnit.EnhancedIdentification, b => 0),
            new VifeFdTableRecord(0x0c, VariableDataQuantityUnit.ModelVersion, b => 0),
            new VifeFdTableRecord(0x0d, VariableDataQuantityUnit.HardwareVersionNr, b => 0),
            new VifeFdTableRecord(0x0e, VariableDataQuantityUnit.FirmwareVersionNr, b => 0),
            new VifeFdTableRecord(0x0f, VariableDataQuantityUnit.SoftwareVersionNr, b => 0),
            new VifeFdTableRecord(0x10, VariableDataQuantityUnit.CustomerLocation, b => 0),
            new VifeFdTableRecord(0x11, VariableDataQuantityUnit.Customer, b => 0),
            new VifeFdTableRecord(0x12, VariableDataQuantityUnit.AccessCodeUser, b => 0),
            new VifeFdTableRecord(0x13, VariableDataQuantityUnit.AccessCodeOperator, b => 0),
            new VifeFdTableRecord(0x14, VariableDataQuantityUnit.AccessCodeSystemOperator, b => 0),
            new VifeFdTableRecord(0x15, VariableDataQuantityUnit.AccessCodeDeveloper, b => 0),
            new VifeFdTableRecord(0x16, VariableDataQuantityUnit.Password, b => 0),
            new VifeFdTableRecord(0x17, VariableDataQuantityUnit.ErrorFlags, b => 0),
            new VifeFdTableRecord(0x18, VariableDataQuantityUnit.ErrorMask, b => 0),
            new VifeFdTableRecord(0x19, VariableDataQuantityUnit.ReservedVIFE_FD_19, b => 0),
            new VifeFdTableRecord(0x1a, VariableDataQuantityUnit.DigitalOutput, b => 0),
            new VifeFdTableRecord(0x1b, VariableDataQuantityUnit.DigitalInput, b => 0),
            new VifeFdTableRecord(0x1c, VariableDataQuantityUnit.Baudrate, b => 0),
            new VifeFdTableRecord(0x1d, VariableDataQuantityUnit.ResponseDelayTime, b => 0),
            new VifeFdTableRecord(0x1e, VariableDataQuantityUnit.Retry, b => 0),
            new VifeFdTableRecord(0x1f, VariableDataQuantityUnit.ReservedVIFE_FD_1f, b => 0),
            new VifeFdTableRecord(0x20, VariableDataQuantityUnit.FirstStorageNr, b => 0),
            new VifeFdTableRecord(0x21, VariableDataQuantityUnit.LastStorageNr, b => 0),
            new VifeFdTableRecord(0x22, VariableDataQuantityUnit.SizeOfStorage, b => 0),
            new VifeFdTableRecord(0x23, VariableDataQuantityUnit.ReservedVIFE_FD_23, b => 0),
            new VifeFdTableRecord(0x24, VariableDataQuantityUnit.StorageInterval, b => 0),
            new VifeFdTableRecord(0x25, VariableDataQuantityUnit.StorageInterval, b => 0),
            new VifeFdTableRecord(0x26, VariableDataQuantityUnit.StorageInterval, b => 0),
            new VifeFdTableRecord(0x27, VariableDataQuantityUnit.StorageInterval, b => b & 0x03),
            new VifeFdTableRecord(0x28, VariableDataQuantityUnit.StorageIntervalMmnth, b => 0),
            new VifeFdTableRecord(0x29, VariableDataQuantityUnit.StorageIntervalYear, b => 0),
            new VifeFdTableRecord(0x2a, VariableDataQuantityUnit.ReservedVIFE_FD_2a, b => 0),
            new VifeFdTableRecord(0x2b, VariableDataQuantityUnit.ReservedVIFE_FD_2b, b => 0),
            new VifeFdTableRecord(0x2c, VariableDataQuantityUnit.DurationSinceLastReadout, b => 0),
            new VifeFdTableRecord(0x2d, VariableDataQuantityUnit.DurationSinceLastReadout, b => 0),
            new VifeFdTableRecord(0x2e, VariableDataQuantityUnit.DurationSinceLastReadout, b => 0),
            new VifeFdTableRecord(0x2f, VariableDataQuantityUnit.DurationSinceLastReadout, b => 0),
            new VifeFdTableRecord(0x30, VariableDataQuantityUnit.StartDateTimeOfTariff, b => 0),
            new VifeFdTableRecord(0x31, VariableDataQuantityUnit.DurationOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x32, VariableDataQuantityUnit.DurationOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x33, VariableDataQuantityUnit.DurationOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x34, VariableDataQuantityUnit.PeriodOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x35, VariableDataQuantityUnit.PeriodOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x36, VariableDataQuantityUnit.PeriodOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x37, VariableDataQuantityUnit.PeriodOfTariff, b => b & 0x03),
            new VifeFdTableRecord(0x38, VariableDataQuantityUnit.PeriodOfTariffMonths, b => 0),
            new VifeFdTableRecord(0x39, VariableDataQuantityUnit.PeriodOfTariffYear, b => 0),
            new VifeFdTableRecord(0x3a, VariableDataQuantityUnit.Dimensionless, b => 0),
            new VifeFdTableRecord(0x3b, VariableDataQuantityUnit.Reserved_FD_3b, b => 0),
            new VifeFdTableRecord(0x3c, VariableDataQuantityUnit.Reserved_FD_3c, b => 0),
            new VifeFdTableRecord(0x3d, VariableDataQuantityUnit.Reserved_FD_3c, b => 0),
            new VifeFdTableRecord(0x3e, VariableDataQuantityUnit.Reserved_FD_3c, b => 0),
            new VifeFdTableRecord(0x3f, VariableDataQuantityUnit.Reserved_FD_3c, b => 0),
            new VifeFdTableRecord(0x40, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x41, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x42, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x43, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x44, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x45, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x46, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x47, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x48, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x49, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4a, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4b, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4c, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4d, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4e, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x4f, VariableDataQuantityUnit.Volts, b => (b & 0x0f) - 9),
            new VifeFdTableRecord(0x50, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x51, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x52, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x53, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x54, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x55, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x56, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x57, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x58, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x59, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5a, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5b, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5c, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5d, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5e, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x5f, VariableDataQuantityUnit.Ampers, b => (b & 0x0f) - 12),
            new VifeFdTableRecord(0x60, VariableDataQuantityUnit.ResetCounter, b => 0),
            new VifeFdTableRecord(0x61, VariableDataQuantityUnit.CumulationCounter, b => 0),
            new VifeFdTableRecord(0x62, VariableDataQuantityUnit.ControlSignal, b => 0),
            new VifeFdTableRecord(0x63, VariableDataQuantityUnit.DayOfWeek, b => 0),
            new VifeFdTableRecord(0x64, VariableDataQuantityUnit.WeekNumber, b => 0),
            new VifeFdTableRecord(0x65, VariableDataQuantityUnit.TimePointOfDayChange, b => 0),
            new VifeFdTableRecord(0x66, VariableDataQuantityUnit.StateOfParameterActivation, b => 0),
            new VifeFdTableRecord(0x67, VariableDataQuantityUnit.SpecialSupplierInformation, b => 0),
            new VifeFdTableRecord(0x68, VariableDataQuantityUnit.DurationSinceLastCumulation, b => 0),
            new VifeFdTableRecord(0x69, VariableDataQuantityUnit.DurationSinceLastCumulation, b => 0),
            new VifeFdTableRecord(0x6a, VariableDataQuantityUnit.DurationSinceLastCumulation, b => 0),
            new VifeFdTableRecord(0x6b, VariableDataQuantityUnit.DurationSinceLastCumulation, b => 0),
            new VifeFdTableRecord(0x6c, VariableDataQuantityUnit.OperatingTimeBattery, b => 0),
            new VifeFdTableRecord(0x6d, VariableDataQuantityUnit.OperatingTimeBattery, b => 0),
            new VifeFdTableRecord(0x6e, VariableDataQuantityUnit.OperatingTimeBattery, b => 0),
            new VifeFdTableRecord(0x6f, VariableDataQuantityUnit.OperatingTimeBattery, b => 0),
            new VifeFdTableRecord(0x70, VariableDataQuantityUnit.DateTimeOfBatteryChange, b => 0),
            new VifeFdTableRecord(0x71, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x72, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x73, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x74, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x75, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x76, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x77, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x78, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x79, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7a, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7b, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7c, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7d, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7e, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
            new VifeFdTableRecord(0x7f, VariableDataQuantityUnit.Reserved_FD_71, b => 0),
        };

    }

    public class VifeOrthogonalTableRecord
    {
        public byte VIFO { get; }
        public VariableDataQuantityUnit Units { get; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public Func<byte, int> Magnitude { get; }
        public Func<int,string> Name { get; }

        public VifeOrthogonalTableRecord(byte vifo, VariableDataQuantityUnit units, Func<byte, int> magnitude, Func<int,string> name)
        {
            VIFO = vifo;
            Units = units;
            Magnitude = magnitude;
            Name = name;
        }

        public override string ToString()
        {
            return Name(Magnitude(VIFO));
        }

        public static readonly VifeOrthogonalTableRecord[] VifeOrthogonalTable =
        {
            new VifeOrthogonalTableRecord(0x00, VariableDataQuantityUnit.Undefined, b => 0, n=> $"None ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x20, VariableDataQuantityUnit.Per_second, b => 0, n=> $"Per second ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x21, VariableDataQuantityUnit.Per_minute, b => 0, n=> $"Per minute ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x22, VariableDataQuantityUnit.Per_hour, b => 0, n=> $"Per hour ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x23, VariableDataQuantityUnit.Per_day, b => 0, n=> $"Per day ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x24, VariableDataQuantityUnit.Per_week, b => 0, n=> $"Per week ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x25, VariableDataQuantityUnit.Per_month, b => 0, n=> $"Per month ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x26, VariableDataQuantityUnit.Per_year, b => 0, n=> $"Per year ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x27, VariableDataQuantityUnit.Per_RevolutionMeasurement, b => 0, n=> $"Per revolution / measurement ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x28, VariableDataQuantityUnit.Increment_per_inputPulseOnInputChannel0, b => 0, n=> $"Increment per input pulse on input channel number 0 ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x29, VariableDataQuantityUnit.Increment_per_inputPulseOnInputChannel1, b => 0, n=> $"Increment per input pulse on input channel number 1 ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2a, VariableDataQuantityUnit.Increment_per_outputPulseOnOutputChannel0, b => 0, n=> $"Increment per output pulse on output channel number 0 ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2b, VariableDataQuantityUnit.Increment_per_outputPulseOnOutputChannel1, b => 0, n=> $"Increment per output pulse on output channel number 1 ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2c, VariableDataQuantityUnit.Per_liter, b => 0, n=> $"Per liter ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2d, VariableDataQuantityUnit.Per_m3, b => 0, n=> $"Per m^3 ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2e, VariableDataQuantityUnit.Per_kg, b => 0, n=> $"Per kilo ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x2f, VariableDataQuantityUnit.Per_Kelvin, b => 0, n=> $"Per kelvin ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x30, VariableDataQuantityUnit.Per_kWh, b => 0, n=> $"Per kWh ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x31, VariableDataQuantityUnit.Per_GJ, b => 0, n=> $"Per GJ ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x32, VariableDataQuantityUnit.Per_kW, b => 0, n=> $"Per kW ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x33, VariableDataQuantityUnit.Per_KelvinLiter, b => 0, n=> $"Per Kelvin*Liter ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x34, VariableDataQuantityUnit.Per_Volt, b => 0, n=> $"Per Volt ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x35, VariableDataQuantityUnit.Per_Ampere, b => 0, n=> $"Per Ampere ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x36, VariableDataQuantityUnit.MultipliedBySek, b => 0, n=> $"Multiplied by s ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x37, VariableDataQuantityUnit.MultipliedBySek_per_V, b => 0, n=> $"Multiplied by s / V ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x38, VariableDataQuantityUnit.MultipliedBySek_per_A, b => 0, n=> $"Multiplied by s / A ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x39, VariableDataQuantityUnit.StartDateTimeOf, b => 0, n=> $"Start date(/time) of ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x3a, VariableDataQuantityUnit.UncorrectedUnit, b => 0, n=> $"Uncorrected Unit ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x3b, VariableDataQuantityUnit.AccumulationPositive, b => 0, n=> $"Accumulation only if positive contributions (forward flow contribution) ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x3c, VariableDataQuantityUnit.AccumulationNegative, b => 0, n=> $"Accumulation of abs value only if negative contributions (backward flow) ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x40, VariableDataQuantityUnit.LimitValue, b => (b & 0x08) >> 3, n=> $"Lower limit value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x48, VariableDataQuantityUnit.LimitValue, b => (b & 0x08) >> 3, n=> $"Upper limit value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x41, VariableDataQuantityUnit.NrOfLimitExceeds, b => (b & 0x08) >> 3, n=> $"Number of exceeds of lower limit ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x49, VariableDataQuantityUnit.NrOfLimitExceeds, b => (b & 0x08) >> 3, n=> $"Number of exceeds of upper limit ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x70, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x71, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x72, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x73, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x74, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x75, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x76, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x77, VariableDataQuantityUnit.MultiplicativeCorrectionFactor, b => (b & 0x07) -6, n=> $"Multiplicative correction factor for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x78, VariableDataQuantityUnit.AdditiveCorrectionConstant, b => (b & 0x03) -3, n=> $"Additive correction constant for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x79, VariableDataQuantityUnit.AdditiveCorrectionConstant, b => (b & 0x03) -3, n=> $"Additive correction constant for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x7a, VariableDataQuantityUnit.AdditiveCorrectionConstant, b => (b & 0x03) -3, n=> $"Additive correction constant for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x7b, VariableDataQuantityUnit.AdditiveCorrectionConstant, b => (b & 0x03) -3, n=> $"Additive correction constant for value ({UnitPrefix.GetUnitPrefix(n)})"),
            new VifeOrthogonalTableRecord(0x7d, VariableDataQuantityUnit.MultiplicativeCorrectionFactor1000, b => 3, n=> $"Multiplicative correction constant for value ({UnitPrefix.GetUnitPrefix(n)})"),
        };
    }
}
