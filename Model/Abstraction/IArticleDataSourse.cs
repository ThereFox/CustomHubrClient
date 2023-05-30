using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Abstraction
{
    public interface IAsyncArticleDataSourse
    {
        public Task<List<ArticleShortInfo>> GetAvaliableArticlsAsync();
        public Task<Articl> GetArticlByIDAsync(long id);
    }
}
