using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SRP
{
    public sealed class Pizzeria
    {
        private static IReadOnlyDictionary<string, decimal> Toppings = new Dictionary<string, decimal>()
        {
            {"Salami", 3.0m},
            {"Mozzarella Di Bufala", 2.5m},
            {"Sun Dried Tomatoes", 2.0m },
            {"Ananas", 1.5m },
            {"Bacon", 2.5m },
            {"Prosciutto", 3.0m },
            {"Shrimp", 3.25m },
        };

        private static IReadOnlyDictionary<string, decimal> Pizzas = new Dictionary<string, decimal>()
        {
            {"Margarita", 8.0m },
            {"Fantasia", 12.0m },
            {"Petri's Pizzeria Special", 10m },
        };


        public void TakeAnOrder(string ordererEmail, string pizza, List<string> additionalToppings)
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


        }

    }
}
