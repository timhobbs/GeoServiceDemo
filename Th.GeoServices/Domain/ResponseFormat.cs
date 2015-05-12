using System.ComponentModel.DataAnnotations;

namespace Th.GeoServices.Domain {

    public enum ResponseFormat {

        [Display(Name = "json")]
        Json,

        [Display(Name = "html")]
        Html,

        [Display(Name = "kmz")]
        Kmz,

        [Display(Name = "jsonp")]
        Jsonp
    }
}