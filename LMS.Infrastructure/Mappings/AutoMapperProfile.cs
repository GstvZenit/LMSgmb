using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LMS.Core.DTO;
using LMS.Core.Entities;
namespace LMS.Infrastructure.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Tema, TemaDTO>();
            CreateMap<TemaDTO, Tema>();

            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();

            CreateMap<Parametro, ParametroDTO>();
            CreateMap<ParametroDTO, Parametro>();

            CreateMap<Instructor, InstructorDTO>();
            CreateMap<InstructorDTO, Instructor>();

            CreateMap<Inscripcion, InscripcionDTO>();
            CreateMap<InscripcionDTO, Inscripcion>();

            CreateMap<Estudiante, EstudianteDTO>();
            CreateMap<EstudianteDTO, Estudiante>();

            CreateMap<Curso, CursoDTO>();
            CreateMap<CursoDTO, Curso>();

            CreateMap<Controlasistencia, ControlasistenciaDTO>();
            CreateMap<ControlasistenciaDTO, Controlasistencia>();

            CreateMap<Calificacion, CalificacionDTO>();
            CreateMap<CalificacionDTO, Calificacion>();

            CreateMap<Adjunto, AdjuntoDTO>();
            CreateMap<AdjuntoDTO, Adjunto>();

            CreateMap<Actividad, ActividadDTO>();
            CreateMap<ActividadDTO, Actividad>();
        }
    }
}
