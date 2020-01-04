namespace AOC2019.Modules.Fuel.NanoFactories
{
    public struct Ingredient
    {
        public string Type { get; set; }
        public int Quantity { get; set; }

        public static Ingredient operator *(Ingredient a, int b) => new Ingredient
        {
            Quantity = a.Quantity * b,
            Type = a.Type
        };

        public static Ingredient operator *(int a, Ingredient b) => new Ingredient
        {
            Quantity = b.Quantity * a,
            Type = b.Type
        };

        public static Ingredient operator +(Ingredient a, int b) => new Ingredient
        {
            Quantity = a.Quantity + b,
            Type = a.Type
        };

        public static Ingredient operator +(int a, Ingredient b) => new Ingredient
        {
            Quantity = b.Quantity + a,
            Type = b.Type
        };

        public static Ingredient operator -(Ingredient a, int b) => new Ingredient
        {
            Quantity = a.Quantity - b,
            Type = a.Type
        };

        public static Ingredient operator -(int a, Ingredient b) => new Ingredient
        {
            Quantity = b.Quantity - a,
            Type = b.Type
        };

        public override string ToString() => $"{Quantity} {Type}";
    }
}
