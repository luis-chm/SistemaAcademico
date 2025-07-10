using SistemaAcademico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Modelos
{
    // APLICACIÓN DE POO: Abstracción - Clase abstracta que define comportamientos comunes
    /// <summary>
    /// Clase abstracta que representa una persona en el sistema académico.
    /// </summary>
    public abstract class Persona : IPersona
    {
        // APLICACIÓN DE POO: Encapsulamiento - Propiedades públicas con acceso controlado
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellidos de la persona.
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Teléfono de la persona.
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Número de cédula de la persona.
        /// </summary>
        public string NumCedula { get; set; }
        /// <summary>
        /// Correo electrónico de la persona.
        /// </summary>
        public string Correo { get; set; }
        // APLICACIÓN DE POO: Constructor - Inicializa las propiedades de la persona
        /// <summary>
        /// Constructor para inicializar propiedades comunes de la persona.
        /// </summary>
        public Persona(string nombre, string apellidos, string telefono, string numCedula, string correo)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            NumCedula = numCedula;
            Correo = correo;
        }
        // APLICACIÓN DE POO: Polimorfismo - Método virtual que puede ser sobrescrito
        /// <summary>
        /// Método virtual que obtiene información básica de la persona.
        /// </summary>
        public virtual string ObtenerInformacion()
        {
            return $"Cédula: {NumCedula}, Nombre: {Nombre} {Apellidos}, Teléfono: {Telefono}, Email: {Correo}";
        }
        // APLICACIÓN DE POO: Polimorfismo - Método abstracto que debe ser implementado por las clases derivadas
        /// <summary>
        /// Método abstracto que obtiene el tipo de persona (Estudiante, Profesor, etc.).
        /// </summary>
        public abstract string ObtenerTipo();
    }
}
