#!/bin/bash

# docker-compose build

cluste_name=meu-cluster
kind_node=$cluste_name-control-plane

docker exec -it $kind_node crictl rmi $(docker images "kafka.estudos*" -q)

kind load docker-image kafka.estudos.logs:latest --name $cluste_name
kind load docker-image kafka.estudos.orders:latest --name $cluste_name
kind load docker-image kafka.estudos.payments:latest --name $cluste_name
kind load docker-image kafka.estudos.emails:latest --name $cluste_name

# visualizar as imagens dentro do cluster kind
docker exec -it $kind_node crictl images