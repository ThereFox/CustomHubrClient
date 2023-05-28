using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstraction
{
    public interface IArticleDataSourse
    {
        public List<ArticleShortInfo> GetAvaliableArticls();
        public Articl GetArticlByID(long id);
    }
}
