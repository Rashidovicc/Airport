using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Passengers;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.BlackLists;
using AirportSystem.Service.DTO_s.Passengers;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Interfaces.IPassengerServices;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class PassengerService : IPassengerService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PassengerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Passenger> CreateAsync(PassengerForCreation passengerForCreation)
        {
            var exist = await unitOfWork.Passengers.GetAsync(a => a.PassportNumber == passengerForCreation.PassportNumber && a.Email == passengerForCreation.Email);

            if (exist is not null)
                throw new Exception("This Passenger already exists!");

            var mappedPassenger = mapper.Map<Passenger>(passengerForCreation);

            mappedPassenger.Created();
            
            mappedPassenger.Password = mappedPassenger.Password.GetHash();

            var result = await unitOfWork.Passengers.CreateAsync(mappedPassenger);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Passenger, bool>> expression)
        {
            var exist = await unitOfWork.Passengers.GetAsync(expression);

            if (exist is null)
                throw new Exception("This Passenger not found!");

            exist.Deleted();
            
            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<Passenger>> GetAllAsync(Expression<Func<Passenger, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.Passengers.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                .GetWithPagination(pagination);

            return Task.FromResult(result);
        }


        public async Task<Passenger> GetAsync(Expression<Func<Passenger, bool>> expression)
        {
            var exist = await unitOfWork.Passengers.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Passenger not found!");

            return exist;
        }

        public async Task<Passenger> UpdateAsync(long id, PassengerForCreation passengerForCreation)
        {
            var exist = await unitOfWork.Passengers.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This Passenger not found!");

            exist = mapper.Map(passengerForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Passengers.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }

        public async Task<bool> CheckingBlacklist(Expression<Func<Passenger, bool>> expression)
        {
            var passenger = await unitOfWork.Passengers.GetAsync(expression);

            var duration = new BlackListForCreation();

            if (passenger.IsBlackList)
            {
                if ((duration.Duration - DateTime.Now).TotalMinutes != 0)
                    return false;
                return true;
            }

            return false;
        }

    }
}