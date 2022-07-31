### Calculadora

**Objetivo:** usando uma aplicação do tipo console do dotnet, criar uma calculadora simples que terá as operações de soma, subtração, multiplicação e divisão. Faça o controle de versionamento da sua aplicação com git e suba a mesma para o github.

## Novos conceitos ou funcionalidades desse exercício

Nossa primeira aplicação é bem simples e, se você já tem conhecimentos em lógica de programação, algoritmos e alguma linguagem de programação não terá problemas para desenvolver a aplicação.
Faremos uso de operadores condicionais, estrutura condicional 'switch', criação e chamada de métodos simples.

## Requisitos para desenvolver a aplicação

- Ao entrar na calculadora o usuário deverá ter um menu com as opções 1, 2, 3, 4 e 0. Sendo elas:

	1 - Somar
	
	2 - Subtrair
	
	3 - Multiplicar
	
	4 - Dividir
	
	0 - Sair
	

- Todas as operações devem solicitar que o usuário entre com dois valores e então estes valores devem ser utilizados para realizar a operação escolhida. Exemplo de fluxo da operação de Soma:
	1. Aplicação solicita o primeiro valor;
	2. Usuário digita valor e pressiona enter;
	3. Aplicação solicita o segundo valor;
	4. Usuário digita valor e pressiona enter;
	5. Aplicação escreve em tela o resultado da soma;
	6. Usuário pressiona Enter;
	7. Aplicação retorna para o menu;

- Para a operação de divisão, validar se o divisor é 0. Se verdadeiro deve ser exibida a mensagem "Não é possível dividir por zero."

**Opcional**
- Fazer o controle de versionamento da sua aplicação usando git;
- Subir a aplicação para um repositório do github.

# Desafios

1. Crie uma nova opção na calculadora (opção número 5 do menu) que retorne o resto da divisão.
2. Crie uma nova opção na calculadora (opção número 6 do menu) que retorne o resultado da potenciação de uma determinada base pelo seu expoente. Exemplo **2³ = 8**.
