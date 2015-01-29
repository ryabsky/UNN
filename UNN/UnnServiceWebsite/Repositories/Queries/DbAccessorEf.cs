using System.Linq;
using DataAccess;

namespace Repositories.Queries
{
    internal class DbAccessorEf
    {
        private readonly UNNEntities context;

        public DbAccessorEf() { }

        public DbAccessorEf(UNNEntities context) { this.context = context; }

        public IQueryable<class_assignments> GetClassAssignmentsForDay(int weekdayId)
        {
            return context.class_assignments.Where(x => x.weekday_id == weekdayId);
        }

        public IQueryable<class_assignments> GetClassAssignmentsForGroup(int groupId)
        {
            return context.group_assignments.Where(x => x.group_id == groupId).Select(y => y.class_assignments);
        }
    }
}
