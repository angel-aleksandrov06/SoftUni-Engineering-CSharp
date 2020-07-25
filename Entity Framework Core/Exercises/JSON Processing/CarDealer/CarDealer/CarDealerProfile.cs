namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using AutoMapper;
    using CarDealer.DTO.Car;
    using CarDealer.DTO.Customer;
    using CarDealer.DTO.Supply;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, OrderedCustomersDTO>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<Car, CarMakeToyotaDTO>();

            this.CreateMap<Supplier, LocalSuplliersDTO>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(z => z.Parts.Count));

            this.CreateMap<Customer, CustomerSalesDTO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(z => z.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(z => z.Sales.Sum(k => k.Car.PartCars.Sum(j => j.Part.Price))));
                
        }
    }
}
