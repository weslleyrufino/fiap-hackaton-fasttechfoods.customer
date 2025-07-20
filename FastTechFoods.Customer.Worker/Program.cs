using FastTechFoods.Customer.Infrastructure.Repository;
using FastTechFoods.Customer.Worker.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

        // MassTransit + RabbitMQ
        services.AddMassTransit(x =>
        {
            x.AddConsumer<MenuItemConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                var section = configuration.GetSection("MassTransit_CreateItemMenu");

                cfg.Host(section["Servidor"], h =>
                {
                    h.Username(section["Usuario"]);
                    h.Password(section["Senha"]);
                });

                cfg.ReceiveEndpoint(section["NomeFila"], e =>
                {
                    e.ConfigureConsumer<MenuItemConsumer>(context);
                });
            });
        });

        services.AddMassTransitHostedService();
        services.AddScoped<MenuItemConsumer>();
    })
    .Build()
    .Run();
