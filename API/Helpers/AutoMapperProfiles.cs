using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Alumno;
using API.DTOs.Curso;
using API.DTOs.Nota;
using AutoMapper;
using data.Context;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AlumnoCreacionDTO, AP_Alvarez_Ricardo_Alumno>()
                .ForMember(dest => dest.apellidos, opt => opt.MapFrom(x => x.apellidos))
                .ForMember(dest => dest.nombres, opt => opt.MapFrom(x => x.nombres))
                .ForMember(dest => dest.sexo, opt => opt.MapFrom(x => x.sexo))
                .ForMember(dest => dest.fecha_nacimiento, opt => opt.MapFrom(x => x.fecha_nacimiento))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => true));
            
            CreateMap<AlumnoDTO, AP_Alvarez_Ricardo_Alumno>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(x => x.id))
                .ForMember(dest => dest.apellidos, opt => opt.MapFrom(x => x.apellidos))
                .ForMember(dest => dest.nombres, opt => opt.MapFrom(x => x.nombres))
                .ForMember(dest => dest.sexo, opt => opt.MapFrom(x => x.sexo))
                .ForMember(dest => dest.fecha_nacimiento, opt => opt.MapFrom(x => x.fecha_nacimiento))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => x.estado)).ReverseMap();

            CreateMap<CursoCreacionDTO, AP_Alvarez_Ricardo_Curso>()
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(x => x.nombre))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(x => x.descripcion))
                .ForMember(dest => dest.obligatorio, opt => opt.MapFrom(x => x.obligatorio))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => true));

            CreateMap<CursoDTO, AP_Alvarez_Ricardo_Curso>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(x => x.id))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(x => x.descripcion))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(x => x.nombre))
                .ForMember(dest => dest.obligatorio, opt => opt.MapFrom(x => x.obligatorio))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => x.estado)).ReverseMap();

            CreateMap<NotaCreacionDTO, AP_Alvarez_Ricardo_Nota>()
                .ForMember(dest => dest.idalumno, opt => opt.MapFrom(x => x.idalumno))
                .ForMember(dest => dest.idcurso, opt => opt.MapFrom(x => x.idcurso))
                .ForMember(dest => dest.practica1, opt => opt.MapFrom(x => x.practica1))
                .ForMember(dest => dest.practica2, opt => opt.MapFrom(x => x.practica2))
                .ForMember(dest => dest.practica3, opt => opt.MapFrom(x => x.practica3))
                .ForMember(dest => dest.parcial, opt => opt.MapFrom(x => x.parcial))
                .ForMember(dest => dest.final, opt => opt.MapFrom(x => x.final))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => true));

            CreateMap<NotaDTO, AP_Alvarez_Ricardo_Nota>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(x => x.id))
                .ForMember(dest => dest.idalumno, opt  => opt.MapFrom(x => x.idalumno))
                .ForMember(dest => dest.idcurso, opt => opt.MapFrom(x => x.idcurso))
                .ForMember(dest => dest.practica1, opt => opt.MapFrom(x => x.practica1))
                .ForMember(dest => dest.practica2, opt => opt.MapFrom(x => x.practica2))
                .ForMember(dest => dest.practica3, opt => opt.MapFrom(x => x.practica3))
                .ForMember(dest => dest.parcial, opt => opt.MapFrom(x => x.parcial))
                .ForMember(dest => dest.final, opt => opt.MapFrom(x => x.final))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(x => x.estado)).ReverseMap();
        }
    }
}