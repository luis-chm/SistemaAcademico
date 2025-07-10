# Proyecto #1 – Sistema de Gestión Académica 

**Universidad:** Universidad Politécnica Internacional (UPI)  
**Curso:** Técnicas de Programación  
**Estudiante:** Luis Angel Chaves Mora



---

## Descripción del Proyecto

Este proyecto consiste en el desarrollo de un **Sistema de Gestión Académica** que permite administrar estudiantes, profesores y cursos de una institución educativa. El sistema fue diseñado aplicando los **4 pilares de la Programación Orientada a Objetos (POO)** y los **5 principios SOLID**, siguiendo las mejores prácticas de **Clean Code**.

### Objetivo Principal
Crear un sistema funcional que demuestre el dominio de los conceptos fundamentales de POO, la implementación correcta de principios SOLID y la aplicación de código limpio, utilizando únicamente estructuras de almacenamiento interno (listas) sin bases de datos.

### Tecnologías Utilizadas
- **Lenguaje:** C# (.NET)
- **IDE:** Visual Studio / Visual Studio Code
- **Estructuras de datos:** `List<T>` únicamente
- **Paradigma:** Programación Orientada a Objetos

---

## Arquitectura del Sistema

### Estructura de Carpetas
```
📁 SistemaAcademico/
├── 📂 Interfaces/          # Contratos y abstracciones
│   ├── IPersona.cs         # Interface base para personas
│   ├── IEstudiante.cs      # Interface específica para estudiantes
│   ├── IProfesor.cs        # Interface específica para profesores
│   ├── ICurso.cs           # Interface para cursos
│   └── ISistemaAcademico.cs # Interface del sistema principal
├── 📂 Modelos/             # Clases del modelo de datos
│   ├── Persona.cs          # Clase abstracta base
│   ├── Estudiante.cs       # Clase concreta heredada
│   ├── Profesor.cs         # Clase concreta heredada
│   ├── Curso.cs            # Clase para gestión de cursos
│   ├── DatosIniciales.cs   # Clase para la carga de datos iniciales
│   └── SistemaAcademico.cs # Lógica de negocio principal
├── Program.cs              # Punto de entrada y menú principal
└── README.md               # Documentación (este archivo)
```

### Modelo de Datos

#### Atributos de Persona (Clase Base)
- **Nombre:** Nombre de la persona
- **Apellidos:** Apellidos completos
- **Telefono:** Número de contacto
- **NumCedula:** Cédula de identidad (clave primaria)
- **Correo:** Dirección de correo electrónico

#### Estudiante (Hereda de Persona)
- **Matricula:** Código único del estudiante
- **Carrera:** Programa académico que cursa
- **CursosInscritos:** Lista de códigos de cursos matriculados

#### Profesor (Hereda de Persona)
- **TituloProfesional:** Grado académico del profesor
- **CursosAsignados:** Lista de códigos de cursos que imparte

#### Curso
- **NombreCurso:** Denominación del curso
- **CodigoCurso:** Identificador único del curso
- **HorarioCurso:** Horario de clases
- **ProfesorAsignado:** Profesor que imparte el curso
- **EstudiantesInscritos:** Lista de estudiantes matriculados

---

## Funcionalidades del Sistema

El sistema presenta un **menú interactivo** con las siguientes opciones:

1. **Registrar estudiante** - Permite ingresar un nuevo estudiante al sistema
2. **Registrar profesor** - Permite ingresar un nuevo profesor al sistema
3. **Crear curso** - Permite crear un nuevo curso
4. **Asignar profesor a curso** - Asigna un profesor específico a un curso
5. **Matricular estudiante en curso** - Inscribe un estudiante en un curso
6. **Ver cursos de un estudiante** - Muestra todos los cursos de un estudiante
7. **Ver estudiantes y profesor de un curso** - Muestra la información completa de un curso
8. **Listar todos los cursos** - Muestra todos los cursos registrados
9. **Salir** - Termina la ejecución del programa

### Ejemplo de Flujo de Uso
```
1. Crear un curso → "Programación I"
2. Registrar un profesor → "Dr. Juan Pérez"
3. Asignar profesor al curso
4. Registrar estudiantes → "María González", "Carlos López"
5. Matricular estudiantes en el curso
6. Consultar información del curso
```

---

## Aplicación de los 4 Pilares de POO

### 1. Encapsulamiento

**Implementación en el proyecto:**
- **Propiedades públicas:** `{ get; set; }` para acceso controlado a los atributos
- **Listas privadas:** Las listas de almacenamiento en `SistemaAcademico` son privadas
- **Métodos específicos:** Cada clase expone solo los métodos relevantes a su responsabilidad

