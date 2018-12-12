using AutoMapper;
using CompanyPatrimony.Domain.Entities;
using CompanyPatrimony.Service.ViewModels;

namespace CompanyPatrimony.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PatrimonyViewModel, Patrimony>();
            CreateMap<BrandViewModel, Brand>();
        }
    }
}