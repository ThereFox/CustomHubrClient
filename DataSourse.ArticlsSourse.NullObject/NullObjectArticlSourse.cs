using Model.Abstraction;
using Model.Types;

namespace DataSourse.ArticlsSourse.NullObject
{
    public class NullObjectArticlSourse : IArticleDataSourse
    {
        public Articl GetArticlByID(long id)
        {
            return new Articl();
        }

        public List<ArticleShortInfo> GetAvaliableArticls()
        {
            return new List<ArticleShortInfo>() { new ArticleShortInfo(0, "test", "test") };
        }
    }
}
