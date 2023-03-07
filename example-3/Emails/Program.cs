using Contracts;

var generator = new OrderGenerator();
var order = generator.Generate();
Console.WriteLine(order.ToString());