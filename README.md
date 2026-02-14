\# ZenBlog - .NET 9 Clean Architecture API



ZenBlog, modern yazılım geliştirme prensipleriyle tasarlanmış, \*\*Onion (Clean) Architecture\*\* yapısına sahip, ölçeklenebilir bir Backend RESTful API projesidir. Bu proje, spagetti kod yapısından uzak, test edilebilir ve sürdürülebilir bir mimari sunar.



\## 🚀 Proje Hakkında

Bu proje, kurumsal düzeyde bir uygulama geliştirme standartlarını hedefler. \*\*.NET 9\*\* ekosisteminin en güncel özellikleri kullanılarak, güvenli ve performanslı bir altyapı kurulmuştur.



\## 🛠️ Temel Özellikler ve Mimari

Projede kullanılan teknolojiler ve tasarım desenleri şunlardır:



\- \*\*🏗️ Onion / Clean Architecture:\*\*

&nbsp; - Kodun katmanlara ayrılarak bağımlılıkların yönetildiği yapı.

&nbsp; - Core, Infrastructure ve Presentation katmanları ile tam modülerlik.



\- \*\*🔄 Mediator Design Pattern (MediatR):\*\*

&nbsp; - \*\*CQRS (Command Query Responsibility Segregation)\*\* altyapısı.

&nbsp; - Nesneler arası sıkı bağımlılığı (coupling) azaltan, merkezi iletişim yönetimi.



\- \*\*🔒 Güvenlik (Authentication \& Authorization):\*\*

&nbsp; - \*\*ASP.NET Core Identity\*\* kütüphanesi ile kullanıcı yönetimi.

&nbsp; - \*\*JWT (JSON Web Token)\*\* tabanlı güvenli kimlik doğrulama.

&nbsp; - Rol bazlı yetkilendirme (Role-based Authorization) ile endpoint güvenliği.



\- \*\*💾 Veri Yönetimi:\*\*

&nbsp; - \*\*Entity Framework Core\*\* ile Code-First yaklaşımı.

&nbsp; - SQL veritabanı işlemleri ve optimizasyonu.



\- \*\*🌐 API Standartları:\*\*

&nbsp; - RESTful mimariye uygun endpoint tasarımı.

&nbsp; - Standart HTTP durum kodları ve hata yönetimi.



\## 📂 Proje Gereksinimleri

\- .NET 9 SDK

\- SQL Server (veya geliştirme aşamasında LocalDB)

\- Visual Studio 2022 / VS Code




