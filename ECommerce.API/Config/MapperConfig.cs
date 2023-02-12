using AutoMapper;
using ECommerce.API.Dtos;
using ECommerce.API.Entities;

namespace ECommerce.API.Config
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientCreateDto, Client>();
            CreateMap<ClientUpdateDto, Client>();
           
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<InvoiceCreateDto, Invoice>();
            CreateMap<InvoiceUpdateDto, Invoice>();

            CreateMap<InvoiceDetailDto, InvoiceDetail>().ReverseMap();
            CreateMap<InvoiceDetailCreateDto, InvoiceDetail>();

        }
    }
}
