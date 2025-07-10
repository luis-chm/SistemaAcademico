using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    // APLICACIÓN DE POO: Herencia - Profesor hereda de Persona e implementa IProfesor
    /// <summary>
    /// Clase que representa a un profesor en el sistema académico.
    /// </summary>
    public class Profesor : Persona, IProfesor
    {
        // APLICACIÓN DE POO: Encapsulamiento - Propiedades específicas del profesor
        /// <summary>
        /// Título profesional del profesor.
        /// </summary>
        public string TituloProfesional { get; set; }
        /// <summary>
        /// Lista de códigos de cursos asignados al profesor.
        /// </summary>
        public List<string> CursosAsignados { get; set; }
        // APLICACIÓN DE POO: Constructor - Inicializa las propiedades del profesor
        /// <summary>
        /// Constructor para inicializar propiedades específicas del profesor.
        /// </summary>
        public Profesor(string nombre, string apellidos, string telefono, string numCedula, string correo, string tituloProfesional)
            : base(nombre, apellidos, telefono, numCedula, correo)
        {
            TituloProfesional = tituloProfesional;
            CursosAsignados = new List<string>();
        }
        // APLICACIÓN DE POO: Polimorfismo - Implementación obligatoria del método abstracto
        /// <summary>
        /// Obtiene el tipo de persona.
        /// </summary>
        /// <returns></returns>
        public override string ObtenerTipo()
        {
            return "Profesor";
        }
        // APLICACIÓN DE POO: Polimorfismo - Sobrescritura del método virtual de la clase base
        /// <summary>
        /// Obtiene información completa del profesor, incluyendo su título profesional.
        /// </summary>
        /// <returns></returns>
        public override string ObtenerInformacion()
        {
            return $"{base.ObtenerInformacion()}, Título: {TituloProfesional}";
        }
        // Método específico de la interfaz IProfesor
        /// <summary>
        /// Asigna un curso al profesor.
        /// </summary>
        /// <param name="codigoCurso"></param>
        public void AsignarseACurso(string codigoCurso)
        {
            if (!string.IsNullOrEmpty(codigoCurso) && !CursosAsignados.Contains(codigoCurso))
            {
                CursosAsignados.Add(codigoCurso);
            }
        }
    }
}