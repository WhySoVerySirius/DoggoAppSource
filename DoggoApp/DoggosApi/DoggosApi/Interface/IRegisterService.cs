using DoggosApi.Data;
using System.Net;

namespace DoggosApi.Interface
{
    public interface IRegisterService
    {
        public string GetIndexContent(ApplicationDbContext context);

    }
}
