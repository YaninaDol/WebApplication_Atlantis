﻿using DataAccess.Data;
using RepositoriesLibrary;
using RepositoriesLibrary.Models;

namespace DataAccess
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(Atlantis20DbContext context) : base(context)
        {
           
        }


        public IEnumerable<Room> getAllList()
        {
            return db.Rooms.ToList();

        }

        public string getSide(int id)
        {
            if (db.RoomSides.Any(x => x.Id.Equals(id)))
                return db.RoomSides.ToList().Where(x => x.Id == id).FirstOrDefault().Name;
            else
                return "Null";
        }

        public bool Update(int IdUpdate,Room item)
        {
            if(db.Rooms.Any(x => x.Id.Equals(IdUpdate)) )
            
            {
                
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Name = item.Name;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Picture1 = item.Picture1;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Picture2 = item.Picture2;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Picture3 = item.Picture3;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Category = item.Category;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Capacity = item.Capacity;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Status = item.Status;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Description = item.Description;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Side = item.Side;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Views = getSide(Convert.ToInt32( item.Side));
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Size = item.Size;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Notice = item.Notice;

                return true;

            }
            else return false;

        }

        public IEnumerable<Room> Availability(DateTime Start, DateTime End, int Adults, int Children)
        {
            List <Room> availability= new List <Room>();

            foreach (var item in db.Categories.ToList())
            {
                Room select = db.Rooms.Where(x =>x.Category==item.Id&& x.Capacity >= (Adults + Children)).FirstOrDefault();
                if(checkAvailability(Start,End,select.Id))
                {
                    availability.Add(select);
                }
            }

            return availability;

           

        }
        public bool checkAvailability(DateTime Start, DateTime End,int roomnumber)

        {
            int f = 0;
            
            for (var day = Start; day.Date < End; day = day.AddDays(1))

            {

                if(db.ListBookDates.Any(x=>x.Date.Equals(day) && x.RoomNumber.Equals(roomnumber)))
                 {
                    f = 1;
                    return false;
                }

            }

            return true;
        }


    }
}
