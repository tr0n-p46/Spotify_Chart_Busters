using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransfer
{
    public class DataSearchRequest
    {
        public string OrderBy { get; set; }
        public bool OrderByAsc { get; set; }
        public string Search { get; set; }

        [Required]
        public int? Start { get; set; }
        [Required]
        public int? Count { get; set; }
    }
}
