using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppName.Web.ViewModels.Products
{
    public class IndexViewModel
    {
        public IEnumerable<IndexItemViewModel> Items { get; set; }
    }
    public class IndexItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}