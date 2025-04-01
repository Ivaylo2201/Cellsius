# Cellsius

A web-based application built with C# and TypeScript, focused on cellphones. It features a scalable architecture and efficient data management, adhering to modern software development practices for optimal performance and maintainability.

## 🚀 Starting the Project

Follow these steps to run the project locally:

1. **Clone the repository**  
```sh
git clone https://github.com/Ivaylo2201/Cellsius.git
cd Cellsius
```

2. **Install & run the backend**  
```sh
cd server/Api
dotnet restore
dotnet run
```

3. **Install & run the frontend**
```sh
cd ../../client
npm install
npm run dev
```

4. **Additional configurations**
```sh
If there are additional configurations, such as a database or a .env file, you should include them as well. 🚀
```

5. **Accessibility**
```sh
The frontend will be available at: **http://localhost:5173**
The backend will be available at: **http://localhost:1634**

Those settings may vary according to the appsettings.json or .env in `/client`
```

##  📧 Querying the backend


Base url: **http://localhost:1634/api**

Access the RESTful API at these endpoints:

---

### POST /phones

- Creates a new phone resource on the server.

#### **Body (multipart/form-data)**
| Field       | Type        | Required | Description                        |
|------------|------------|----------|------------------------------------|
| `brand`    | `string`    | Yes      | Brand name of the phone           |
| `model`    | `string`    | Yes      | Model name of the phone           |
| `color`    | `string`    | Yes      | Color of the phone                |
| `price`    | `decimal`   | Yes      | Initial price of the phone        |
| `memory`   | `int`       | Yes      | Memory size in GB                 |
| `image`    | `file`      | Yes      | Image file of the phone           |

#### **Response**
```json
{
  "message": "Phone created successfully."
}
```

---

### GET /phones

- Retrieves all phone resources on the server

#### **Query Parameters**
| Parameter   | Type      | Required | Description                                    |
|-------------|-----------|----------|------------------------------------------------|
| `brand`     | `string`  | No       | Filter by brand name                          |
| `models`    | `string`  | No       | Filter by model name                          |
| `color`     | `string`  | No       | Filter by color                               |
| `minPrice`  | `decimal` | No       | Filter by minimum price                       |
| `maxPrice`  | `decimal` | No       | Filter by maximum price                       |
| `search`    | `string`  | No       | Search by brand, model, or color              |
| `sortBy`    | `string`  | No       | Sort by `price` or `discount`                 |
| `order`     | `string`  | No       | Sorting order (`asc` or `desc`, default: `asc`) |


#### **Response**

```json
[
  {
    "id": 1,
    "brand": "Samsung",
    "model": "Galaxy S24 Ultra",
    "color": "Gold",
    "discountPercentage": 15,
    "price": {
      "initial": 1400.0,
      "discounted": 1190.0
    },
    "memory": 512,
    "imagePath": "/uploads/samsung-galaxy-s24ultra.jpg"
  }
  ...
]
```

---

### POST /auth/register

- Creates a new user resource on the server

#### **Body (application/json)**
| Parameter            | Type     | Required | Description                        |
|----------------------|----------|----------|------------------------------------|
| `email`              | `string` | Yes      | The email address of the user.     |
| `username`           | `string` | Yes      | The username chosen by the user.   |
| `password`           | `string` | Yes      | The password chosen by the user.   |
| `passwordConfirmation` | `string` | Yes      | The confirmation of the password.  |



#### **Response**

```json
{
    "token": "bXJkZyBzZXNzaW9uYWwgYWxnb3JpdGhtZGF0YSJmdGxqZXhpdFxpY2tlMjVtM3V5qZtZTtwAGjkjQ1BYiA4wH2d8Km4YIquQcA8V9xYP0OYZz1rVLEZvwq51ot0j0paF2_5wkw"
}
```

---

### POST /auth/login

- Authenticates and provides a new token and information about the user

#### **Body (application/json)**
| Parameter            | Type     | Required | Description                        |
|----------------------|----------|----------|------------------------------------|
| `email`              | `string` | Yes      | The email address of the user.     |
| `password`           | `string` | Yes      | The password chosen by the user.   |



#### **Response**

