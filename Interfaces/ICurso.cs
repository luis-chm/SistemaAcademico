using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de un curso en el sistema académico.
    /// Incluye propiedades para el nombre, código, horario, profesor asignado y estudiantes inscritos
    /// </summary>
    public interface ICurso
    {
        /// <summary>
        /// Nombre del curso.
        /// </summary>
        string NombreCurso { get; set; }
        /// <summary>
        /// Código único del curso.
        /// </summary>
        string CodigoCurso { get; set; }
        /// <summary>
        /// Horario del curso.
        /// </summary>
        string HorarioCurso { get; set; }
        /// <summary>
        /// Profesor asignado al curso.
        /// </summary>
        IProfesor ProfesorAsignado { get; set; }
        /// <summary>
        /// Lista de estudiantes inscritos en el curso.
        /// </summary>
        List<IEstudiante> EstudiantesInscritos { get; set; }
        /// <summary>
        /// Método para asignar un profesor al curso.
        /// </summary>
        /// <param name="profesor">El profesor a asignar.</param>
        void AsignarProfesor(IProfesor profesor);
        /// <summary>
        /// Método para matricular un estudiante en el curso.
        /// </summary>
        /// <param name="estudiante">El estudiante a matricular.</param>
        void MatricularEstudiante(IEstudiante estudiante);
        /// <summary>
        /// Método para obtener información completa del curso.
        /// </summary>
        string ObtenerInformacionCompleta();
    }
}
