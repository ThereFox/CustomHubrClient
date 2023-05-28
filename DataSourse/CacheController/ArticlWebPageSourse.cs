using Model.Abstraction;
using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourse.ArticlsSourse
{
    public class ArticlWithCachingSourse : IArticleDataSourse
    {
        private readonly IArticleListGetter _articleListGetter;

        public Articl GetArticlByID(long id)
        {
            throw new NotImplementedException();
        }

        public List<ArticleShortInfo> GetAvaliableArticls()
        {
            throw new NotImplementedException();
        }

        public ArticlWithCachingSourse(IArticleListGetter articleListGetter)
        {
            _articleListGetter = articleListGetter;
        }
    }
}
