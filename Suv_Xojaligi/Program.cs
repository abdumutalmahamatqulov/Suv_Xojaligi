using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Suv_Xojaligi.Data.Contexts;
using Suv_Xojaligi.Data.Entities;
using Suv_Xojaligi.V1.Auth.Services.Extentions;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
.AddJsonOptions(o => {
    o.JsonSerializerOptions.Converters.Add(new JsonTimeSpanConverter());
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));



builder.Services.AddEntityFrameworkCore();
builder.Services.AddServiceConfiguration()
    .AddSwaggerService(builder.Configuration);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
class JsonTimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        /*        var bytes = new Span<byte>();
                reader.CopyString(bytes);
                var str = Encoding.UTF8.GetString(bytes);
                return TimeSpan.Parse(str);*/
        var str = reader.GetString();
        return TimeSpan.Parse(str);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
       // writer.WriteRawValue(value.ToString());
       writer.WriteStringValue(value.ToString());
    }
}
