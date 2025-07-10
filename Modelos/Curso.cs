using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    // APLICACIÓN DE POO: Encapsulamiento - Clase que maneja toda la información de un curso
    /// <summary>
    /// Clase que representa un curso en el sistema académico.
    /// </summary>
    public class Curso : ICurso
    {
        // APLICACIÓN DE POO: Encapsulamiento - Propiedades públicas simples
        /// <summary>
        /// Nombre del curso.
        /// </summary>
        public string NombreCurso { get; set; }
        /// <summary>
        /// Código único del curso.
        /// </summary>
        public string CodigoCurso { get; set; }
        /// <summary>
        /// Horario del curso.
        /// </summary>
        public string HorarioCurso { get; set; }
        /// <summary>
        /// Profesor asignado al curso.
        /// </summary>
        public IProfesor ProfesorAsignado { get; set; }
        /// <summary>
        /// Lista de estudiantes inscritos en el curso.
        /// </summary>
        public List<IEstudiante> EstudiantesInscritos { get; set; }
        /// <summary>
        /// Constructor que inicializa un curso con su nombre, código y horario.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="codigo"></param>
        /// <param name="horario"></param>
        public Curso(string nombre, string codigo, string horario)
        {
            NombreCurso = nombre;
            CodigoCurso = codigo;
            HorarioCurso = horario;
            EstudiantesInscritos = new List<IEstudiante>();
        }
        // APLICACIÓN DE SOLID: SRP - Método con responsabilidad específica de asignar profesor
        /// <summary>
        /// Asigna un profesor al curso.
        /// </summary>
        /// <param name="profesor"></param>
        public void AsignarProfesor(IProfesor profesor)
        {
            ProfesorAsignado = profesor;
            if (profesor != null)
            {
                profesor.AsignarseACurso(CodigoCurso);
            }
        }
        // APLICACIÓN DE SOLID: SRP - Método con responsabilidad específica de matricular estudiante
        /// <summary>
        /// Matricula un estudiante en el curso.
        /// </summary>
        /// <param name="estudiante"></param>
        public void MatricularEstudiante(IEstudiante estudiante)
        {
            if (estudiante != null && !EstudiantesInscritos.Any(e => e.NumCedula == estudiante.NumCedula))
            {
                EstudiantesInscritos.Add(estudiante);
                estudiante.InscribirseEnCurso(CodigoCurso);
            }
        }
        // APLICACIÓN DE SOLID: SRP - Método con responsabilidad específica de desmatricular estudiante
        /// <summary>
        /// Desmatricula un estudiante del curso.
        /// </summary>
        /// <param name="numCedula"></param>
        public bool DesmatricularEstudiante(string numCedula)
        {
            var estudiante = EstudiantesInscritos.FirstOrDefault(e => e.NumCedula == numCedula);
            if (estudiante == null) return false;

            EstudiantesInscritos.Remove(estudiante);
            estudiante.CursosInscritos.Remove(CodigoCurso);
            return true;
        }
        // Método para obtener información completa del curso
        /// <summary>
        /// Obtiene información completa del curso, incluyendo nombre, código, horario, profesor asignado y número de estudiantes inscritos.
        /// </summary>
        public string ObtenerInformacionCompleta()
        {
            string info = $"Curso: {NombreCurso} ({CodigoCurso})\n";
            info += $"Horario: {HorarioCurso}\n";
            info += $"Profesor: {(ProfesorAsignado?.Nombre ?? "Sin asignar")}\n";
            info += $"Estudiantes inscritos: {EstudiantesInscritos.Count}";
            return info;
        }
    }
}
