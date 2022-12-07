using Microsoft.AspNetCore.Mvc;
using DoggosApi.Models;
using DoggosApi.Interface;
using System.Text.Json;

namespace DoggosApi.Controllers
{
    public class PreviewController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public PreviewController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: Preview/Details/5
        [HttpGet]
        public IActionResult Details(long id)
        {
            Appointment? appointment = _appointmentService.GetAppointment(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(long id, [FromBody] JsonElement json)
        {
            Appointment? appointment = _appointmentService.EditAppointment(json, id);
            if (appointment == null)
            {
                return BadRequest();
            }
            return Ok(appointment);
        }



        // POST: Preview/Delete/5
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            return StatusCode(_appointmentService.DeleteAppointment(id));
        }
    }
}
