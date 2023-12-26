using System;
using System.Linq;
using System.Xml.Linq;

namespace EntityLinq
{
    public class Program
    {
        static void Main(string[] args)
        {

            XElement root = XElement.Load(@"C:\Users\Rafael\source\repos\EntityLinq\EntityLinq\Data\AluraTunes.xml");

            var queryXml =
                from g in root.Element("Generos").Elements("Genero")
                select g;

            foreach (var genero in queryXml)
            {
                Console.WriteLine("{0}\t{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }

            Console.WriteLine("------------------------");


            var query = from g in root.Element("Generos").Elements("Genero")
                        join m in root.Element("Musicas").Elements("Musica")
                        on g.Element("GeneroId").Value equals m.Element("GeneroId").Value
                        select new
                        {
                            Musica =m.Element("Nome").Value,
                            Genero = g.Element("Nome").Value
                        };

            foreach (var musicaGenero in query)
            {
                Console.WriteLine("{0}\t{1}", musicaGenero.Musica, musicaGenero.Genero);
            }


            Console.ReadKey();
        }
    }
}
