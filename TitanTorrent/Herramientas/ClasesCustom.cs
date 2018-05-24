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

        public class CustomContenido
        {
            public string Nombre { get; set; }
            public bool TieneMagnet { get; set; }
            public bool TieneTorrent { get; set; }
            public System.Collections.Generic.List<string> Archivos { get; set; }
            public System.Collections.Generic.List<string> Imagenes { get; set; }
        }
    }
}