# 🗳️ Voting Application

## 📌 Project Overview
This is a **full-stack Voting Application** developed using **Angular (Frontend)** and **ASP.NET Core (.NET) (Backend)**.  
The application is designed to be simple yet **scalable**, keeping future real-world election use cases in mind.

The system allows users to manage voters and candidates, cast votes, and see real-time updates in the UI.

---

## 🛠️ Tech Stack

### Frontend
- Angular (Standalone Components – Angular 19)
- TypeScript
- HTML / CSS
- HttpClient for API communication

### Backend
- ASP.NET Core Web API (.NET)
- Entity Framework Core
- SQL Server (or In-Memory DB for development)
- RESTful API architecture

---

## ✅ Core Features

### 👥 Voters Management
- Add voters
- Display voters list
- Track whether a voter has voted (`HasVoted` flag)

### 🧑‍💼 Candidates Management
- Add candidates
- Display candidates list
- Track vote count per candidate

### 🗳️ Voting Functionality
- Select a voter and a candidate
- Cast a vote
- Automatically:
  - Increment candidate vote count
  - Update voter’s `HasVoted` status
- UI updates immediately after vote submission

---

## 📐Application Design Considerations

This project is intentionally structured with **future scalability** in mind:

- Separation of concerns (Controller, Service, Data layers)
- REST-based backend APIs
- Angular service layer for API communication
- Easy extension for:
  - Authentication & Authorization
  - Vote validation rules
  - Admin dashboards
  - Real election constraints

---



