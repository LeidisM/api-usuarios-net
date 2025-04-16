# API de Autenticación de Usuarios

## 📌 Descripción
Servicio web construido en .NET para registro y autenticación de usuarios mediante endpoints REST.

## 🚀 Tecnologías
- .NET 6
- Entity Framework Core
- SQL Server
- Swagger (Documentación)

## 🔑 Endpoints
| Método | Ruta                     | Descripción                  |
|--------|--------------------------|------------------------------|
| POST   | `/api/usuarios/registrar`| Registra un nuevo usuario.   |
| POST   | `/api/usuarios/login`    | Autentica un usuario.        |

Ejemplo de JSON para Postman:

Ejemplo de Request (Postman)
```json
{
  "nombreUsuario": "ejemplo",
  "contrasena": "123456"
}
