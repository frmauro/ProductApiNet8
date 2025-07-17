#!/bin/bash

IMAGE_NAME="productapi"
CONTAINER_NAME="productapi_container"

echo "Verificando se o container $CONTAINER_NAME existe..."
if [ "$(docker ps -a --format '{{.Names}}' | grep -w $CONTAINER_NAME)" ]; then
    echo "Removendo container existente..."
    docker rm -f $CONTAINER_NAME
else
    echo "Nenhum container para remover."
fi

echo "Verificando se a imagem $IMAGE_NAME existe..."
if [ "$(docker images -q $IMAGE_NAME)" ]; then
    echo "Removendo imagem existente..."
    docker rmi -f $IMAGE_NAME
else
    echo "Nenhuma imagem para remover."
fi

echo "Criando nova imagem Docker..."
docker build -t $IMAGE_NAME .

echo "Criando e iniciando container..."
docker run -d -p 5002:8080 --name $CONTAINER_NAME --network quark $IMAGE_NAME