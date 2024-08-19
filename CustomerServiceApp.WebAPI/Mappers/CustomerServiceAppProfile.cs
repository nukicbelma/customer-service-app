using AutoMapper;
using CustomerServiceApp.WebAPI.DTOs.Customer;

namespace CustomerServiceApp.WebAPI.Mappers
{
    public class CustomerServiceAppProfile : Profile
    {
        public CustomerServiceAppProfile() {

            CreateMap<Database.Customer, CustomerDTO>().ReverseMap();                    // Customer
            CreateMap<Database.Customer, CustomerSearchDTO>().ReverseMap();
            CreateMap<Database.Customer, CustomerCreateDTO>().ReverseMap();
            CreateMap<Database.Customer, CustomerUpdateDTO>().ReverseMap();
        }
    }
}
