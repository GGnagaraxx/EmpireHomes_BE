using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Controllers.Services;
using EmpireHomes_BE.Models.DTOs;
using EmpireHomes_BE.Models;

namespace EmpireHomes_BE.Controllers.Mappers
{
    public class ApplicationMapper
    {

        private readonly ApplicationService applicationService;
        private readonly IBlobStorage storage;
        private readonly string connectionString;
        private readonly string container;

        public ApplicationMapper(ApplicationService applicationService, IBlobStorage storage, IConfiguration iConfig)
        {
            this.applicationService = applicationService;
            this.storage = storage;
            connectionString = iConfig.GetValue<string>("StorageConnection");
            container = iConfig.GetValue<string>("MyConfig:ContainerName");
        }
        public Application ReqToApplication(ApplicationRequest applicaitonDto)
        {

            Application newApplication = new Application
            {
                Id = applicaitonDto.Id,
                FirstName = applicaitonDto.FirstName,
                LastName = applicaitonDto.LastName,
                Email = applicaitonDto.Email,
                ContactNumber = applicaitonDto.ContactNumber,
                Province = applicaitonDto.Province,
                City = applicaitonDto.City,
                NationalId = applicaitonDto.NationalId,
                IdType = applicaitonDto.IdType,
                IdNumber = applicaitonDto.IdNumber,


            };

            return newApplication;
        }
    }
}
