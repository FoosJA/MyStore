using MyStore.Models;

var builder = WebApplication.CreateBuilder(args);

//old way
//builder.Services.AddMvc();
//new way
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, FakeProductRepository>();//���������� ������ ��� ���������, ��� ����� ����������� ���������� ���������� ����������,
                                                                           //��� ������ �������� ��������� ������ Fake.
                                                                           //������� � ����������� ����� ����� �������� �� ��������� ���������

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

//new way
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

//old way
/* app.UseMvc(routes => {
    routes.MapRoute(
        name: "default",
        template: "{controller=Product}/{action=List}/{id?}");
    });*/

app.Run();
