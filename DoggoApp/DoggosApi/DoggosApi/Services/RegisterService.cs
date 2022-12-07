using DoggosApi.Data;
using DoggosApi.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DoggosApi.Models;
using Newtonsoft.Json;

namespace DoggosApi.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UuidGenerator _uuidGenerator;
        public RegisterService(UuidGenerator uuidGenerator)
        {
            _uuidGenerator = uuidGenerator;
        }
        public string GetIndexContent(ApplicationDbContext context)
        {
            object response = new IndexData()
            {
                Breeds = context.Breeds.ToList(),
                Uuid = _uuidGenerator.generatedUuid
            };
            return JsonConvert.SerializeObject(response);
        }
    }
}
