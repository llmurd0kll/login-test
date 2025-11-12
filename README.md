# LoginTest – SOAP Integration Demo

## 📌 Overview
This project demonstrates integration with the **ICUTech SOAP service** using ASP.NET Core Razor Pages.  
It implements **Login** and **RegisterNewCustomer** methods, processes JSON responses, and displays success/error messages in the UI.

Deployed demo: [https://login-test-cvj0.onrender.com](https://login-test-cvj0.onrender.com)

---

## 🚀 Features
- **SOAP Client Integration** (`ICUTechClient`)
- **Login Page** (`/`)  
  - Accepts email + password  
  - Calls `LoginAsync`  
  - Displays green/red message depending on `ResultCode`
- **Register Page** (`/Register`)  
  - Accepts email + password  
  - Calls `RegisterNewCustomerAsync` with generated unique phone  
  - Displays green/red message depending on `ResultCode`
- **Result Handling**
  - JSON response parsed (`ResultCode`, `ResultMessage`, `EntityId`)  
  - Success → green alert  
  - Error → red alert  
  - Full JSON shown for debugging

---

## 🛠️ Tech Stack
- ASP.NET Core Razor Pages (.NET 9)
- Bootstrap 5 for styling
- SOAP client generated from WSDL
- Hosted on [Render.com](https://render.com)

---

## 🔑 How to Test
1. Open [https://login-test-cvj0.onrender.com](https://login-test-cvj0.onrender.com).
2. Navigate to `/Register`:
   - Enter a new email + password.
   - Registration will call SOAP service.
   - Success → green message, Error → red message.
3. Navigate to `/` (Login):
   - Enter registered email + password.
   - Login will call SOAP service.
   - Success → green message, Error → red message.

---

## ✅ Status
- Part 1 (SOAP integration) **completed and deployed**.

---
