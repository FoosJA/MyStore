using Microsoft.EntityFrameworkCore;
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

string connection = builder.Configuration.GetConnectionString("DefaultConnection");// �������� ������ ����������� �� ����� ������������
																				   // ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connection));

builder.Services.AddTransient<IProductRepository, EFProductRepository>();//���������� ������ ��� ���������, ��� ����� ����������� ���������� ���������� ����������,
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
// ����������� ���������
//�������� "controller" ����� �������������� �� ����� � ����� �� ������������ ����������
//�������� "action" - � ��������� ����� �����������
//defaults: �������� ���������� ��������� �� ���������
app.MapControllerRoute(
	name: null,
	pattern: "{category}/Page{productPage:int}",
	defaults: new { Controller = "Product", action = "List" }
);
app.MapControllerRoute(
	name: null,
	pattern: "Page{productPage:int}",
	defaults: new { Controller = "Product", action = "List", productPage = 1 }
);
app.MapControllerRoute(
	name: null,
	pattern: "{category}",
	defaults: new { Controller = "Product", action = "List", productPage = 1 }
);
app.MapControllerRoute(
	name: null,
	pattern: "",
	defaults: new { Controller = "Product", action = "List", productPage = 1 }
);
app.MapControllerRoute(
	name: null,
	pattern: "{controller}/{action}/{id?}");

//old way ������ ����� ������������� � �������������� RouterMiddleware
//builder.Services.AddControllersWithViews(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });//���� �� ����� ������������ ����� UseMvc(),
//�� ���������� ��� ����������� �������� MVC � ������ ConfigureServices ����� ������� ��������� ������������� �������� �����.

/*app.UseMvc(routes => {
   routes.MapRoute(
       name: "default",
       template: "{controller=Product}/{action=List}/{id?}");
   });*/


app.Run();
