# 🎯 **Task Manager System**

<div align="center">

![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-Server-blue?style=for-the-badge&logo=blazor)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-red?style=for-the-badge&logo=microsoft-sql-server)

**Sistema de Gerenciamento de Tarefas Moderno e Elegante**

*Desenvolvido com .NET 10, Blazor Server e Entity Framework Core*

[🚀 Como Executar](#-como-executar) • [📋 Funcionalidades](#-funcionalidades) • [🏗️ Arquitetura](#️-arquitetura) • [📱 Screenshots](#-screenshots)

</div>

---

## 📖 **Sobre o Projeto**

O **Task Manager System** é uma aplicação web completa para gerenciamento de tarefas, desenvolvida com as mais modernas tecnologias .NET. O sistema oferece uma interface elegante e intuitiva para criar, organizar e acompanhar tarefas pessoais ou profissionais.

### ✨ **Características Principais**
- 🎨 **Interface Moderna**: Design elegante com tema escuro corporativo
- 📱 **Responsivo**: Funciona perfeitamente em desktop, tablet e mobile
- ⚡ **Performance**: Arquitetura otimizada com Blazor Server
- 🔧 **Modular**: Estrutura Clean Architecture bem organizada
- 💾 **Persistência**: Banco de dados SQL Server LocalDB
- 🎯 **CRUD Completo**: Todas as operações de gerenciamento

---

## 🏗️ **Arquitetura**

O projeto segue os princípios da **Clean Architecture** e está organizado em camadas bem definidas:

```
TaskManagerSystem/
├── 📁 TaskManager.Core/          # Entidades e Interfaces
│   ├── Entities/                 # Modelos de domínio
│   └── Interfaces/               # Contratos dos repositórios
├── 📁 TaskManager.Infrastructure/ # Implementações e Dados
│   ├── Data/                     # Contexto do Entity Framework
│   └── Repositories/             # Implementação dos repositórios
├── 📁 TaskManager.API/           # API REST
│   └── Controllers/              # Controladores da API
└── 📁 TaskManager.Web/           # Interface Blazor
    ├── Components/               # Componentes Blazor
    └── Services/                 # Serviços de comunicação
```

### 🛠️ **Tecnologias Utilizadas**

| Camada | Tecnologia | Versão |
|--------|------------|--------|
| **Frontend** | Blazor Server | .NET 10 |
| **Backend** | ASP.NET Core Web API | .NET 10 |
| **Banco de Dados** | SQL Server LocalDB | - |
| **ORM** | Entity Framework Core | .NET 10 |
| **UI Framework** | Bootstrap 5 | 5.3.2 |
| **Ícones** | Bootstrap Icons | 1.11.3 |
| **Linguagem** | C# | 12.0 |

---

## 🚀 **Como Executar**

### 📋 **Pré-requisitos**

Certifique-se de ter instalado:
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/) ou [VS Code](https://code.visualstudio.com/)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

### 🔧 **Instalação e Configuração**

1. **Clone o repositório**
```bash
git clone https://github.com/0LOTERIO1/task-manager-system.git
cd task-manager-system
```

2. **Restaure as dependências**
```bash
dotnet restore
```

3. **Execute o projeto**
```bash
# Terminal 1 - API
dotnet run --project TaskManager.API

# Terminal 2 - Web App
dotnet run --project TaskManager.Web
```

4. **Acesse a aplicação**
- **Web App**: http://localhost:5098
- **API**: http://localhost:5000

### 🎯 **Execução Rápida**

```bash
# Compilar tudo
dotnet build

# Executar API em background
start dotnet run --project TaskManager.API

# Executar Web App
dotnet run --project TaskManager.Web
```

---

## 📋 **Funcionalidades**

### 🏠 **Dashboard**
- **Visão Geral**: Estatísticas de tarefas (total, concluídas, pendentes)
- **Categorias e Tarefas**: Visualização organizada por categoria
- **Interface Intuitiva**: Cards informativos com design moderno

### ✅ **Gerenciamento de Tarefas**
- ➕ **Criar Tarefas**: Título, descrição, prioridade, categoria, data de vencimento
- ✏️ **Editar Tarefas**: Modificar qualquer campo da tarefa
- ✅ **Concluir/Desmarcar**: Alternar status de conclusão
- 🗑️ **Excluir Tarefas**: Remoção com confirmação
- 🎨 **Visualização**: Cards elegantes com cores e ícones

### 🏷️ **Gerenciamento de Categorias**
- ➕ **Criar Categorias**: Nome e cor personalizada
- ✏️ **Editar Categorias**: Modificar nome e cor
- 🗑️ **Excluir Categorias**: Remoção com confirmação
- 📊 **Contador**: Quantidade de tarefas por categoria

### 🎨 **Interface e UX**
- **Tema Escuro**: Design corporativo elegante
- **Responsivo**: Funciona em todos os dispositivos
- **Animações**: Transições suaves e feedback visual
- **Navegação**: Sidebar intuitiva com "Gerenciamento"

---

## 📱 **Screenshots**

### 🏠 Dashboard
![Dashboard](https://via.placeholder.com/800x400/1a1a1a/ffffff?text=Dashboard+Moderno)

### ✅ Gerenciamento de Tarefas
![Tarefas](https://via.placeholder.com/800x400/2d2d2d/ffffff?text=Interface+de+Tarefas)

### 🏷️ Categorias
![Categorias](https://via.placeholder.com/800x400/1a1a1a/ffffff?text=Gerenciamento+de+Categorias)

---

## 🔧 **Desenvolvimento**

### 📁 **Estrutura de Arquivos**

```
TaskManager.Web/Components/
├── 📁 Layout/
│   ├── MainLayout.razor         # Layout principal
│   └── NavMenu.razor           # Menu de navegação
├── 📁 Pages/
│   ├── Home.razor              # Dashboard
│   ├── Tasks.razor             # Gerenciamento de tarefas
│   └── Categories.razor        # Gerenciamento de categorias
└── App.razor                   # Configurações globais
```

### 🎨 **Customização de Estilos**

O sistema utiliza CSS personalizado para:
- **Tema escuro corporativo**
- **Gradientes e sombras**
- **Animações de hover**
- **Responsividade**

### 🔌 **API Endpoints**

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/tasks` | Listar todas as tarefas |
| `POST` | `/api/tasks` | Criar nova tarefa |
| `PUT` | `/api/tasks/{id}` | Atualizar tarefa |
| `DELETE` | `/api/tasks/{id}` | Excluir tarefa |
| `GET` | `/api/categories` | Listar todas as categorias |
| `POST` | `/api/categories` | Criar nova categoria |
| `PUT` | `/api/categories/{id}` | Atualizar categoria |
| `DELETE` | `/api/categories/{id}` | Excluir categoria |

---

## 🚀 **Deploy**

### 🌐 **Deploy Local**
```bash
# Publicar para produção
dotnet publish TaskManager.Web -c Release -o ./publish

# Executar versão publicada
dotnet ./publish/TaskManager.Web.dll
```

### ☁️ **Deploy em Nuvem**
- **Azure**: Azure App Service + SQL Database
- **AWS**: Elastic Beanstalk + RDS
- **Docker**: Containerização completa

---

## 🤝 **Contribuição**

Contribuições são sempre bem-vindas! Para contribuir:

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

---

## 📄 **Licença**

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👨‍💻 **Desenvolvedor**

**Pedro Loterio** - Desenvolvedor .NET

- 🌐 GitHub: [@0LOTERIO1](https://github.com/0LOTERIO1)
- 💼 LinkedIn: [Pedro Loterio](https://www.linkedin.com/in/pedroloterio)
- 📧 Email: loterio.fiap@gmail.com

---

## 🙏 **Agradecimentos**

- [Microsoft](https://microsoft.com) pelo .NET e Blazor
- [Bootstrap](https://getbootstrap.com) pelo framework CSS
- [Bootstrap Icons](https://icons.getbootstrap.com) pelos ícones

---

<div align="center">

**⭐ Se este projeto te ajudou, não esqueça de dar uma estrela! ⭐**

![Made with ❤️](https://img.shields.io/badge/Made%20with-❤️-red?style=for-the-badge)

</div>