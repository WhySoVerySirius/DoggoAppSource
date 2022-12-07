using DoggosApi.Data;
using DoggosApi.Models;

namespace DoggosApi.Services
{
    public class UuidGenerator
    {
        private readonly ApplicationDbContext _context;
        public long generatedUuid;
        public UuidGenerator(ApplicationDbContext context)
        {
            _context = context;
            generatedUuid = GetUuid();
        }

        private long GetUuid()
        {
            Random rnd = new Random();
            long uuid = rnd.NextInt64(10000000000, 99999999999);
            if (CheckIfUnique(uuid))
            {
                return uuid;
            }
            return GetUuid();
        }

        private bool CheckIfUnique(long uuid)
        {
            Appointment? appointment = _context.Appointments.Where(appointment => appointment.Uuid == uuid).FirstOrDefault();
            if (appointment == null)
            {
                return true;
            }
            return false;
        }
    }
}
