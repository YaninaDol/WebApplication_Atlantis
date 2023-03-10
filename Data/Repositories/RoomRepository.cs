using DataAccess.Data;
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

        public bool Update(int IdUpdate, Room item)
        {
            if (db.Rooms.Any(x => x.Id.Equals(IdUpdate)))

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
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Views = getSide(Convert.ToInt32(item.Side));
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Size = item.Size;
                db.Rooms.Where(x => x.Id == IdUpdate).FirstOrDefault().Notice = item.Notice;

                return true;

            }
            else return false;

        }

        public IEnumerable<Room> Availability(DateTime Start, DateTime End, int Adults, int Children)
        {
            
            List<Room> availability = new List<Room>();
            foreach (var sides in db.RoomSides.ToList())
            {
                foreach (var item in db.Categories.ToList())
                {
                    Room select = db.Rooms.Where(x => x.Category == item.Id &&x.Side==sides.Id && x.Capacity >= (Adults + Children)&& x.Status!=3).FirstOrDefault();
                    if(select!=null)
                    { 
                    if (checkAvailability(Start, End, select.Id))
                    {
                        availability.Add(select);
                    }
                    }
                }
            }
          

            return availability;



        }
        public bool checkAvailability(DateTime Start, DateTime End, int roomnumber)

        {
           
            if (Start.Day >= DateTime.Now.Day & Start.Month >= DateTime.Now.Month&&Start.Year >= DateTime.Now.Year &&
                End.Day > DateTime.Now.Day & End.Month >= DateTime.Now.Month && End.Year >= DateTime.Now.Year)
            {
                for (var day = Start; day.Date < End; day = day.AddDays(1))

                {

                    if (db.ListBookDates.Any(x => x.Date.Equals(day.Date) && x.RoomNumber.Equals(roomnumber)))
                    {
                       
                        return false;
                    }

                }

                return true;
            }
            else return false;
        }

        public bool booking(int roomNumber, string userID, DateTime Start, DateTime End, string phoneNumber, string notice)
        {
            if (checkAvailability(Start, End, roomNumber))
            {
                db.BookingInfos.Add(new BookingInfo() { DateFisrt = Start, DateLast = End, TotalDays = End.Subtract(Start).Days, UserId = userID, RoomNumber = roomNumber, PhoneNumber = phoneNumber, Notes = notice, Status = "new" });

                for (var day = Start; day.Date < End; day = day.AddDays(1))

                {

                    db.ListBookDates.Add(new ListBookDate() { RoomNumber=roomNumber,UserId=userID, Date=day.Date});
                   

                }

                return true;
            }
            else return false;


        }


    }
}
