using System.Runtime.Serialization;

namespace Th.GeoServices.Domain {

    [DataContract]
    public class Address {

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StateAbbreviation { get; set; }

        [DataMember]
        public string Zip { get; set; }
    }
}