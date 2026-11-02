# ClínicaFácil — Gestão de Consultas, Prontuário Fotográfico e Controle de Retornos

Aplicação web interativa e implementação de referência em **C# (ASP.NET Core MVC - .NET 8)** com persistência em **SQLite (`clinica.db`)**, desenhada para execução enxuta em apresentações e no **Google Colab**.

---

## Escopo do Projeto (6 Entregas Principais)

1. **Criação de Cliente:** Cadastro rápido de pacientes na recepção (Nome, Telefone/WhatsApp e CPF).
2. **Registro de Procedimento:** Lançamento do atendimento clínico vinculado à chave estrangeira (`ClienteId`) do paciente, data de realização, data prevista de retorno e evolução clínica.
3. **Upload de Fotos:** Anexação de fotografia clínica de acompanhamento (Antes/Depois) convertida em `Base64` (`IFormFile` -> `MemoryStream` -> `FotoBase64`) e gravada diretamente no banco SQLite.
4. **Listagem de Histórico:** Prontuário visual com busca textual, filtro por paciente e modal para inspeção ampliada das fotos clínicas.
5. **Visualização do Painel de Retornos:** Dashboard operacional com indicadores automáticos (**Atrasados / Urgentes**, **Agendados / Próximos** e **Retornos Concluídos**) e baixa de comparecimento em 1 clique.
6. **Persistência de Dados no Banco (SQLite):** Armazenamento relacional em arquivo único (`clinica.db`) gerenciado via Entity Framework Core (`AppDbContext` + `db.Database.EnsureCreated()`).

---

## Estrutura de Arquivos do Repositório

```text
├── index.html                        # Página principal (Landing Page + Plataforma Operacional Ao Vivo)
├── styles.css                        # Folha de estilos customizada da interface
├── app.js                            # Lógica do simulador MVC, banco persistente e snippets C#
├── assets/
│   └── hero-clinica.jpg              # Ilustração principal da seção Hero
├── docs/
│   └── breakdown_mvc_clinicafacil.txt # Detalhamento arquitetural completo (Fluxo M -> V -> C)
└── src-csharp-mvc/                   # Código-fonte C# ASP.NET Core MVC (.NET 8 + SQLite)
    ├── ClinicaMvc.csproj             # Manifesto do projeto .NET 8 com pacotes EF Core SQLite
    ├── Program.cs                    # Inicialização da aplicação e criação automática do clinica.db
    ├── Models/
    │   └── AppDbContext.cs           # Entidades Cliente, Procedimento e contexto SQLite
    ├── Controllers/
    │   └── ClinicaController.cs      # Rotas Index, CriarCliente, RegistrarProcedimento e AlternarRetorno
    └── Views/
        └── Clinica/
            └── Index.cshtml          # View Razor unificada da clínica
```

