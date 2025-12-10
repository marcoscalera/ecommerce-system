# 🛒 TechStore – Sistema de E-commerce Fullstack

Este projeto é um sistema de E-commerce completo, desenvolvido para demonstrar a aplicação prática de Padrões de Projeto (Design Patterns) do Gang of Four (GoF).  
Backend em **.NET 8**, frontend em **Angular 17+**.

---

## 🚀 Tecnologias Utilizadas

### **Backend (API)**
- C# / .NET 8  
- ASP.NET Core Web API  
- Entity Framework Core  
- SQLite  
- Swagger / OpenAPI  

### **Frontend (SPA)**
- Angular 17+  
- TypeScript  
- Bootstrap 5  
- SCSS  
- RxJS  

---

## 🧠 Padrões de Projeto Implementados

### **Strategy**  
Usado para cálculo de frete e métodos de pagamento.

### **Decorator**  
Usado para adicionar serviços extras (ex.: garantia estendida, embalagem especial).

### **Factory**  
Criação controlada de objetos relacionados a frete e pagamento.

### **Repository**  
Abstração do acesso ao banco de dados.

---

## 📂 Estrutura do Projeto

```bash
ecommerce-system/
├── backend/
│   └── EcommerceSystem/
│       ├── Controllers/
│       ├── Patterns/
│       ├── Services/
│       ├── Repositories/
│       └── Models/
└── frontend/
    └── src/
        ├── app/
        │   ├── components/
        │   ├── services/
        │   └── models/
```

---

## 🛠️ Como Rodar o Projeto

### **1️⃣ Clonar repositório**
```bash
git clone https://github.com/SEU_USUARIO/ecommerce-system.git
cd ecommerce-system
```

---

### **2️⃣ Rodar o Backend**
```bash
cd backend/EcommerceSystem
dotnet restore
dotnet run
```

API disponível em:  
🔗 http://localhost:5004  
Swagger:  
🔗 http://localhost:5004/swagger  

---

### **3️⃣ Rodar o Frontend**
```bash
cd ../../frontend
npm install
ng serve
```

Aplicação Angular em:  
🔗 http://localhost:4200  

---

## ✅ Funcionalidades Incluídas

- Catálogo de produtos  
- Carrinho de compras  
- Cálculo de frete (Strategy)  
- Serviços adicionais (Decorator)  
- Checkout completo  
- API REST integrada com Angular  
