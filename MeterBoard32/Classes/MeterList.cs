using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MeterBoard32.Classes
{
    [CollectionDataContract]
    class MeterList: List<Meter>
    {
        public MeterList() { }
    }
}
