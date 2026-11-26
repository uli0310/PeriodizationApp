# 🏋️‍♂️ Odysseus — Science-Based Periodization & Workout Tracker (.NET 10 + Blazor WASM)

**Odysseus (`PeriodizationApp`)** es una plataforma Full-Stack de periodización, autorregulación y seguimiento de fuerza e hipertrofia basada en evidencia científica, construida con **.NET 10**, **ASP.NET Core Web API**, **Blazor WebAssembly (PWA)**, **MudBlazor** y **Entity Framework Core con PostgreSQL**.

---

## 🚀 Arquitectura e Ingeniería de Software

El proyecto implementa los principios de **Clean Architecture** y **Domain-Driven Design (DDD)** separados en 4 capas desacopladas:

- **`PeriodizationApp.Core` (Dominio):**
  - Entidades de negocio puras (`User`, `Mesocycle`, `WorkoutSession`, `Exercise`, `SetRecord`) y contratos de repositorios (`IUserRepository`, `IMesocycleRepository`, `IWorkoutSessionRepository`, `IExerciseRepository`, `ISetRecordRepository`).
  - Lógica de dominio encapsulada para el cálculo de **1RM Estimado (`e1RM`) ajustado por RIR** mediante un modelo híbrido **Epley + Brzycki**.
- **`PeriodizationApp.Infrastructure` (Persistencia y Datos):**
  - Implementación de `ApplicationDbContext` con **Entity Framework Core 10** y proveedor **Npgsql (PostgreSQL)**.
  - Sembrado automatizado (*Data Seeding*) de **51+ ejercicios clasificados biomecánicamente** por agonistas primarios, sinergistas secundarios y patrón articular (`Compuesto` vs `Aislamiento`).
  - Integridad referencial configurada (`DeleteBehavior.SetNull` en registros históricos para preservar récords de fuerza al archivar o eliminar bloques de entrenamiento).
- **`PeriodizationApp.Api` (Backend RESTful):**
  - Controladores REST (`UsersController`, `MesocycleController`, `WorkoutSessionsController`, `ExercisesController`, `SetRecordsController`) con inyección de dependencias, serialización protegida contra referencias circulares (`ReferenceHandler.IgnoreCycles`) y política CORS multi-dispositivo.
  - Autenticación y registro multi-usuario con hashing criptográfico `SHA-256` y gestión segura de credenciales mediante **`.NET User Secrets`**.
- **`PeriodizationApp.Client` (Frontend SPA / PWA):**
  - Aplicación interactiva en **Blazor WebAssembly** con **MudBlazor v9** (Modo Oscuro) y visualización de datos con **ApexCharts**.
  - Detección dinámica de red (`localhost` en escritorio y acceso directo en red local LAN/Wi-Fi desde dispositivos móviles) y barra de navegación inferior estilo aplicación nativa.

---

## 🔬 Funcionalidades Clave y Ciencia del Entrenamiento

1. **Consola de Entrenamiento en Vivo (UX Estilo Hevy):**
   - Tarjetas apiladas por ejercicio con columna **`ANTERIOR`** en tiempo real, clasificación de series interactiva (**`W` Calentamiento**, **`1-N` Serie Efectiva**, **`F` Fallo Muscular**, **`D` Drop Set**) y marcado rápido con casilla **`✓`**.
   - **Algoritmo de Sobrecarga Progresiva y Doble Progresión:** Analiza el último `ActualRIR` del atleta para prescribir automáticamente incrementos de carga (`+2.5 kg` en compuestos, `+1.25 kg` en aislados) o incremento de repeticiones.
   - **Detector de Récords Personales (`🏆 ¡NUEVO PR!`) en Vivo** y tarjeta resumen al finalizar la sesión (*Duración, Tonelaje Total Movido y PRs rotos*).
   - **Calculadora Visual de Discos Olímpicos (*Plate Calculator*):** Desglose gráfico por lado de la barra con código de colores olímpico oficial (`25 kg` a `1.25 kg`).
   - **Cronómetro Biomecánico de Descanso Automático:** Asigna `3:00 min` en ejercicios compuestos (resíntesis de ATP-PCr y recuperación del SNC), `1:30 min` en aislamiento y `1:00 min` en series de calentamiento.

2. **Dashboard Analítico de Fuerza y Volumen Fraccional:**
   - **Contabilidad de Volumen Fraccional (`1.0` Agonista Primario / `0.5` Sinergista Secundario):** Basado en meta-regresiones modernas (*Pelland et al., 2024*), filtrando exclusivamente **Series Efectivas ($\text{RIR} \le 4$)** (*Robinson et al., 2024*).
   - **Semáforo MEV / MAV / MRV y Gráfica Radar (Hexágono de Balance Muscular):** Visualización del equilibrio entre `Pecho`, `Espalda`, `Pierna`, `Hombro`, `Bíceps` y `Tríceps` junto con curvas históricas de evolución de `e1RM`.

3. **Recomendador de Rutinas y Periodización de Bloques:**
   - Prescripción interactiva de esquemas de **2 a 6 días** (*Full Body*, *Upper/Lower/Full Body*, *Upper/Lower*, *Upper/Lower/PPL*, *PPL x2*) con progresión automática de `Target RIR` por semana (`Semana 1: RIR 3` → `Semana 5: RIR 0-1 Overreaching` → `Semana 6: Descarga / Deload`) y paneles desplegables de **justificación científica revisada por pares**.

---

## 🛠️ Configuración y Ejecución Local

1. **Configurar cadena de conexión en PostgreSQL (usando `.NET User Secrets`):**
   ```powershell
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=PeriodizationDb;Username=postgres;Password=TU_PASSWORD" --project PeriodizationApp.Api
   ```
2. **Aplicar migraciones de Entity Framework Core:**
   ```powershell
   dotnet ef database update --project eriodizationApp.Infrastructure --startup-project PeriodizationApp.Api
   ```
3. **Levantar API y Cliente Blazor:**
   ```powershell
   dotnet run --project PeriodizationApp.Api --launch-profile https
   dotnet run --project PeriodizationApp.Client --launch-profile https
   ```
