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
        private readonly IAsyncArticleListGetter _articleListGetter;


        public async Task<List<ArticleShortInfo>> GetAvaliableArticlsAsync()
        {
            var avaliavleArticl = await _articleListGetter.GetArticlsListAsync();
            return avaliavleArticl;
        }

        public Task<Articl> GetArticlByIDAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ArticlWithCachingSourse(IAsyncArticleListGetter articleListGetter)
        {
            _articleListGetter = articleListGetter;
        }
    }
}
