### Instalação do Dotnet

Nesse exercício iremos apenas preparar o ambiente com a instalação do Dotnet mais recente e aprender o básico dos seus comandos.
Para desenvolver com dotnet você precisa baixar o SDK.
Para baixar a versão mais atual do Dotnet acesse o link: https://dotnet.microsoft.com/download

## Comandos básicos do dotnet:

Após a instalação podemos verificar se o dotnet foi instalado com sucesso verificando sua versão com o comando:
    `dotnet --version`

1. `dotnet --help`: Esse comando é usado para acessar a ajuda do CLI do dotnet.

2. `dotnet new`: Cria um novo projeto, arquivo de configuração ou solução com base no modelo especificado.

    Exemplos:
    
    `dotnet new console -o MinhaAplicacaoConsole`: cria um novo projeto de console no diretório atual com o nome "MinhaAplicacaoConsole"
    
    `dotnet new webAPI -o MinhaAPI`: cria um novo projeto API no diretório atual com o nome "MinhaAPI"

3. `dotnet build`: Compila um projeto e todas as suas dependências.

4. `dotnet run`: Executa o código-fonte sem qualquer comando de compilação ou inicialização explícito.

**Existem diversos outros comandos, mas os que utilizaremos durante os exercícios estão acima.**

Para mais detalhes do CLI do Dotnet, acesse a documentação: https://docs.microsoft.com/pt-br/dotnet/core/tools/ 
