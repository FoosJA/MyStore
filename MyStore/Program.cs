using MyStore.Models;

//�������� ���������� �� ��������� ���������� ���������� � ������ WebApplicationBuilder
//��� ������������� ������� WebApplicationBuilder � ���� ����� ����� ������������ ��������� ��������� ������,
//��������� ��� ������� ���������� (�������� ����� ������ ������������ �������� args)
var builder = WebApplication.CreateBuilder(args);//���� ����� ���������� ������ WebApplicationOption:





//��� ������� � ���������� middleware, ������� ��������������� ASP.NET �� ���������, �������������� � ���������� � �������
//������� ���������� IServiceCollection, ������� ����� ����� Add[��������_�������].
//old way
//builder.Services.AddMvc();
//new way
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductRepository, FakeProductRepository>();//���������� ������ ��� ���������, ��� ����� ����������� ���������� ���������� ����������,
                                                                           //��� ������ �������� ��������� ������ Fake.

//����� WebApplication ����������� ��� ���������� ���������� �������, ��������� ���������, ��������� �������� � �.�.                                                                           //������� � ����������� ����� ����� �������� �� ��������� ���������
var app = builder.Build();
//��� ����������� ����������� middleware � �������� ��������� ������� ���������� ������ ���������� ���� UseXXX
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

//default way
//app.MapGet("/", () => "Hello World!"); //� ������ ������  ���� "/", �� ���� �� ���� ������ ���-����������

//new way
app.UseRouting();//��������� � �������� ��������� ������� ���������������� ������������� �������� � ���������.
                 //������ middleware �������� �������� �����, ������� ������������� ������� � ������� ����� ������������ ������
app.MapControllerRoute(// ����������� ���������
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

//old way ������ ����� ������������� � �������������� RouterMiddleware
//builder.Services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });//���� �� ����� ������������ ����� UseMvc(),
//�� ���������� ��� ����������� �������� MVC � ������ ConfigureServices ����� ������� ��������� ������������� �������� �����.

/*app.UseMvc(routes => {
   routes.MapRoute(
       name: "default",
       template: "{controller=Product}/{action=List}/{id?}");
   });*/

app.Run();
