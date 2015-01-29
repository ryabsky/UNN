using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using DataAccess;
using DataContracts;
using EntityFramework.Extensions;
using RepositoryInterfaces;
using Utils;

namespace Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public IEnumerable<Room> GetRooms(int buildingId)
        {
            var result = context.rooms.Where(x => x.building_id == buildingId)
                .Select(r => new Room
                {
                    BuildingId = r.building_id,
                    RoomId = r.room_id,
                    RoomNumber = r.room_number
                }).ToList();
            return result;
        }

        public Timesheet GetTimesheet()
        {
            return new Timesheet
            {
                Classes = GetClasses(),
                Headers = new Headers
                {
                    GroupList = context.groups.Select(x => x.group_id).ToList(),
                    StartTimeList = context.start_times.ToList().Select(x => x.start_time_id.AsString()),
                    WeekdayList = context.weekdays.Select(x => (Weekday)x.weekday_id).ToList()
                }
            };
        }

        public IEnumerable<Class> GetClasses()
        {
            var classes = context.class_assignments.ToList().Select(x => new Class
            {
                ClassAssignmentId = x.class_assignment_id,
                ClassName = x.class_name,
                StartTime = x.start_time_id.AsString(),
                Weekday = (Weekday)x.weekday_id,
                IsLecture = x.lecture_indicator,
                IsLowerWeek = x.odd_even_indicator,
                Room = new Room
                {
                    BuildingId = x.room.building_id,
                    RoomId = x.room_id,
                    RoomNumber = x.room.room_number
                },
                Teacher = new Teacher
                {
                    TeacherId = x.teacher.teacher_id,
                    FirstName = x.teacher.first_name,
                    LastName = x.teacher.last_name
                },
                Groups = x.group_assignments.Select(g => new Group
                {
                    Direction = (Direction)g.group.direction_id,
                    GroupId = g.group_id,
                    Year = g.group.year_id
                })
            });

            /*  AddClassForYear(new Class
                       {
                           ClassName = "Fizra",
                           IsLecture = false,
                           IsLowerWeek = null,
                           Room = new Room {RoomNumber = 0, BuildingId = 12},
                           StartTime = new TimeSpan(11, 20, 0),
                           Weekday = Weekday.Tuesday,
                           Teacher = new Teacher {LastName = "OTHER"},
                       }, 1);
            
                       UpdateClassForGroup(new Class
                       {
                           ClassName = "Fizra",
                           IsLecture = false,
                           IsLowerWeek = false,
                           Room = new Room {RoomNumber = 0, BuildingId = 12},
                           StartTime = new TimeSpan(11, 20, 0),
                           Weekday = Weekday.Tuesday,
                           Teacher = new Teacher {LastName = "OTHER"},
                       }, null);
                       */
            return classes;
        }

        public void AddClassForYear(Class inputClass, int year)
        {
            inputClass.Groups = context.groups.Where(x => x.year_id == year).Select(g => new Group {GroupId = g.group_id});
            AddClassForGroup(inputClass);
        }

        public void AddClassForDirection(Class inputClass, int year, int directionId)
        {
            inputClass.Groups = context.groups.Where(x => x.year_id == year).Where(x => x.direction_id == directionId).Select(g => new Group {GroupId = g.group_id});
            AddClassForGroup(inputClass);
        }

        public void UpdateClassForGroup(Class oldClass, Class newClass)
        {
            var roomId = context.rooms.Single(x => x.room_number == oldClass.Room.RoomNumber && x.building_id == oldClass.Room.BuildingId).room_id;

            context.class_assignments.Where(x => x.room_id == roomId &&
                                                 x.start_time_id == oldClass.StartTime.AsTimeSpan() &&
                                                 x.weekday_id == (int) oldClass.Weekday &&
                                                 x.odd_even_indicator == oldClass.IsLowerWeek)
                                     .Update(t => new class_assignments
                                     {
                                         odd_even_indicator = null
                                     });
        }

        public void AddClassForGroup(Class inputClass)
        {
            using (var transaction = new TransactionScope())
            {
                int teacherId;
                var roomId = context.rooms.Single(x => x.room_number == inputClass.Room.RoomNumber && x.building_id == inputClass.Room.BuildingId).room_id;
                try
                {
                    teacherId = context.teachers.Single(x => x.last_name.Contains(inputClass.Teacher.LastName)).teacher_id;
                }
                catch (Exception ex)
                {
                    throw new Exception("Zero or multiple teachers with name '" + inputClass.Teacher.LastName + "' were found. The database was not updated.", ex);
                }

                context.class_assignments.Add(new class_assignments
                {
                    class_name = inputClass.ClassName,
                    room_id = roomId,
                    start_time_id = inputClass.StartTime.AsTimeSpan(),
                    teacher_id = teacherId,
                    weekday_id = (int)inputClass.Weekday,
                    lecture_indicator = inputClass.IsLecture,
                    odd_even_indicator = inputClass.IsLowerWeek,
                });

                context.SaveChanges();

                var classAssignmentId = context.class_assignments.Local.Single(x => x.room_id == roomId &&
                                                                                    x.start_time_id == inputClass.StartTime.AsTimeSpan() &&
                                                                                    x.weekday_id == (int)inputClass.Weekday &&
                                                                                    x.odd_even_indicator == inputClass.IsLowerWeek).class_assignment_id;

                foreach (var group in inputClass.Groups)
                {
                    context.group_assignments.Add(new group_assignments
                    {
                        class_assignment_id = classAssignmentId,
                        group_id = group.GroupId
                    });
                }

                context.SaveChanges();

                transaction.Complete();
            }
        }
    }
}
