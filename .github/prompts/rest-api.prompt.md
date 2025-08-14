# Istruzioni per implementare il progetto rest-api 

1. Utilizza il modello Minimal API di .NET 9 per implementare le API.
2. Devi obbigatoriamente utilizzare i template che trovi all'indirizzo https://github.com/BrewUp/CrastuArrustutu. Non usare il template di default di .NET 9.
   - Il template CrastuArrustutu.Rest è un progetto di esempio che mostra come implementare un'API RESTful utilizzando un modello custom Minimal API.  
   - Il progetto CrastuArrustutu.Rest include già le configurazioni necessarie per OpenAPI, Swagger e OpenTelemetry e altro. Usale.
   - Il progetto CrastuArrustutu.Rest include anche le configurazioni per la gestione della documentazione e delle metriche. Usale.
   - Il template CrastuArrustutu.Rest contiene un'interfaccia IModule che devi utilizzare nei moduli, così come devi usare le classi e le interfacce già presenti.
   - Il template CrastuArrustutu.Rest contiene anche un OpenApiModule e un OpenTelemetryModule che devi usare per esporre la documentazione OpenAPI e le metriche di monitoraggio.
   - Il template CrastuArrustutu.Rest contiene ModuleExtensions che contiene i metodi per registrare i moduli.
   - Il template CrastuArrustutu.Rest contiene il file program.cs così come deve essere nella soluzione finale.
   - Il template CrastuArrustutu.Rest contiene anche un esempio di come implementare i Facade per esporre gli endpoints.
   - Tutti i progetti presenti nel repository hanno come prefisso "CrastuArrustutu", ma tu devi usare il prefisso "SpiedoBresciano" per i tuoi progetti.
3. Nel progetto prepara i moduli, che implementano IModule, MacelleriaModule e TrattoriaModule, per gestire i Bounded Context di macellazione e trattoria.
4. Nei moduli Facade prepara le classi per esporre gli endpoints come da esempio nei progetti Cannizzaro/CrastuArrustutu.Cannizzaro.Facade e Tannura/CrastuArrustutu.Tannura.Facade.
   - Le classi Facade devono implementare le interfacce IMacelleriaFacade e ITrattoriaFacade.
   - Nei progetti Facade prepara anche le classi per registrare i servizi e le dipendenze necessarie come estensioni di IServiceCollection e come da esempio che trovi nei progetti Facade nel repository.
   - Non dimenticare di registrare i servizi nei metodi Register() dei moduli.
5. Suddivi la solution in diversi progetti, suddivisi per solution folder. I solution folder non sono cartelle fisiche nel file system, ma sono una struttura logica per organizzare i progetti nella soluzione. Le uniche cartelle fisiche sono quelle dei moduli Macelleria e Trattoria. Segui l'organizzazione della solution come da esempio che trovi nel repository CrastuArrustutu:
   - Solution Folder 90:
     - Un solo progetto per la parte rest API.
      - Il progetto rest deve esporre la documentazione OpenAPI e Swagger sempre rispettando il template, quindi inserendo il codice in un OpenApiModule
      - Deve esporre le metriche di monitoraggio compatibili con OpenTelemetry tramite un OpenTelemetryModule.
      - Deve avere dipendenze verso i moduli Macelleria e Trattoria solo tramite i rispettivi progetti Facade.
      - Quando implementi le classi MacelleriaModule e TrattoriaModule, assicurati che i metodi per esporre gli endpoints implementino l'interfaccia IModule che trovi nel template indicato e che rispettino le convenzioni di naming e struttura del progetto. Inoltre devono invocare i metodi esposti dai rispettivi progeti Facade per registrare endpoints e dipendenze.
     - SpiedoBresciano.Tests: per i test di integrazione.
   - Solution Folder 80:
     - SpiedoBresciano.Infrastructure: per l'accesso ai dati e le implementazioni dei repository.
   - Solution Folder 50:
   - Dentro questo solution folder devi creare un solution folder per ogni modulo (Macelleria e Trattoria).
   - Solution Folder Macelleria:
     - SpiedoBresciano.Macelleria.Facade: per esporre gli endpoints e le interfacce IMacelleriaFacade.
     - SpiedoBresciano.Macelleria.Domain: per le entità e le logiche di dominio.
     - SpiedoBresciano.Macelleria.SharedKernel: per le classi, i tipi custom e le interfacce condivise tra i progetti del modulo Macelleria.
     - SpiedoBresciano.Macelleria.ReadModel: per le classi di ReadModel e le query.
     - SpiedoBresciano.Macelleria.Infrastructure: per l'accesso ai dati e le implementazioni dei repository del modulo Macelleria.
     - SpiedoBresciano.Macelleria.Tests: per i test unitari e architetturali del modulo Macelleria.
    - Solution Folder Trattoria:
     - SpiedoBresciano.Trattoria.Facade: per esporre gli endpoints e le interfacce ITrattoriaFacade.
     - SpiedoBresciano.Trattoria.Domain: per le entità e le logiche di dominio.
     - SpiedoBresciano.Trattoria.SharedKernel: per le classi, i tipi custom e le interfacce condivise tra i progetti del modulo Trattoria.
     - SpiedoBresciano.Trattoria.ReadModel: per le classi di ReadModel e le query.
     - SpiedoBresciano.Trattoria.Infrastructure: per l'accesso ai dati e le implementazioni dei repository del modulo Trattoria.
     - SpiedoBresciano.Trattoria.Tests: per i test unitari e architetturali del modulo Trattoria.
   - Solution Folder 30 Shared:
     - SpiedoBresciano.Shared: per le classi, i tipi custom e le interfacce condivise tra i progetti della solution.
    
  6. In questa fase non creare Enitità, Repository o servizi specifici per i moduli Macelleria e Trattoria. Concentrati solo sulla struttura della solution e sull'implementazione dei Facade e dei moduli.
7. Implementa i test di architettura che utilizzano la libreria NetArchTest per verificare il corretto isolamento dei moduli.
  
    