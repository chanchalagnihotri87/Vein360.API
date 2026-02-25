using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Helpers.Costants;

namespace Vein360.Application.Common.Dtos
{
    public class PagedResponse<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; private set; }
        public int CurrentPage { get; private set; }

        public int Skip { get; private set; }

        public int PageSize => ConstantsHelper.PageSize;
        public void CalculateTotalPages(int totalItems)
        {
            this.TotalPages = (int)Math.Ceiling((double)totalItems / ConstantsHelper.PageSize);
        }

        public void CalculateSkipCount(int? currentPage)
        {
            this.CurrentPage = currentPage.IsNull() || currentPage.Value < 0 ? ConstantsHelper.DefaultPageNo : currentPage.Value;

            this.Skip = ConstantsHelper.PageSize * (this.CurrentPage > 1 ? this.CurrentPage - 1 : 0);
        }


    }
}
