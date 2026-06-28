namespace ToDo
{
    class Tarea
    {
        public const int MIN_DURACION_TAREA =  10;
        public const int MAX_DURACION_TAREA = 100;
        private static int _id = 0; //id para el pueblo
        public int TareaID {get;}
        public string Descripcion {get; set;} = string.Empty;
        public int Duracion {get;} //entre 10 y 100
        public Tarea(string Descripcion, int Duracion)
        {
            TareaID = _id;
            _id ++;
            this.Descripcion = Descripcion;
            this.Duracion = Duracion;
        }

        public override string ToString()
        {
            return $"Tarea {TareaID:D4}. Descripcion: {Descripcion}. Duracion {Duracion} minutos.";
        }
    }
}
// Por ejemplo para un cartel tipo antigua caja registradora:
// Console.WriteLine($"TOTAL: ${precio.ToString("N2").PadLeft(12, '0')}");
// // → TOTAL: $0.000.049,50
// TareasPendientes
// TareasRealizadas
