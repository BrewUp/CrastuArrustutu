# Istruzioni per implementare una nuova API .NET utilizzando un template

## Feature iniziale
1. Utilizza il glossario dei termini per comprendere i concetti chiave che trovi nel file glossario.prompt.md e le direttive su DDD che trovi nel file domain-driven-design.prompt.md.
2. Utilizza il modello Minimal API di .NET 9 per implementare le API.
3. Devi obbigatoriamente utilizzare il template che trovi all'indirizzo https://github.com/BrewUp/CrastuArrustutu. Non usare il template di default di .NET 9.
   - Se non riesci ad accedere al template, prova a clonare il repository.
   - Se non riesci nemmeno a clonare il repository, fermati.
   - Nel template trovi il progetto di esempio `CrastuArrustutu.Rest` che mostra come implementare un'API RESTful utilizzando un modello custom Minimal API.
   - Il progetto di esempio `CrastuArrustutu.Rest` include già le configurazioni necessarie per OpenAPI, Swagger e OpenTelemetry e altro. Usale.
   - Il progetto di esempio `CrastuArrustutu.Rest` include anche le configurazioni per la gestione della documentazione e delle metriche. Usale.
   - Il progetto `CrastuArrustutu.Rest` contiene un'interfaccia `IModule` che devi utilizzare nei moduli, così come devi usare le classi e le interfacce già presenti.
   - Il progetto di esempio `CrastuArrustutu.Rest` contiene anche un OpenApiModule e un OpenTelemetryModule che devi usare per esporre la documentazione OpenAPI e le metriche di monitoraggio.
   - Il progetto di esempio `CrastuArrustutu.Rest` contiene ModuleExtensions che contiene i metodi per registrare i moduli.
   - Il progetto di esempio `CrastuArrustutu.Rest` contiene il file `program.cs` così già pronto per essere utilizzato nella soluzione finale.
   - Il progetto di esempio `CrastuArrustutu.Rest` contiene i file `CarnizzaroModule.cs` e `TannuraModule.cs` che mostrano come invocare i metodi dei rispettivi progetti Facade. Replica il comportamento del template per i nuovi progetti `{SpiedoBresciano}.{Macelleria}.Facade` e `{SpiedoBresciano}.{Trattoria}.Facade`
   - Tutti i progetti di esempio presenti nel template hanno come prefisso `{CrastuArrustutu}`, ma tu devi usare il prefisso `{SpiedoBresciano}` per i tuoi progetti.
   - Mantieni la struttura del progetto `CrastuArrustutu.Rest`, ossia cartella `Modules` e crea i file Module al suo interno.
   - Quando crei un nuovo progetto, rimuovi la classe di default `Class1.cs`
4. Nel progetto Rest della nuova applicazione prepara i file Module (`TrattoriaModule` e `MacelleriaModule`), che implementano `IModule` per gestire i Bounded Context di `macelleria`e `trattoria`.
5. Nei progetti `{SpiedoBresciano}.{Macelleria}.Facade` e `{SpiedoBresciano}.{Trattoria}.Facade` prepara le classi per esporre gli endpoints come nei progetti di esempio `Cannizzaro/CrastuArrustutu.Cannizzaro.Facade` e `Tannura/CrastuArrustutu.Tannura.Facade`.
   - Usa i file `CarnizzaroFacadeHelper` e `TannuraFacadeHelper` come riferimento per implementare i tuoi helper.
   - Usa i file `CarnizzaroEndpoints` e `TannuraEndpoints` come riferimento per implementare i tuoi endpoints.
   - I progetti Facade devono esporre le interfacce `IMacelleriaFacade` e `ITrattoriaFacade`.
6. Suddivi la solution in diversi progetti, suddivisi per solution folder. I solution folder non sono cartelle fisiche nel file system, ma sono una struttura logica per organizzare i progetti nella soluzione. Le uniche cartelle fisiche sono quelle dei moduli Macelleria e Trattoria. Segui l'organizzazione della solution come da esempio che trovi nel repository CrastuArrustutu:
   - Solution Folder `90 Presentation`:
     - Un solo progetto per la parte rest API.
      - Il progetto rest deve esporre la documentazione OpenAPI e Swagger sempre rispettando il template, quindi inserendo il codice in un OpenApiModule
      - Deve esporre le metriche di monitoraggio compatibili con OpenTelemetry tramite un OpenTelemetryModule.
      - Deve avere dipendenze verso i moduli Macelleria e Trattoria solo tramite i rispettivi progetti Facade.
      - Quando implementi le classi MacelleriaModule e TrattoriaModule, assicurati che i metodi per esporre gli endpoints implementino l'interfaccia IModule che trovi nel template indicato e che rispettino le convenzioni di naming e struttura del progetto. Inoltre devono invocare i metodi esposti dai rispettivi progeti Facade per registrare endpoints e dipendenze.
   - Solution Folder `80 Infrastructure`:
     - `SpiedoBresciano.Infrastructure`: per l'accesso ai dati e le implementazioni dei repository.
   - Solution Folder `50 Modules`:
   - Dentro questo solution folder devi creare un solution folder per ogni modulo (Macelleria e Trattoria).
   - Solution Folder `Macelleria`:
     - `SpiedoBresciano.Macelleria.Facade`: per esporre gli endpoints e le interfacce `IMacelleriaFacade`.
     - `SpiedoBresciano.Macelleria.Domain`: per le entità e le logiche di dominio.
     - `SpiedoBresciano.Macelleria.SharedKernel`: per le classi, i tipi custom e le interfacce condivise tra i progetti del modulo Macelleria.
     - `SpiedoBresciano.Macelleria.ReadModel`: per le classi di ReadModel e le query.
     - `SpiedoBresciano.Macelleria.Infrastructure`: per l'accesso ai dati e le implementazioni dei repository del modulo Macelleria.
     - `SpiedoBresciano.Macelleria.Tests`: per i test architetturali del modulo Macelleria.
   - Solution Folder `Trattoria`:
     - `SpiedoBresciano.Trattoria.Facade`: per esporre gli endpoints e le interfacce `ITrattoriaFacade`.
     - `SpiedoBresciano.Trattoria.Domain`: per le entità e le logiche di dominio.
     - `SpiedoBresciano.Trattoria.SharedKernel`: per le classi, i tipi custom e le interfacce condivise tra i progetti del modulo Trattoria.
     - `SpiedoBresciano.Trattoria.ReadModel`: per le classi di ReadModel e le query.
     - `SpiedoBresciano.Trattoria.Infrastructure`: per l'accesso ai dati e le implementazioni dei repository del modulo Trattoria.
     - `SpiedoBresciano.Trattoria.Tests`: per i test architetturali del modulo Trattoria.
   - Solution Folder `30 Shared`:
     - `SpiedoBresciano.Shared`: per le classi, i tipi custom e le interfacce condivise tra i progetti della solution.

