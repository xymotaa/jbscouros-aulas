# JBS Aulas — Portal Corporativo de Vídeos

Portal interno de treinamentos e comunicação corporativa da **JBS S.A.**, desenvolvido em **ASP.NET Core MVC (.NET 10)**.  
Permite que colaboradores acessem vídeos de treinamento, eventos, reuniões e materiais de compliance de forma centralizada.

---

## Índice

- [Visão Geral](#visão-geral)
- [Tecnologias](#tecnologias)
- [Requisitos](#requisitos)
- [Instalação e Execução](#instalação-e-execução)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Arquitetura](#arquitetura)
- [Rotas](#rotas)
- [Identidade Visual](#identidade-visual)
- [Melhorias Futuras](#melhorias-futuras)

---

## Visão Geral

O **JBS Aulas** é um portal web corporativo que centraliza vídeos institucionais categorizados por tipo de conteúdo. As funcionalidades atuais incluem:

- Listagem dos vídeos em grade com filtro por categoria
- Player de vídeo com thumbnail e overlay de play
- Sugestões de vídeos relacionados na página de visualização
- Design responsivo seguindo a identidade visual JBS

---

## Tecnologias

| Camada | Tecnologia |
|---|---|
| Framework | ASP.NET Core MVC — .NET 10 |
| Linguagem | C# 13 |
| Views | Razor Pages (`.cshtml`) |
| CSS utilitário | Tailwind CSS (via CDN) |
| Ícones | Lucide Icons (via CDN) |
| Fonte | Inter — Google Fonts |
| IDE recomendada | Visual Studio 2022 / VS Code |

---

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) ou superior
- Navegador moderno com suporte a Tailwind CSS

> Não há banco de dados ou dependências externas. O catálogo de vídeos está em memória no `HomeController`.

---

## Instalação e Execução

```bash
# 1. Clone o repositório
git clone <url-do-repositorio>
cd jbscouros-aulas

# 2. Restaure os pacotes
dotnet restore

# 3. Execute em modo desenvolvimento
dotnet run
```

Acesse em: `https://localhost:5001` ou `http://localhost:5000`

Para executar com hot reload:

```bash
dotnet watch run
```

Para gerar o build de produção:

```bash
dotnet publish -c Release -o ./publish
```

---

## Estrutura do Projeto

```
jbscouros-aulas/
├── Controllers/
│   └── HomeController.cs          # Controller principal — catálogo e roteamento
├── Models/
│   ├── VideoViewModel.cs          # Model de um vídeo (id, título, duração, categoria...)
│   ├── WatchViewModel.cs          # Model da tela Watch (vídeo atual + sugestões)
│   └── ErrorViewModel.cs          # Model da tela de erro padrão ASP.NET
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Página inicial — grade de vídeos com filtros
│   │   ├── Watch.cshtml           # Página de visualização do vídeo
│   │   └── Privacy.cshtml         # Página de política de privacidade
│   ├── Shared/
│   │   ├── _LayoutJBS.cshtml      # Layout base compartilhado (JBS Aulas)
│   │   ├── _HeaderJBS.cshtml      # Partial view do cabeçalho corporativo
│   │   ├── _Layout.cshtml         # Layout padrão ASP.NET (mantido por compatibilidade)
│   │   └── Error.cshtml           # Tela de erro
│   ├── _ViewImports.cshtml        # Imports globais de namespaces e Tag Helpers
│   └── _ViewStart.cshtml          # Define layout padrão das views
├── wwwroot/
│   ├── css/
│   │   └── site.css               # Estilos globais — scrollbar, clamp, player
│   └── js/
│       └── site.js                # Scripts globais
├── appsettings.json               # Configurações da aplicação
├── appsettings.Development.json   # Configurações de ambiente de desenvolvimento
├── Program.cs                     # Entry point — configuração do pipeline HTTP
└── jbscouros-aulas.csproj         # Definição do projeto .NET
```

---

## Arquitetura

O projeto segue o padrão **MVC (Model-View-Controller)** do ASP.NET Core.

```
Request HTTP
    │
    ▼
HomeController
    ├── Index()  → IEnumerable<VideoViewModel>  → Index.cshtml
    └── Watch(id) → WatchViewModel              → Watch.cshtml
                        ├── Video: VideoViewModel
                        └── Suggestions: IReadOnlyList<VideoViewModel>
```

### Models

| Model | Descrição |
|---|---|
| `VideoViewModel` | Representa um vídeo: `Id`, `Title`, `Duration`, `ThumbnailUrl`, `Category`, `Description`, `PublishDate` |
| `WatchViewModel` | Agrega o vídeo em exibição (`Video`) e a lista de sugestões (`Suggestions`) |

### Views

| View | Layout | Model |
|---|---|---|
| `Index.cshtml` | `_LayoutJBS` | `IEnumerable<VideoViewModel>` |
| `Watch.cshtml` | `_LayoutJBS` | `WatchViewModel` |

### Partial Views

| Partial | Descrição |
|---|---|
| `_HeaderJBS.cshtml` | Cabeçalho com logo, campo de busca e identidade visual JBS |

---

## Rotas

| Método | URL | Action | Descrição |
|---|---|---|---|
| `GET` | `/` | `Home/Index` | Listagem de todos os vídeos |
| `GET` | `/Home/Index` | `Home/Index` | Listagem de todos os vídeos |
| `GET` | `/Home/Watch?id={n}` | `Home/Watch` | Visualização do vídeo de id `n` |
| `GET` | `/Home/Privacy` | `Home/Privacy` | Política de privacidade |

---

## Identidade Visual

A interface segue a paleta de cores corporativa da **JBS**:

| Cor | Hex | Uso |
|---|---|---|
| Azul escuro | `#2E2F86` | Header / Navbar |
| Azul | `#1E6FD2` | Botões principais, play, hover |
| Azul claro | `#46C1E6` | Destaques e bordas interativas |
| Verde | `#9EDB00` | Tags de categoria |
| Texto principal | `#1A1A2E` | Títulos e corpo de texto |
| Fundo | `#F4F6F9` | Background da aplicação |

Fonte tipográfica: **Inter** (Google Fonts) — pesos 400, 700 e 900.

---

## Melhorias Futuras

- [ ] Migrar o catálogo de vídeos para banco de dados (ex: SQL Server + Entity Framework Core)
- [ ] Criar interface `IVideoService` e injetar via DI no controller
- [ ] Implementar autenticação com Azure AD / Identity para controle de acesso por setor
- [ ] Integrar player real (iframe YouTube/Vimeo ou tag `<video>` com MP4)
- [ ] Adicionar paginação na listagem de vídeos
- [ ] Implementar busca funcional no campo do header
- [ ] Criar painel administrativo para cadastro de novos vídeos

---

## Licença

Uso interno JBS S.A. — todos os direitos reservados.
