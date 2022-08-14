using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Service.DTO_s.Airplanes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportSystem.Domain.Entities.Airports;
using AirportSystem.Service.DTO_s.Airports;
using AirportSystem.Domain.Entities.BlackLists;
using AirportSystem.Service.DTO_s.BlackLists;
using AirportSystem.Domain.Entities.Employees;
using AirportSystem.Service.DTO_s.Employees;
using AirportSystem.Domain.Entities.Orders;
using AirportSystem.Service.DTO_s.Orders;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Service.DTO_s.Passengers;
using AirportSystem.Domain.Entities.Payments;
using AirportSystem.Service.DTO_s.Payments;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Service.DTO_s.RoulTable;
using AirportSystem.Domain.Entities.Tickets;
using AirportSystem.Service.DTO_s.Tickets;

namespace AirportSystem.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airplane, AirplaneForCreation>().ReverseMap();
            CreateMap<Airport, AirportForCreation>().ReverseMap();
            CreateMap<Employee, EmployeeForCreation>().ReverseMap();
            CreateMap<Ticket, TicketForCreation>().ReverseMap();
            CreateMap<Payment, PaymentForCreation>().ReverseMap();
            CreateMap<RouleTable, RoulTableForCreation>().ReverseMap();
            CreateMap<Passenger, PassengerForCreation>().ReverseMap();
            CreateMap<Order, OrderForCreation>().ReverseMap();
            CreateMap<BlackList, BlackListForCreation>().ReverseMap();
            
        }
    }
}
