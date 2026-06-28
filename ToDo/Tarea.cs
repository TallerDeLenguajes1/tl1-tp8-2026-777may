namespace ToDo
{
    class Tarea
    {
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
            return $"Tarea {TareaID:D4} Descripcion: {Descripcion}. Duracion {Duracion} ";
        }
    }
}


// TareasPendientes
// TareasRealizadas
