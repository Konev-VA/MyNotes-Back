
using MyNotes.BLL.Implementations;
using MyNotes.BLL.Interfaces;
using MyNotes.DAL.Implementations;
using MyNotes.DAL.Interfaces;

namespace MyNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("devPostgres");

            builder.Services.AddSingleton<INotesDAL, NotesDAL>(provider => new NotesDAL(connectionString));
            builder.Services.AddSingleton<INotesBLL, NotesBLL>();

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
        }
    }
}