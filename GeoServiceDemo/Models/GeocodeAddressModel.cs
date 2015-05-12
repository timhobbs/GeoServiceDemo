using Th.GeoServices.Domain;

namespace GeoServiceDemo.Models {

    public class GeocodeAddressModel {

        public Address Address { get; set; }

        public Candidate TopCandidate { get; set; }

        public GeocodeAddressResponse GeocodeJsonResult { get; set; }

        public CensusBlockResponse FccJsonResult { get; set; }

        public string County { get; set; }
    }
}