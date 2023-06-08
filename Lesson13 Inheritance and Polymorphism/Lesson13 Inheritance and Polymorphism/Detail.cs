
public class Detail
{
    protected string Name { get; set; }
    protected decimal Cost { get; set; }
    protected bool IsBrokenDetail { get; set; }

    public Detail(string Name, decimal Cost, bool isBroken)
    {
        this.Name = Name;
        this.Cost = Cost;
        this.IsBrokenDetail = isBroken;
    }

    public decimal GetCost() => Cost;
    public bool IsBroken() => IsBrokenDetail;
}
