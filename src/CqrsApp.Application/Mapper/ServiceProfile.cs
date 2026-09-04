using AutoMapper;
using Contract.Service.V1.Product ;
using CqrsApp.Domain.Entities;
using DemoCICD.Contract.Services.V1.Product;

namespace CqrsApp.Application.Mapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Product, Response.ProductResponse>().ReverseMap();
    }
}