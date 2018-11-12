using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MeterBoard32.Classes.VIFTableRecord;
using static MeterBoard32.Classes.VifeFbTableRecord;
using static MeterBoard32.Classes.VifeFdTableRecord;
using static MeterBoard32.Classes.VifeOrthogonalTableRecord;
using System.Runtime.Serialization;

namespace MeterBoard32.Classes
{
    public class VIF
    {
        public VIFType Type { get; set; }

        public bool Extension { get; set; }

        public VariableDataQuantityUnit Units { get; set; }

        public string Unit { get; set; }

        public int Magnitude { get; set; }

        public string Quantity { get; set; }

        public string VIF_string { get; set; }

        public string Name { get; set; }

        public byte Data { get; private set; }

        public VIF(byte data)
        {
            var record = VifVariableTable.ToDictionary(x => x.VIF)[(byte)(data & (byte)VariableDataRecordType.MBUS_DIB_VIF_WITHOUT_EXTENSION)]; // clear Extension bit

            Data = data;
            Extension = (data & 0x80) != 0;
            Units = record.Units;
            Unit = record.Unit;
            Type = record.Type;
            Magnitude = record.Magnitude(data);
            Name = record.Name(record.Magnitude(data));
            Quantity = record.Quantity;
        }
    }

    public class VIFE_FB
    {
        public bool Extension { get; }

        public VariableDataQuantityUnit Units { get; }

        public string Unit { get; }

        public string Quantity { get; }

        public string Prefix { get; }

        public int Magnitude { get; }

        public byte Data { get; }

        public VIFE_FB(byte data)
        {
            var record = VifeFbTable.ToDictionary(x => x.VIFFB)[(byte)(data & (byte)VariableDataRecordType.MBUS_DIB_VIF_WITHOUT_EXTENSION)]; // clear Extension bit

            Data = data;
            Extension = (data & 0x80) != 0;
            Units = record.Units;
            Unit = record.Unit;
            Quantity = record.Quantity;
            Magnitude = record.Magnitude(data);
            Prefix = UnitPrefix.GetUnitPrefix(record.Magnitude(data));
        }

    }

    public class VIFE_FD
    {
        public bool Extension { get; }

        public VariableDataQuantityUnit Units { get; }

        public string Unit { get; }

        public string Quantity { get; }

        public string Prefix { get; }

        public int Magnitude { get; }

        public byte Data { get; }

        public VIFE_FD(byte data)
        {
            var record = VifeFdTable.ToDictionary(x => x.VIFFD)[(byte)(data & (byte)VariableDataRecordType.MBUS_DIB_VIF_WITHOUT_EXTENSION)]; // clear Extension bit

            Data = data;
            Extension = (data & 0x80) != 0;
            Units = record.Units;
            Unit = record.Unit;
            Quantity = record.Quantity;
            Magnitude = record.Magnitude(data);
            Prefix = UnitPrefix.GetUnitPrefix(record.Magnitude(data));
        }
    }

    public class VIFEOrthogonal
    {
        public bool Extension { get; }

        public VariableDataQuantityUnit Units { get; }

        public string Unit { get; }

        public string Quantity { get; }

        public string Prefix { get; }

        public int Magnitude { get; }

        public byte Data { get; }

        public VIFEOrthogonal(byte data)
        {
            var record = VifeOrthogonalTable.ToDictionary(x => x.VIFO)[(byte)(data & (byte)VariableDataRecordType.MBUS_DIB_VIF_WITHOUT_EXTENSION)]; // clear Extension bit

            Data = data;
            Extension = (data & 0x80) != 0;
            Units = record.Units;
            Unit = record.Unit;
            Quantity = record.Quantity;
            Magnitude = record.Magnitude(data);
            Prefix = UnitPrefix.GetUnitPrefix(record.Magnitude(data));
        }
    }

    [DataContract]
    public class DataRecord
    {
        const byte STORAGE_MASK = 0x40;         // 0100 0000
        const byte FUNCTION_MASK = 0x30;        // 0011 0000
        const byte EXTENSION_MASK = 0x80;       // 1000 0000
        const byte DIFE_STORAGE_MASK = 0x0F;    // 0000 1111
        const byte DIFE_TARIFF_MASK = 0x30;     // 0011 0000
        const byte DIFE_SUBUNIT_MASK = 0x40;    // 0100 0000
        const byte DATA_TYPE_MASK = 0x0F;		// 0000 1111

