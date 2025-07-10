using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas del sistema académico.
    /// </summary>
    public interface ISistemaAcademico
    {
        /// <summary>
        /// Método para registrar un estudiante en el sistema.
        /// Este método recibe un objeto que implementa la interfaz IEstudiante.
        /// </summary>
        /// <param name="estudiante"></param>
        void RegistrarEstudiante(IEstudiante estudiante);
        /// <summary>
        /// Método para registrar un profesor en el sistema.
        /// Este método recibe un objeto que implementa la interfaz IProfesor.
        /// </summary>
        /// <param name="profesor"></param>
        void RegistrarProfesor(IProfesor profesor);
        /// <summary>
        /// Método para registrar un curso en el sistema.
        /// Este método recibe un objeto que implementa la interfaz ICurso.
        /// </summary>
        /// <param name="curso"></param>
        void CrearCurso(ICurso curso);
        /// <summary>
        /// Método para asignar un profesor a un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaProfesor"></param>
        void AsignarProfesorACurso(string codigoCurso, string numCedulaProfesor);
        /// <summary>
        /// Método para matricular un estudiante en un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaEstudiante"></param>
        void MatricularEstudianteEnCurso(string codigoCurso, string numCedulaEstudiante);
        /// <summary>
        /// Método para verificar si un estudiante está inscrito en un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaEstudiante"></param>
        /// <returns></returns>
        bool VerificarEstudianteInscrito(string codigoCurso, string numCedulaEstudiante);
        /// <summary>
        /// Método para verificar si un curso existe en el sistema.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <returns></returns>
        bool VerificarCursoExistente(string codigoCurso);
        /// <summary>
        /// Método para verificar si un estudiante existe en el sistema.
        /// </summary>
        /// <param name="numCedulaEstudiante"></param>
        /// <returns></returns>
        bool VerificarEstudianteExistente(string numCedulaEstudiante);
        /// <summary>
        /// Método para verificar si un profesor existe en el sistema.
        /// </summary>
        /// <param name="numCedulaProfesor"></param>
        /// <returns></returns>
        bool VerificarProfesorExistente(string numCedulaProfesor);
        /// <summary>
        /// Método para obtener todos los cursos de un estudiante.
        /// </summary>
        /// <param name="numCedulaEstudiante"></param>
        /// <returns></returns>
        List<ICurso> ObtenerCursosDeEstudiante(string numCedulaEstudiante);
        /// <summary>
        /// Método para obtener todos los cursos de un profesor.
        /// </summary>
        /// <param name="numCedulaProfesor"></param>
        /// <returns></returns>
        List<ICurso> ObtenerCursosDeProfesor(string numCedulaProfesor);
        /// <summary>
        /// Método para obtener todos los estudiantes inscritos en un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <returns></returns>
        List<IEstudiante> ObtenerEstudiantesDeCurso(string codigoCurso);
        /// <summary>
        /// Método para obtener todos los profesores del sistema.
        /// </summary>
        /// <returns></returns>
        List<IProfesor> ObtenerProfesores();
        /// <summary>
        /// Método para obtener todos los estudiantes del sistema.
        /// </summary>
        /// <returns></returns>
        List<IEstudiante> ObtenerEstudiantes();
        /// <summary>
        /// Método para obtener todos los cursos del sistema.
        /// </summary>
        /// <returns></returns>
        List<ICurso> ObtenerCursos();
        /// <summary>
        /// Método para buscar un curso por su código.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        ICurso BuscarCurso(string codigo);
        /// <summary>
        /// Método para buscar un estudiante por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        /// <returns></returns>
        IEstudiante BuscarEstudiante(string numCedula);
        /// <summary>
        /// Método para buscar un profesor por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        /// <returns></returns>
        IProfesor BuscarProfesor(string numCedula);
        /// <summary>
        /// Método para eliminar un curso del sistema por su código.
        /// </summary>
        /// <param name="codigoCurso"></param>
        void EliminarCurso(string codigoCurso);
        /// <summary>
        /// Método para eliminar un estudiante del sistema por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        void EliminarEstudiante(string numCedula);
        /// <summary>
        /// Método para eliminar un profesor del sistema por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        void EliminarProfesor(string numCedula);
        /// <summary>
        /// Método para mostrar los estudiantes inscritos y el profesor asignado a un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        void MostrarEstudiantesYProfesorDeCurso(string codigoCurso);
        /// <summary>
        /// Método para listar todos los cursos registrados en el sistema.
        /// </summary>
        void ListarTodosLosCursos();
    }
}
