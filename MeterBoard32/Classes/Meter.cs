using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MeterBoard32.Classes
{
    [DataContract]
    public class Meter
    {
        [DataMember]
        public string MeterId { get; set; }

        [DataMember]
        public int PrimaryAddress { get; set; }

        [DataMember]
        public MeterType MeterType { get; set; }

        [DataMember]
        public string ManufacturerId { get; set; }

        [DataMember]
        public List<DataRecord> dataRecords = new List<DataRecord>();

        public Meter(string meterId, int primaryAddress, MeterType meterType, string manufacturerId)
        {
            MeterId = meterId;
            PrimaryAddress = primaryAddress;
            MeterType = meterType;
            ManufacturerId = manufacturerId;
        }

        public void AddDataRecord()
        {

        }

    }
}
