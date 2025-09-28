# CrastuArrustutu - .NET Modular API Template

Un template avanzato per la creazione di API .NET basate su architettura modulare e principi Domain-Driven Design (DDD).

## 🎯 Obiettivo

Questo progetto fornisce una base solida per lo sviluppo rapido di API .NET che seguono:
- **Architettura modulare** con Bounded Context separati
- **Domain-Driven Design (DDD)** patterns e best practices
- **Clean Architecture** con separazione netta dei layer
- **Struttura standardizzata** e scalabile

## 🏗️ Architettura

Il template implementa un'architettura modulare dove ogni modulo rappresenta un Bounded Context del dominio:

```
src/
├── {ProjectName}.Rest/              # API Layer & Composition Root
├── {ProjectName}.Infrastructure/    # Shared Infrastructure
├── {ProjectName}.Shared/           # Shared Kernel
└── {ModuleName}/                   # Bounded Context Module
    ├── {ProjectName}.{ModuleName}.Domain/       # Domain Layer
    ├── {ProjectName}.{ModuleName}.Facade/       # Presentation Layer
    ├── {ProjectName}.{ModuleName}.Infrastructure/# Infrastructure Layer
    ├── {ProjectName}.{ModuleName}.ReadModel/    # Query Models
    ├── {ProjectName}.{ModuleName}.SharedKernel/ # Module Contracts
    └── {ProjectName}.{ModuleName}.Tests/        # Unit Tests
```

## 🚀 Come Utilizzare

### 1. Generazione dello Skeleton

Modifica il file `.github/prompts/rest-api.prompt.md` per definire:
- Nome del progetto
- Moduli necessari (Bounded Contexts)
- Struttura base delle API

Quindi chiedi al tuo AI assistant di generare lo skeleton usando questo prompt.

### 2. Implementazione dei Moduli

Per ogni modulo creato, utilizza i prompt specifici per sviluppare la logica di business:
- `.github/prompts/carnizzaro-module.prompt.md` - Modulo per la gestione delle carni
- `.github/prompts/tannura-module.prompt.md` - Modulo per la gestione del servizio
- `.github/prompts/domain-driven-design.prompt.md` - Linee guida DDD

### 3. Personalizzazione

Adatta i prompt alle tue esigenze specifiche modificando:
- Nomi dei domini e dei moduli
- Logiche di business specifiche
- Integrazioni esterne necessarie

## 📁 Struttura dei Prompt

I prompt sono organizzati in `.github/prompts/` e includono:

| Prompt | Scopo |
|--------|--------|
| `rest-api.prompt.md` | Generazione dello skeleton dell'API |
| `domain-driven-design.prompt.md` | Linee guida per l'applicazione dei pattern DDD |
| `carnizzaro-module.prompt.md` | Implementazione del modulo Carnizzaro |
| `tannura-module.prompt.md` | Implementazione del modulo Tannura |

## 🛠️ Tecnologie

- **.NET 8+** - Framework principale
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM per la persistenza
- **MediatR** - Pattern Mediator per CQRS
- **FluentValidation** - Validazione dei modelli
- **Serilog** - Logging strutturato

## 🎨 Pattern Implementati

### Domain-Driven Design
- **Bounded Context** - Separazione logica dei domini
- **Aggregates** - Consistenza dei dati
- **Domain Events** - Comunicazione asincrona
- **Repository Pattern** - Astrazione della persistenza
- **Value Objects** - Oggetti immutabili senza identità

### Clean Architecture
- **Domain Layer** - Regole di business pure
- **Application Layer** - Casi d'uso e orchestrazione
- **Infrastructure Layer** - Implementazioni concrete
- **Presentation Layer** - API endpoints e presentazione

### CQRS
- **Commands** - Operazioni di scrittura
- **Queries** - Operazioni di lettura
- **Handlers** - Elaborazione separata di comandi e query

## 📖 Esempio d'Uso

1. **Clona il template**
2. **Modifica** `rest-api.prompt.md` con i tuoi requisiti:
   ```markdown
   # Nome Progetto: RistoranteManager
   # Moduli: Cucina, Sala, Magazzino
   ```
3. **Genera lo skeleton** usando l'AI assistant
4. **Implementa i moduli** usando i prompt specifici
5. **Personalizza** la logica di business

## 🤝 Contribuire

Per contribuire al template:
1. Migliora i prompt esistenti
2. Aggiungi nuovi prompt per altri domini
3. Proponi miglioramenti architetturali
4. Condividi esempi d'uso

## 📄 Licenza

Questo progetto è rilasciato sotto licenza MIT. Vedi il file [LICENSE](LICENSE) per i dettagli.

---

**Nota**: Questo è un template per accelerare lo sviluppo di API modulari. Adattalo alle tue esigenze specifiche e migliora i prompt in base alla tua esperienza d'uso.