7. Non creare Entità, Repository o servizi specifici per i moduli Macelleria e Trattoria. Concentrati solo sulla struttura della solution e sull'implementazione dei Facade e dei moduli.
8. Implementa i test di architettura utilizzando la libreria NetArchTest, presente nei progetti `CrastuArrustutu.Carnizzaro.Tests` e `CrastuArrustutu.Tannura.Tests`, per verificare il corretto isolamento dei moduli.

9. Questa fase è considerata DONE quando:
  - La solution compila (Debug/Release) senza warning critici (idealmente treat warnings as errors).
  - Tutti i test architetturali (NetArchTest) passano.
  - Endpoint di base esposti: `/v1/macelleria`, `/v1/trattoria` (anche vuoti) → HTTP 200/204.
  - Swagger/OpenAPI accessibile (JSON + UI Scalar) e versione valorizzata.
  - Telemetria configurabile (OpenTelemetry module disattivato finché non configurato).
  - README aggiornato con istruzioni run locali.

10. Regole per i Test Architetturali
  - Non ci devono essere dipendenze fra i moduli (es. Nessun progetto di un modulo deve fare riferimento a un progetto di un altro modulo).
  - Il progetto `{SpiedoBresciano.Rest}` deve essere l'unico punto di accesso per le API esterne.
  - Il progetto `{SpiedoBresciano.Rest}` deve avere dipendenze solo con i progetti `Facade` dei moduli `Macelleria` e `Trattoria`.

11. Naming & Convenzioni
- Namespace radice: `SpiedoBresciano.[Modulo].[Strato]`.
- Endpoint group path: `/v1/{modulo}` (versione nel path per semplicità iniziale).
- File Module: `{NomeModulo}Module.cs` implementa `IModule`.
- Interfacce Facade: `IMacelleriaFacade`, `ITrattoriaFacade` (anche vuote inizialmente) in progetto Facade.

12. Versioning API
- Strategia iniziale: path-based (`/v1`).
- Quando si introdurrà `/v2`, duplicare solo endpoints modificati (Backward compatibility).
- OpenAPI Title includa versione maggiore (`SpiedoBresciano API v1`).

13. OpenAPI & Documentazione
- Generare un singolo documento per major version.
- Server URL base `/` per compatibilità reverse proxy.
- Tag: usare il nome del modulo in PascalCase.
- Evitare esposizione tipi interni di dominio: utilizzare DTO nel Facade layer.

14. Logging
- Serilog con sink Console + File (rolling) + livello minimo `Information` (override `Microsoft.*` a `Warning`).
- Correlazione: includere trace/span id se OpenTelemetry attivo.

15. Telemetria (OpenTelemetry)
- Resource Attributes obbligatori: `service.name=SpiedoBrescianoApi`, `service.version=<assemblyVersion>`.
- Attivare modulo impostando `IsEnabled=true`.
- Esportatori minimi: OTLP (futuro) + Azure Monitor.

16. Error Handling
- Standardizzare su `ProblemDetails` (RFC 7807).
- Mappare eccezioni di dominio (future) in 409 / 422 (a seconda dei casi) + codice custom in `problemDetails.Extensions["errorCode"]`.

17. Sicurezza
- Questa API sarà pubblicata su Azure come Container App.
- Prevedere autenticazione e autorizzazione tramite Azure AD.

18. Health & Operatività
- Aggiungere /healthz (liveness) e /ready (readiness) (TODO).
- Metriche OTel automaticamente su `/metrics` se introdotto exporter Prometheus (non ancora richiesto).

19. Summary
- Dopo aver generato la nuova applicazione, formula un giudizio su questo prompt rispetto al risultato ottenuto.
