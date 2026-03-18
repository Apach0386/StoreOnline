Console.WriteLine("Hello, World!");


decimal CalculateTotalProductPrice (int quantity, decimal price)
{ 
    var res = quantity * price;
    Console.WriteLine(res);
    return res;
};

decimal CalculateDiscountPerPerson (decimal totalPrice, bool rule, decimal discount)
{ 
    if (rule)
    {
        var res = totalPrice - (totalPrice * discount / 100);
        return res;
    }
    else
    {
        return totalPrice;
    }
}

void PrintTotalPrice (decimal totalPrice)
{
    Console.WriteLine($"Total price: {totalPrice}");
}