🚀 Sistema de Gestión de Empleados

API REST con .NET 10

Este repositorio contiene una API REST desarrollada en .NET 10 como proyecto práctico para aplicar y consolidar buenas prácticas reales de desarrollo backend.
La idea no es solo que funcione, sino que el código sea claro, fácil de mantener y preparado para crecer, como en un proyecto profesional.

🛠️ Tecnologías utilizadas

*  .NET 10 (C# 14)
*  SQL Server (ejecutándose en Docker)
*  Entity Framework Core (Code-First y migraciones)
*  JWT para autenticación
*  Serilog para logging estructurado
*  Scalar / OpenAPI para documentar y probar la API

🏗️ Cómo está organizado el proyecto

He intentado mantener una estructura limpia y fácil de entender:
Repository Pattern para separar el acceso a datos de la lógica de negocio
DTOs para no exponer directamente las entidades
Inyección de dependencias usando el contenedor nativo de .NET
Pruebas unitarias con xUnit para validar la lógica principal
Nada especialmente “mágico”, solo patrones que funcionan bien en proyectos reales.

🚀 Calidad y automatización

El repositorio incluye un flujo de CI con GitHub Actions.
Cada vez que se hace un push a main:
1. El proyecto se compila en Linux
2. Se ejecutan los tests
3. Si algo falla, el cambio no pasa
Esto ayuda a detectar errores rápido y mantener el código estable.

🐳 Ejecutar el proyecto

Todo está preparado para ejecutarse con Docker, sin instalar nada extra.
Solo ejecuta: docker-compose up --build

Una vez levantado, la documentación interactiva de la API está en:
👉 https://localhost:8080/scalar/v1

🎯 Objetivo del proyecto

Este proyecto sirve como:
*  Ejemplo de API REST bien estructurada en .NET moderno
*  Práctica real de arquitectura, testing y seguridad
*  Base para seguir añadiendo funcionalidades

👨‍💻 Autor

Abel Poveda
Desarrollador .NET centrado en backend, arquitectura y sistemas cloud.
