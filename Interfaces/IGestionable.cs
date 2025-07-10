using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones básicas de gestión de elementos en el sistema académico.
    /// Permite registrar, buscar, obtener todos los elementos, verificar existencia y eliminar elementos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGestionable<T>
    {
        /// <summary>
        /// Registra un nuevo elemento en el sistema.
        void Registrar(T elemento);
        /// </summary>
        /// <summary>
        /// Busca un elemento en el sistema por su número de cédula.
        /// </summary>
        /// <param name="numCedula">El número de cédula del elemento a buscar.</param>
        /// <returns>El elemento encontrado o null si no existe.</returns>
        T Buscar(string numCedula);
        /// <summary>
        /// Obtiene todos los elementos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista con todos los elementos registrados.</returns>
        List<T> ObtenerTodos();
        /// <summary>
        /// Verifica si un elemento con el número de cédula especificado ya existe en el sistema.
        /// </summary>
        /// <param name="numCedula">El número de cédula del elemento a verificar.</param>
        /// <returns>True si el elemento existe, false en caso contrario.</returns>
        bool Existe(string numCedula);
        /// <summary>
        /// Elimina un elemento del sistema por su número de cédula.
        /// </summary>
        /// <param name="numCedula">El número de cédula del elemento a eliminar.</param>
        /// <returns>True si se eliminó correctamente, false en caso contrario.</returns>
        bool Eliminar(string numCedula);
    }
}
