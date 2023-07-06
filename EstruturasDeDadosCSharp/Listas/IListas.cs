using EstruturasDeDadosCSharp.Tipos;

namespace EstruturasDeDadosCSharp.Listas
{
    internal interface IListas
    {
        public int Tamanho();

        public Pessoa? Busca(string nomeBusca);

        public bool Vazia();

        public void AdicionaFinal(Pessoa pessoa);

        public void AdicionaInicio(Pessoa pessoa);

        public void Adiciona(Pessoa pessoa, string nomeBusca);

        public Pessoa? RemoveFinal();

        public Pessoa? RemoveInicio();

        public Pessoa? Remove(string nomeBusca);

        public void Print();
    }
}
