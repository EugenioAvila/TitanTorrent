namespace TitanTorrent.Herramientas
{
    public class ClasesCustom
    {
        public class CustomPlataformas
        {
            public string DESCRIPCION { get; set; }
            public int ID { get; set; }
        }

        public class CustomCategorias
        {
            public string DESCRIPCION { get; set; }
            public int ID { get; set; }
            public int ID_PLATAFORMA { get; set; }
        }
    }
}