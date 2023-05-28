using Model.Abstraction;
using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourse.ArticlsSourse
{
    public class MainPageParser : IArticleListGetter
    {
        private readonly string URLBase; //https://habr.com/ru/all/page1/
        private readonly HttpClient _client;

        public List<ArticleShortInfo> GetArticlsList()
        {

        }
        private string getPageContent()
        { }
        private HttpRequestMessage createRequest(int pageId)
        {
            var Url = URLBase + pageId;

            return new HttpRequestMessage(HttpMethod.Get, URL);
        }
        private string parsePageContent()
        { }

    }
}
