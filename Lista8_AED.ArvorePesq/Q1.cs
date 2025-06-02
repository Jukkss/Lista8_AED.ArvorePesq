using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista8_AED.ArvorePesq
{
    internal class Aluno
    {
        public string Nome { get; set; }
        public int Nota { get; set; }
        public Aluno(string nome, int nota)
        {
            Nome = nome;
            Nota = nota;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Informe quantos alunos(N):");
            int n = int.Parse(Console.ReadLine());
            Aluno[] alunos = new Aluno[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Aluno {i}: ");
                string csv = Console.ReadLine();
                csv = csv.ToLower();

                string[] resp1 = csv.Split(',');
                string nome = resp1[0];
                int nota = int.Parse(resp1[1]);
                Aluno aluno = new Aluno(nome, nota);

                alunos[i] = aluno;
            }

            Console.WriteLine("Informe o nome a ser pesquisado: ");
            string nome2 = Console.ReadLine();
            nome2 = nome2.ToLower();
            bool resp2 = false;
            int dir = n - 1, esq = 0, meio;
            while(esq <= dir)
            {
                meio = (esq + dir) / 2;
                if ((string.Compare(nome2, alunos[meio].Nome)) == 0)
                {
                    resp2 = true;
                    Console.WriteLine(alunos[meio].Nota);
                    break;
                }
                else if ((string.Compare(nome2, alunos[meio].Nome)) < 0)
                {
                    dir = meio - 1;
                }
                else
                {
                    esq = meio + 1;
                }
            }
            if (!resp2)
            {
                Console.WriteLine("Não encontrado");
            }
        }
    }
}
