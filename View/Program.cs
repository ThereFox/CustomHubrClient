using Model.Abstraction;
using DataSourse.ArticlsSourse;
using DataSourse.ArticlsSourse.NullObject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddSingleton<IAsyncArticleDataSourse, NullObjectArticlSourse>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute("main", "{controller = HabrDataShower}/{Action = GetHabrArticlsList}");

app.Run();
