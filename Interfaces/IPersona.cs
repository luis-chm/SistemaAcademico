using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de una persona en el sistema académico.
    /// </summary>
    public interface IPersona
    {
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        string Nombre { get; set; }
        /// <summary>
        /// Apellidos de la persona.
        /// </summary>
        string Apellidos { get; set; }
        /// <summary>
        /// Teléfono de la persona.
        /// </summary>
        string Telefono { get; set; }
        /// <summary>
        /// Número de cédula de la persona.
        /// </summary>
        string NumCedula { get; set; }
        /// <summary>
        /// Correo electrónico de la persona.
        /// </summary>
        string Correo { get; set; }
        /// <summary>
        /// Método para obtener información completa de la persona.
        /// </summary>
        /// <returns>Información completa de la persona.</returns>
        string ObtenerInformacion();
        /// <summary>
        /// Método para obtener el tipo de persona (Estudiante, Profesor, etc.).
        /// </summary>
        /// <returns>Tipo de persona.</returns>
        string ObtenerTipo();
    }
}