**Ejemplo práctico:**
```csharp
public class SistemaAcademico : ISistemaAcademico
{
    //ENCAPSULAMIENTO: Listas privadas, no accesibles desde fuera
    private List<IEstudiante> estudiantes;
    private List<IProfesor> profesores;
    private List<ICurso> cursos;
    
    //Métodos públicos para interactuar con los datos
    public void RegistrarEstudiante(IEstudiante estudiante) { ... }
}
```

### 2. Abstracción

**Implementación en el proyecto:**
- **Clase abstracta Persona:** Define comportamientos comunes sin implementación completa
- **Interfaces:** Definen contratos sin especificar cómo se implementan
- **Métodos abstractos:** Obligan a las clases derivadas a proporcionar implementación específica

**Ejemplo práctico:**
```csharp
public abstract class Persona : IPersona
{
    // Propiedades comunes a todas las personas
    public string Nombre { get; set; }
    
    // Método que debe ser implementado por clases derivadas
    public abstract string ObtenerTipo();
    
    // Método con implementación base que puede ser sobrescrito
    public virtual string ObtenerInformacion() { ... }
}
```

### 3. Herencia

**Implementación en el proyecto:**
- **Estudiante hereda de Persona:** Obtiene propiedades básicas y agrega específicas
- **Profesor hereda de Persona:** Reutiliza código común y especializa comportamiento
- **Reutilización de código:** Constructor base, métodos comunes

**Ejemplo práctico:**
```csharp
public class Estudiante : Persona, IEstudiante
{
    // Constructor que utiliza el constructor de la clase padre
    public Estudiante(string nombre, string apellidos, ...) 
        : base(nombre, apellidos, ...)
    {
        // Inicialización específica del estudiante
    }
    
    // Implementación obligatoria del método abstracto
    public override string ObtenerTipo() => "Estudiante";
}
```

### 4. Polimorfismo

**Implementación en el proyecto:**
- **Métodos virtuales sobrescritos:** `ObtenerInformacion()` se comporta diferente en cada clase
- **Interfaces:** Múltiples implementaciones del mismo contrato
- **Métodos abstractos:** Implementación específica en cada clase derivada

**Ejemplo práctico:**
```csharp
//El mismo método se comporta diferente según el tipo de objeto
IPersona persona1 = new Estudiante(...);
IPersona persona2 = new Profesor(...);

//cada objeto responde según su tipo
string info1 = persona1.ObtenerInformacion(); // Muestra info de estudiante
string info2 = persona2.ObtenerInformacion(); // Muestra info de profesor
```

---

## Aplicación de los 5 Principios SOLID

### 1. SRP (Single Responsibility Principle)
**Aplicación en el proyecto:**
- **`Persona`:** Solo maneja datos básicos de personas
- **`SistemaAcademico`:** Solo se encarga de la lógica de negocio académico
- **`Program`:** Solo maneja la interfaz de usuario y el menú
- **`Curso`:** Solo gestiona información y operaciones de cursos

**Justificación:** Cada clase tiene una responsabilidad bien definida, lo que facilita el mantenimiento y reduce el acoplamiento.

### 2. OCP (Open/Closed Principle)

**Aplicación en el proyecto:**
- **Extensibilidad:** Se pueden agregar nuevos tipos de personas (ej: Administrador) heredando de `Persona`
- **Interfaces:** Permiten nuevas implementaciones sin modificar código existente
- **Polimorfismo:** Nuevos comportamientos sin cambiar el código cliente

**Ejemplo práctico:**
```csharp
// Se puede agregar sin modificar código existente
public class Administrador : Persona, IPersona
{
    public override string ObtenerTipo() => "Administrador";
}
```

### 3. LSP (Liskov Substitution Principle)

**Aplicación en el proyecto:**
- **Sustitución correcta:** `Estudiante` y `Profesor` pueden usarse donde se espere `IPersona`
- **Comportamiento consistente:** Los métodos sobrescritos mantienen el contrato de la clase base
- **Interfaces compatibles:** Las implementaciones respetan los contratos definidos

**Ejemplo práctico:**
```csharp
// Cualquier implementación de IPersona puede usarse aquí
public void MostrarInformacion(IPersona persona)
{
    Console.WriteLine(persona.ObtenerInformacion()); // Funciona con cualquier implementación
}
```

### 4. ISP (Interface Segregation Principle)

