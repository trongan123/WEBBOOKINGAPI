using Repositories.IService;
using Repositories.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<IBookingRoomDetailService, BookingRoomDetailService>();
builder.Services.AddTransient<IBookingSeviceDetailService, BookingSeviceDetailService>();
builder.Services.AddTransient<IBookingTransportDetailService, BookingTransportDetailService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IRoomTypeSevice, RoomTypeSevice>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<ITransportService, TransportService>();
builder.Services.AddTransient<ITypeTransportService, TypeTransportService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
