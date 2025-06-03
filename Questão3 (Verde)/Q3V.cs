using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão2__Verde_
{
    class No
    {
        public string Valor;
        public No Esquerda, Direita;

        public No(string valor)
        {
            Valor = valor;
            Esquerda = Direita = null;
        }
    }
    class ArvoreBinaria
    {
        private No raiz;

        public void Inserir(string valor)
        {
            raiz = Inserir(raiz, valor);
        }

        private No Inserir(No no, string valor)
        {
            if (no == null) return new No(valor);
            if (valor.CompareTo(no.Valor) < 0)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor.CompareTo(no.Valor) > 0)
                no.Direita = Inserir(no.Direita, valor);
            return no;
        }

        public void Remover(string valor)
        {
            raiz = Remover(raiz, valor);
        }

        private No Remover(No no, string valor)
        {
            if (no == null) return null;

            if (valor.CompareTo(no.Valor) < 0)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor.CompareTo(no.Valor) > 0)
                no.Direita = Remover(no.Direita, valor);
            else
            {
                if (no.Esquerda == null) return no.Direita;
                if (no.Direita == null) return no.Esquerda;

                No sucessor = EncontrarMin(no.Direita);
                no.Valor = sucessor.Valor;
                no.Direita = Remover(no.Direita, sucessor.Valor);
            }

            return no;
        }

        private No EncontrarMin(No no)
        {
            while (no.Esquerda != null)
                no = no.Esquerda;
            return no;
        }

        public bool Pesquisar(string valor)
        {
            return Pesquisar(raiz, valor);
        }

        private bool Pesquisar(No no, string valor)
        {
            if (no == null) return false;
            if (valor == no.Valor) return true;
            if (valor.CompareTo(no.Valor) < 0)
                return Pesquisar(no.Esquerda, valor);
            return Pesquisar(no.Direita, valor);
        }

        public void EmOrdem()
        {
            EmOrdem(raiz);
            Console.WriteLine();
        }

        private void EmOrdem(No no)
        {
            if (no == null) return;
            EmOrdem(no.Esquerda);
            Console.Write(no.Valor + " ");
            EmOrdem(no.Direita);
        }

        public void PreOrdem()
        {
            PreOrdem(raiz);
            Console.WriteLine();
        }

        private void PreOrdem(No no)
        {
            if (no == null) return;
            Console.Write(no.Valor + " ");
            PreOrdem(no.Esquerda);
            PreOrdem(no.Direita);
        }

        public void PosOrdem()
        {
            PosOrdem(raiz);
            Console.WriteLine();
        }

        private void PosOrdem(No no)
        {
            if (no == null) return;
            PosOrdem(no.Esquerda);
            PosOrdem(no.Direita);
            Console.Write(no.Valor + " ");
        }
    }

    internal class Q2V
    {
        static void Main(string[] args)
        {
            ArvoreBinaria arvore = new ArvoreBinaria();
            int opcao = 0;

            do
            {
                Console.Write("Op:\n");
                string entrada = Console.ReadLine();
                bool ehNumero = int.TryParse(entrada, out opcao);

                if (!ehNumero)
                {
                    Console.WriteLine("Entrada inválida.");
                    opcao = 0;
                }

                switch (opcao)
                {
                    case 1:
                        string nomeInserir = Console.ReadLine();
                        arvore.Inserir(nomeInserir);
                        break;

                    case 2:
                        string nomeRemover = Console.ReadLine();
                        arvore.Remover(nomeRemover);
                        break;

                    case 3:
                        string nomePesquisar = Console.ReadLine();
                        Console.WriteLine(arvore.Pesquisar(nomePesquisar) ? "sim" : "nao");
                        break;

                    case 4:
                        arvore.EmOrdem();
                        break;

                    case 5:
                        arvore.PosOrdem();
                        break;

                    case 6:
                        arvore.PreOrdem();
                        break;

                    case 7:
                        break;

                    default:
                        if (opcao != 0)
                            Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 7);
        }
    }
}
