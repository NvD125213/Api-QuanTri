using BLL;
using BLL.Interface;
using DAL.Interface;
using DAL.Helper;
using DAL;
using DAL.Helper.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<IUserRespository, UserRespository>();
builder.Services.AddTransient<IUserBLL, UserBLL>();

builder.Services.AddTransient<INhaCungCapRespository, NhaCungCapRespository>();
builder.Services.AddTransient<INhaCungCapBLL, NhaCungCapBLL>();

builder.Services.AddTransient<ISanPhamResponsitory, SanPhamResponsitory>();
builder.Services.AddTransient<ISanPhamBLL, SanPhamBLL>();


builder.Services.AddTransient<IDanhMucResponsitory, DanhMucResponsitory>();
builder.Services.AddTransient<IDanhMucBLL, DanhMucBLL>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();