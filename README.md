## Sobre o projeto

Esta **API**, desenvolvida utilizando **.NET 8**, adota os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução estruturada e eficaz no gerenciamento de orçamentos. O principal objetivo é permitir que os usuários registrem pedidos de orçamentos, detalhando informações como Nome completo, E-mail, telefone e descrição, com os dados sendo armazenados de forma segura em um banco de dados **MySQL**.

Após o envio do pedido, o site retorna automaticamente um e-mail ao usuário confirmando o recebimento da solicitação. Além disso, o dono do negócio terá acesso a todos os pedidos registrados e entrará em contato com o cliente por **WhatsApp** ou **e-mail** para dar continuidade ao atendimento.

A arquitetura da **API** baseia-se em **REST**, utilizando métodos **HTTP** padrão para uma comunicação eficiente e simplificada. Além disso, é complementada por uma documentação **Swagger**, que proporciona uma interface gráfica interativa para que os desenvolvedores possam explorar e testar os endpoints de maneira fácil.

Dentre os pacotes NuGet utilizados, o **AutoMapper** é o responsável pelo mapeamento entre objetos de domínio e requisição/resposta, reduzindo a necessidade de código repetitivo e manual. O **FluentValidation** é usado para implementar regras de validação de forma simples e intuitiva nas classes de requisições, mantendo o código limpo e fácil de manter. Por fim o **EntityFramework** atua como um ORM (Object-Relacional-Mapper) que simplifica as interações com o banco de dados, permitindo o uso de objetos .NET para manipular dados diretamente, sem a necessidade de lidar com consultas SQL.

![hero-image]

### Features

- **Domain-Driven-Design (DDD):** Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade:** Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Geração de Relatórios:** Capacidade de exportar relatórios detalhados para **PDF** e **Excel**, oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger:** Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

### Construido com
![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]
![badge-html]
![badge-css]
![badge-js]

## Getting Started

Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos

* Visual Studio versão 2022+ ou Visual Studio Code
* Windows 10+ ou Çinux/MacOS com [.NET SDK][dot-net-sdk] instalado
* MySql Server

### Instalação

1. Clone o repositório:
    ```sh
    git clone https://github.com/Luizmartinez4/CashFlow.git
    ```

2. Preencha as informações no arquivo `appsettings.Development.json`.
3. Execute a API e aproveite o seu teste :)


<!-- Links -->
[dot-net-sdk]: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0

<!-- Images -->
[hero-image]: Images/heroimage.png

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge
[badge-html]: https://img.shields.io/badge/HTML5-E34F26?logo=html5&logoColor=fff&style=for-the-badge
[badge-css]: https://img.shields.io/badge/CSS3-1572B6?logo=css3&logoColor=fff&style=for-the-badge
[badge-js]: https://img.shields.io/badge/JavaScript-F7DF1E?logo=javascript&logoColor=000&style=for-the-badge
