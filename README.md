# 3D Dungeon RPG: State-Driven Architecture

[🇺🇸 English](#english) | [🇹🇷 Türkçe](#türkçe)

---

<a name="english"></a>
## English

This is a **3D Dungeon RPG** project developed in Unity, focusing on advanced architectural patterns and performance-oriented programming. The core of the game is built around a robust **Hierarchical State Machine** and decoupled systems using **Dependency Injection**.

### 🏗 Technical Highlights

* **Advanced State Machine:** Character and enemy behaviors are managed using an `IState` interface. It utilizes inheritance (e.g., `BaseState` to `GroundedState`) to manage complex hierarchical transitions cleanly.
* **Dependency Injection (Zenject):** All systems and dependencies are bound via Zenject to ensure loose coupling and high testability.
* **Asynchronous Programming (UniTask):** High-performance async/await operations are handled using UniTask, replacing traditional coroutines for better memory management and readability.
* **Data-Driven Design:** Character stats, enemy configurations, and game data are managed via **ScriptableObjects**, allowing for easy balancing and modularity.
* **Tweening & Feedback (DOTween):** Visual polish, such as smooth health bar transitions and UI animations, is implemented using DOTween for a high-quality feel.

### 🛠 Tech Stack
* **Engine:** Unity 2022.x+
* **Dependency Injection:** Zenject / Extenject
* **Async Logic:** UniTask
* **Animation/Tweening:** DOTween
* **Design Patterns:** State Pattern, Factory Pattern, Data-Driven Design

---

<a name="türkçe"></a>
## Türkçe

Bu proje, gelişmiş mimari desenler ve performans odaklı programlama prensipleri kullanılarak geliştirilmiş bir **3D Dungeon RPG** çalışmasıdır. Oyunun temeli, güçlü bir **Hiyerarşik Durum Makinesi (State Machine)** ve **Bağımlılık Enjeksiyonu (DI)** ile birbirinden ayrılmış (decoupled) sistemler üzerine kurulmuştur.

### 🏗 Teknik Özellikler

* **Gelişmiş State Machine:** Karakter ve düşman davranışları `IState` arayüzü ile yönetilmektedir. `BaseState` üzerinden türetilen (örn: `GroundedState`) kalıtım yapısı sayesinde karmaşık durum geçişleri temiz bir yapıda tutulmuştur.
* **Zenject (Dependency Injection):** Tüm sistemler ve sınıflar arası bağlamalar Zenject ile yapılarak kodun esnekliği ve test edilebilirliği artırılmıştır.
* **Asenkron Programlama (UniTask):** Performans odaklı asenkron işlemler için UniTask kullanılmıştır. Geleneksel Coroutine yapısı yerine modern async/await yapısı tercih edilerek bellek yönetimi optimize edilmiştir.
* **Data-Driven Tasarım:** Oyuncu ve düşman verileri **ScriptableObject**'ler ile yönetilmektedir. Bu sayede oyun dengesi kod değiştirmeden kolayca ayarlanabilmektedir.
* **Animasyon ve Geri Bildirim (DOTween):** Can barının yavaşça azalması gibi görsel detaylar ve arayüz animasyonları DOTween kullanılarak akıcı hale getirilmiştir.

### 🛠 Kullanılan Teknolojiler
* **Oyun Motoru:** Unity 2022.x+
* **Dependency Injection:** Zenject / Extenject
* **Asenkron Yapı:** UniTask
* **Animasyon:** DOTween
* **Tasarım Desenleri:** State Pattern, Factory Pattern, Data-Driven Design