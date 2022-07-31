### Jogar dados

**Objetivo:** usando uma aplicação do tipo console do dotnet, criar um jogo simplificado onde dois jogadores podem jogar dados e a aplicação informa qual dos jogadores tirou o maior número. Faça o controle de versionamento da sua aplicação com git e suba a mesma para o github.

## Novos conceitos ou funcionalidades desse exercício

Usaremos nesse exercício a classe Random do dotnet para simular uma jogada de dados com 6 lados. O random irá possibilitar que tiremos um número aleatório (de 1 a 6 para nosso exemplo).
Você pode usar loop para esse exercício, estude sobre loops caso não conheça. Poderá também optar por usar **recursão** (o exemplo de consulta usa recursão no método "IniciarRodadas"), recomendo estudar sobre recursão também antes de iniciar o exercício.

## Requisitos para desenvolver a aplicação

- Quando o usuário abrir o jogo deverá ser solicitado o nome do primeiro e do segundo jogador. Não será possível jogar com mais do que dois jogadores.

- O jogo deverá solicitar um nome para cada jogador e os nome não podem ser iguais.

- O jogo terá 3 rodadas, o jogador que tirar o maior número no dados na maioria das jogadas vence a partida.

- Em caso de empate (onde os dois tiram o mesmo número) nenhum jogador pontuará.

- A cada rodada a aplicação deve informar quem foi o jogador vencedor. Exemplos de mensagens:
	- **João tirou o número 2 e Maria o número 6. Maria venceu a rodada 1.**
	- **João tirou o número 1 e Maria o número 1. Empate.**

- Um placar sempre deve ser exibido até o final do jogo para que os jogadores acompanhem o resultado. Exemplo:
	Pontos do jogador Maria: 1
	Pontos do jogador João: 0

- Ao final da rodada 3 a aplicação deve informar quem foi o vencedor ou se foi um empate.

**Opcional**
- Fazer o controle de versionamento da sua aplicação usando git;
- Subir a aplicação para um repositório do github.

# Desafios

1. Se a terceira rodada terminar em empate, faça com que os jogadores continuem jogando dados. O próximo a pontuar ganha o jogo.
2. Crie uma opção antes de iniciar o jogo que permite que o usuário selecione a quantidade de rodadas. A quantidade deve estar entre 1 e 5.
