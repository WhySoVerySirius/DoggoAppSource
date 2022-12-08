using DoggosApi.Models;
using DoggosApi.Interface;
using DoggosApi.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;


namespace DoggosApi.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJsonValidateService _jsonValidateService;

        public AppointmentService(ApplicationDbContext context, IJsonValidateService jsonValidateService)
        {
            _context = context;
            _jsonValidateService = jsonValidateService;
        }

        public Appointment? EditAppointment(JsonElement json, long id)
        {
            if (!_jsonValidateService.ValidateJson(json, "Appointment")) return null;
            Appointment? appointment = JsonSerializer.Deserialize<Appointment>(json);
            if (
                appointment != null
                && _context.Appointments.Where(x=>x.Uuid == appointment.Uuid).Include(appointment => appointment.Breed).FirstOrDefault() is Appointment found
                && found != null
                && found.Uuid == id
                && appointment.Uuid == found.Uuid
                && appointment.Id == found.Id
            )
            {
                Breed? breed = _context.Breeds.Find(appointment.BreedID);
                _context.Entry(found).CurrentValues.SetValues(appointment);
                if (breed == null)
                {
                    found.Breed = null;
                } else
                {
                    found.Breed = breed;
                };
                try {
                    _context.SaveChanges();
                    return GetAppointment(appointment.Uuid);
                } catch (Exception ex) {
                    return null;
                }
            }
            return null;
        }

        public Appointment? GetAppointment(long id)
        {
            return _context.Appointments.Where(x => x.Uuid == id).Include(appointment => appointment.Breed).FirstOrDefault();
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment?> SetAppointment(JsonElement json)
        {
            if (!_jsonValidateService.ValidateJson(json, "AppointmentRegister")) return null;
            Appointment? appointment = JsonSerializer.Deserialize<Appointment>(json);
            if (appointment != null && _context.Appointments.Where(x => x.Uuid == appointment.Uuid).FirstOrDefault() == null)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return GetAppointment(appointment.Uuid);
            }
            return null;
        }

        public int DeleteAppointment(long uuid)
        {
            //if (!ValidateJson(json, "Appointment")) return 400;
            Appointment? appointmentDb = _context.Appointments.Where(x=>x.Uuid == uuid).FirstOrDefault();
            //Appointment? appointment = JsonSerializer.Deserialize<Appointment>(json);
            //CompareLogic compare = new CompareLogic();
            //compare.Config.IgnoreProperty<Appointment>(x => x.Id);
            //compare.Config.IgnoreProperty<Appointment>(x => x.Breed);
            //compare.Config.IgnoreProperty<Appointment>(x => x.BreedID);
            //var comparison = compare.Compare(appointmentDb, appointment);
            //if (appointmentDb == null || !comparison.AreEqual)
            //{
            //    return 400;
            //}
            if (appointmentDb == null) return 400; 
            _context.Appointments.Remove(appointmentDb);
            _context.SaveChanges();
            return 204;
        }
    }
}
