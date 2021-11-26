using WebApi.Models;

namespace WebApi.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;

        #region Constructor
        static PizzaService()
        {
            Pizzas = new List<Pizza>()
            {
                new Pizza { 
                    Id = 1, 
                    Name = "Classic Italian", 
                    IsGlutenFree = false,
                    Ingredients = new List<Ingredients>(),
                    Image="https://images.unsplash.com/photo-1571997478779-2adcbbe9ab2f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=387&q=80" 
                },

                new Pizza { 
                    Id = 2, 
                    Name = "Veggie", 
                    IsGlutenFree = true,
                    Ingredients = new List<Ingredients>(),
                    Image = "https://images.unsplash.com/photo-1595854341625-f33ee10dbf94?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80"
                },
                
                new Pizza { 
                    Id = 3, 
                    Name = "Pepperoni Special Meatlovers", 
                    IsGlutenFree = false,
                    Ingredients = new List<Ingredients>(),
                    Image = "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1176&q=80"
                },
            };
        }
        #endregion

        public static List<Pizza> GetAll() => Pizzas;
        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
        public static void Add(Pizza pizza)
        {
            pizza.Id = ++nextId;
            Pizzas.Add(pizza);
        }
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
            {
                return;
            }
            Pizzas.Remove(pizza);
        }
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
            {
                return;
            }

            Pizzas[index] = pizza;
        }
    }
}
