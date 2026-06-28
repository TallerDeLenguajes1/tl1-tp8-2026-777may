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

using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using ToDo;

Random rand = new();
List<Tarea> tareasPendientes = [];
List<Tarea> tareasRealizadas = [];
char[] opcionesMenuPP = ['1', '2', '3', '4', '0'];
char[] opcionesMenuIngreso = ['1', '2', '0'];
char[] opcionesMenuBusqueda = ['1', '2', '0'];
char[] opcionesMenuMuestra = ['1', '2', '3', '0'];
char[] opcionesMenuMover = ['1', '2', '3', '0'];
string[] opcionesDeTareas = ["Leer", "Trabajar", "Escribir", "Barrer", "Cocinar"];
char opcionMenu;
Tarea buscada;
List<Tarea> buscadas;
do
{
    MenuPrincipal(out opcionMenu);
    switch (opcionMenu)
    {
    // (1)Ingresar tarea:
    case '1':
        MenuIngreso(out opcionMenu);
        switch (opcionMenu)
        {
            // (1)Ingresar 3 tareas aleatorias:
            case '1':
                IngresarGrupoDeTareas(3, tareasPendientes);
            break;
            // (2)Ingresar X tareas aleatorias:
            case '2':
                //Solicitamos cantidad de tareas a realizar y las guardamos en la lista de pendientes
                IngresarGrupoDeTareas(ObtenerEnteroPositivo("Ingrese la cantidad de tareas aleatorias:"), tareasPendientes);
            break;
            case '0':
            break;
        }
    break;
    // (2)Buscar tarea:
    case '2':
        MenuBusqueda(out opcionMenu);
        switch (opcionMenu)
        {
            // (1)Buscar por Descripcion:
            case '1': 
                Console.WriteLine("\nDescriba la tarea que busca:");
                buscadas = BuscarTareaPorDescripcion(tareasPendientes, Console.ReadLine());
                if (buscadas.Count > 1)
                {
                    MostrarTareasListaX(buscadas, "Hemos encontrado las siguientes coincidencias:");
                }else if (buscadas.Count == 1)
                {
                    Console.WriteLine($"La tarea es: {buscadas[0]}.");
                }
                else
                {
                    Console.WriteLine("No se ha encontrado coincidencia.");
                }
            break;
            // (2)Buscar por ID:
            case '2': 
                buscada = BuscarTareaPorID(ObtenerEnteroPositivo("Ingrese el ID a buscar:"), tareasPendientes);
                if (buscada != null)
                {
                    Console.WriteLine($"La tarea es: {buscada}.");
                }else{
                    Console.WriteLine($"No se ha encontrado la tarea.");
                }
            break;
            case '0':
            break;
        }
    break;
    // (3)Mostrar lista:
    case '3':
        MenuMuestra(out opcionMenu);
        switch (opcionMenu)
        {
            // (1)Motrar pendientes:
            case '1':  
                MostrarTareasListaX(tareasPendientes, "Las tareas pendientes son:");
            break;
            // (2)Mostrar realizadas:
            case '2':  
                MostrarTareasListaX(tareasRealizadas, "Las tareas realizadas son:");
            break;
            //(3)Mostrar todas:
            case '3':
                Console.WriteLine("\n---------------------------------------------------------------\n");
                Console.WriteLine("\nTodas las tareas son:\n");
                MostrarTareasListaX(tareasPendientes, "Las pendientes:");
                MostrarTareasListaX(tareasRealizadas, "Las realizadas:");
                Console.WriteLine("\n---------------------------------------------------------------\n");
            break;
            case '0':
            break;
        }
    break;
    // (4)MoverTarea:
    // 3. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
    case '4':
        MenuMover(out opcionMenu);
        switch (opcionMenu)
        {
            // (1)Mover grupo por descripcion.
            case '1':  
                Console.WriteLine("\nDescriba las tareas que busca mover:");
                buscadas = BuscarTareaPorDescripcion(tareasPendientes, Console.ReadLine());
                if (buscadas.Count != 0)
                {
                    foreach (var busc in buscadas)
                    {
                        MoverTarea(busc, tareasPendientes, tareasRealizadas);
                    }
                }
                else
                {
                    Console.WriteLine("No se han encontrado coincidencias.");
                }
            break;
            // (2)Mover tarea por descripcion.
            case '2':  
                Console.WriteLine("\nDescriba la tarea que busca mover:");
                buscadas = BuscarTareaPorDescripcion(tareasPendientes, Console.ReadLine());
                if (buscadas.Count != 0)
                {
                    if (buscadas.Count > 1)
                    {
                        MostrarTareasListaX(buscadas, "Hemos encontrado las siguientes coincidencias:");
                    }
                    for (int i = buscadas.Count; i >= 1; i--)
                    {
                        Console.WriteLine($"¿Desea seleccionar la tarea: < {buscadas[i-1]} > como realizada? (s/n):");
                        opcionMenu = char.ToLower(Console.ReadKey().KeyChar);
                        Console.WriteLine();
                        if (opcionMenu == 's')
                        {
                            MoverTarea(buscadas[i-1], tareasPendientes, tareasRealizadas);
                        }
                        else if(opcionMenu != 'n')
                        {
                            Console.WriteLine("\nOpción inválida\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No se han encontrado coincidencias.");
                }
                //
            break;
            // (3)Mover tarea por ID.
            case '3':  
                buscada = BuscarTareaPorID(ObtenerEnteroPositivo("\nIngrese el ID de la tarea que busca mover:"), tareasPendientes);
                if(buscada != null){
                    MoverTarea(buscada, tareasPendientes, tareasRealizadas);
                }else{
                    Console.WriteLine("No se han encontrado coincidencias");
                }
            break;
            case '0':
            break;
        }
    break;
    case '0':
    break;
    }
} while (opcionMenu != '0');







Tarea CrearTareaAleatoria(){
    return new(opcionesDeTareas[rand.Next(opcionesDeTareas.Length)], rand.Next(Tarea.MIN_DURACION_TAREA,Tarea.MAX_DURACION_TAREA+1));
}
void MostrarTareasListaX(List<Tarea> lista, string titulo)
{
    Console.WriteLine("\n====================================\n");
    Console.WriteLine($"{titulo}");
    foreach (var Tarea in lista)
    {
        Console.WriteLine($"\n {Tarea}\n");
    }
    Console.WriteLine("\n====================================\n");
}


void MoverTarea(Tarea tarea, List<Tarea> listaOrigen, List<Tarea> listaFin){
    listaFin.Add(tarea);
    listaOrigen.Remove(tarea);
}

Tarea BuscarTareaPorID(int id, List<Tarea> lista)
{
    return lista.FirstOrDefault(p => p.TareaID == id);
}



List<Tarea> BuscarTareaPorDescripcion(List<Tarea> pendientes, string descripcion)
{
    // Primera coincidencia
    // Tarea? primera = pendientes.FirstOrDefault(t => t.Descripcion.Contains(descripcion));
    // Lista de coincidencias
    return pendientes.Where(tarea => tarea.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase)).ToList();
    // return pendientes.Where(tarea => tarea.Descripcion.Contains(descripcion, StringComparison.OrdinalIgnoreCase)).[];
}
//! int MostrarTareaPorDescripcion(List<Tarea> pendientes, string descripcion){
//!     List<Tarea> encontradas = BuscarTareaPorDescripcion(pendientes, descripcion);
//!     foreach (var tarea in encontradas){
//!         Console.WriteLine($"\n{tarea}\n");
//!     }
//!     return encontradas.Count;
//! }
// 5. Mostrar un listado de todas las tareas (pendientes y realizadas)
// 6. Diseña un menú principal que permita al usuario acceder a cada una de las funcionalidades descritas.

void MenuPrincipal(out char opcion)
{
    do
    {
        Console.WriteLine($"""
        
        =========================================
        Seleccione una opcion:
        (1)Ingresar tarea pendiente.
        (2)Buscar tarea pendiente.
        (3)Mostrar lista.
        (4)MoverTarea.
        (0)Salir
        =========================================
        """);
        opcion = Console.ReadKey().KeyChar;
    } while (!opcionesMenuPP.Contains(opcion));
}
// char[] validas = ['1', '2', '3', '4', '0'];

// do
// {
//     opcion = char.ToLower(Console.ReadKey().KeyChar);
//     Console.WriteLine();

//     if (!validas.Contains(opcion))
//         Console.WriteLine("Opción inválida");

// } while (!validas.Contains(opcion));


void MenuIngreso(out char opcion){
    do
    {
        Console.WriteLine($"""
        
        =========================================
        Seleccione una opcion:
        (1)Ingresar 3 tareas aleatorias.
        (2)Ingresar X tareas aleatorias.
        (0)Salir
        =========================================
        """);
        opcion = Console.ReadKey().KeyChar;
    } while (!opcionesMenuIngreso.Contains(opcion));
}

void MenuBusqueda(out char opcion)
{
    do
    {
        Console.WriteLine($"""
        
        =========================================
        Seleccione una opcion a buscar en PENDIENTES:
        (1)Buscar por Descripcion.
        (2)Buscar por ID.
        (0)Salir
        =========================================
        """);
        opcion = Console.ReadKey().KeyChar;
    } while (!opcionesMenuBusqueda.Contains(opcion));
}

void MenuMuestra(out char opcion)
{ 
    do
    {
        Console.WriteLine($"""
        
        =========================================
        Seleccione una opcion:
        (1)Motrar pendientes.
        (2)Mostrar realizadas.
        (3)Mostrar todas.
        (0)Salir
        =========================================
        """);
        opcion = Console.ReadKey().KeyChar;
    } while (!opcionesMenuMuestra.Contains(opcion));
}

void MenuMover(out char opcion)
{
    do
    {
        Console.WriteLine($"""
        
        =========================================
        Seleccione una opcion:
        (1)Mover grupo por descripcion.
        (2)Mover tarea por descripcion.
        (3)Mover tarea por ID.
        (0)Salir
        =========================================
        """);
        opcion = Console.ReadKey().KeyChar;
    } while (!opcionesMenuMover.Contains(opcion));
}


int ObtenerEnteroPositivo(string texto){
    int cantidad;
    bool valido;
    do
    {
        Console.WriteLine($"\n{texto}");
        valido = int.TryParse(Console.ReadLine(), out cantidad);

    } while (cantidad <= 0 || !valido);
    return cantidad;
}

void IngresarGrupoDeTareas(int cant, List<Tarea> lista){
    while (cant != 0)
    {
        Tarea nueva = CrearTareaAleatoria();
        lista.Add(nueva);
        cant--;
    }
}



//     char opcion;
//     do
//     {
//         Console.WriteLine("¿Desea marcar alguna tarea como realizada? (s/n)");
//         opcion = char.ToLower(Console.ReadKey().KeyChar);
//         Console.WriteLine();
//         if (opcion == 's')
//         {
//     // 4. Desarrolle una función para buscar tareas pendientes por descripción y mostrarla por consola.
//             Console.WriteLine("\nDescriba la tarea que busca:");
//             buscadas = BuscarTareaPorDescripcion(tareasPendientes, Console.ReadLine());
//             if (buscadas.Count > 1)
//             {
//                 MostrarTareasListaX(buscadas, "Hemos encontrado las siguientes coincidencias:");
//             }
//             for (int i = buscadas.Count; i >= 1; i--)
//             {
//                 Console.WriteLine($"Desea seleccionar la tarea: < {buscadas[i-1]} > como realizada?:");
//                 opcion = char.ToLower(Console.ReadKey().KeyChar);
//                 Console.WriteLine();
//                 if (opcion == 's')
//                 {
//                     MoverTarea(buscadas[i-1], tareasPendientes, tareasRealizadas);
//                 }
//                 else if(opcion != 'n')
//                 {
//                     Console.WriteLine("\nOpción inválida\n");
//                 }
//             }

//         }else if(opcion != 'n')
//         {
//             Console.WriteLine("\nOpción inválida\n");
//         }
//     } while (opcion != 'n');
// }

// La interacción debe ser intuitiva (ej. "Presione 1 para...", "Ingrese el ID de la tarea:", etc.).

