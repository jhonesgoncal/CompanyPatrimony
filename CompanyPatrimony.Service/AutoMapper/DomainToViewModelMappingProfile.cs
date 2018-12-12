using AutoMapper;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Service.ViewModels;

namespace CompanyPatrimony.Service.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Patrimony, PatrimonyViewModel>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}