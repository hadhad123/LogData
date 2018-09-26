using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class FilterObject<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public T SearchObject { get; set; }
    }
}
