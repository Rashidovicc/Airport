using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.RouleTables;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.RoulTable;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services
{
    public class RoulTableService : IRoulTableService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RoulTableService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<RouleTable> CreateAsync(RoulTableForCreation rouleTableForCreation)
        {
            var mappedRouleTable = mapper.Map<RouleTable>(rouleTableForCreation);

            mappedRouleTable.Created();

            var result = await unitOfWork.RouleTables.CreateAsync(mappedRouleTable);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<RouleTable, bool>> expression)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(expression);

            if (exist is null)
                throw new Exception("This RouleTable not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public Task<IEnumerable<RouleTable>> GetAllAsync(Expression<Func<RouleTable, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.RouleTables.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                .GetWithPagination(pagination);

            return Task.FromResult(result);
        }


        public async Task<RouleTable> GetAsync(Expression<Func<RouleTable, bool>> expression)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This RouleTable not found!");

            return exist;
        }

        public async Task<RouleTable> UpdateAsync(long id, RoulTableForCreation rouleTableForCreation)
        {
            var exist = await unitOfWork.RouleTables.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This RouleTable not found!");

            exist = mapper.Map(rouleTableForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.RouleTables.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}