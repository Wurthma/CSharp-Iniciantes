### Orientação a Objetos - Drone de Exploração

**Objetivo:** aprender conceitos de **orientação a objetos (OO)**.

Nos requisitos para fazer os exercícios foi solicitado que você já conhecesse os conceitos de orientação a objetos e aqui você não terá um livro onde aprenderá tudo sobre OO, nosso objetivo maior é pôr em prática esses conceitos no C#. Se não conhece sobre OO, não desanime, leia artigos, livros, assista vídeos, faça cursos etc. Conteúdo sobre o assunto não falta!
Para atingir esse objetivo, a aplicação que vamos utilizar simula o controle de um drone robô.

*Esse é facilmente o exercício mais importante da lista, no entanto, um único exercício de orientação a objetos não é o suficiente. Então pratique mais, procure por outros exercícios, retorne aos exercícios que já fez e aplique os novos conceitos que vai aprender.*

Usando uma aplicação do tipo console do dotnet desenvolva uma aplicação **Drone de Exploração** que deve simular o controle de um drone que além das capacidades já conhecidas de um drone comum, terá câmera de alta resolução, 2 braços mecânicos para permitir coletar materiais e 1 recipiente para armazenar o material coletado. Cada braço terá ferramentas específicas que serão detalhadas nos requisitos e o software também deverá permitir o controle de voo e movimentação do drone.

## Novos conceitos ou funcionalidades desse exercício

Nos exercícios anteriores já fizemos o uso de alguns conceitos que você vai agora estudar mais a fundo.

Entenda o que é cada pilar da Programação Orientada a Objetos e como implementar elas em exemplos práticos no C#. Esses pilares são:
- Encapsulamento
- Herança
- Abstração
- Polimorfismo

Para aprender esses pilares você precisa dominar alguns conceitos básicos do C#:
- Modificadores de acesso: `public`, `private` e `protected`.
- Classes, classes abstratas (modificador `abstract`) e classes estáticas (modificador `static`).
- Construtores.
- Propriedades, métodos e seus modificadores.
- Interfaces.

**No código de exemplo há diversos comentários que exemplificam a aplicação de cada um dos pilares. Tente realizar seu exercício e posteriormente consulte o exemplo e faça as melhorias necessários no seu.**

## Requisitos da aplicação

- O usuário deve ser capaz de controlar o drone por um menu da aplicação, o menu deve disponibilizar as opções de acordo com as regras especificadas abaixo.

- **Controle de voo:**
	- Regra: altura máxima deve ser 25 metros do chão;
	- Regra: altura mínima deve ser 0,5 metros do chão;
	- Usuário deve ser capaz de informar a qual altura deseja voar, respeitando as regras de voo acima.
	- Usuário deve ser capaz de mudar a altura progressivamente também, onde cada comando sobe ou desce 0,5 metros, respeitando as regras de voo.
	
- **Direção de movimento:**
	- Usuário deve ser capaz de mudar a direção do drone e 0º à 360º, informando exatamente em qual ângulo deseja ficar direcionado (leve em consideração que o drone sempre começa na direção norte, que representa nosso ângulo zero).
	- Usuário deve ser capaz de mudar a direção do drone progressivamente, onde cada comando muda a direção para esquerda ou direita em 5º.
		- Exemplo 1: se atualmente o drone está na direção 100º, ao usar o comando para ir para esquerda progressivamente, a direção deve mudar para 95º.
		- Exemplo 2: se atualmente o drone está na direção 100º, ao usar o comando para ir para direita progressivamente, a direção deve mudar para 105º.
		- Exemplo 3: se atualmente o drone está na direção 2º, ao usar o comando para ir para esquerda progressivamente, a direção deve mudar para 357º.
		- Exemplo 4: se atualmente o drone está na direção 359º, ao usar o comando para ir para direita progressivamente, a direção deve mudar para 4º.
		
- **Velocidade de movimento:**
	- Regra: velocidade máxima de movimento deve ser 15 metros por segundos (estado "Em movimento" para qualquer valor acima de 0).
	- Regra: velocidade mínima de movimento deve ser 0 metros por segundos, onde o drone ficará no estado "Sem movimento".
	- Usuário deve ser capaz de mudar a velocidade do drone progressivamente, onde cada comando muda aumenta ou diminui a velocidade de 0,5 em 0,5 metro/s.

- **Aproximação de objeto:**
	- Regra: *aproximação de objeto* só pode ser realizada após estar parado (0 metro/s);
	- *Aproximação de objeto* deverá ser um comando dado ao drone que aproximara ele lentamente até determinado objeto, com o objetivo de ficar no alcance dos braços mecânicos.
	- Após realizar a *aproximação de objeto* o drone deve ficar impedido de fazer nova aproximação, ou mudança de altura, direção e deve estar parado (0 metro/s).
	- Estando próximo de um objeto o Drone deve ser capaz de se distanciar desse mesmo objeto para voltar as suas funções normais.
	
- **Ações dos braços**
	- Regra: Os braços do drone, só podem ser utilizados após realizar "aproximação de objeto".
	- Regra: Os braços do drone, quando "em movimento" devem estar no estado "Repouso".
	- Regra: Os braços do drone, quando "sem movimento" podem passar para o estado "Em atividade".
	- Regra: Qualquer movimento do braço só pode ser realizado quando ele estiver "Em atividade".
	- Regra: o braço não pode ficar "Em repouso" se estiver no estado "Ocupado".
	- **Braço Esquerdo:**
		- Cotovelo
			1. Em Repouso
			2. Contraído
		- Pulso
			1. Rotação positiva a cada 5º
			2. Rotação negativa a cada -5º
			3. Rotação para ângulo específico informado pelo usuário de 0º a 360º
		- Ferramentas do braço esquerdo
			1. Pegar: só pode ser utilizada se o cotovelo estiver contraído. (pinça para manipular objetos)
				- Regra: Ao pegar um objeto o braço deve ficara em um estado de "Ocupado" e só sairá desse estado depois de armazenar.
			2. Armazenar: só pode ser utilizada se o cotovelo estiver Em repouso. (leva objeto até recipiente de armazenamento)
			3. Bater: só pode ser utilizada se o cotovelo estiver contraído e braço desocupado. (martelo pequeno para quebrar rochas e outros objetos para coleta)
	- **Braço Direito:**
		- Cotovelo (mesmas ações do braço esquerdo)
		- Pulso (mesmas ações do braço esquerdo)
		- Ferramentas do braço direito
			1. Pegar (mesma do braço esquerdo)
				- Regra: Ao pegar um objeto o braço deve ficara em um estado de "Ocupado" e só sairá desse estado depois de armazenar.
			2. Armazenar (mesma braço esquerdo)
			3. Cortar: só pode ser utilizada se o cotovelo estiver contraído e braço desocupado. (tesoura para cortar objetos)
			4. Coletar: só pode ser utilizada se o cotovelo estiver Em Repouso e braço desocupado. (pá/colher utilizado para objetos não sólidos)
				- Regra: Ao coletar alguma substância o braço deve ficar em um estado de "Ocupado" e só sairá desse estado depois de armazenar.

**Opcional**
- Fazer o controle de versionamento da sua aplicação usando git;
- Subir a aplicação para um repositório do github.

# Desafios

1. Crie funções para seu drone que permitam ao usuário controlar a câmera de alta resolução. Leve em consideração que a câmera pode fazer rotações horizontais e verticais e capturar foto ou vídeo.
