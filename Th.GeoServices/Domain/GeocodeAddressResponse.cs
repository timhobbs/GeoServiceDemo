using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Th.GeoServices.Domain {

    [DataContract]
    public class GeocodeAddressResponse {

        [DataMember(Name = "spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [DataMember(Name = "candidates")]
        public List<Candidate> Candidates { get; set; }

        public GeocodeAddressResponse() {
            SpatialReference = new SpatialReference();
            Candidates = new List<Candidate>();
        }
    }

    [DataContract]
    public class SpatialReference {

        [DataMember(Name = "wkid")]
        public string WellKnownId { get; set; }

        [DataMember(Name = "latestWkid")]
        public string LatestWellKnownId { get; set; }

        [DataMember(Name = "vcsWkid")]
        public string VcsWellKnownId { get; set; }

        [DataMember(Name = "latestVcsWkid")]
        public string LatestVcsWellKnownId { get; set; }

        public SpatialReference() { }
    }

    [DataContract]
    public class Candidate {

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "location")]
        public Point Location { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }

        [DataMember(Name = "attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        public Candidate() {
            Location = new Point();
            Attributes = new Dictionary<string, object>();
        }
    }

    [DataContract]
    public class Point {

        [DataMember(Name = "x")]
        public double X { get; set; }

        [DataMember(Name = "y")]
        public double Y { get; set; }

        [DataMember(Name = "spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        public Point() {
            SpatialReference = new SpatialReference();
        }
    }
}