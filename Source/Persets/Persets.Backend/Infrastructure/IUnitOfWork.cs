namespace Persets.Backend.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}