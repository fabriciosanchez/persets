namespace Persets.Backend.Models
{
    public partial class PersetsDBEntities
    {
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}