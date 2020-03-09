using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SRP
{
    public sealed class Pizzeria
    {
        private static readonly IReadOnlyDictionary<string, decimal> Toppings = new Dictionary<string, decimal>()
        {
            {"Salami", 3.0m},
            {"Mozzarella Di Bufala", 2.5m},
            {"Sun Dried Tomatoes", 2.0m },
            {"Ananas", 1.5m },
            {"Bacon", 2.5m },
            {"Prosciutto", 3.0m },
            {"Shrimp", 3.25m },
        };

        private static readonly IReadOnlyDictionary<string, decimal> Pizzas = new Dictionary<string, decimal>()
        {
            {"Margarita", 8.0m },
            {"Fantasia", 12.0m },
            {"Petri's Pizzeria Special", 10m },
        };


        public async Task TakeAnOrder(string ordererEmail, string pizza, List<string> additionalToppings)
        {
            var isValidEmail = new EmailAddressAttribute().IsValid(ordererEmail);
            if (!isValidEmail)
            {
                throw new InvalidEmailException(ordererEmail);
            }

            if (!Pizzas.ContainsKey(pizza))
            {
                throw new PizzaNotFoundException(pizza);
            }

            var isAllToppingsValid = additionalToppings.All(Toppings.ContainsKey);
            if (!isAllToppingsValid)
            {
                var notFoundTopping = additionalToppings.First(x => !Toppings.ContainsKey(x));
                throw new ToppingNotFoundException(notFoundTopping);
            }

            var pizzaPrice = Pizzas[pizza] + additionalToppings.Sum(x => Toppings[x]);

            //Give discount of 5% if 5 additional toppings has been added, excluding Fantasia
            if (5 <= additionalToppings.Count && pizza != "Fantasia")
            {
                pizzaPrice *= 0.95m;
            }

            var db = new Database();
            var customerId = await db.Query<int?>("SELECT ID FROM Customers WHERE Email = @Email", new {Email = ordererEmail});

            if (!customerId.HasValue)
            {
                await db.Execute("INSERT INTO Customers (Email) VALUES (@Email)", new {Email = ordererEmail});
                customerId = await db.Query<int?>("SELECT ID FROM Customers WHERE Email = @Email",
                    new {Email = ordererEmail});
            }

            await db.Execute(
                "INSERT INTO Orders (OrdererEmail, Pizza, ListOfToppings, Price) Values (@Email, @Pizza, @ListOfToppings, @Price)",
                new
                {
                    Email = ordererEmail,
                    Pizza = pizza,
                    ListOfToppings = string.Join(",", additionalToppings),
                    Price = pizzaPrice
                });


            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sendgrid.com/v3/mail/send");
            request.Headers.Add("Authorization", "Bearer Aeofkewpofkwaop53251095121==");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = new StringContent(@"{""personalizations"": [{""to"": [{""email"": """ + ordererEmail + @"""}]}],""subject"": ""Pizza order"",""content"": [{""type"": ""text/plain"", ""value"": ""Your pizza is on the way""}]}");
            var httpClient = new HttpClient();
            await httpClient.SendAsync(request);

        }

    }
}
