using Model.Abstraction;
using Model.Types;

namespace DataSourse.ArticlsSourse.NullObject
{
    public class NullObjectArticlSourse : IAsyncArticleDataSourse
    {
        public async Task<Articl> GetArticlByIDAsync(long id)
        {
            await Task.CompletedTask;
            return new Articl();
        }

        public async Task<List<ArticleShortInfo>> GetAvaliableArticlsAsync()
        {
            await Task.CompletedTask;
            return new List<ArticleShortInfo>() { new ArticleShortInfo(0, "test", new List<string>() { "test" }, 123, 0) };
        }
    }
}
