using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Types
{
    public class ArticleShortInfo
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string Preview { get; init; }

        public ArticleShortInfo(long id, string title, string preview)
        {
            Id = id;
            Title = title;
            Preview = preview;
        }
    }
}
