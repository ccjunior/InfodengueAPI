# **InfoDengue API**

A **InfoDengue API** é uma aplicação para consulta e armazenamento de dados epidemiológicos da plataforma INFODENGUE. A API oferece funcionalidades como registro de solicitantes, geração de relatórios epidemiológicos por município, arbovirose e consultas específicas para os municípios do Rio de Janeiro e São Paulo. Um projeto desenvolvido para facilitar o acesso e análise de dados relacionados a arboviroses no Brasil.

## **Tecnologias Utilizadas**

A API foi desenvolvida utilizando as seguintes tecnologias e ferramentas:

- **ASP.NET Core**: Framework principal para construção da API REST.
- **Entity Framework Core**: ORM para manipulação do banco de dados.
- **SQL Server**: Banco de dados relacional utilizado.
- **Swagger**: Para documentação da API.
- **HttpClient**: Para integração com a API externa do INFODENGUE.

## **Configuração do Ambiente**

### **Pré-requisitos**

Certifique-se de ter instalado:

- **[.NET SDK 8.0+](https://dotnet.microsoft.com/download/dotnet/7.0)**
- **[SQL Server](https://www.microsoft.com/sql-server/)**
- **Uma ferramenta para testar requisições HTTP, como [Postman](https://www.postman.com/) ou [Insomnia](https://insomnia.rest/).**

### **Configuração**

1. Clone este repositório:

```bash
git clone https://github.com/seu-repositorio/infodengue-api.git
cd infodengue-api
```

2. Configure o banco de dados no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InfoDengueDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

3. Execute as migrações do banco de dados:

```bash
dotnet ef database update
```

4. Execute a aplicação:

```bash
dotnet run
```

5. Acesse a documentação Swagger em: `http://localhost:5000/swagger`

## **Arquitetura do Projeto**

O projeto foi estruturado seguindo os princípios da Clean Architecture, dividido em camadas:

- **Presentation**: Controllers e endpoints REST
- **Business**: Lógica de negócios e integrações
- **Data**: Infraestrutura e acesso ao banco de dados
- **Domain**: Modelos, Dtos e Validators

## **Uso**

Agora você pode testar os endpoints de API disponíveis usando ferramentas como Postman ou Insomnia.

Aqui alguns exemplos de endpoints:

### Relatórios

- **POST** `/api/relatorios` - Cria um novo relatório epidemiológico.
- **GET** `/api/relatorios` - Lista todos os relatórios cadastrados.
- **GET** `/api/relatorios/municipio/{codigoIBGE}` - Lista relatórios por código IBGE do município.
- **GET** `/api/relatorios/rj-sp` - Lista dados epidemiológicos do Rio de Janeiro e São Paulo.
- **GET** `/api/relatorios/total-casos-rj-sp` - Lista o total de casos epidemiológicos dos municípios do Rio de Janeiro e São Paulo.
- **GET** `/api/relatorios/total-por-arbovirose` - Lista o total de casos epidemiológicos dos municípios por arbovirose.

### Solicitantes

- **GET** `/api/solicitantes` - Lista todos os solicitantes cadastrados.

## **Modelo de Dados**

O sistema utiliza duas entidades principais:

- **Solicitante**: Armazena dados de quem solicita relatórios (Nome e CPF).
- **Relatório**: Armazena os dados epidemiológicos consultados e referência ao solicitante.

## **Integração com a API InfoDengue**

A aplicação consome a API da plataforma InfoDengue para obter dados epidemiológicos, utilizando os seguintes parâmetros:

- Arbovirose (dengue, zika, chikungunya)
- Semana de início e fim
- Código IBGE do município

## **Contato**

Para quaisquer dúvidas ou sugestões, entre em contato com [carlos.costajunior@hotmail.com]
