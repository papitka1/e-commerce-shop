namespace E_commerceShop.Models
{
    public class Product
    {
        int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public bool isAvalible { get; set; }

        public string DamageClass   { get; set; }

        public int Quantity { get; set; }

        public virtual Shipping Shipp { get; set; }

    }
}
