using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Business;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    // --------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();

    builder.Services.AddScoped<IRoomDal, EfRoomDal>();
    builder.Services.AddScoped<IGuestDal, EfGuestDal>();
    builder.Services.AddScoped<IAboutDal, EfAboutDal>();
    builder.Services.AddScoped<IStaffDal, EfStaffDal>();
    builder.Services.AddScoped<IContactDal, EfContactDal>();
    builder.Services.AddScoped<IServiceDal, EfServiceDal>();
    builder.Services.AddScoped<IBookingDal, EfBookingDal>();
    builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
    builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
    builder.Services.AddScoped<IMessageCategoryDal, EfMessageCategoryDal>();
    builder.Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
    builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
    
    builder.Services.AddScoped<IRoomService, RoomManager>();
    builder.Services.AddScoped<IGuestService, GuestManager>();
    builder.Services.AddScoped<IAboutService, AboutManager>();
    builder.Services.AddScoped<IStaffService, StaffManager>();
    builder.Services.AddScoped<IContactService, ContactManager>();
    builder.Services.AddScoped<IServiceService, ServiceManager>();
    builder.Services.AddScoped<IBookingService, BookingManager>();
    builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
    builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
    builder.Services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
    builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
    builder.Services.AddScoped<IAppUserService, AppUserManager>();

    // Mapper için tanımladık
    builder.Services.AddAutoMapper(typeof(Program));

    // CORS Yapılandırması Adım 1
    builder.Services.AddCors(options => 
    {
        options.AddPolicy("OtelApiCors", options =>
        {
            options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });
    // --------------------------------------------------------------------------------------

// builder.Services.AddControllers(); INCLUDE ÖZELLİKLİ METOTLARI WEBAPI İÇİNDE KULLANABİLMEK İÇİN BUNU SİLİP AŞAĞIDAKİ KODU EKLEMEMİZ GEREKİYOR VE AŞAĞIDAKİ NUGET'I EKLEMEMİZ GEREKİYOR
// NUGET : dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.0.12
builder.Services.AddControllers().AddNewtonsoftJson(options => 
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// -------------------------------------------------------------

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

app.UseHttpsRedirection();

    // CORS Yapılandırması Adım 2 --------------------------------------------------------------
    app.UseCors("OtelApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
