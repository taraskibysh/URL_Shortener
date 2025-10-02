# 🔗 URL Shortener

Додаток для скорочення посилань

---

## 🛠️ Технології

**Backend:**
- ASP.NET Core 
- Entity Framework Core (Code First)
- Identity (авторизація/реєстрація)
- JWT Authentication
- MSSQL
- AutoMapper 

**Frontend:**
- React + TypeScript
- Context API (для auth)
- Axios (для запитів)

---

## ⚙️ Налаштування

### 1. Клонування репозиторію
```bash
git clone https://github.com/your-username/url-shortener.git
```
### 2. Налаштування бекенд частини 
- Потрібно відкрити бекенд частину і в appsettings.development.json змінити connectionstring на ваший, при потребі можна змінити й інші параметри
- Після цього запустити бекенд
### 3. Налаштування клієнт частини
-Потрібно відкрити клієнт частину і прописати 
```bash
npm install
```
- Впевніться що бекенд працює за url http://localhost:5099
- Якщо ні то потрібно перейти в url-shortener-frontend/src/api/Auth.ts і url-shortener-frontend/src/api/Client.ts і змінити там API_URL на потрібний 
- після цього можна прописати
 ```bash
npm start 
```
Це запустить фронтенд частину додатку 