        private List<byte> dib = new List<byte>();
        private List<byte> vib = new List<byte>();
        private List<byte> data = new List<byte>();

        [DataMember(Name = "dib")]
        public string _dib
        {
            get
            {
                return BitConverter.ToString(Helpers.TrimEnd(this.dib.ToArray())).Replace("-", "");
            }
            set
            {
                byte[] bytes = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                     .ToArray();
                this.dib = bytes.ToList<byte>();
            }
        }

        [DataMember(Name = "vib")]
        public string _vib
        {
            get
            {
                return BitConverter.ToString(this.vib.ToArray()).Replace("-", "");
            }
            set
            {
                byte[] bytes = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                     .ToArray();
                this.vib = bytes.ToList<byte>();
            }
        }

        [DataMember(Name = "data")]
        public string _data
        {
            get
            {
                return BitConverter.ToString(this.data.ToArray()).Replace("-", "");
            }
            set
            {
                byte[] bytes = Enumerable.Range(0, value.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(value.Substring(x, 2), 16))
                     .ToArray();
                this.data = bytes.ToList<byte>();
            }
        }

        private DataType DataType;
        private Int64 StorageNumber;
        private Int32 Tariff;
        private Function Function;
        private Int32 Unit;

        private VIFTableRecord vif;
        private VifeFbTableRecord vife_fb;
        private VifeOrthogonalTableRecord vife_o;

        private string dataString;

        public DataRecord() {
            this.dib.AddRange(Enumerable.Range(0, 9).Select(i => (byte)0).ToArray());
            this.vib.Add(0);
        }

        public void encode()
        {
            encodeDIB();
            encodeVIB();
            encodeData();
        }

        private void encodeDIB()
        {
            this.dib.Clear();
            this.dib.AddRange(Enumerable.Range(0, 9).Select(i => (byte)0).ToArray());
            this.EncodeDataType();
            this.EncodeStorageNumber();
            this.EncodeTariff();
            this.EncodeFunction();
            this.EncodeUnit();
        }

        private void encodeVIB()
        {
            this.vib.Clear();
            this.vib.Add(vif.VIF);
            if (this.vife_fb != null)
            {
                this.vib[0] |= DataRecord.EXTENSION_MASK;
                this.vib.Add(vife_fb.VIFFB);
            }
            if ((this.vife_o != null) && (this.vife_o.VIFO != 0x00))
            {
                this.vib[this.vib.Count -1] |= DataRecord.EXTENSION_MASK;
                this.vib.Add(vife_o.VIFO);
            }
        }

        public byte[] GetDIB()
        {
            return Helpers.TrimEnd(this.dib.ToArray());
        }

        public byte[] GetVIB()
        {
            return Helpers.TrimEnd(this.vib.ToArray());
        }

        public void SetDataType(DataType dataType)
        {
            this.DataType = dataType;
        }

        public void SetStorageNumber(Int64 storageNo)
        {
            if ((storageNo < 0) || (storageNo > Math.Pow(2, 41)))
            {
                throw new Exception("Erroneous storage number");
            }
            this.StorageNumber = storageNo;
        }

        public void SetTariff(Int32 tariff)
        {
            if ((tariff < 0) || (tariff > Math.Pow(2, 20)))
            {
                throw new Exception("Erroneous tariff number");
            }
            this.Tariff = tariff;
        }

        public void SetFunction(Function function)
        {
            this.Function = function;
        }

        public void SetUnit(Int32 unit)
        {
            if ((unit < 0) || (unit > Math.Pow(2, 10)))
            {
                throw new Exception("Erroneous unit number");
            }
            this.Unit = unit;
        }

        private void EncodeDataType()
        {
            this.dib[0] |= (byte)(DataRecord.DATA_TYPE_MASK & (int)DataType);
        }

        public DataType GetDataType()
        {
            DataType ret = (DataType)(this.dib[0] & DataRecord.DATA_TYPE_MASK);
            this.DataType = ret;
            return ret;
        }

