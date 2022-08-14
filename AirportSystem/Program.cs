using AirportSystem.Data.DbContests;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Data.Repositories.CommonRepo;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Airplanes;
using AirportSystem.Service.DTO_s.Employees;
using AirportSystem.Service.DTO_s.Passengers;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AirportSystem.Service.Services;
using AirportSystem.Service.Services.AirplaneServices;
using AirportSystem.Service.Services.EmployeeServices;
using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Domain.Configurations;
using AirportSystem.Service.DTO_s.BlackLists;
using AirportSystem.Service.Interfaces.IEmployeeServices;
using AirportSystem.Service.Interfaces.IPassengerServices;
using AirportSystem.Service.Services.BlackListServices;

namespace AirportSystem
{
    internal class Program
    {


        static async Task Main(string[] args)
        {


            EmployeeForCreation employeeForCreation = new EmployeeForCreation()
            {
                FirstName = "BotiraliA",
                LastName = "Raxmonberdiyevvv",
                UserName = "IVawdasa05",
                Address = "Main str. 1",
                Department = Department.Dispatcher,
                Email = "emails@gmail.com",
                Gender = Gender.Male,
                Password = "imen",
                Phone = "54872136",
                Salary = 90000,
                PassportNumber = "AK29104A10481",
                DateOfBirth = DateTime.UtcNow
            };

            IMapper mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            AirportSystemDbContext dbContext = new AirportSystemDbContext();

            using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            {
                IPassengerService passenger = new PassengerService(mapper, unitOfWork);
                IBlackListService blackList = new BlackListService(mapper, unitOfWork);
                IEmployeeService employee = new EmployeeService(mapper, unitOfWork);
                /*PassengerForCreation passengerForCreation = new PassengerForCreation()
                {
                    Address = "Austria",
                    FirstName = "Foster",
                    LastName = "Barrett",
                    UserName = "Jimmi",
                    AgeCategory = AgeCategory.Adult,
                    CountryCode = "GER",
                    Email = "nnAgAele@gmail.com",
                    Gender = Gender.Male,
                    PassportNumber = "OO001241",
                    Phone = "7845961",
                    Password = "Mert1202",
                    IsBlackList = true

                };
                */

               
                
                var res = employee.GetAllAsync(pagination: Tuple.Create(2, 5) );
                
                foreach( var item in res.Result)
                {
                    Console.WriteLine(item.FirstName);
                }

                
                
            }



            //IMapper mapper = new MapperConfiguration
            //    (cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();

            //AirportSystemDbContext dbContext = new AirportSystemDbContext();

            //using (IUnitOfWork unitOfWork = new UnitOfWork(dbContext))
            //{
            //    EmployeeService passengerService = new EmployeeService(mapper, unitOfWork);
            //    var res = await passengerService.ChangePasswordAsync(new EmployeeForChangePassword()
            //    {
            //        Username = "IVawdasa05",
            //        OldPassword = "imen",
            //        NewPassword = "olim000",
            //        ConfirmPassword = "olim000"
            //    });
            //    Console.WriteLine("Done");
            //}
        }
    }
}