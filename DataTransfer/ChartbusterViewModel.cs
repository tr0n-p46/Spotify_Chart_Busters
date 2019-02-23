using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class ChartbusterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artists { get; set; }
        public int? Rank { get; set; }
    }
}
