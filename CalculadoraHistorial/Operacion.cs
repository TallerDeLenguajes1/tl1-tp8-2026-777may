namespace EspacioCalculadora
{
    public class Operacion(double anterior, TipoOperacion operacion, double NuevoValor)
    {
        private readonly double _resultadoAnterior = anterior;
        public double ResultadoAnterior{get => _resultadoAnterior; }
        private readonly double _nuevoValor = NuevoValor;
        public double NuevoValor{get => _nuevoValor; }
        private readonly TipoOperacion _operacion = operacion;
        public TipoOperacion TipoOperacion {get => _operacion; }
        public double Resultado => _operacion switch
        {
            TipoOperacion.Suma           => _resultadoAnterior + _nuevoValor,
            TipoOperacion.Resta          => _resultadoAnterior - _nuevoValor,
            TipoOperacion.Multiplicacion => _resultadoAnterior * _nuevoValor,
            TipoOperacion.Division       => _resultadoAnterior / _nuevoValor,
            _ => 0,
        };
        // public double Resultado()
        // {
        //     switch (_operacion)
        //     {
        //         case TipoOperacion.Suma: return _resultadoAnterior + _nuevoValor;
        //         case TipoOperacion.Resta: return _resultadoAnterior - _nuevoValor;
        //         case TipoOperacion.Multiplicacion: return  _resultadoAnterior * _nuevoValor;
        //         case TipoOperacion.Division: return _resultadoAnterior / _nuevoValor;
        //     }
        //     return 0;
        // } 
        // public Operacion(Operacion anterior, double NuevoValor)
        // {
        //     _resultadoAnterior = anterior.NuevoValor;
        //     _nuevoValor = NuevoValor;
        // }

        public override string ToString()
        {
            string signo = _operacion switch
            {
                TipoOperacion.Suma           => "+",
                TipoOperacion.Resta          => "-",
                TipoOperacion.Multiplicacion => "*",
                TipoOperacion.Division       => "/",
                TipoOperacion.Limpiar        => "C",
                _                            => "?",
            };
                return $"{_resultadoAnterior} {signo} {_nuevoValor} = {Resultado}";
        }
    }
}