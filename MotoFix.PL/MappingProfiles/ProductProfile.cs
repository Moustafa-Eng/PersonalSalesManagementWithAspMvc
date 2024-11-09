using AutoMapper;
using MotoFix.BLL.Repositories;
using MotoFix.DAL.Models;
using MotoFix.PL.ViewModels;

namespace MotoFix.PL.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
