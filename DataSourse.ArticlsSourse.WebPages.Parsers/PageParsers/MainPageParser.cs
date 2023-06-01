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
using static System.Net.WebRequestMethods;

namespace DataSourse.ArticlsSourse.Parsers
{
    public class MainPageParser : IAsyncArticleListGetter
    {
        private readonly string URLBase; 
        private readonly HttpClient _client;

        public async Task<List<ArticleShortInfo>> GetArticlsListAsync()
        {
            var pageContent = await getPageContent();
            var content = parsePageContent(pageContent);
            return content;
        }
        private async ValueTask<string> getPageContent()
        {
            var request = createRequestMessage(0);
            var response = await SendMessage(request);
            return response;
        }
        private HttpRequestMessage createRequestMessage(int pageId)
        {
            string Url;

            if(pageId == 0)
            {
                Url = URLBase;
            }
            else
            {
                Url = URLBase + "/page" + pageId;
            }
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

            return info;

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
            var articlsResult = articls.ConvertAll(getArticlShortInfoFromArticl);
            return articlsResult;   
        }
        private ArticleShortInfo getArticlShortInfoFromArticl(HtmlNode articl)
        {
            var titleField = articl.QuerySelector("h2.tm-title_h2");
            string name = titleField.QuerySelector("a span").InnerText;
            var id = titleField.QuerySelector("a").GetAttributeValue("href", "0").Split("/").Reverse().ElementAt(1) ;

            var tags = articl
                .QuerySelectorAll(".tm-article-snippet__hubs-container .tm-article-snippet__hubs .tm-article-snippet__hubs-item .tm-article-snippet__hubs-item-link")
                .ToList()
                .ConvertAll(
                    element =>
                        element
                        .InnerText
                );

            var footerField = articl.QuerySelector(".tm-data-icons");
            var reitingText = footerField.QuerySelector(".tm-votes-meter__value").InnerText;
            var commentsText = footerField.QuerySelector(".tm-article-comments-counter-link__value").InnerText;

            var reiting = int.Parse( reitingText );
            var comments = uint.Parse(commentsText);


            return new ArticleShortInfo(long.Parse(id), name, tags, reiting, comments);
        }
        public MainPageParser()
        {
            _client = new();
            URLBase = @"https://habr.com/ru/all";
        }

    }
}
