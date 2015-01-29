using System.Collections.Generic;
using DataContracts;

namespace RepositoryInterfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms(int buildingId);
        IEnumerable<Class> GetClasses();
        Timesheet GetTimesheet();
        void AddClassForYear(Class inputClass, int year);
        void AddClassForDirection(Class inputClass, int year, int directionId);
        void AddClassForGroup(Class inputClass);
    }
}
