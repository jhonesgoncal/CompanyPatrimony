using AutoMapper;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Service.ViewModels;

namespace CompanyPatrimony.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatrimonyViewModel, Patrimony>();
            CreateMap<BrandViewModel, Brand>();
            CreateMap<Patrimony, PatrimonyViewModel>();
            CreateMap<Brand, BrandViewModel>();
        }
    }
}