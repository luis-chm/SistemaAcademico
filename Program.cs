using SistemaAcademico.Interfaces;
using SistemaAcademico.Modelos;
using System;
using System.Linq;
using System.Threading;

internal static class Program
{
    // APLICACIÓN DE SOLID: DIP - Dependency Inversion Principle
    // Dependemos de la abstracción ISistemaAcademico, no de la implementación concreta
    // APLICACIÓN DE POO: Encapsulamiento - sistema es privado y solo accesible dentro de esta clase
    /// <summary>
    /// Instancia del sistema académico.
    /// </summary>
    private static ISistemaAcademico sistema = new SistemaAcademico.Modelos.SistemaAcademico();
    /// <summary>
    /// Punto de entrada principal para la aplicación.
    /// </summary>
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE GESTIÓN ACADÉMICA ===");
        Console.WriteLine("Proyecto UPI - Técnicas de Programación");
        Console.WriteLine("Aplicando POO y principios SOLID\n");
        Console.WriteLine("Cargando datos iniciales...");
        DatosIniciales.CargarDatos(sistema);
        Thread.Sleep(4000);
        Console.WriteLine("Datos cargados exitosamente.\n");
        Thread.Sleep(2000);

        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            int opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    RegistrarEstudiante();
                    break;
                case 2:
                    RegistrarProfesor();
                    break;
                case 3:
                    CrearCurso();
                    break;
                case 4:
                    AsignarProfesorACurso();
                    break;
                case 5:
                    MatricularEstudianteEnCurso();
                    break;
                case 6:
                    VerCursosDeEstudiante();
                    break;
                case 7:
                    VerEstudiantesYProfesorDeCurso();
                    break;
                case 8:
                    ListarTodosLosCursos();
                    break;
                case 9:
                    salir = true;
                    Console.WriteLine("¡Gracias por usar el sistema!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
    // APLICACIÓN DE CLEAN CODE: Métodos cortos y descriptivos
    /// <summary>
    /// Muestra el menú principal de la aplicación.
    /// </summary>
    private static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Registrar estudiante");
        Console.WriteLine("2. Registrar profesor");
        Console.WriteLine("3. Crear curso");
        Console.WriteLine("4. Asignar profesor a curso");
        Console.WriteLine("5. Matricular estudiante en curso");
        Console.WriteLine("6. Ver cursos de un estudiante");
        Console.WriteLine("7. Ver estudiantes y profesor de un curso");
        Console.WriteLine("8. Listar todos los cursos");
        Console.WriteLine("9. Salir");
        Console.Write("\nSeleccione una opción: ");
    }
    // APLICACIÓN DE CLEAN CODE: Manejo de excepciones para entrada de usuario
    /// <summary>
    /// Lee la opción seleccionada por el usuario.
    /// </summary>
    private static int LeerOpcion()
    {
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            return 0; // Retorna 0 si no se puede parsear (opción inválida)
        }
    }
    // APLICACIÓN DE CLEAN CODE: Métodos cortos con nombres descriptivos
    /// <summary>
    /// Registra un nuevo estudiante en el sistema.
    /// </summary>
    private static void RegistrarEstudiante()
    {
        Console.WriteLine("\n=== REGISTRAR ESTUDIANTE ===");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellidos: ");
        string apellidos = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Número de Cédula: ");
        string numCedula = Console.ReadLine();

        Console.Write("Correo electrónico: ");
        string correo = Console.ReadLine();

        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine();

        Console.Write("Carrera: ");
        string carrera = Console.ReadLine();

        //APLICACIÓN DE SOLID: DIP - Usamos la interfaz, no la implementación
        IEstudiante estudiante = new Estudiante(nombre, apellidos, telefono, numCedula, correo, matricula, carrera);
        sistema.RegistrarEstudiante(estudiante);

        Console.WriteLine("Estudiante registrado exitosamente.");
    }
    /// <summary>
    /// Registra un nuevo profesor en el sistema.
    /// </summary>
    private static void RegistrarProfesor()
    {
        Console.WriteLine("\n=== REGISTRAR PROFESOR ===");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Apellidos: ");
        string apellidos = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Número de Cédula: ");
        string numCedula = Console.ReadLine();

        Console.Write("Correo electrónico: ");
        string correo = Console.ReadLine();

        Console.Write("Título profesional: ");
        string titulo = Console.ReadLine();

        IProfesor profesor = new Profesor(nombre, apellidos, telefono, numCedula, correo, titulo);
        sistema.RegistrarProfesor(profesor);

        Console.WriteLine("Profesor registrado exitosamente.");
    }
    /// <summary>
    /// Crea un nuevo curso en el sistema.
    /// </summary>
    private static void CrearCurso()
    {
        Console.WriteLine("\n=== CREAR CURSO ===");

        Console.Write("Nombre del curso: ");
        string nombre = Console.ReadLine();

        Console.Write("Código del curso: ");
        string codigo = Console.ReadLine();

        Console.Write("Horario: ");
        string horario = Console.ReadLine();

        ICurso curso = new Curso(nombre, codigo, horario);
        sistema.CrearCurso(curso);

        Console.WriteLine("Curso creado exitosamente.");
    }
    /// <summary>
    /// Asigna un profesor a un curso existente.
    /// </summary>
    private static void AsignarProfesorACurso()
    {
        Console.WriteLine("\n=== ASIGNAR PROFESOR A CURSO ===");

        Console.Write("Código del curso: ");
        string codigoCurso = Console.ReadLine();

        Console.Write("Número de cédula del profesor: ");
        string numCedulaProfesor = Console.ReadLine();

        sistema.AsignarProfesorACurso(codigoCurso, numCedulaProfesor);
        Console.WriteLine("Profesor asignado al curso exitosamente.");
    }
    /// <summary>
    /// Matricula un estudiante en un curso existente.
    /// </summary>
    private static void MatricularEstudianteEnCurso()
    {
        Console.WriteLine("\n=== MATRICULAR ESTUDIANTE EN CURSO ===");

        Console.Write("Código del curso: ");
        string codigoCurso = Console.ReadLine();

        Console.Write("Número de cédula del estudiante: ");
        string numCedulaEstudiante = Console.ReadLine();

        sistema.MatricularEstudianteEnCurso(codigoCurso, numCedulaEstudiante);
        Console.WriteLine("Estudiante matriculado en el curso exitosamente.");
    }
    /// <summary>
    /// Verifica los cursos en los que está inscrito un estudiante.
    /// </summary>
    private static void VerCursosDeEstudiante()
    {
        Console.WriteLine("\n=== VER CURSOS DE ESTUDIANTE ===");

        Console.Write("Número de cédula del estudiante: ");
        string numCedulaEstudiante = Console.ReadLine();

        var cursos = sistema.ObtenerCursosDeEstudiante(numCedulaEstudiante);

        if (cursos.Count == 0)
        {
            Console.WriteLine("El estudiante no está inscrito en ningún curso.");
        }
        else
        {
            Console.WriteLine($"\nCursos del estudiante ({cursos.Count}):");
            foreach (var curso in cursos)
            {
                Console.WriteLine($"- {curso.NombreCurso} ({curso.CodigoCurso}) - {curso.HorarioCurso}");
            }
        }
    }
    /// <summary>
    /// Muestra los estudiantes inscritos y el profesor asignado a un curso.
    /// </summary>
    private static void VerEstudiantesYProfesorDeCurso()
    {
        Console.WriteLine("\n=== VER ESTUDIANTES Y PROFESOR DE CURSO ===");

        Console.Write("Código del curso: ");
        string codigoCurso = Console.ReadLine();

        sistema.MostrarEstudiantesYProfesorDeCurso(codigoCurso);
    }
    /// <summary>
    /// Lista todos los cursos disponibles en el sistema.
    /// </summary>
    private static void ListarTodosLosCursos()
    {
        sistema.ListarTodosLosCursos();
    }
}