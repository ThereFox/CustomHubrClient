using Model.Abstraction;
using DataSourse.ArticlsSourse;
using DataSourse.ArticlsSourse.NullObject;
using DataSourse.ArticlsSourse.Parsers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var articklsSourse = new ArticlWithCachingSourse(new MainPageParser());

builder.Services.AddSingleton<IAsyncArticleDataSourse>(articklsSourse);

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute("main", "{controller = HabrDataShower}/{Action = GetHabrArticlsList}");

app.Run();
