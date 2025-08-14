# Istruzioni per implementare una nuova API .NET utilizzando un template

1. Utilizza il glossario dei termini per comprendere i concetti chiave che trovi nel file glossario.prompt.md e le direttive su DDD che trovi nel file domain-driven-design.prompt.md.
2. Utilizza il modello Minimal API di .NET 9 per implementare le API.
3. Devi obbigatoriamente utilizzare il template che trovi all'indirizzo https://github.com/BrewUp/CrastuArrustutu. Non usare il template di default di .NET 9.
   - Nel template trovi il progetto di esempio CrastuArrustutu.Rest che mostra come implementare un'API RESTful utilizzando un modello custom Minimal API.
   - Il progetto di esempio CrastuArrustutu.Rest include già le configurazioni necessarie per OpenAPI, Swagger e OpenTelemetry e altro. Usale.
   - Il progetto di esempio CrastuArrustutu.Rest include anche le configurazioni per la gestione della documentazione e delle metriche. Usale.
   - Il progetto CrastuArrustutu.Rest contiene un'interfaccia `IModule` che devi utilizzare nei moduli, così come devi usare le classi e le interfacce già presenti.
   - Il progetto di esempio CrastuArrustutu.Rest contiene anche un OpenApiModule e un OpenTelemetryModule che devi usare per esporre la documentazione OpenAPI e le metriche di monitoraggio.
   - Il progetto di esempio CrastuArrustutu.Rest contiene ModuleExtensions che contiene i metodi per registrare i moduli.
   - Il progetto di esempio CrastuArrustutu.Rest contiene il file `program.cs` così già pronto per essere utilizzato nella soluzione finale.
   - Il progetto di esempio CrastuArrustutu.Rest contiene i file CarnizzaroModule.cs e TannuraModule.cs che mostrano come invocare i metodi dei rispettivi progetti Facade. Replica il comportamento del template per i nuovi progetti `{SpiedoBresciano}.{Macelleria}.Facade` e `{SpiedoBresciano}.{Trattoria}.Facade`
   - Tutti i progetti di esempio presenti nel template hanno come prefisso `{CrastuArrustutu}`, ma tu devi usare il prefisso `{SpiedoBresciano}` per i tuoi progetti.
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
9. Dopo aver generato la nuova applicazione, formula un giudizio su questo prompt rispetto al risultato ottenuto.
