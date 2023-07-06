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
        private int TamanhoLista = 0;

        public int Tamanho()
        {
            return TamanhoLista;
        }

        public Pessoa? Busca(string nomeBusca)
        {
            if (Tamanho() == 0)
                return null;


            Node? node = Inicio;
            while (node != null)
            {
                if (node.Pessoa.Nome.Equals(nomeBusca))
                    return node.Pessoa;

                node = node.Proximo;
            }

            return null;
        }

        public bool Vazia()
        {
            return Tamanho() == 0;
        }

        public void AdicionaFinal(Pessoa pessoa)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no final...");

            if (Inicio == null)
            {
                Inicio = new Node(pessoa);
                TamanhoLista++;
                return;
            }

            Node? node = Inicio;
            while (node?.Proximo != null)
                node = node.Proximo;

            node.Proximo = new Node(pessoa);
            TamanhoLista++;
        }

        public void AdicionaInicio(Pessoa pessoa)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no início...");

            Inicio = new Node(pessoa, Inicio);
            TamanhoLista++;
        }

        public void Adiciona(Pessoa pessoa, string nomeBusca)
        {
            Console.WriteLine($"Adicionando {pessoa.Nome} no lugar de {nomeBusca}...");

            if (Inicio == null || Inicio.Pessoa.Nome.Equals(nomeBusca))
            {
                Inicio = new Node(pessoa, Inicio);
                TamanhoLista++;
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
            TamanhoLista++;
        }

        public Pessoa? RemoveFinal()
        {
            if (TamanhoLista == 0 || Inicio == null)
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
                TamanhoLista--;
                return node?.Pessoa;
            }

            nodeAnterior.Proximo = null;
            TamanhoLista--;
            return node?.Pessoa;
        }

        public Pessoa? RemoveInicio()
        {
            if (TamanhoLista == 0 || Inicio == null)
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
            TamanhoLista--;
            return node?.Pessoa;
        }

        public Pessoa? Remove(string nomeBusca)
        {
            if (TamanhoLista == 0 || Inicio == null)
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
                TamanhoLista--;
                return nodeAtual.Pessoa;
            }

            nodeAnterior.Proximo = nodeAtual.Proximo;
            TamanhoLista--;
            return nodeAtual.Pessoa;
        }

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine("----------- Lista Encadeada -----------");
            Console.WriteLine($"Tamanho: {Tamanho()}");

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