        private void EncodeStorageNumber()
        {
            Int64 tmpStorageNumber = StorageNumber;
            int index = 1;
            this.dib[0] |= (byte)(DataRecord.STORAGE_MASK & ((tmpStorageNumber & 0x1) << 6));

            tmpStorageNumber = tmpStorageNumber >> 1;

            while (tmpStorageNumber > 0)
            {
                this.dib[index-1] |= DataRecord.EXTENSION_MASK;
                this.dib[index] |= (byte)(tmpStorageNumber & DataRecord.DIFE_STORAGE_MASK);
                tmpStorageNumber = tmpStorageNumber >> 4;
                index++;
            }
        }

        public Int64 GetStorageNumber()
        {
            Int64 res = (Int64)(this.dib[0] >> 6) & 0x1;
            for (int i = 0; i < this.dib.Count - 1; i++)
                res |= (Int64)(this.dib[i + 1] & DataRecord.DIFE_STORAGE_MASK) << ((4 * i) + 1);
            this.StorageNumber = res;
            return res;
        }

        private void EncodeTariff()
        {
            Int32 tmpTariff = Tariff;
            int index = 1;
            while (tmpTariff > 0)
            {
                this.dib[index - 1] |= DataRecord.EXTENSION_MASK;
                this.dib[index] |= (byte)(DataRecord.DIFE_TARIFF_MASK & ((byte)((tmpTariff & 0x3) << 4)));
                tmpTariff = tmpTariff >> 2;
                index++;
            }
        }

        public Int32 GetTariff()
        {
            Int32 res = 0;
            int bit_index = 0;
            for (int i = 1; i < this.dib.Count; i++)
            {
                res |= (Int32)((this.dib[i] & DataRecord.DIFE_TARIFF_MASK) >> 4) << bit_index;
                bit_index += 2;
            }
            this.Tariff = res;
            return res;
        }

        private void EncodeFunction()
        {
            this.dib[0] |= (byte)(DataRecord.FUNCTION_MASK & ((byte)Function << 4));
        }

        public Function GetFunction()
        {
            Function res = (Function)((this.dib[0] & DataRecord.FUNCTION_MASK) >> 4);
            this.Function = res;
            return res;
        }

        private void EncodeUnit()
        {
            Int32 tmpUnit = Unit;
            int index = 1;
            while (tmpUnit > 0)
            {
                this.dib[index - 1] |= DataRecord.EXTENSION_MASK;
                this.dib[index] |= (byte)(DataRecord.DIFE_SUBUNIT_MASK & (byte)((tmpUnit & 0x1) << 6));
                tmpUnit = tmpUnit >> 1;
                index++;
            }
        }

        public Int32 GetUnit()
        {
            Int32 res = 0;
            int bit_index = 0;
            for (int i = 1; i < this.dib.Count; i++)
            {
                res |= (Int32)((this.dib[i] & DataRecord.DIFE_SUBUNIT_MASK) >> 6) << bit_index;
                bit_index += 1;
            }
            this.Unit = res;
            return res;
        }

        public void SetVIF(VIFTableRecord vif)
        {
            this.vif = vif;
        }

        public void SetVIFE_FB(VifeFbTableRecord vife_fb)
        {
            this.vife_fb = vife_fb;
        }

        public void SetVIFE_O(VifeOrthogonalTableRecord vife_o)
        {
            this.vife_o = vife_o;
        }

        public VIFTableRecord GetVIF()
        {
            return this.vif;
        }

        public VifeFbTableRecord GetVIFE_FB()
        {
            return this.vife_fb;
        }

        public VifeOrthogonalTableRecord GetVIFE_O()
        {
            return this.vife_o;
        }

        public void SetData(string dataString)
        {
            this.dataString = dataString;
        }

