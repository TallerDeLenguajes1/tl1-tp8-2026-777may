namespace EspacioCalculadora
{
    public class Calculadora
    {
        public List<Operacion> operaciones =[];
        public double Resultado => operaciones.LastOrDefault()?.Resultado??0;
        // public double Resultado(){ 
        //     if(operaciones.LastOrDefault()!= null)
        //     {
        //         return operaciones.Last().Resultado;
        //     }
        //     else
        //     {
        //         return 0;
        //     }
        // } 
        private void AgregarOperacion(TipoOperacion operacion, double termino)
        {
            operaciones.Add(new(Resultado, operacion, termino));
        }
        //*==Esto es lo que usarán==
        public override string ToString() => operaciones.LastOrDefault()?.ToString()??"0";
        public void Operar(TipoOperacion operacion, double termino = 0)
        {
            if(operacion == TipoOperacion.Limpiar)
            {
                operaciones.Clear();
            }else
            {
                if(operacion == TipoOperacion.Division && !ValidarDivisor(termino))
                {
                    Console.WriteLine("Divisor invalido");
                }
                else
                {
                    AgregarOperacion(operacion, termino);
                }
            } 
        }       
        //*======================== 
        //  public void Operar(TipoOperacion operacion)
        // {
        //     switch (operacion)
        //     {
                
        //     }
        // }
        // public void Sumar(double termino) => AgregarOperacion(TipoOperacion.Suma, termino);
        // // {

        //     // Operacion nueva;
        //     // if(operaciones.LastOrDefault()!= null)
        //     // { 
        //     //     nueva = new(operaciones.Last().Resultado, TipoOperacion.Suma, termino);
        //     // }
        //     // else
        //     // {
        //     //     nueva = new(0, TipoOperacion.Suma, termino);
        //     // }
        //     // operaciones.Add(nueva);     
        // // }
        // public void Restar(double termino) => AgregarOperacion(TipoOperacion.Resta, termino);
        // public void Multiplicar(double termino) => AgregarOperacion(TipoOperacion.Multiplicacion, termino);
        // public void Dividir(double termino){
        //     if (ValidarDivisor(termino))
        //     {
        //         AgregarOperacion(TipoOperacion.Division, termino);
        //     }
        //     else
        //     {
        //         Console.WriteLine("Divisor invalido");
        //     }
        // } 
        // public void Limpiar()
        // {
        //     operaciones.Clear();
        // }
        public static bool ValidarDivisor(double termino)
        {
            return termino != 0;
        }
    }
}