# ProductApiNet8
## build a image docker
docker build -t productapi .


## command to create a container
 docker run -d -p 5002:8080 --name productapi_container --network quark productapi
 