using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Strategy.ConcreteStrategies;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Strategy;
using FurnitureStoreAPI.Services;
using FurnitureStoreAPI.Services.DecoratorCoffeeService;
using FurnitureStoreAPI.Services.SimpleFlyWeightService;
using FurnitureStoreAPI.Services.StrategyPaymentService;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer.ConcreteObservers;
using FurnitureStoreAPI.Patterns.BehavioralPattterns.RefactoringGuru.Observer;
using FurnitureStoreAPI.Services.ObserverStockService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add FurnitureService as a Singleton
builder.Services.AddSingleton<FurnitureService>();
builder.Services.AddSingleton<CoffeeShopService>();
builder.Services.AddSingleton<SimpleFlyweightService>();
builder.Services.AddSingleton<StrategyPaymentService>();
builder.Services.AddSingleton<ObserverStockService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Strategy Design Pattern from Refactoring Guru
// The client code picks a concrete strategy and passes it to the
// context. The client should be aware of the differences between
// strategies in order to make the right choice.
var context = new Context();

Console.WriteLine("Client: Strategy is set to normal sorting.");
context.SetStrategy(new ConcreteStrategyA());
context.DoSomeBusinessLogic();

Console.WriteLine();

Console.WriteLine("Client: Strategy is set to reverse sorting.");
context.SetStrategy(new ConcreteStrategyB());
context.DoSomeBusinessLogic();


// OBSERVER DESING PATTERN - REFACTORING GURU
// The client code.
var subject = new Subject();
var observerA = new ConcreteObserverA();
subject.Attach(observerA);

var observerB = new ConcreteObserverB();
subject.Attach(observerB);

subject.SomeBusinessLogic();
subject.SomeBusinessLogic();

subject.Detach(observerB);

subject.SomeBusinessLogic();