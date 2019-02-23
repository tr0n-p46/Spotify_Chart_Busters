using DataTransfer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransfer
{
    public class ListResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int Filtered { get; set; }
        public int Total { get; set; }
    }

    public class BadResponse<X>
    {
        public bool Success { get; set; }
        public ICollection<X> Errors { get; set; }
    }
}
