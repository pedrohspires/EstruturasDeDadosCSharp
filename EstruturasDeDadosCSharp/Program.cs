using EstruturasDeDadosCSharp.Listas;
using EstruturasDeDadosCSharp.Tipos;


/*
 * Para utilizar um tipo de lista específico, basta descomentar a lista desejada e comentar as demais listas.
 * Todos os métodos são compatíveis em nome e função.
 */


// Atenção: nomes colocados aleatóriamente, não fazem mensões a pessoas reais, exceto o meu próprio nome
Pessoa PedroHenrique = new Pessoa("Pedro Henrique", 23);
Pessoa JoaoSilva = new Pessoa("João Silva", 31);
Pessoa MariaSousa = new Pessoa("Maria Sousa", 25);
Pessoa JuliaAlmeida = new Pessoa("Júlia Almeida", 28);

// ---------- Lista Encadeada ----------
ListaEncadeada lista = new ListaEncadeada();


// ---------- Testes ----------
lista.AdicionaFinal(PedroHenrique);
lista.AdicionaFinal(MariaSousa);
lista.AdicionaInicio(JoaoSilva);
lista.Adiciona(JuliaAlmeida, JoaoSilva.Nome);
lista.Print();

Pessoa? pessoaRemovida = lista.Remove(PedroHenrique.Nome);
pessoaRemovida?.Apresentese();
pessoaRemovida = lista.Remove(JoaoSilva.Nome);
pessoaRemovida?.Apresentese();
pessoaRemovida = lista.Remove(MariaSousa.Nome);
pessoaRemovida?.Apresentese();
pessoaRemovida = lista.Remove(JuliaAlmeida.Nome);
pessoaRemovida?.Apresentese();
pessoaRemovida = lista.Remove(PedroHenrique.Nome);
pessoaRemovida?.Apresentese();

lista.Print();