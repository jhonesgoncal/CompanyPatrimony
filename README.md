# CompanyPatrimony
=====================

API Rest para gerenciamento de patrimonios. 

## Configuração

Mudar connectionString nos arquivos appsettings.json.

## Tecnologias Implementadas:

- ASP.NET Core 2.0 (com .NET Core)
 - ASP.NET WebApi Core
- Entity Framework Core 
- .NET Core Native DI
- AutoMapper
- Fluent

## Arquitetura:

- Desenvolvimento em camadas, SOLID e Clean Code
- Domain Driven Design 
- Notification Pattern
- Unit of Work
- Repository e Generic Repository

## EndPoints

lista dos endpoints para consumo da api.

> ## Patrimony

### GET /patrimony

> Toda lista de patrimonios.

--

**Exemplo retorno**

```json
    [
        {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        },
        {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        }
    ]
```

### GET /patrimony/id

> Traz um patrimonio pelo id.

**Argumentos**

| Argumento | Tipo    |
|-----------|---------|
|`id`       | *guid*  |  


**Exemplo retorno**

```json
    {
        "id": "guid",
        "name": "string",
        "description": "string",
        "numbertumble": "guid",
        "brandId": "guid"
    }
```

### POST /patrimony

> Cadastra um patrimonio.


**Exemplo post**

```json
    {
        "name": "string",
        "description": "string",
        "brandId": "guid"
    }
```

**Exemplo retorno**

```json
    {
        "success": "true",
        "data": {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        }
    }
    
```

### PUT /patrimony

> Atualiza um patrimonio.

**Exemplo post**

```json
    {
        "id": "guid",
        "name": "string",
        "description": "string",
        "brandId": "guid"
    }
```

**Exemplo retorno**

```json
    {
        "success": "true",
        "data": {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        }
    }
    
```

### DELETE /patrimony/id

> Remove um patrimonio pelo id.

**Argumentos**

| Argumento | Tipo    |
|-----------|---------|
|`id`       | *guid*  |  


**Exemplo retorno**

```json
    {
        "success": "true",
        "data": null
    }
```


> ## Brand

### GET /brand

> Toda lista de marcas.

--

**Exemplo retorno**

```json
    [
        {
            "id": "guid",
            "name": "string",
        },
        {
            "id": "guid",
            "name": "string",
        }
    ]
```

### GET /brand/id

> Traz um marca pelo id.

**Argumentos**

| Argumento | Tipo    |
|-----------|---------|
|`id`       | *guid*  |  


**Exemplo retorno**

```json
    {
        "id": "guid",
        "name": "string",
    }
```


### GET /brand/id/patrimony

> Traz uma lista de patrimonios de uma marca pelo id.

**Argumentos**

| Argumento | Tipo    |
|-----------|---------|
|`id`       | *guid*  |  

--

**Exemplo retorno**

```json
    [
        {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        },
        {
            "id": "guid",
            "name": "string",
            "description": "string",
            "numbertumble": "guid",
            "brandId": "guid"
        }
    ]
```

### POST /brand

> Cadastra uma marca.


**Exemplo post**

```json
    {
        "name": "string"
    }
```

**Exemplo retorno**

```json
    {
        "success": "true",
        "data": {
            "id": "guid",
            "name": "string"
        }
    }
    
```

### PUT /brand

> Atualiza uma marca.

**Exemplo post**

```json
    {
        "id": "guid",
        "name": "string"
    }
```

**Exemplo retorno**

```json
    {
        "success": "true",
        "data": {
            "id": "guid",
            "name": "string"
        }
    }
    
```

### DELETE /brand/id

> Remove uma marca pelo id.

**Argumentos**

| Argumento | Tipo    |
|-----------|---------|
|`id`       | *guid*  |  


**Exemplo retorno**

```json
    {
        "success": "true",
        "data": null
    }
```


## Authors

| ![Jhones Gonçalves](https://avatars2.githubusercontent.com/u/23177787?s=400&u=21bdafe4c1b9da7c42b78d7269df068771299f0b&v=4)|
|:---------------------:|
|  [Jhones Gonçalves](https://github.com/jhonesgoncal/)   |


