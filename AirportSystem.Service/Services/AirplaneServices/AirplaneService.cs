using AirportSystem.Data.IRepositories.ICommonRepo;
using AirportSystem.Domain.Configurations;
using AirportSystem.Domain.Entities.Airplanes;
using AirportSystem.Domain.Enums;
using AirportSystem.Service.DTO_s.Airplanes;
using AirportSystem.Service.Extentions;
using AirportSystem.Service.Interfaces;
using AirportSystem.Service.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Service.Services.AirplaneServices
{
#pragma warning disable

    public class AirplaneService : IAirplaneService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AirplaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Airplane> CreateAsync(AirplaneForCreation airplaneForCreation)
        {
            var exist = await unitOfWork.Airplanes.GetAsync(a => a.Name == airplaneForCreation.Name);

            if (exist is not null)
                throw new Exception("This airplane already exists!");

            var mappedAirplane = mapper.Map<Airplane>(airplaneForCreation);

            mappedAirplane.Created();

            var result = await unitOfWork.Airplanes.CreateAsync(mappedAirplane);

            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Airplane, bool>> expression)
        {
            var exist = await unitOfWork.Airplanes.GetAsync(expression);

            if (exist is null)
                throw new Exception("This airplane not found!");

            exist.Deleted();

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Airplane>> GetAllAsync(Expression<Func<Airplane, bool>> expression = null, Tuple<int, int> pagination = null)
        {
            var result = unitOfWork.Airplanes.GetAll(expression)
                .Where(client => client.ItemState != ItemState.Deleted)
                    .GetWithPagination(pagination);

            return result;
        }

        public Task<IEnumerable<Airplane>> GetAllAsync(PaginationParams @params, Expression<Func<Airplane, bool>> expression = null)
        {
            var exist = unitOfWork.Airplanes.GetAll(expression => expression.ItemState != ItemState.Deleted);

            exist.ToPaged(@params);
            
            if (exist is null)
                throw new Exception("Airplanes not found");

            return Task.FromResult<IEnumerable<Airplane>>(exist);
        }

        public async Task<Airplane> GetAsync(Expression<Func<Airplane, bool>> expression)
        {
            var exist = await unitOfWork.Airplanes.GetAsync(expression);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This airplane not found!");

            return exist;
        }

        public async Task<Airplane> UpdateAsync(long id, AirplaneForCreation airplaneForCreation)
        {
            var exist = await unitOfWork.Airplanes.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This airplane not found!");

            exist = mapper.Map(airplaneForCreation, exist);

            exist.Updated();
            exist.Id = id;

            var result = unitOfWork.Airplanes.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;

        }
    }
}
