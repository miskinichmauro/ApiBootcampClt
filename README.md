# ApiBootcampClt

API REST para gestión de categorías y productos. Implementa arquitectura en capas con CQRS + MediatR, persistencia en PostgreSQL y logging con Serilog.

## Características
- CRUD completo de categorías y productos.
- Swagger/OpenAPI en entorno Development.
- Persistencia con Entity Framework Core (PostgreSQL).
- Observabilidad con Serilog.
- Contenerizacion con Docker y despliegue con Helm.
- Pipeline CI/CD con GitHub Actions.

## Stack
- .NET 9 (ASP.NET Core)
- Entity Framework Core + Npgsql
- MediatR + CQRS
- Serilog
- PostgreSQL
- Docker, Helm, Kubernetes

## Requisitos
- .NET SDK 9.0
- PostgreSQL
- (Opcional) Docker
- (Opcional) Helm + kubectl + Minikube

## Configuración
Variables recomendadas (también se pueden definir en `appsettings.json`):
- `ConnectionStrings__ProductosDb` (ejemplo: `Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=a.123456`)
- `ASPNETCORE_ENVIRONMENT` (ejemplo: `Development`)
- `ASPNETCORE_URLS` (ejemplo: `http://+:8080` para contenedor)
- `ApplicationName` (ejemplo: `api-bootcampclt`)
- `Serilog__WriteTo__1__Args__configure__0__Args__serverUrl` (ejemplo: `http://localhost:5341`)

## Ejecutar localmente
1) Configura la cadena de conexión a PostgreSQL.
2) Ejecuta:

```bash
  dotnet restore
  dotnet build ApiBootcampClt.sln -c Release
  dotnet run --project src/ApiBootcampClt.Api/ApiBootcampClt.Api.csproj
```

Swagger (solo en Development):
- `http://localhost:5055/swagger`

## Docker
Build:

```bash
  docker build -t api-bootcampclt:local .
```

Run:

```bash
  docker run -p 8080:8080 \
    -e ASPNETCORE_ENVIRONMENT=Development \
    -e ConnectionStrings__ProductosDb="Host=host.docker.internal;Port=5433;Database=postgres;Username=postgres;Password=a.123456" \
    api-bootcampclt:local
```

Swagger en contenedor (si esta en Development):
- `http://localhost:8080/swagger`

## Helm / Kubernetes
Valores base en `k8s/helm/values.yaml`.

Instalar/actualizar:

```bash
  helm upgrade --install api-bootcampclt k8s/helm --set image.tag=1.0
```

Acceso local (ejemplo con port-forward):

```bash
  kubectl port-forward svc/api-bootcampclt-svc 8080:80
```

## CI/CD
Workflow en `.github/workflows/ci-cd.yml`:
- CI: build + test + push de imagen a Docker Hub.
- CD: despliegue con Helm en runner self-hosted.

Secrets requeridos:
- `DOCKERHUB_USERNAME`
- `DOCKERHUB_TOKEN`

## Endpoints
Base: `v1/api`

Categorias:
- `GET /categorias`
- `GET /categorias/{id}`
- `POST /categorias`
- `PUT /categorias/{id}`
- `PATCH /categorias/{id}`
- `DELETE /categorias/{id}`

Ejemplo `POST /categorias`:

```json
{
  "nombre": "Perifericos",
  "descripcion": "Accesorios",
  "estado": true
}
```

Productos:
- `GET /productos`
- `GET /productos/{id}`
- `POST /productos`
- `PUT /productos/{id}`
- `PATCH /productos/{id}`
- `DELETE /productos/{id}`

Ejemplo `POST /productos`:

```json
{
  "codigo": "KB-001",
  "nombre": "Teclado",
  "descripcion": "Mecanico",
  "precio": 49990,
  "activo": true,
  "categoriaId": 1,
  "cantidadStock": 20
}
```
