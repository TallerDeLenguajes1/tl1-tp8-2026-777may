//!Tipos de Generics
// Dictionary<Tkey,TValue>
// Stack<T>    // Pila (LIFO)
// Queue<T>    // Cola (FIFO)
// List<T>     // Lista dinámica
// LinkedList<T> // Lista enlazada
//!Usos de LINQ
// List<Persona> mayores = estudiantes
//     .Where(p => p.Edad > 21)
//     .ToList();

// List<String> nombresMayores = estudiantes
//     .Select(p => p.Nombre)
//     .ToList();

// Cree aleatoriamente N tareas y guardelas en una lista dedicada a tareas pendientes (por ejemplo, List<Tarea> tareasPendientes).

using ToDo;

Random rand = new();
List<Tarea> pendientes = new();
List<Tarea> realizadas = new();
string[] opciones = ["Leer", "Trabajar", "Escribir", "Barrer", "Cocinar"];
Console.WriteLine("Ingrese la cantidad de tareas aleatorias:");
if(int.TryParse(Console.ReadLine(), out int cantidad))
{
    while (cantidad != 0)
    {
        Tarea nueva = CrearTarea();
        pendientes.Add(nueva);
        cantidad--;
    }
}
Tarea CrearTarea(){
    return new(opciones[rand.Next(5)], rand.Next(10,101));
}
void MostrarTareas(List<Tarea> lista, string nombre)
{
    Console.WriteLine($"La lista de {nombre} es:");
    foreach (var Tarea in lista)
    {
        Tarea.ToString();
    }
}
// 3. Desarrolle una interfaz para mover las tareas pendientes a realizadas. 
// 4. Desarrolle una función para buscar tareas pendientes por descripción y mostrarla por consola.
// 5. Mostrar un listado de todas las tareas (pendientes y realizadas)
// 6. Diseña un menú principal que permita al usuario acceder a cada una de las
// funcionalidades descritas.
// La interacción debe ser intuitiva (ej. "Presione 1 para...", "Ingrese el ID de la
// tarea:", etc.).

