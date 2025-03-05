using KennysCorner.Api;
using Marten;
using Marten.Events;
using Marten.Linq.SoftDeletes;
using Microsoft.AspNetCore.Http.HttpResults;
using Scalar.AspNetCore;

var builder = WebApplication.CreateSlimBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenApi();

builder.AddNpgsqlDataSource("psql");
builder.Services.AddMarten().UseNpgsqlDataSource();

builder.Services.AddSingleton<TimeProvider>(TimeProvider.System);

var app = builder.Build();
app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

var orderGroup = app.MapGroup("orders");

orderGroup.MapPost(
    string.Empty,
    async (IDocumentStore documentStore, TimeProvider timeProvider, string name) =>
    {
        await using var session = documentStore.LightweightSession();
        var @event = new Events.OrderCreated(timeProvider.GetUtcNow(), name);
        session.Events.StartStream<Order>(@event.Id, @event);
        await session.SaveChangesAsync();
        return TypedResults.Ok(@event);
    }
);

orderGroup.MapPut(
    "{id:guid}",
    async (IDocumentStore documentStore, Guid id, string newName) =>
    {
        await using var session = documentStore.LightweightSession();
        var @event = new Events.OrderNameChanged(newName);
        session.Events.Append(id, @event);
        await session.SaveChangesAsync();

        var order = await session.Events.AggregateStreamAsync<Order>(id);
        return TypedResults.Ok(order);
    }
);

orderGroup.MapGet(
    "{id:guid}",
    async (IDocumentStore documentStore, Guid id) =>
    {
        await using var session = documentStore.QuerySession();
        var order = await session.Events.AggregateStreamAsync<Order>(id);
        return TypedResults.Ok(order);
    }
);

app.Run();

namespace KennysCorner.Api
{
#pragma warning disable CA1515
#pragma warning disable CA1034
    public static class Events
    {
        public sealed record OrderCreated(DateTimeOffset Time, string Name)
        {
            public Guid Id { get; } = Guid.CreateVersion7();
        }

        public sealed record OrderNameChanged(string NewName);
    }

    public sealed class Order
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTimeOffset Time { get; set; }

        public static Order Create(IEvent<Events.OrderCreated> @event)
        {
            return new Order
            {
                Id = @event.Data.Id,
                Name = @event.Data.Name,
                Time = @event.Data.Time,
            };
        }

        public void Apply(Events.OrderNameChanged @event)
        {
            Name = @event.NewName;
        }
    }
#pragma warning restore CA1515
#pragma warning restore CA1034
}
