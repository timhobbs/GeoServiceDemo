using System.Runtime.Serialization;

namespace Th.GeoServices.Domain {

    [DataContract]
    public class CensusBlockResponse {

        [DataMember]
        public Block Block { get; set; }

        [DataMember]
        public County County { get; set; }

        [DataMember]
        public State State { get; set; }

        [DataMember(Name = "executionTime")]
        public int ExecutionTime { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }
    }

    [DataContract]
    public class Block : FipsBase { }

    [DataContract]
    public class County : FipsBase {

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class State : FipsBase {

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class FipsBase {

        [DataMember]
        public string FIPS { get; set; }
    }
}