# CatalogoProdutos

Uma api para gerenciar e manter produtos e suas respectivas categoria.

### Features

- Cadastrar produtos
- Atualizar produtos
- Listar produtos
- Deletar produtos
- Cadastrar categorias
- Atualizar categorias
- Listar categorias
- Deletar categorias

### Pré-requisitos para rodar a api

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.Net6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0). 
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/) ou [VisualStudio](https://visualstudio.microsoft.com/pt-br/)

### Rodando a api na web

```bash
# Clone este repositório
$ git clone <https://github.com/ScientistReV/CatalogoProdutos>

# Acesse a pasta do projeto no terminal/cmd
$ cd CatalogoProdutos

# Vá para a pasta ApiCatalog
$ cd ApiCatalog

# Vá para a pasta ApiCatalog
$ Dentro da pasta execute dotnet run

# O servidor inciará na porta:7229 - acesse <https://localhost:7229/swagger>
```
### Como testar os endpoints
Entre no swagger

Vá até o endpoint de 

![image](https://github.com/ScientistReV/CatalogoProdutos/assets/56131415/1e72789a-6a3e-4dc7-8f0f-5d5220978ed8)

Use o id = 1, o UsuarioNome: batman e a senha: 123456, papel gerente conforme o esquema abaixo

![image](https://github.com/ScientistReV/CatalogoProdutos/assets/56131415/896bf64d-16d2-4205-ad85-69ee15d52424)

Como isso vai gerar um token e você pode se autenticar aqui

![image](https://github.com/ScientistReV/CatalogoProdutos/assets/56131415/41944a3b-3cb2-4d98-90d0-2cba72e32a41)

### Sobre o banco de dados
Eu criei um banco de dados em memória, com isso já vai popular pra você automaticamente a api, porém, tem possibilidade de você criar mais campos.


### Status

<h5> 
Primeira versão da api concluída.
</h5>

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [.Net6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)


