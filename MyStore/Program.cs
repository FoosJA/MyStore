using MyStore.Models;

//Создание приложения по умолчанию фактически начинается с класса WebApplicationBuilder
//Для инициализации объекта WebApplicationBuilder в этот метод могут передаваться аргументы командной строки,
//указанные при запуске приложения (доступны через неявно определенный параметр args)
var builder = WebApplication.CreateBuilder(args);//Либо можно передавать объект WebApplicationOption:





//Все сервисы и компоненты middleware, которые предоставляются ASP.NET по умолчанию, регистрируются в приложение с помощью
//методов расширений IServiceCollection, имеющих общую форму Add[название_сервиса].
//old way
//builder.Services.AddMvc();
//new way
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, FakeProductRepository>();//добавление службы для сообщения, что когда контроллеру необходима реализация интерфейса,
                                                                           //она должна получить экземпляр класса Fake.

//Класс WebApplication применяется для управления обработкой запроса, установки маршрутов, получения сервисов и т.д.                                                                           //Который в последствии можно легко изменить на настоящее хранилище
var app = builder.Build();
//Для встраивания компонентов middleware в конвейер обработки запроса определены методы расширения типа UseXXX
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

//default way
//app.MapGet("/", () => "Hello World!"); //В данном случае  путь "/", то есть по сути корень веб-приложения

//new way
app.UseRouting();//добавляет в конвейер обработки запроса функциональность сопоставления запросов и маршрутов.
                 //Данный middleware выбирает конечную точку, которая соответствует запросу и которая затем обрабатывает запрос
app.MapControllerRoute(// определение маршрутов
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

//old way старую форму маршрутизации с использованием RouterMiddleware
//builder.Services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });//если мы хотим использовать метод UseMvc(),
//то необходимо при подключении сервисов MVC в методе ConfigureServices явным образом отключить использование конечных точек.

/*app.UseMvc(routes => {
   routes.MapRoute(
       name: "default",
       template: "{controller=Product}/{action=List}/{id?}");
   });*/

app.Run();