**Aplicación en el proyecto:**
- **Interfaces específicas:** `IEstudiante`, `IProfesor`, `ICurso` en lugar de una interfaz gigante
- **Métodos relevantes:** Cada interface contiene solo métodos específicos a su dominio
- **Dependencias mínimas:** Las clases implementan solo lo que necesitan

**Ejemplo práctico:**
```csharp
// Interface específica para estudiantes
public interface IEstudiante : IPersona
{
    string Matricula { get; set; }
    void InscribirseEnCurso(string codigoCurso); // Solo métodos relevantes
}
```

### 5. DIP (Dependency Inversion Principle)

**Aplicación en el proyecto:**
- **Program depende de ISistemaAcademico:** No de la implementación concreta
- **SistemaAcademico trabaja con interfaces:** `IEstudiante`, `IProfesor`, `ICurso`
- **Flexibilidad:** Se pueden cambiar implementaciones sin afectar el código cliente

**Ejemplo práctico:**
```csharp
// Dependemos de la abstracción, no de la implementación
private static ISistemaAcademico sistema = new Modelos.SistemaAcademico();

// El método trabaja con interfaces, no clases concretas
public void RegistrarEstudiante(IEstudiante estudiante) { ... }
```

---

## Aplicación de Clean Code

### Nombres Descriptivos

**Implementación:**
- **Clases:** `SistemaAcademico`, `Estudiante`, `Profesor` (nombres que expresan claramente su propósito)
- **Métodos:** `RegistrarEstudiante()`, `ObtenerInformacion()`, `AsignarProfesorACurso()`
- **Variables:** `codigoCurso`, `numCedulaEstudiante`, `tituloProfesional`

### Métodos Cortos y Específicos

**Implementación:**
- **Separación de responsabilidades:** Cada método del menú está separado
- **Funciones específicas:** `BuscarEstudiante()`, `BuscarProfesor()`, `BuscarCurso()`
- **Evitar duplicación:** Métodos reutilizables para operaciones comunes

### Sin Números Mágicos

**Implementación:**
- **Validaciones claras:** Uso de constantes descriptivas donde es necesario
- **Condiciones explícitas:** `if (opcion >= 1 && opcion <= 9)` en lugar de números arbitrarios

### Organización del Código

**Implementación:**
- **Separación por responsabilidades:** Interfaces, Modelos, Program en carpetas separadas
- **Comentarios útiles:** Documentación de principios SOLID aplicados
- **Estructura lógica:** Flujo fácil de seguir desde Program.cs

---

## Instrucciones de Ejecución

### Requisitos Previos
- .NET 6.0 SDK o superior
- Visual Studio 2022 / Visual Studio Code

### Pasos para Ejecutar
1. **Descargar archivo ZIP** Extraer archivo 
2. **Abrir Visual Studio** 
3. **Abrir Solucion** SistemaAcademico.sln (en la carpeta del proyecto)

4. **Correr el programa:** CTRL + F5 o Presionar boton run

5. **Ejecutar la aplicación:**

---


# Datos Iniciales Cargados

Al iniciar el sistema, se cargan automáticamente datos de prueba realistas y consistentes para facilitar el uso inmediato del programa.

---

## Estudiantes Cargados

| Nombre completo            | Carrera           | Código   |
|----------------------------|-------------------|----------|
| Ana García López           | Ing. Sistemas     | EST001   |
| Carlos Rodríguez Mora      | Ing. Industrial   | EST002   |
| María Fernández Castro     | Administración    | EST003   |
| José Vargas Solano         | Contaduría        | EST004   |
| Laura Jiménez Rojas        | Ing. Sistemas     | EST005   |

---

## Profesores Cargados

- **Dr. Roberto Méndez** – Ciencias Computación  
- **Msc. Patricia Sánchez** – Ingeniería de Software  
- **Lic. Miguel Torres** – Matemáticas  
- **Msc. Carmen López** – Administración  
- **Dr. Fernando Castro** – Ingeniería Industrial  

---

## Cursos Disponibles

| Curso                      | Código   |
|---------------------------|----------|
| Técnicas de Programación  | PROG101  |
| Estructura de Datos       | PROG201  |
| Base de Datos I           | BD101    |
| Matemáticas Discretas     | MAT201   |
| Gestión de Proyectos      | ADM301   |

---

## Asignaciones y Matrículas

- Todos los **profesores han sido asignados** a cursos.
- Los **estudiantes están matriculados** en múltiples cursos.

---


**Nota:** Este proyecto fue desarrollado con fines académicos como parte del curso de Técnicas de Programación, demostrando el dominio de los conceptos fundamentales de POO, principios SOLID y Clean Code en un contexto práctico y funcional.