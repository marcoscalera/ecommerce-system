# 🛒 TechStore - Sistema de E-commerce Fullstack

Este projeto é um sistema de E-commerce completo, desenvolvido para demonstrar a aplicação prática de **Padrões de Projeto (Design Patterns)** do Gang of Four (GoF) em um cenário real de desenvolvimento de software.

O sistema é composto por uma API robusta construída em **.NET 8** e um frontend moderno e responsivo desenvolvido em **Angular 17+**.

---

## 🚀 Tecnologias Utilizadas

### Backend (API)
* **C# / .NET 8:** Plataforma de desenvolvimento principal.
* **ASP.NET Core Web API:** Framework para construção de serviços RESTful.
* **Entity Framework Core:** ORM (Object-Relational Mapper) para interação com o banco de dados.
* **SQLite:** Banco de dados relacional leve, ideal para desenvolvimento e demonstrações portáteis.
* **Swagger / OpenAPI:** Ferramenta para documentação e teste interativo dos endpoints da API.

### Frontend (SPA)
* **Angular 17+:** Framework para criação de Single Page Applications (SPA), utilizando Standalone Components.
* **TypeScript:** Superset do JavaScript que adiciona tipagem estática e recursos modernos.
* **Bootstrap 5:** Framework CSS para estilização rápida, grid system e componentes responsivos.
* **SCSS (Sass):** Pré-processador CSS para uma estilização mais organizada e modular.
* **RxJS:** Biblioteca para programação reativa, essencial para manipulação de dados assíncronos no Angular.

---

## 🧠 Padrões de Projeto (Gang of Four - GoF)

A arquitetura deste projeto foca na utilização de padrões de design consagrados para resolver problemas recorrentes de forma elegante e desacoplada.

### 1. Strategy Pattern (Comportamental)
Este padrão define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. O Strategy permite que o algoritmo varie independentemente dos clientes que o utilizam.

* **Aplicação no Projeto:**
    * **Cálculo de Frete:** As classes `FretePAC`, `FreteSEDEX` e `FreteExpresso` implementam a interface `IEstrategiaFrete`. O sistema escolhe a estratégia de cálculo baseada na seleção do usuário sem alterar a lógica principal do carrinho.
    * **Processamento de Pagamento:** As classes `PagamentoPix`, `PagamentoBoleto` e `PagamentoCartao` implementam `IEstrategiaPagamento`, permitindo variar as taxas e descontos conforme o método escolhido.
* **Localização no Código:** `backend/EcommerceSystem/Patterns/Strategy`

### 2. Decorator Pattern (Estrutural)
O Decorator anexa responsabilidades adicionais a um objeto dinamicamente. Ele fornece uma alternativa flexível à herança para estender funcionalidades.

* **Aplicação no Projeto:**
    * **Serviços Adicionais no Produto:** O sistema permite adicionar funcionalidades como `GarantiaEstendida` e `EmbrulhoPresente` a um `ProdutoBase`. Estes decoradores envolvem o objeto original, modificando seu preço e descrição em tempo de execução, sem necessidade de criar classes como "ProdutoComGarantia" ou "ProdutoComEmbrulho".
* **Localização no Código:** `backend/EcommerceSystem/Patterns/Decorator`

### 3. Factory Pattern (Criação)
Este padrão define uma interface para criar um objeto, mas deixa as subclasses decidirem que classe instanciar. O Factory Method permite adiar a instanciação para as subclasses.

* **Aplicação no Projeto:**
    * **Fábrica de Estratégias:** As classes `FreteFactory` e `PagamentoFactory` são responsáveis por instanciar a estratégia correta (ex: retornar um `new FreteSEDEX()`) baseada em uma string identificadora (ex: "SEDEX"). Isso isola a lógica de criação da lógica de negócio.
* **Localização no Código:** `backend/EcommerceSystem/Patterns/Strategy/*Factory.cs`

### 4. Repository Pattern (Arquitetural)
Apesar de não ser um dos 23 padrões originais do GoF (é um padrão de arquitetura de aplicações corporativas), é amplamente utilizado em conjunto com eles. Ele faz a mediação entre o domínio e as camadas de mapeamento de dados.

* **Aplicação no Projeto:**
    * **Abstração de Dados:** As interfaces `IProdutoRepository`, `IPedidoRepository` e `IUsuarioRepository` definem os contratos de acesso a dados, enquanto suas implementações lidam com o `DbContext` do Entity Framework. Isso facilita testes e manutenção.
* **Localização no Código:** `backend/EcommerceSystem/Repositories`

---

## 📂 Estrutura de Pastas

```bash
ecommerce-system/
├── backend/               # Projeto API .NET
│   └── EcommerceSystem/   # Código fonte do backend
│       ├── Controllers/   # Controladores da API (ex: Produtos, Checkout)
│       ├── Patterns/      # Implementações dos padrões GoF (Strategy, Decorator)
│       ├── Services/      # Regras de Negócio e orquestração
│       ├── Repositories/  # Camada de acesso a dados
│       └── Models/        # Entidades do domínio
└── frontend/              # Projeto Angular
    └── src/
        ├── app/
        │   ├── components/# Componentes visuais (Navbar, Carrinho, Checkout)
        │   ├── services/  # Serviços para comunicação HTTP com o backend
        │   └── models/    # Interfaces TypeScript espelhando o backend
