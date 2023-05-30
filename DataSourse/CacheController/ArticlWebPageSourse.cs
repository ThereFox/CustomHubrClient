using Model.Abstraction;
using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourse.ArticlsSourse
{
    public class ArticlWithCachingSourse : IAsyncArticleDataSourse
    {
        private readonly IArticleListGetter _articleListGetter;


        public Task<List<ArticleShortInfo>> GetAvaliableArticlsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Articl> GetArticlByIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ArticlWithCachingSourse(IArticleListGetter articleListGetter)
        {
            _articleListGetter = articleListGetter;
        }
    }
}
