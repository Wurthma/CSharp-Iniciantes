### Orientação a Objetos - Drone de Exploração

**Objetivo:** aprender conceitos de **orientação a objetos (OO)**.
Nos requisitos para fazer os exercícios foi solicitado que você já conhecesse os conceitos de orientação a objetos e aqui você não terá um livro onde aprenderá tudo sobre OO, nosso objetivo maior é por em prática esses conceitos no C#. Se não conhece sobre OO, não desanime, leia artigos, livros, assista vídeos, faça cursos, etc. Conteúdo sobre o assunto não falta!
Para atingir esse objetivo, a aplicação que vamos utilizar simula o controle de um robo.

*Esse é fácilmente o exercício mais importante da lista, no entanto, um único exercício de orientação a objetos não é o suficiente. Então prátique mais, procure por outros exercícios, retorne aos exercícios que já fez e aplique os novos conceitos que vai aprender.*

Usando uma aplicação do tipo console do dotnet desenvolva uma aplicação **Drone de Exploração** que deve simular o controle de um drone que além das capacidade já conhecidas de um drone comum, terá câmera de alta resolução, 2 braços mecânicos para permitir coletar materiais e 1 recipiênte para armazenar o material coletado. Cada braço terá ferramentas específicas que serão detalhadas nos requisitos e o software também deverá permitir o controle de vôo e movimentação do drone.

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
- Propriedades, métodos e seus moficicadores.
- Interfaces.

**No código de exemplo há diversos comentários que exemplificam a aplicação de cada um dos pilares. Tente realizar seu exercício e posteriomente consulte o exemplo e faça as melhorias necessários no seu.**

## Requisitos da aplicação

- O usuário deve ser capaz de controlar o drone por um menu da aplicação, o menu deve disponibilizar as opções de acordo com as regras específicadas abaixo.

- **Controle de vôo:**
	- Regra: altura máxima deve ser 25 metros do chão;
	- Regra: altura mínima deve ser 0,5 metros do chão;
	- Usuário deve ser capaz de informar a qual altura deseja voar, respeitando as regras de vôo acima.
	- Usuário deve ser capaz de mudar a altura progressivamente também, onde cada comando sobe ou desce 0,5 metros, respeitando as regras de vôo.
	
- **Direção de movimento:**
	- Usuário deve ser capaz de mudar a direção do drone e 0º à 360º, informando exatamente em qual ângulo deseja ficar direcionado (leve em consideração que o drone sempre começa na direção norte, que representa nosso ângulo zero).
	- Usuário deve ser capaz de mudar a direção do drone progressivamente, onde cada comando muda a direção para esquerda ou direita em 5º.
		- Exemplo 1: se atualmente o drone está na direção 100º, ao usar o comando para ir para esquerda progressivamente, a direção deve mudar para 95º.
		- Exemplo 2: se atualmente o drone está na direção 100º, ao usar o comando para ir para direita progressivamente, a direção deve mudar para 105º.
		
- **Velocidade de movimento:**
	-Regra: velocidade máxima de movimento deve ser 15 metros por segundos (estado "Em movimento").
	-Regra: velocidade mínima de movimento deve ser 0 metros por segundos, onde o drone ficará no estado "Sem movimento".

- **Aproximação de objeto:**
	- Regra: *apróximação de objeto* só pode ser realizada após estar à 0,5 metros do chão e parado (0 mestro/s);
	- *Apróximação de objeto* deverá ser um comando dado ao drone que aproximara ele lentamente até determinado objeto, com o objetivo de ficar no alcance dos braços mecânicos.
	- Após realizar a *apróximação de objeto* o drone deve ficar impedido de fazer nova aproximação, ou mudança de altura, direção e deve estar parado (0 mestro/s).
	
- **Ações dos braços**
	- Regra: Os braços do drone, quando "em movimento" devem estar no estado "Repouso"
	- Regra: Os braços do drone, quando "sem movimento" podem passar para o estado "Em atividade"
	- Regra: Qualquer movimento do braço só pode ser realizado quando o mesmo estiver "Em atividade".
	- **Braço Esquerdo:**
		- Cotovelo
			1. Em Repouso
			2. Contraído
		- Pulso
			1. Rotação positiva a cada 5º
			2. Rotação negativa a cada -5º
			3. Rotação para ângulo específico informado pelo usuário de 0º a 360º
		- Ferramentas do braço esquerdo
			1. Pegar (pinça para manipular objetos)
			2. Armazenar (leva objeto até recipiente de armazenamento)
			3. Bater (martelo pequeno para quebrar rochas e outros objetos para coleta)
	- **Braço Direito:**
		- Cotovelo (mesmas ações do braço esquerdo)
		- Pulso (mesmas ações do braço esquerdo)
		- Ferramentas do braço direito
			1. Pegar (mesma do braço esquerdo)
			2. Armazenar (mesma braço esquerdo)
			3. Cortar (teroura para cortar objetos)
			4. Coletar (pá/colher utilizado para objetos não sólidos )

**Opcional**
- Fazer o controle de versionamento da sua aplicação usando git;
- Subir a aplicação para um repositório do github.

# Desafios

1. Crie novas funções para seu drone que permitam ao usuário controlar a câmera de alta resolução. Leve em consideração que a câmera pode fazer rotações horizontais e verticais e capturar foto ou vídeo.