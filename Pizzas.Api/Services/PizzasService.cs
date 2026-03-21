using Pizzas.Api.Dtos;

namespace Pizzas.Api.Services
{
    public class PizzasService
    {

        public List<ProductoDto> ObtenerPizzas()
        {
            var productos = new List<ProductoDto>
            {
                new ProductoDto
                {
                    Id = 1,
                    Nombre = "Carbonara",
                    Ingredientes = null,
                    Ruta = "/images/pizzas/022238e3-ac62-45af-b765-379a077a9b26.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 2,
                    Nombre = "Triple peperoni",
                    Ingredientes = null,
                    Ruta = "/images/pizzas/00455854-40f9-45e2-a241-b03e70dfe6cc.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 3,
                    Nombre = "Peperoni",
                    Ingredientes = null,
                    Ruta = "/images/pizzas/be242cad-08db-4b00-becd-be48a9fb86a4.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 4,
                    Nombre = "Hawaiina",
                    Ingredientes = null,
                    Ruta = "/images/pizzas/75b89c2b-2c59-4225-8478-4e9ab4432ec9.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 5,
                    Nombre = "Mexicana",
                    Ingredientes = null,
                    Ruta = "/images/pizzas/7f339d0c-bf13-4839-a9dc-de6721210a5b.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 6,
                    Nombre = "Texas bbq",
                    Ingredientes = "Salsa BBQ, Salsa de tomate, Carne molida, Pollo, Tocino",
                    Ruta = "/images/pizzas/67734d82-5c38-40f8-a311-255c0d157bd5.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 7,
                    Nombre = "Cuatro quesos",
                    Ingredientes = null,
                    Ruta = "images/pizzas/0ad30a1e-d7ed-4384-9b1e-b8a5c9587174.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 8,
                    Nombre = "Pepperoni especial",
                    Ingredientes = null,
                    Ruta = "images/pizzas/8be27c50-bb3c-4774-ac8f-a41f42029617.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 9,
                    Nombre = "Carnes frias",
                    Ingredientes = null,
                    Ruta = "images/pizzas/f8748c06-e178-4d38-b99c-a522ad450a86.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 10,
                    Nombre = "Chicken hawaiina",
                    Ingredientes = null,
                    Ruta = "images/pizzas/49249843-d9af-4356-bcac-ae94e3357742.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 11,
                    Nombre = "Honolulu",
                    Ingredientes = null,
                    Ruta = "images/pizzas/cdcef20a-407a-488e-9751-6f481a871048.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 12,
                    Nombre = "Veggie",
                    Ingredientes = null,
                    Ruta = "images/pizzas/3f362b55-3f56-47f9-b67a-ff49eb10f66a.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 13,
                    Nombre = "Extravaganzza",
                    Ingredientes = null,
                    Ruta = "images/pizzas/db99ef86-f2b8-4a8e-8afb-5ad4409e4233.jpg",
                    Precio = 0
                },
                new ProductoDto
                {
                    Id = 14,
                    Nombre = "Deluxe",
                    Ingredientes = null,
                    Ruta = "images/pizzas/9614b6f3-0def-4ace-8c5d-e0954d899a5b.jpg",
                    Precio = 0
                }
            };

            return productos;
        }
    }
}
