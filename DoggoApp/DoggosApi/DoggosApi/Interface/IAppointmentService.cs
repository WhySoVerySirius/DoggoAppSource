using DoggosApi.Models;
using System.Text.Json;

namespace DoggosApi.Interface
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment? GetAppointment(long id);
        public Task<Appointment?> SetAppointment(JsonElement json);
        public Appointment? EditAppointment(JsonElement json, long id);
        public int DeleteAppointment(long id);
    }
}
