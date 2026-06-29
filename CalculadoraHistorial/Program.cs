using EspacioCalculadora;
Calculadora calc1 = new();
char[] opcionesMenuPP = ['1', '2', '3', '4', '5', '0'];
char opcion;
double num1;
do
{
    MenuPP(out opcion);
    if( opcion is not '0' and not '5')
    {
        SolicitarNumero(out num1);
        switch (opcion)
        {
            //(1) Sumar
            case '1':
                calc1.Operar(TipoOperacion.Suma, num1);
                break;
            //(2) Restar
            case '2':
                calc1.Operar(TipoOperacion.Resta, num1);
                break;
            // (3) Multiplicar
            case '3':
                calc1.Operar(TipoOperacion.Multiplicacion, num1);
                break;
            // (4) Dividir    
            case '4':
                calc1.Operar(TipoOperacion.Division, num1);
                break; 
        }
        Console.WriteLine($"-------------------------");
        Console.WriteLine($"\n{calc1}\n");
        Console.WriteLine($"-------------------------");
    }
    else  if (opcion == '5') calc1.Operar(TipoOperacion.Limpiar); 
    Console.WriteLine("\n\n");
} while (opcion != '0');

void MenuPP(out char respuesta)
{
    do
    {
    Console.WriteLine("""

    ================================ 
    Seleccione una opción: 
        (1) Sumar
        (2) Restar
        (3) Multiplicar
        (4) Dividir
        (5) Limpiar resultado
        (0) Salir
    ================================
    """);
    respuesta = Console.ReadKey().KeyChar;
    } while (!opcionesMenuPP.Contains(respuesta));
    Console.WriteLine();
}
void SolicitarNumero(out double num)
{
    do
    {
        Console.WriteLine("\nIngrese un num:\n");
    } while (!double.TryParse(Console.ReadLine(), out num));
}