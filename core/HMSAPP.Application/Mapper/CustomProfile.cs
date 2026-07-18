using AutoMapper;
using HMSAPP.Contract.DTOs;
using HMSAPP.Domainn.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSAPP.Application.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile() { 
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        }
    }
}
