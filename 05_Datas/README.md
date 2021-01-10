### Datas

**Objetivo:** usando uma aplicação do tipo console do dotnet, criar uma aplicação que listará algumas datas importante da área da técnologia, escolhar 5 datas ou utilize os sugeridos nos requisitos.

## Novos conceitos ou funcionalidades desse exercício

Usaremos nesse exercício a classe DateTime do dotnet então antes ou durante o exercício estude sua documentação.
Tente desenvolver o exercício criando uma classe chamada "DataConfiguracao" (você pode usar outro nome se preferir) a classe deverá conter os métodos responsáveis por configurar o formato escolhido, método para aplicar o formato da data, método para exibir o cabeçalho com a data no formato específicado, etc.

**Estude:**
- Classes, métodos, propriedades e construtores.
- Modificadores de acesso: público, privado e protegido.
- Retornando valores nos métodos.
- Recebendo valores em atributos de métodos.

## Requisitos da aplicação

- Quando o usuário abrir a aplicação deve ser solicitado qual o formato de data ele deseja visualizar. Deve ser disponibilizada as formatações abaixo:
1. Utilizar minha configuração de sistema: 08/01/2021 20:48:13 (Este item deve apenas converter a data para string, deixar que o sistema use o formato dele)
2. Formato simples: 08-01-21
3. Formato longo sexta-feira, 8 de janeiro de 2021
4. Formato longo personalizado 08-01-2021 08:48:13
5. Formato RFC1123 pattern Fri, 08 Jan 2021 20:48:13 GMT

- Você deverá mostrar as datas conforme os formatos nos exemplos acima. Siga as dicas abaixo:
	- Estude como usar o `string.Format` para personalizar o formato da data.
	- Estude as conversões para string específicas para `DateTime`.
	- Para o item 5, verifique como aplicar o formato RFC1123Pattern para o `DateTime`.
	
- Na seleção do formato da data, valide a opção e exiba uma mensagem caso não esteja entre 1 e 5 conforme opções do primeiro requisito, e volte para o menu da seleção do formato da data para que o usuário tente novamente.

- Após seleção correta de uma opção exiba um segundo menu com as seguintes opções (ou use outras de sua escolha):
1- ENIAC
2- RFC1
3- Alan Turing

- Ao escolher uma das opções o sistema deverá exibir para o usuário um cabeçalho com a data do evento e um texto com a descrição do evento. Abaixo você encontra as datas e textos dos eventos sugeridos acima:

**(ENIAC) - 15 de agosto de 1946**
No dia 15 de agosto de 1946 os norte-americanos John Eckert e John Mauchly apresentaram o ENIAC, o primeiro equipamento eletrônico chamado de computador no mundo.

**(RFC1) - 17 de abril de 1969**
Em 17 de abril de 1969 foi feita a publicação da RFC1, por esse motivo considera-se esse o dia da internet até hoje.

**(Alan Turing) - 23 de junho de 1912**
Nascimento de Alan Turing, matemático e criptoanalista britânico que é considerado o "pai da informática" por ter sido essencial na criação de máquinas que, mais tarde, dariam origem aos PCs que utilizamos hoje para trabalhar, estudar e realizar nossas atividades diárias. Sua genialidade e influência fundamental na história da humanidade, entretanto, foram ceifadas pelo preconceito de uma época que, felizmente, já ficou para trás.

**Opcional**
- Fazer o controle de versionamento da sua aplicação usando git;
- Subir a aplicação para um repositório do github.

# Desafios

1. Estude novos formatos de datas e aplique mais opções ao menu de escolha de formato de data.
2. Estude a classe `System.Globalization.CultureInfo` e aplique novos formatos utilizando ela.