        private void encodeData()
        {
            this.data.Clear();
            if (dataString.Equals(""))
                return;
            switch (DataType)
            {
                case DataType._No_data:
                    this.data.Clear();
                    break;
                case DataType._8_Bit_Integer:
                    this.data.Add(Convert.ToByte(dataString));
                    break;
                case DataType._16_Bit_Integer:
                    this.data.AddRange(BitConverter.GetBytes(Convert.ToInt16(dataString)));
                    break;
                case DataType._24_Bit_Integer:
                    byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(dataString));
                    var byteSegment = new ArraySegment<byte>(bytes, 0, 3);
                    this.data.AddRange(byteSegment.ToArray());
                    break;
                case DataType._32_Bit_Integer:
                    this.data.AddRange(BitConverter.GetBytes(Convert.ToInt32(dataString)));
                    break;
                case DataType._32_Bit_Real:
                    this.data.AddRange(BitConverter.GetBytes(Convert.ToSingle(dataString)));
                    break;
                case DataType._48_Bit_Integer:
                    byte[] bytes2 = BitConverter.GetBytes(Convert.ToInt64(dataString));
                    var byteSegment2 = new ArraySegment<byte>(bytes2, 0, 6);
                    this.data.AddRange(byteSegment2.ToArray());
                    break;
                case DataType._64_Bit_Integer:
                    this.data.AddRange(BitConverter.GetBytes(Convert.ToInt64(dataString)));
                    break;
                case DataType._Selection_for_Readout:
                    throw new NotImplementedException();
                case DataType._2_digit_BCD:
                    this.data.Add(Helpers.ToBCD(Convert.ToInt32(dataString), 1).First());
                    break;
                case DataType._4_digit_BCD:
                    this.data.AddRange(Helpers.ToBCD(Convert.ToInt32(dataString), 2));
                    break;
                case DataType._6_digit_BCD:
                    this.data.AddRange(Helpers.ToBCD(Convert.ToInt32(dataString), 3));
                    break;
                case DataType._8_digit_BCD:
                    this.data.AddRange(Helpers.ToBCD(Convert.ToInt32(dataString), 4));
                    break;
                case DataType._variable_length:
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(dataString);
                    byte length = (byte)asciiBytes.Count();
                    this.data.Add(length);
                    this.data.AddRange(asciiBytes);
                    break;
                case DataType._12_digit_BCD:
                    this.data.AddRange(Helpers.ToBCD(Convert.ToInt32(dataString), 6));
                    break;
            }
        }

        public string GetDataString()
        {
            string res = "";
            byte[] _data = this.data.ToArray();
            switch (DataType)
            {
                case DataType._No_data:
                    break;
                case DataType._8_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 1);
                    res = Convert.ToString(BitConverter.ToSingle(_data, 0));
                    break;
                case DataType._16_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 2);
                    res = Convert.ToString(BitConverter.ToInt16(_data, 0));
                    break;
                case DataType._24_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 3);
                    res = Convert.ToString(BitConverter.ToInt32(_data, 0));
                    break;
                case DataType._32_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 4);
                    res = Convert.ToString(BitConverter.ToInt32(_data, 0));
                    break;
                case DataType._32_Bit_Real:
                    System.Diagnostics.Debug.Assert(_data.Length == 4);
                    res = Convert.ToString(BitConverter.ToSingle(_data, 0));
                    break;
                case DataType._48_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 6);
                    res = Convert.ToString(BitConverter.ToInt32(_data, 0));
                    break;
                case DataType._64_Bit_Integer:
                    System.Diagnostics.Debug.Assert(_data.Length == 8);
                    res = Convert.ToString(BitConverter.ToInt64(_data, 0));
                    break;
                case DataType._Selection_for_Readout:
                    throw new NotImplementedException();
                case DataType._2_digit_BCD:
                    System.Diagnostics.Debug.Assert(_data.Length == 1);
                    res = (Helpers.BCDDecode(_data, 1));
                    break;
                case DataType._4_digit_BCD:
                    System.Diagnostics.Debug.Assert(_data.Length == 2);
                    res = (Helpers.BCDDecode(_data, 2));
                    break;
                case DataType._6_digit_BCD:
                    System.Diagnostics.Debug.Assert(_data.Length == 3);
                    res = (Helpers.BCDDecode(_data, 3));
                    break;
                case DataType._8_digit_BCD:
                    System.Diagnostics.Debug.Assert(_data.Length == 4);
                    res = (Helpers.BCDDecode(_data, 4));
                    break;
                case DataType._variable_length:
                    byte length = _data.First();
                    System.Diagnostics.Debug.Assert(_data.Length == length + 1);
                    var byteSegment = new ArraySegment<byte>(_data, 1, length);
                    res = Encoding.ASCII.GetString(byteSegment.ToArray());
                    break;
                case DataType._12_digit_BCD:
                    System.Diagnostics.Debug.Assert(_data.Length == 6);
                    res = (Helpers.BCDDecode(_data, 6));
                    break;
            }
            return res;
        }

        public byte[] GetData()
        {
            return this.data.ToArray();
        }

    }
}