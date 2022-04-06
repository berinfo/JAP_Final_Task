using server.Models;

namespace server.Dtos
{
    public class GetIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string PurchaseUnit { get; set; }
        public int PurchasePrice { get; set; }
        public int PurchaseQuantity { get; set; }

    }
}
