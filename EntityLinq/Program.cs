﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generos = new List<Genero>
            {
                new Genero {Id = 1, Nome ="Rock"},
                new Genero {Id = 2, Nome ="Reggae"},
                new Genero {Id = 3, Nome ="Rock Progressivo"},
                new Genero {Id = 4, Nome ="Punck Rock"},
                new Genero {Id = 5, Nome ="Clássica"}
            };

            foreach (var genero in generos)
            {
                if (genero.Nome.Contains("Rock"))
                {
                    Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
                }
            }

            Console.WriteLine("--------------------------");

            var query = from g
                        in generos
                        where g.Nome.Contains("Rock")
                        select g;

            foreach (var g in query)
            {
                Console.WriteLine("{0}\t{1}", g.Id, g.Nome);
            }

            Console.WriteLine("--------------------------");

            var musicas = new List<Musica>
            {
               new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
               new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
               new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 5 }
            };

            var musicaQuery = from m in musicas
                              join g in generos on m.GeneroId equals g.Id
                              select new { m, g};

            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}\t{2}", musica.m.Id, musica.m.Nome, musica.g.Nome);
            }

            Console.ReadKey();
        }
    }
}
