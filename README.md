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
- Swagger

**Frontend:**
- React + TypeScript
- Context API (для auth)
- Axios (для запитів)

---

## ⚙️ Налаштування

### 1. Клонування репозиторію
```bash
git clone https://github.com/taraskibysh/URL_Shortener.git
```
### 2. Налаштування бекенд частини 
1. Відкрити бекенд-проект у IDE .  
2. В `appsettings.Development.json` змінити параметр `ConnectionStrings:DefaultConnection` на ваш локальний сервер бази даних.  
3. За бажанням можна змінити:
   - `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience` для власного JWT.  
   - Адміністративний акаунт (`AdminEmail`, `AdminPassword`).  
4. Запустити проект:  
   ```bash
   dotnet run
   ```
### 3. Налаштування клієнт частини
1. Відкрити фронтенд-проект у VS Code / іншому редакторі.
2. Встановити залежності:
 ```bash
npm install
```
3. Переконатися, що API_URL у файлах:
src/api/Auth.ts
src/api/Client.ts
відповідає URL бекенду, за замовчуванням http://localhost:5099.
4. Запустити фронтенд:
```bash
npm start
```
Відкриється браузер з самим застосунком

### 4. Після запуску
Можна зареєструвати нового користувача через форму реєстрації.
Або увійти під адміністративним акаунтом, дані якого задано у appsettings.Development.json.

# Скріни робочого додатку 
<img width="2559" height="1324" alt="image" src="https://github.com/user-attachments/assets/11955208-33df-4b26-9b99-883e1f349ce1" />
<img width="2536" height="1331" alt="image" src="https://github.com/user-attachments/assets/7a6e388b-b39c-4bfd-970c-7e535ea5a536" />
<img width="2541" height="1231" alt="image" src="https://github.com/user-attachments/assets/48095f01-511e-495b-ad19-09c50e5b56a5" />


