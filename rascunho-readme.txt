<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Documentação da API</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 0;
            padding: 0;
            background: #f4f4f4;
        }
        .container {
            width: 80%;
            margin: auto;
            overflow: hidden;
        }
        header {
            background: #333;
            color: #fff;
            padding-top: 30px;
            min-height: 70px;
            border-bottom: #bbb 1px solid;
            text-align: center;
        }
        header h1 {
            margin: 0;
        }
        .content {
            background: #fff;
            padding: 20px;
            margin: 20px 0;
            border-radius: 5px;
        }
        h2 {
            color: #333;
        }
        pre {
            background: #eee;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
        code {
            font-family: monospace;
        }
    </style>
</head>
<body>
    <header>
        <div class="container">
            <h1>Documentação da API de Clientes e Cidades</h1>
        </div>
    </header>

    <div class="container">
        <div class="content">
            <h2>Introdução</h2>
            <p>Este documento fornece uma visão geral detalhada da API para gerenciar clientes e cidades. A API foi desenvolvida usando ASP.NET Core e fornece operações CRUD (Criar, Ler, Atualizar e Deletar) para as entidades <code>Clientes</code> e <code>Cidades</code>.</p>

            <h2>Endpoints da API</h2>

            <h3>Clientes</h3>

            <h4>1. Criar Cliente (POST /Clientes)</h4>
            <p>Este endpoint cria um novo cliente. Ele espera um corpo de requisição com os dados do cliente e a cidade onde o cliente está localizado. Se a cidade não existir, ela será criada.</p>
            <pre><code>
{
    "Nome": "João Silva",
    "Telefone": "123456789",
    "Foto": "url-da-foto",
    "Sexo": "Masculino",
    "Cidade": {
        "Nome": "São Paulo",
        "Estado": "SP"
    }
}
            </code></pre>
            <p>Resposta:</p>
            <pre><code>
{
    "Codigo": 1,
    "Nome": "João Silva",
    "Telefone": "123456789",
    "Foto": "url-da-foto",
    "Sexo": "Masculino",
    "CreatedAt": "2024-08-14T00:00:00Z"
}
            </code></pre>

            <h4>2. Listar Todos os Clientes (GET /Clientes)</h4>
            <p>Este endpoint retorna uma lista de todos os clientes, incluindo informações sobre suas cidades.</p>
            <pre><code>
[
    {
        "Codigo": 1,
        "Nome": "João Silva",
        "Telefone": "123456789",
        "Foto": "url-da-foto",
        "Sexo": "Masculino",
        "CreatedAt": "2024-08-14T00:00:00Z",
        "Cidade": {
            "Nome": "São Paulo",
            "Estado": "SP"
        }
    }
]
            </code></pre>

            <h4>3. Obter Cliente por ID (GET /Clientes/{id})</h4>
            <p>Este endpoint retorna os detalhes de um cliente específico com base no ID fornecido.</p>
            <pre><code>
{
    "Codigo": 1,
    "Nome": "João Silva",
    "Telefone": "123456789",
    "Foto": "url-da-foto",
    "Sexo": "Masculino",
    "CreatedAt": "2024-08-14T00:00:00Z",
    "Cidade": {
        "Nome": "São Paulo",
        "Estado": "SP"
    }
}
            </code></pre>

            <h4>4. Atualizar Cliente (PUT /Clientes/{id})</h4>
            <p>Este endpoint atualiza as informações de um cliente existente com base no ID fornecido.</p>
            <pre><code>
{
    "Nome": "João Silva",
    "Telefone": "987654321",
    "Foto": "nova-url-da-foto",
    "Sexo": "Masculino"
}
            </code></pre>

            <h4>5. Deletar Cliente (DELETE /Clientes/{id})</h4>
            <p>Este endpoint remove um cliente específico do banco de dados com base no ID fornecido.</p>

            <h3>Cidades</h3>

            <h4>1. Criar Cidade (POST /Cidades)</h4>
            <p>Este endpoint cria uma nova cidade no banco de dados.</p>
            <pre><code>
{
    "Nome": "São Paulo",
    "Estado": "SP"
}
            </code></pre>
            <p>Resposta:</p>
            <pre><code>
{
    "Id": 1,
    "Nome": "São Paulo",
    "Estado": "SP"
}
            </code></pre>

            <h4>2. Listar Todas as Cidades (GET /Cidades)</h4>
            <p>Este endpoint retorna uma lista de todas as cidades, incluindo informações sobre os clientes associados a cada cidade.</p>
            <pre><code>
[
    {
        "Id": 1,
        "Nome": "São Paulo",
        "Estado": "SP",
        "Clientes": [
            {
                "Codigo": 1,
                "Nome": "João Silva",
                "Telefone": "123456789",
                "Foto": "url-da-foto",
                "Sexo": "Masculino",
                "CreatedAt": "2024-08-14T00:00:00Z"
            }
        ]
    }
]
            </code></pre>

            <h4>3. Obter Cidade por ID (GET /Cidades/{id})</h4>
            <p>Este endpoint retorna os detalhes de uma cidade específica com base no ID fornecido, incluindo os clientes associados.</p>
            <pre><code>
{
    "Id": 1,
    "Nome": "São Paulo",
    "Estado": "SP",
    "Clientes": [
        {
            "Codigo": 1,
            "Nome": "João Silva",
            "Telefone": "123456789",
            "Foto": "url-da-foto",
            "Sexo": "Masculino",
            "CreatedAt": "2024-08-14T00:00:00Z"
        }
    ]
}
            </code></pre>

            <h4>4. Atualizar Cidade (PUT /Cidades/{id})</h4>
            <p>Este endpoint atualiza as informações de uma cidade existente com base no ID fornecido.</p>
            <pre><code>
{
    "Nome": "São Paulo",
    "Estado": "SP"
}
            </code></pre>

            <h4>5. Deletar Cidade (DELETE /Cidades/{id})</h4>
            <p>Este endpoint remove uma cidade específica do banco de dados com base no ID fornecido.</p>

            <h2>Configuração do Ambiente</h2>
            <p>Para rodar esta API localmente, você precisa configurar a string de conexão com o banco de dados e subir o contêiner do SQL Server.</p>

            <h3>Configuração da String de Conexão</h3>
            <p>Defina a string de conexão do banco de dados usando o comando <code>dotnet user-secrets</code>:</p>
            <pre><code>
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "SuaStringDeConexaoAqui"
            </code></pre>

            <h3>Subir o Contêiner do SQL Server</h3>
            <p>Use o comando <code>docker-compose</code> para subir o contêiner do SQL Server:</p>
            <pre><code>
docker-compose up -d
            </code></pre>

            <h2>Conclusão</h2>
            <p>Esta API fornece uma maneira robusta e escalável para gerenciar clientes e cidades, permitindo operações básicas de CRUD através de uma interface RESTful. Se você tiver alguma dúvida ou precisar de mais informações, sinta-se à vontade para entrar em contato.</p>
        </div>
    </div>
</body>
</html>

/Formulario.Api
    /Data
        AppDbContext.cs
    /Endpoints
        /Clientes
            ClienteEndpoints.cs
        /Cidades
            CidadeEndpoints.cs
    /Interfaces
        IClienteService.cs
        ICidadeService.cs
    /Services
        ClienteService.cs
        CidadeService.cs
    Program.cs
/Formularios.Core
    /Models
        Cliente.cs
        Cidade.cs
    /Responses
        ClienteResponse.cs
        CidadeDetalhesResponse.cs
    /Requests
        CreateClienteRequest.cs
        UpdateClienteRequest.cs
        DeleteClienteRequest.cs
        GetClienteByIdRequest.cs
        GetAllClientesRequest.cs
        CreateCidadeRequest.cs
        UpdateCidadeRequest.cs
        DeleteCidadeRequest.cs
        GetCidadeByIdRequest.cs
        GetAllCidadesRequest.cs
