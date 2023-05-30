using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using Model.Abstraction;
using Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataSourse.ArticlsSourse.Parsers
{
    public class MainPageParser : IArticleListGetter
    {
        private readonly string URLBase; //https://habr.com/ru/all/page1/
        private readonly HttpClient _client;

        public List<ArticleShortInfo> GetArticlsList()
        {
            var pageContent = getPageContent();
            return null;
        }
        private async ValueTask<string> getPageContent()
        {
            var request = createRequestMessage(0);
            var response = await SendMessage(request);
            return response;
        }
        private HttpRequestMessage createRequestMessage(int pageId)
        {
            var Url = URLBase + pageId;
            var message = new HttpRequestMessage(HttpMethod.Get, Url);
            return message;
        }
        private async ValueTask<string> SendMessage(HttpRequestMessage request)
        {
            try
            {
                var tocken = new CancellationTokenSource().Token;
                var response = await _client.SendAsync(request, tocken);
                
                if(response.IsSuccessStatusCode == false)
                {
                    throw new AccessViolationException("resourse isnt acsessible");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                
                if(responseContent == null)
                {
                    throw new AccessViolationException("resourse isnt acsessible");
                }


                return responseContent;
            }
            catch(TaskCanceledException ex)
            {
                throw;
            }
            catch (AccessViolationException ex)
            {
                throw;
            }
        }


        private List<ArticleShortInfo> parsePageContent(string content)
        {
            var document = createDocumentFromContent(content);
            var articls = getArticlsFromDocument(document);
            var info = GetArticleShortInfoFromArticlsList(articls);

            return null;

        }

        private HtmlDocument createDocumentFromContent(string content)
        {
            var document = new HtmlDocument();
            document.LoadHtml(content);
            return document;
        }
        private List<HtmlNode> getArticlsFromDocument(HtmlDocument PageDocument)
        {
            var node = PageDocument.DocumentNode;
            var articls = node.QuerySelectorAll("article.tm-articles-list__item");
            return articls.ToList();
        }
        private List<ArticleShortInfo> GetArticleShortInfoFromArticlsList(List<HtmlNode> articls)
        {
            return articls.ConvertAll(getArticlShortInfoFromArticl);   
        }
        private ArticleShortInfo getArticlShortInfoFromArticl(HtmlNode articl)
        {
            var titleField = articl.QuerySelector("h2.tm-title_h2");
            var tags = articl.QuerySelectorAll(".tm-article-snippet__hubs-container .tm-article-snippet__hubs .tm-article-snippet__hubs-item .tm-article-snippet__hubs-item-link");

            return null;
        }
    }
}
