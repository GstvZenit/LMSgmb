using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
using LMS.Core.Interfaces;
using LMS.Infrastructure.Data;
namespace LMS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Usuario> _usuarioRepository;
        private IRepository<Tema> _temaRepository;
        private IRepository<Rol> _rolRepository;
        private IRepository<Parametro> _parametroRepository;
        private IRepository<Instructor> _instructorRepository;
        private IRepository<Inscripcion> _inscripcionRepository;
        private IRepository<Estudiante> _estudianteRepository;
        private IRepository<Curso> _cursoRepository;
        private IRepository<Controlasistencia> _controlasistenciaRepository;
        private IRepository<Calificacion> _calificacionRepository;
        private IRepository<Adjunto> _adjuntoRepository;
        private IRepository<Actividad> _actividadRepository;

        private readonly LMS2Context _context;

        public UnitOfWork(LMS2Context context)
        {
            _context = context;
        }

        

        public IRepository<Usuario> UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                    _usuarioRepository = new BaseRepository<Usuario>(_context);
                return _usuarioRepository;
            }
        }

        public IRepository<Tema> TemaRepository => _temaRepository ?? new BaseRepository<Tema>(_context);
        public IRepository<Rol> RolRepository => _rolRepository ?? new BaseRepository<Rol>(_context);
        public IRepository<Parametro> ParametroRepository => _parametroRepository ?? new BaseRepository<Parametro>(_context);
        public IRepository<Instructor> InstructorRepository => _instructorRepository ?? new BaseRepository<Instructor>(_context);
        public IRepository<Inscripcion> InscripcionRepository => _inscripcionRepository ?? new BaseRepository<Inscripcion>(_context);
        public IRepository<Estudiante> EstudianteRepository => _estudianteRepository ?? new BaseRepository<Estudiante>(_context);
        public IRepository<Curso> CursoRepository => _cursoRepository ?? new BaseRepository<Curso>(_context);
        public IRepository<Controlasistencia> ControlasistenciaRepository => _controlasistenciaRepository ?? new BaseRepository<Controlasistencia>(_context);
        public IRepository<Calificacion> CalificacionRepository => _calificacionRepository ?? new BaseRepository<Calificacion>(_context);
        public IRepository<Adjunto> AdjuntoRepository => _adjuntoRepository ?? new BaseRepository<Adjunto>(_context);
        public IRepository<Actividad> ActividadRepository => _actividadRepository ?? new BaseRepository<Actividad>(_context);

        //dispose context si existe
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
