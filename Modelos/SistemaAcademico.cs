using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    // APLICACIÓN DE SOLID: SRP - Single Responsibility Principle
    // Esta clase se encarga únicamente de la lógica de negocio del sistema académico
    // APLICACIÓN DE SOLID: DIP - Dependency Inversion Principle
    // Depende de abstracciones (interfaces), no de implementaciones concretas
    public class SistemaAcademico : ISistemaAcademico
    {
        // APLICACIÓN DE POO: Encapsulamiento - Listas privadas para almacenar datos
        // Solo uso de listas como estructura de almacenamiento
        /// <summary>
        /// Lista de estudiantes registrados en el sistema académico.
        /// </summary>
        private List<IEstudiante> estudiantes;
        /// <summary>
        /// Lista de profesores registrados en el sistema académico.
        /// </summary>
        private List<IProfesor> profesores;
        /// <summary>
        /// Lista de cursos registrados en el sistema académico.
        /// </summary>
        private List<ICurso> cursos;
        // APLICACIÓN DE POO: Constructor - Inicializa las listas
        /// <summary>
        /// Constructor para inicializar las listas del sistema académico.
        /// </summary>
        public SistemaAcademico()
        {
            estudiantes = new List<IEstudiante>();
            profesores = new List<IProfesor>();
            cursos = new List<ICurso>();
        }

        // APLICACIÓN DE SOLID: OCP - Open/Closed Principle
        // Abierto para extensión mediante interfaces, cerrado para modificación
        // Métodos para registrar estudiantes, profesores y cursos
        /// <summary>
        /// Registra un estudiante en el sistema académico.
        /// </summary>
        public void RegistrarEstudiante(IEstudiante estudiante)
        {
            if (estudiante != null && !estudiantes.Any(e => e.NumCedula == estudiante.NumCedula))
            {
                estudiantes.Add(estudiante);
            }
        }
        /// <summary>
        /// Registra un profesor en el sistema académico.
        /// </summary>
        public void RegistrarProfesor(IProfesor profesor)
        {
            if (profesor != null && !profesores.Any(p => p.NumCedula == profesor.NumCedula))
            {
                profesores.Add(profesor);
            }
        }
        /// <summary>
        /// Crea un curso en el sistema académico.
        /// </summary>
        public void CrearCurso(ICurso curso)
        {
            if (curso != null && !cursos.Any(c => c.CodigoCurso == curso.CodigoCurso))
            {
                cursos.Add(curso);
            }
        }
        // Métodos para obtener listas de estudiantes, profesores y cursos
        /// <summary>
        /// Asigna un profesor a un curso en el sistema académico.
        /// </summary>
        public void AsignarProfesorACurso(string codigoCurso, string numCedulaProfesor)
        {
            var curso = BuscarCurso(codigoCurso);
            var profesor = BuscarProfesor(numCedulaProfesor);

            if (curso != null && profesor != null)
            {
                curso.AsignarProfesor(profesor);
            }
        }
        /// <summary>
        /// Matricula a un estudiante en un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        /// <param name="numCedulaEstudiante"></param>
        public void MatricularEstudianteEnCurso(string codigoCurso, string numCedulaEstudiante)
        {
            var curso = BuscarCurso(codigoCurso);
            var estudiante = BuscarEstudiante(numCedulaEstudiante);

            if (curso != null && estudiante != null)
            {
                curso.MatricularEstudiante(estudiante);
            }
        }
        /// <summary>
        /// Obtiene la lista de cursos en los que está matriculado un estudiante.
        /// </summary>
        /// <param name="numCedulaEstudiante"></param>
        /// <returns></returns>
        public List<ICurso> ObtenerCursosDeEstudiante(string numCedulaEstudiante)
        {
            // Uso de LINQ para filtrar cursos donde está inscrito el estudiante
            /// <param name="numCedulaEstudiante"></param>
            return cursos.Where(c => c.EstudiantesInscritos.Any(e => e.NumCedula == numCedulaEstudiante)).ToList();
        }

        // Métodos de búsqueda usando LINQ con listas
        /// <summary>
        /// Busca un curso por su código.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public ICurso BuscarCurso(string codigo)
        {
            return cursos.FirstOrDefault(c => c.CodigoCurso == codigo);
        }
        /// <summary>
        /// Busca un estudiante por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        /// <returns></returns>
        public IEstudiante BuscarEstudiante(string numCedula)
        {
            return estudiantes.FirstOrDefault(e => e.NumCedula == numCedula);
        }
        /// <summary>
        /// Busca un profesor por su número de cédula.
        /// </summary>
        /// <param name="numCedula"></param>
        /// <returns></returns>
        public IProfesor BuscarProfesor(string numCedula)
        {
            return profesores.FirstOrDefault(p => p.NumCedula == numCedula);
        }
        // Métodos para mostrar información (opciones 7 y 8 del menú)
        /// <summary>
        /// Muestra los estudiantes inscritos y el profesor asignado a un curso.
        /// </summary>
        /// <param name="codigoCurso"></param>
        public void MostrarEstudiantesYProfesorDeCurso(string codigoCurso)
        {
            var curso = BuscarCurso(codigoCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso no encontrado.");
                return;
            }

            Console.WriteLine($"\n=== Información del Curso: {curso.NombreCurso} ===");
            Console.WriteLine($"Código: {curso.CodigoCurso}");
            Console.WriteLine($"Horario: {curso.HorarioCurso}");
            Console.WriteLine($"Profesor: {(curso.ProfesorAsignado?.Nombre ?? "Sin asignar")}");
            Console.WriteLine($"\nEstudiantes inscritos ({curso.EstudiantesInscritos.Count}):");

            if (curso.EstudiantesInscritos.Count == 0)
            {
                Console.WriteLine("No hay estudiantes inscritos.");
            }
            else
            {
                foreach (var estudiante in curso.EstudiantesInscritos)
                {
                    Console.WriteLine($"- {estudiante.Nombre} {estudiante.Apellidos} (Cédula: {estudiante.NumCedula})");
                }
            }
        }
        /// <summary>
        /// Lista todos los estudiantes registrados en el sistema académico.
        /// </summary>
        public void ListarTodosLosCursos()
        {
            Console.WriteLine("\n=== Lista de Todos los Cursos ===");
            if (cursos.Count == 0)
            {
                Console.WriteLine("No hay cursos registrados.");
                return;
            }

            foreach (var curso in cursos)
            {
                Console.WriteLine($"\n{curso.ObtenerInformacionCompleta()}");
            }
        }
    }
}
