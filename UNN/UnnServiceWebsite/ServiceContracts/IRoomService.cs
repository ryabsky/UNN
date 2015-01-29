using System.Collections.Generic;
using System.ServiceModel;
using DataContracts;

namespace ServiceContracts
{
    [ServiceKnownType(typeof(Room))]
    [ServiceKnownType(typeof(List<Room>))]
    [ServiceKnownType(typeof(Building))]
    [ServiceKnownType(typeof(List<Building>))]
    [ServiceKnownType(typeof(Class))]
    [ServiceKnownType(typeof(List<Class>))]
    [ServiceKnownType(typeof(Group))]
    [ServiceKnownType(typeof(List<Group>))]
    [ServiceKnownType(typeof(Teacher))]
    [ServiceKnownType(typeof(List<Teacher>))]
    [ServiceKnownType(typeof(Timesheet))]
    [ServiceKnownType(typeof(Headers))]
    [ServiceKnownType(typeof(Department))]
    [ServiceKnownType(typeof(Direction))]
    [ServiceKnownType(typeof(Weekday))]
    [ServiceKnownType(typeof(List<Weekday>))]
    [ServiceContract]
    public interface IRoomService
    {
        [OperationContract]
        IEnumerable<Room> GetRooms(int buildingId);

        [OperationContract]
        IEnumerable<Class> GetClasses();

        [OperationContract]
        Timesheet GetTimesheet();

        [OperationContract]
        void AddClassForYear(Class inputClass, int year);

        [OperationContract]
        void AddClassForDirection(Class inputClass, int year, int directionId);

        [OperationContract]
        void AddClassForGroup(Class inputClass);
    }
}
