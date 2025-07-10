using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de un estudiante en el sistema académico.
    /// Incluye propiedades para la matrícula, carrera y lista de cursos inscritos.
    /// </summary>
    public interface IEstudiante : IPersona  // Hereda de IPersona
    {
        /// <summary>
        /// Número de matrícula del estudiante.
        /// </summary>
        string Matricula { get; set; }
        /// <summary>
        /// Carrera del estudiante.
        /// </summary>
        string Carrera { get; set; }
        /// <summary>
        /// Lista de códigos de cursos en los que el estudiante está inscrito.
        /// </summary>
        List<string> CursosInscritos { get; set; }
        /// <summary>
        /// Método para inscribir al estudiante en un curso.
        /// </summary>
        /// <param name="codigoCurso">El código del curso en el que inscribir al estudiante.</param>
        void InscribirseEnCurso(string codigoCurso);
    }
}
