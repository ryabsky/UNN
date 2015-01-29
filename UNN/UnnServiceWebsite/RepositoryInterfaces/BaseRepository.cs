using DataAccess;

namespace RepositoryInterfaces
{
    public abstract class BaseRepository
    {
        protected UNNEntities context;

        protected BaseRepository()
        {
            context = new UNNEntities();
        }
    }
}
