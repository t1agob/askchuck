using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace askchuck.web.Models
{
    public class FactCategory
    {
        public string Text { get; set; }

        public string ButtonStyle { get; set; }
    }

    public class FactCategoryList
    {
        public string SelectedCategory { get; set; }
        public List<FactCategory> FactCategories { get; set; }
    }
}
