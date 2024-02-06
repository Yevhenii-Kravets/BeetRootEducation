public interface ITrade
{
    public void Pay(decimal money);
    public void AddMoney(decimal money);
    public decimal GetMoney();
}