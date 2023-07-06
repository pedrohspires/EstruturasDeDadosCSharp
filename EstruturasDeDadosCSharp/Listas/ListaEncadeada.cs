using EstruturasDeDadosCSharp.Tipos;

namespace EstruturasDeDadosCSharp.Listas
{
    internal class Node
    {
        public Pessoa Pessoa { get; set; }
        public Node? Proximo { get; set; }

        public Node(Pessoa pessoa, Node? proximo = null)
        {
            this.Pessoa = pessoa;
            this.Proximo = proximo;
        }
    }

    public class ListaEncadeada : IListas
    {
        private Node? Inicio = null;
        private int Tamanho = 0;

        public void AdicionaFinal(Pessoa pessoa)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no final...");

            if (Inicio == null)
            {
                Inicio = new Node(pessoa);
                Tamanho++;
                return;
            }

            Node? node = Inicio;
            while (node?.Proximo != null)
                node = node.Proximo;

            node.Proximo = new Node(pessoa);
            Tamanho++;
        }

        public void AdicionaInicio(Pessoa pessoa)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no início...");

            Inicio = new Node(pessoa, Inicio);
            Tamanho++;
        }

        public void Adiciona(Pessoa pessoa, string nomeBusca)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no lugar de {nomeBusca}...");

            if (Inicio == null || Inicio.Pessoa.Nome.Equals(nomeBusca))
            {
                Inicio = new Node(pessoa, Inicio);
                Tamanho++;
                return;
            }

            Node node = Inicio;
            while (node.Proximo != null)
            {
                if (node.Proximo.Pessoa.Nome.Equals(nomeBusca))
                    break;

                node = node.Proximo;
            }

            node.Proximo = new Node(pessoa, node.Proximo);
            Tamanho++;
        }

        public Pessoa? RemoveFinal()
        {
            if (Tamanho == 0 || Inicio == null)
            {
                Console.WriteLine("Erro ao remover no final: Lista Vazia");
                return null;
            }

            Node? node = Inicio;
            Node? nodeAnterior = null;

            while (node?.Proximo != null)
            {
                nodeAnterior = node;
                node = node.Proximo;
            }

            if (nodeAnterior == null)
            {
                Inicio = null;
                Tamanho--;
                return node?.Pessoa;
            }

            nodeAnterior.Proximo = null;
            Tamanho--;
            return node?.Pessoa;
        }

        public Pessoa? RemoveInicio()
        {
            if (Tamanho == 0 || Inicio == null)
            {
                Console.WriteLine("Erro ao remover no início: Lista Vazia");
                return null;
            }

            Node? node = Inicio;
            if (node.Proximo == null)
            {
                Inicio = null;
                return node.Pessoa;
            }

            Inicio = new Node(node.Proximo.Pessoa, node?.Proximo.Proximo);
            Tamanho--;
            return node?.Pessoa;
        }

        public Pessoa? Remove(string nomeBusca)
        {
            if (Tamanho == 0 || Inicio == null)
            {
                Console.WriteLine("Erro ao remover no início: Lista Vazia");
                return null;
            }

            Node? nodeAtual = Inicio;
            Node? nodeAnterior = null;

            while (nodeAtual.Proximo != null)
            {
                if (nodeAtual.Pessoa.Nome.Equals(nomeBusca))
                    break;

                nodeAnterior = nodeAtual;
                nodeAtual = nodeAtual.Proximo;
            }

            if (!nodeAtual.Pessoa.Nome.Equals(nomeBusca))
            {
                Console.WriteLine($"{nomeBusca} não foi encontrado!");
                return null;
            }

            if (nodeAnterior == null)
            {
                Inicio = Inicio.Proximo;
                Tamanho--;
                return nodeAtual.Pessoa;
            }

            nodeAnterior.Proximo = nodeAtual.Proximo;
            Tamanho--;
            return nodeAtual.Pessoa;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("----------- Lista Encadeada -----------");
            Console.WriteLine($"Tamanho: {Tamanho}");

            Node? node = Inicio;
            int count = 1;
            while (node != null)
            {
                Console.Write($"Pessoa {count}: ");
                node.Pessoa?.Apresentese();
                node = node.Proximo;
                count++;
            }
            Console.WriteLine();
        }
    }
}
