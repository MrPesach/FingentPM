using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCG.CoreApp.DTO
{
    public class GridResponseDto<T> where T : class
    {
        public int CurrentPage { get { return this.PageNumber; } }
        public int CountPerPage { get { return this.PageSize; } }
        public List<T> Rows { get; set; }
        public int TotalRecords { get { return this.TotalCount; } }
        public int TotalPages { get { return (int)Math.Ceiling(Convert.ToDecimal(this.TotalRecords) / Convert.ToDecimal(this.CountPerPage)) * 1; } }
        public int RowsFrom
        {
            get { return (this.PageNumber * this.PageSize) + 1; }
        }
        public int RowCount
        {
            get { return this.Rows != null && this.Rows.Any() ? this.Rows.Count : 0; }
        }
        public int RowsTo
        {
            get
            {
                return (this.PageNumber * this.PageSize) + RowCount;
            }
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}
