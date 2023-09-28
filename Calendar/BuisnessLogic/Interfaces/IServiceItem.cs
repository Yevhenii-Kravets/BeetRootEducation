namespace BuisnessLogic.Interfaces
{
    public interface IServiceItem<T> where T : class
    {
        public IEnumerable<T> GetInRange(DateTime start, DateTime end);
        public IEnumerable<T> GetAll();
        public Guid Create(T item);
        public Guid Update(T item);
        public Guid Delete(Guid id);
    }
}
