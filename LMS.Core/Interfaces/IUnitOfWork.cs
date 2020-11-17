using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Core.Entities;
namespace LMS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //insertamos los repos
        #region repos aqui
        #endregion
        IRepository<Usuario> UsuarioRepository { get; }
        IRepository<Tema> TemaRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<Parametro> ParametroRepository { get; }
        IRepository<Instructor> InstructorRepository { get; }
        IRepository<Inscripcion> InscripcionRepository { get; }
        IRepository<Estudiante> EstudianteRepository { get; }
        IRepository<Curso> CursoRepository { get; }
        IRepository<Controlasistencia> ControlasistenciaRepository { get; }
        IRepository<Calificacion> CalificacionRepository { get; }
        IRepository<Adjunto> AdjuntoRepository { get; }
        IRepository<Actividad> ActividadRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
