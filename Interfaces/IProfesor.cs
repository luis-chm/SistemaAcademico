using SistemaAcademico.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de un profesor en el sistema académico.
    /// </summary>
    public interface IProfesor : IPersona
    {
        /// <summary>
        /// Número de cédula profesional del profesor.
        /// </summary>
        string TituloProfesional { get; set; }
        /// <summary>
        /// Lista de códigos de cursos asignados al profesor.
        /// </summary>
        List<string> CursosAsignados { get; set; }
        /// <summary>
        /// Método para inscribir al profesor en un curso.
        /// </summary>
        /// <param name="codigoCurso">El código del curso en el que se desea inscribir al profesor.</param>
        void AsignarseACurso(string codigoCurso);
    }
}
