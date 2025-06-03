using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão2__Verde_
{
    class No
    {
        public int Valor;
        public No Esquerda, Direita;

        public No(int valor)
        {
            Valor = valor;
            Esquerda = Direita = null;
        }
    }
    class ArvoreBinaria
    {
        private No raiz;

        public void Inserir(int valor)
        {
            raiz = Inserir(raiz, valor);
        }

        private No Inserir(No no, int valor)
        {
            if (no == null) return new No(valor);
            if (valor < no.Valor)
                no.Esquerda = Inserir(no.Esquerda, valor);
            else if (valor > no.Valor)
                no.Direita = Inserir(no.Direita, valor);
            return no;
        }

        public void Remover(int valor)
        {
            raiz = Remover(raiz, valor);
        }

        private No Remover(No no, int valor)
        {
            if (no == null) return null;

            if (valor < no.Valor)
                no.Esquerda = Remover(no.Esquerda, valor);
            else if (valor > no.Valor)
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

        public bool Pesquisar(int valor)
        {
            return Pesquisar(raiz, valor);
        }

        private bool Pesquisar(No no, int valor)
        {
            if (no == null) return false;
            if (valor == no.Valor) return true;
            if (valor < no.Valor) return Pesquisar(no.Esquerda, valor);
            return Pesquisar(no.Direita, valor);
        }

        public int GetMaior()
        {
            if (raiz == null) return -1; 
            No atual = raiz;
            while (atual.Direita != null)
                atual = atual.Direita;
            return atual.Valor;
        }

        public int GetMenor()
        {
            if (raiz == null) return -1; 
            No atual = raiz;
            while (atual.Esquerda != null)
                atual = atual.Esquerda;
            return atual.Valor;
        }

        public void EmOrdem()
        {
            if (raiz == null)
            {
                Console.WriteLine("Árvore vazia");
                return;
            }
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
            if (raiz == null)
            {
                Console.WriteLine("Árvore vazia");
                return;
            }
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
            if (raiz == null)
            {
                Console.WriteLine("Árvore vazia");
                return;
            }
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

        public bool EstaVazia()
        {
            return raiz == null;
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
                        if (int.TryParse(Console.ReadLine(), out int valorInserir))
                            arvore.Inserir(valorInserir);
                        else
                            Console.WriteLine("Número inválido.");
                        break;

                    case 2:
                        if (int.TryParse(Console.ReadLine(), out int valorRemover))
                            arvore.Remover(valorRemover);
                        else
                            Console.WriteLine("Número inválido.");
                        break;

                    case 3:
                        if (int.TryParse(Console.ReadLine(), out int valorPesquisar))
                            Console.WriteLine(arvore.Pesquisar(valorPesquisar) ? "sim" : "nao");
                        else
                            Console.WriteLine("Número inválido.");
                        break;

                    case 4:
                        if (arvore.EstaVazia()) Console.WriteLine("Árvore vazia");
                        else Console.WriteLine(arvore.GetMaior());
                        break;

                    case 5:
                        if (arvore.EstaVazia()) Console.WriteLine("Árvore vazia");
                        else Console.WriteLine(arvore.GetMenor());
                        break;

                    case 6:
                        arvore.EmOrdem();
                        break;

                    case 7:
                        arvore.PosOrdem();
                        break;

                    case 8:
                        arvore.PreOrdem();
                        break;

                    case 9:
                        break;

                    default:
                        if (opcao != 0)
                            Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 9);
        }
    }
}