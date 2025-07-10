using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    // APLICACIÓN DE POO: Herencia - Estudiante hereda de Persona e implementa IEstudiante
    /// <summary>
    /// Clase que representa a un estudiante en el sistema académico.
    /// </summary>
    public class Estudiante : Persona, IEstudiante
    {
        // APLICACIÓN DE POO: Encapsulamiento - Propiedades específicas del estudiante
        /// <summary>
        /// Matrícula del estudiante.
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Carrera del estudiante.
        /// </summary>
        public string Carrera { get; set; }
        /// <summary>
        /// Lista de códigos de cursos en los que el estudiante está inscrito.
        /// </summary>
        public List<string> CursosInscritos { get; set; }
        /// <summary>
        /// Constructor que inicializa un estudiante con sus datos personales, matrícula y carrera.
        /// </summary>
        public Estudiante(string nombre, string apellidos, string telefono, string numCedula, string correo, string matricula, string carrera)
            : base(nombre, apellidos, telefono, numCedula, correo)
        {
            Matricula = matricula;
            Carrera = carrera;
            CursosInscritos = new List<string>();
        }
        // APLICACIÓN DE POO: Polimorfismo - Implementación obligatoria del método abstracto
        /// <summary>
        /// Obtiene el tipo de persona.
        /// </summary>
        public override string ObtenerTipo()
        {
            return "Estudiante";
        }
        // APLICACIÓN DE POO: Polimorfismo - Sobrescritura del método virtual de la clase base
        /// <summary>
        /// Obtiene información completa del estudiante, incluyendo matrícula y carrera.
        /// </summary>
        public override string ObtenerInformacion()
        {
            return $"{base.ObtenerInformacion()}, Matrícula: {Matricula}, Carrera: {Carrera}";
        }
        /// <summary>
        /// Inscribe al estudiante en un curso.
        /// </summary>
        public void InscribirseEnCurso(string codigoCurso)
        {
            if (!string.IsNullOrEmpty(codigoCurso) && !CursosInscritos.Contains(codigoCurso))
            {
                CursosInscritos.Add(codigoCurso);
            }
        }
    }
}