```json
{
    "token": "bXJkZyBzZXNzaW9uYWwgYWxnb3JpdGhtZGF0YSJmdGxqZXhpdFxpY2tlMjVtM3V5qZtZTtwAGjkjQ1BYiA4wH2d8Km4YIquQcA8V9xYP0OYZz1rVLEZvwq51ot0j0paF2_5wkw",
    "cart": {
        "items": 5
        "subtotal": 1250.75
    }
}
```

---

### PATCH /carts/item/:id

- Updates a item quantity in the user's cart
- Requires **Bearer** authorization


#### **Body (application/json)**
| Parameter            | Type     | Required | Description                        |
|----------------------|----------|----------|------------------------------------|
| `quantity`              | `int` | Yes      | The new quantity of the item    |



#### **Response**

```json
{
    "message": "Item 1 quantity updated to 5"
}
```

---

### GET /carts/

- Retrieves the details about the user's cart
- Requires **Bearer** authorization

#### **Response**

```json
{
    "items": [
        {
            "id": 36,
            "quantity": 2,
            "phone": {
                "id": 3,
                "brand": "Samsung",
                "model": "Galaxy A16",
                "color": "Black",
                "price": 150.0,
                "memory": 128,
                "imagePath": "/uploads/samsung-galaxy-a16.jpg"
            },
            "price": 300.0
        },
        {
            "id": 37,
            "quantity": 1,
            "phone": {
                "id": 4,
                "brand": "Samsung",
                "model": "Galaxy Z Flip 6",
                "color": "Blue",
                "price": 1200.0,
                "memory": 512,
                "imagePath": "/uploads/samsung-galaxy-zflip6.jpg"
            },
            "price": 1200.0
        }
    ],
    "subtotal": 1500.0
}
```

---

### POST /carts/add

- Adds a phone as an item in the user's cart
- Requires **Bearer** authorization


#### **Body (application/json)**
| Parameter            | Type     | Required | Description                        |
|----------------------|----------|----------|------------------------------------|
| `phoneId`              | `int` | Yes      | The id of the phone    |



#### **Response**

```json
{
    "message": "Item successfully added."
}
```

---

### DELETE /carts/remove/:id

- Removes an item from the user's cart
- Requires **Bearer** authorization

#### **Response**

```json
{}
```

---

### GET /orders

- Retrieves all orders of the user on the server
- Requires **Bearer** authorization

#### **Response**

```json
{
    "id": 9,
    "total": 9763.0,
    "items": [
        {
            "id": 32,
            "quantity": 2,
            "phone": {
                "brand": "Samsung",
                "model": "Galaxy S24 Ultra",
                "imagePath": "/uploads/samsung-galaxy-s24ultra.jpg"
            },
            "price": 2380.0
        },
        ...
    ]
}
```

---

### POST /orders/place

- Packs the items from the user's cart into an order resource
- Requires **Bearer** authorization


#### **Body (application/json)**
| Parameter            | Type     | Required | Description                        |
|----------------------|----------|----------|------------------------------------|
| `shippingId`              | `int` | Yes      | The id of the shipping the user has chosen    |

#### **Response**

```json
{
    "message": Order successfully placed!"
}
```

---

### GET /data

- Retrieves the seeded data on the server

#### **Response**

```json
{
    "brands": [
        {
            "id": 1,
            "name": "Samsung",
            "count": 6
        },
        {
            "id": 2,
            "name": "Apple",
            "count": 3
        },
        ...
    ],
    "colors": [
        {
            "id": 1,
            "name": "Black"
        },
        {
            "id": 2,
            "name": "White"
        },
        ...
    ],
    "shippings": [
        {
            "id": 1,
            "type": "Standard",
            "cost": 0,
            "days": 7
        },
        {
            "id": 2,
            "type": "Express",
            "cost": 15,
            "days": 3
        },
        ...
    ]
}
```

---

### GET /data/models

- Retrieves the seeded models for a specific brand or all if no brand is provided

#### **Query Parameters**
| Parameter   | Type      | Required | Description                                    |
|-------------|-----------|----------|------------------------------------------------|
| `brand`     | `string`  | No       | Retrieve the models only for this brand                        |


#### **Response**

```json
[
    {
        "brand": "Samsung",
        "models": [
            {
                "id": 1,
                "name": "Galaxy S24 Ultra"
            },
            {
                "id": 2,
                "name": "Galaxy S25"
            },
            ...
        ]
    }
]
```
