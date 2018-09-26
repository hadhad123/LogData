using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PagedResult<T> where T : class
    {
        public List<T> Results { get; set; }
        public int TotalNumOfRecords { get; set; }
    }
}
