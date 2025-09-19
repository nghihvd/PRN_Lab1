using AutoMapper;
using PRN232.Lab1.CoffeeStore.API.Models;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;

namespace PRN232.Lab1.CoffeeStore.API.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMenuModel, MenuRequestModel>();
        }
    }
}
