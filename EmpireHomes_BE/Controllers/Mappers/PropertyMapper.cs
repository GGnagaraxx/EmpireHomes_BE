using EmpireHomes_BE.Controllers.Services;
using EmpireHomes_BE.Controllers.Services.Azure;
using EmpireHomes_BE.Models;
using EmpireHomes_BE.Models.DTOs;

namespace EmpireHomes_BE.Controllers.Mappers
{
    public class PropertyMapper
    {
        private readonly PropertyService propertyService;
        private readonly IBlobStorage storage;
        private readonly string connectionString;
        private readonly string container;

        public PropertyMapper(PropertyService propertyService, IBlobStorage storage, IConfiguration iConfig)
        {
            this.propertyService = propertyService;
            this.storage = storage;
            connectionString = iConfig.GetValue<string>("StorageConnection");
            container = iConfig.GetValue<string>("MyConfig:ContainerName");
        }
        public async Task<Property> ReqToProperty(PropertyRequest propDTO)
        {
            Property newProperty = new Property
            {
                Id = propDTO.Id,
                Name = propDTO.Name,
                Location = propDTO.Location,
                Type = propDTO.Type,
                Demand = propDTO.Demand,
                Progress = propDTO.Progress,
                MinPrice = propDTO.MinPrice,
                MaxPrice = propDTO.MaxPrice,
                Description = propDTO.Description,
            };

            newProperty.ImageUrl = await propertyService.uploadImage(propDTO.ImageFile, storage, connectionString, container);

            return newProperty;
        }
    }
}
