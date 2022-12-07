using Microsoft.AspNetCore.Mvc;
using DoggosApi.Data;
using DoggosApi.Models;
using DoggosApi.Interface;
using System.Text.Json;

namespace DoggosApi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRegisterService _registerService;
        private readonly IAppointmentService _appointmentService;

        public RegisterController(
            ApplicationDbContext context,
            IRegisterService registerService,
            IAppointmentService appointmentService
        )
        {
            _context = context;
            _registerService = registerService;
            _appointmentService = appointmentService;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Index()
        {
            var response = _registerService.GetIndexContent(_context);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JsonElement json)
        {
            Appointment? appointment = await _appointmentService.SetAppointment(json);
            if (appointment == null)
            {
                return BadRequest();
            }
            return Ok(appointment);
        }
    }
}