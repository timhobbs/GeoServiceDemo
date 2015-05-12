using System;
using System.Linq;
using Th.GeoServices.Domain;
using Th.GeoServices.Extensions;
using RestSharp;

namespace Th.GeoServices {

    public class GeoService {
        private const string arcGisUrl = "http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Locators/ESRI_Geocode_USA/GeocodeServer";
        private const string fccUrl = "http://data.fcc.gov/api";

        public static string GetCounty(Address address) {
            var geo = GetAddressResponse(address);
            if (geo == null || geo.Candidates.Count == 0) return null;

            var fcc = GetCensusBlockResponse(geo.Candidates.First().Location);
            if (fcc == null) return null;

            return fcc.County.Name;
        }

        public static GeocodeAddressResponse GetAddressResponse(Address address) {
            var client = new RestClient(arcGisUrl);
            var format = ResponseFormat.Json.DisplayName();

            var request = new RestRequest("/findAddressCandidates", Method.GET);
            request.AddParameter("Address", address.Street);
            request.AddParameter("City", address.City);
            request.AddParameter("State", address.StateAbbreviation);
            request.AddParameter("Zip", address.Zip);
            request.AddParameter("f", format);

            // http://stackoverflow.com/questions/10324526/restsharp-not-deserializing-json-object-list-always-null
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute<GeocodeAddressResponse>(request);
            return response.Data;
        }

        public static CensusBlockResponse GetCensusBlockResponse(Point p) {
            var client = new RestClient(fccUrl);
            var format = ResponseFormat.Json.DisplayName();

            var request = new RestRequest("/block/find", Method.GET);
            request.AddParameter("latitude", p.Y);
            request.AddParameter("longitude", p.X);
            request.AddParameter("format", format);

            // http://stackoverflow.com/questions/10324526/restsharp-not-deserializing-json-object-list-always-null
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var raw = client.Execute(request);

            var response = client.Execute<CensusBlockResponse>(request);
            return response.Data;
        }
    }
}