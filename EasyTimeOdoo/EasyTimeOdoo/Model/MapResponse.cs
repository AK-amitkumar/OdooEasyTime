using System;
using System.Collections.Generic;

namespace EasyTimeOdoo.Model
{
    public class MapResponse
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<Row> rows { get; set; }
        public string status { get; set; }

    }

    public class Row{
        public List<Elements> elements { get; set; }
    }

    public class Elements
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }


    };

    public class Distance
    {
        public string text { get; set; }
        public string value { get; set; }

    };

    public class Duration
    {
        public string text { get; set; }
        public string value { get; set; }

    };
}
