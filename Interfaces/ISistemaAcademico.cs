using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones del sistema académico.
    /// </summary>
    public interface ISistemaAcademico
    {
        /// <summary>
        /// Registra un nuevo estudiante en el sistema.
        /// </summary>
        /// <param name="estudiante"></param>
        void RegistrarEstudiante(IEstudiante estudiante);
        /// <summary>
        /// Registra un nuevo profesor en el sistema.
        /// </summary>
        /// <param name="profesor"></param>
        void RegistrarProfesor(IProfesor profesor);
        /// <summary>
        /// Crea un nuevo curso en el sistema.
        /// </summary>
        /// <param name="curso"></param>
        void CrearCurso(ICurso curso);
        /// <summary>
        /// Asigna un profesor a un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaProfesor"></param>
        void AsignarProfesorACurso(string codigoCurso, string numCedulaProfesor);
        /// <summary>
        /// Matricula a un estudiante en un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaEstudiante"></param>
        void MatricularEstudianteEnCurso(string codigoCurso, string numCedulaEstudiante);
        /// <summary>
        /// Obtiene la lista de cursos en los que está matriculado un estudiante.
        /// </summary>
        /// <param name="numCedulaEstudiante"></param>
        List<ICurso> ObtenerCursosDeEstudiante(string numCedulaEstudiante);
        /// <summary>
        /// Busca un curso por su código.
        /// </summary>
        /// <param name="codigo"></param>
        ICurso BuscarCurso(string codigo);
        /// <summary>
        /// Busca un estudiante por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        IEstudiante BuscarEstudiante(string numCedula);
        /// <summary>
        /// Busca un profesor por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        IProfesor BuscarProfesor(string numCedula);
        /// <summary>
        /// Muestra los estudiantes matriculados en un curso y el profesor asignado.
        /// </summary>
        /// <param name="codigoCurso"></param>
        void MostrarEstudiantesYProfesorDeCurso(string codigoCurso);
        /// <summary>
        /// Lista todos los cursos disponibles en el sistema.
        /// </summary>
        void ListarTodosLosCursos();
    }
}
