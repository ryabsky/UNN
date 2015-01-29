using System.Collections.Generic;
using DataContracts;
using Repositories;
using RepositoryInterfaces;
using ServiceContracts;

namespace DataServices
{
    public class RoomService : IRoomService
    {
        protected IRoomRepository roomRepository = new RoomRepository();

        public IEnumerable<Room> GetRooms(int buildingId)
        {
            var result = roomRepository.GetRooms(buildingId);
            return result;
        }

        public IEnumerable<Class> GetClasses()
        {
            var result = roomRepository.GetClasses();
            return result;
        }

        public Timesheet GetTimesheet()
        {
            var result = roomRepository.GetTimesheet();
            return result;
        }

        public void AddClassForYear(Class inputClass, int year)
        {
            roomRepository.AddClassForYear(inputClass, year);
        }

        public void AddClassForDirection(Class inputClass, int year, int directionId)
        {
            roomRepository.AddClassForDirection(inputClass, year, directionId);
        }

        public void AddClassForGroup(Class inputClass)
        {
            roomRepository.AddClassForGroup(inputClass);
        }
    }
}
