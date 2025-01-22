# ProductApp API

## Descripción

Esta API permite gestionar productos con múltiples precios por color, desarrollada en .NET C#. Los usuarios pueden realizar operaciones CRUD sobre los productos, y consultar productos junto con sus precios en función del color seleccionado. La aplicación está pensada para usarse junto con un frontend llamado `ProductApp.React` desarrollado en React.

---

## Funcionalidades

- **CRUD de productos**: Permite crear, leer, actualizar y eliminar productos.
- **Múltiples precios por color**: Cada producto puede tener varios precios asociados a diferentes colores.
- **Consulta de productos**: Permite visualizar los productos y los precios asociados a cada color seleccionado.

---

## Endpoints de la API

### COLORES
### 1. `GET /api/color`

- **Descripción**: Obtiene todos los colores.
- **Respuesta**:
    ```json
    [
      {
        "id": 1,
        "name": "Amarillo"
      },
      {
        "id": 2,
        "name": "Rojo"
      },
    ]
    ```

### 2. `POST /api/color`

- **Descripción**: Crea un nuevo color.
- **Cuerpo de la solicitud**:
    ```json
    {
      "name": "Nuevo Color"
    }
    ```
- **Respuesta**:
    ```json
    1
    
### 3. `PUT /api/color`

- **Descripción**: Actualiza un color existente.
- **Cuerpo de la solicitud**:
    ```json
    {
      "id": 1,
      "name": "Color Actualizado"
    }
    ```
- **Respuesta**:
    ```json
    1
    
### 4. `DELETE /api/color/{id}`

- **Descripción**: Elimina un color por su ID.
- **Respuesta**:
    ```json
    1

### 5. `GET /api/product/{id}`

- **Descripción**: Obtiene un color específico.
- **Respuesta**:
    ```json
    {
      "id": 1,
      "name": "Color Creado"
    }
    ```

### PRODUCTOS
### 1. `GET /api/product`

- **Descripción**: Obtiene todos los productos con sus precios y colores asociados.
- **Respuesta**:
    ```json
    [
      {
        "id": 4,
        "name": "TV",
        "productPrices": [
          {
            "id": 1,
            "price": 7,
            "isSelected": true,
            "productId": 4,
            "product": null,
            "colorId": 1,
            "color": {
              "id": 1,
              "name": "Amarillo",
              "productPrices": null
            }
          },
          {
            "id": 2,
            "price": 88,
            "isSelected": false,
            "productId": 4,
            "product": null,
            "colorId": 1,
            "color": {
              "id": 2,
              "name": "Rojo",
              "productPrices": null
            }
          }
        ]
      }
    ]
    ```

### 2. `POST /api/product`

- **Descripción**: Crea un nuevo producto con precios y colores asociados.
- **Cuerpo de la solicitud**:
    ```json
    {
      "name": "Nuevo Producto",
      "productPrices": [
        {
          "price": 70,
          "isSelected": true,
          "productId": 0,
          "colorId": 1
        },
        {
          "price": 50,
          "isSelected": false,
          "productId": 0,
          "colorId": 2
        },
      ]
    }
    ```
- **Respuesta**:
    ```json
    1
    
### 3. `PUT /api/product`

- **Descripción**: Actualiza un producto existente con nuevos precios o colores.
- **Cuerpo de la solicitud**:
    ```json
    {
      "id": 1,
      "name": "Producto Actualizado",
      "productPrices": [
        {
          "id": 1,
          "price": 90,
          "isSelected": false,
          "productId": 1,
          "colorId": 1
        },
        {
          "id": 2,
          "price": 120,
          "isSelected": true,
          "productId": 1,
          "colorId": 2
        }
      ]
    }
    ```
- **Respuesta**:
    ```json
    1
    
### 4. `DELETE /api/product/{id}`

- **Descripción**: Elimina un producto por su ID.
- **Respuesta**:
    ```json
    1

### 5. `GET /api/product/{id}`

- **Descripción**: Obtiene un producto específico con sus precios y colores.
- **Respuesta**:
    ```json
    {
      "id": 1,
      "name": "Producto Creado",
      "productPrices": [
        {
          "id": 1,
          "price": 88,
          "isSelected": false,
          "productId": 1,
          "product": null,
          "colorId": 1,
          "color": {
            "id": 1,
            "name": "Amarillo",
            "productPrices": null
          }
        },
        {
          "id": 2,
          "price": 45,
          "isSelected": true,
          "productId": 1,
          "product": null,
          "colorId": 2,
          "color": {
            "id": 2,
            "name": "Rojo",
            "productPrices": null
          }
        }
      ]
    }
    ```
---

## Instalación

### Prerrequisitos

- SDK .NET 9.0 o superior
- SQL Server

### Configuración

1. Clonar el repositorio:
    ```bash
    git clone https://github.com/EstivenPad/ProductApp.Backend.git
    cd ProductApp.Backend //Para acceder a la solucion del proyecto
    cd ProductApp.Backend //Para acceder al proyecto API
    ```

2. Restaurar las dependencias:
    ```bash
    dotnet restore
    ```

3. Ejecutar la aplicación:
    ```bash
    dotnet run
    ```

La API se ejecutará en `http://localhost:5000` (o el puerto configurado en tu entorno).

---

## Estructura del Proyecto

- `ProductApp.API`: Proyecto principal que expone los endpoints de la API para interactuar con el sistema.
- `ProductApp.Application`: Capa que contiene la lógica de negocio.
- `ProductApp.DataAccess`: Capa de acceso a datos.
- `ProductApp.Core`: Contiene las entidades y modelos centrales de la aplicación.

---

## Tecnologías

- **Backend**: .NET 9.0, C#, ASP.NET Core
- **Base de Datos**: SQL Server (o base de datos configurada)
- **ORM**: Entity Framework Core
