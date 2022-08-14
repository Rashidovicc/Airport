using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.BlackLists;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.BlackLists;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;

namespace AirportSystem.Service.Services.BlackListServices
{
    public class BlackListService : IBlackListService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BlackListService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<BlackList> CreateAsync(BlackListForCreation blackListForCreation)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(a => a.PassengerId == blackListForCreation.PassengerId);

            if (exist is not null)
                throw new Exception("This blacklist already exists!");

            var mappedAirport = mapper.Map<BlackList>(blackListForCreation);

            mappedAirport.Created();

            var result = await unitOfWork.BlackLists.CreateAsync(mappedAirport);

            await unitOfWork.SaveChangesAsync();

            return result;
            
            
        }

        public async Task<BlackList> UpdateAsync(long id, BlackListForCreation blackListForCreation)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This blacklist not found!");

            exist = mapper.Map(blackListForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.BlackLists.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<BlackList, bool>> expression)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(expression);

            if (exist is null)
                throw new Exception("This blacklist not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();

            return true;

        }

        public Task<IEnumerable<BlackList>> GetAllAsync(Expression<Func<BlackList, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.BlackLists.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                .GetWithPagination(pagination);

            return Task.FromResult(result);
        }


        public async Task<BlackList> GetAsync(Expression<Func<BlackList, bool>> expression)
        {
            var exist = await unitOfWork.BlackLists.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This blacklist not found!");

            return exist;
        }

    }
}