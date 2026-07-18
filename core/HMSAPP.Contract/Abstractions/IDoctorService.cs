using HMSAPP.Contract.DTOs;

namespace HMSAPP.Contract.Abstractions;

public interface IDoctorService
{
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDto> GetByIdAsync(int id);
        Task AddAsync(DoctorDto dto);
        Task UpdateAsync(int id, DoctorDto dto);
        Task DeleteAsync(int id);
    
}
