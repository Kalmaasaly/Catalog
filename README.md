Catalog is ASP.NET Core Project with Docker and mongoDB

docker build -t catelog:v1 .

docker network create netCatalogApp

dotnet ps

docker run --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db --network=netCatalogApp mongo

docker run -it --rm -p 8080:80 -e MongoDbSettigs:Host=mongo --network=netCatalogApp catalog:v1 mongo

docker push {your account in docker}/catalog:v1