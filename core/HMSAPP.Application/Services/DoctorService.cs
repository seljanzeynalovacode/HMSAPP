using AutoMapper;
using HMSAPP.Contract.Abstractions;
using HMSAPP.Contract.DTOs;
using HMSAPP.Domainn.Entities;
using HMSAPP.Domainn.Repository;

namespace HMSAPP.Application.Services;

public class DoctorService : IDoctorService
{
        private readonly IGenericRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IGenericRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(DoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<DoctorDto>>(entities);
            return dtos;
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            var dto = _mapper.Map<DoctorDto>(entity);
            return dto;
        }

        public async Task UpdateAsync(int id, DoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            await _repository.UpdateAsync(id, entity);

        }
    }
