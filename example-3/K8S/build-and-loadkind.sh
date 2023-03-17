#!/bin/bash

docker-compose build

cluster_name=meu-cluster
kind_node=$cluster_name-control-plane

# docker exec -it $kind_node crictl rmi $(docker images "kafka.estudos*" -q)

# kind load docker-image kafka.estudos.logs:latest --name $cluster_name
# kind load docker-image kafka.estudos.orders:latest --name $cluster_name
# kind load docker-image kafka.estudos.payments:latest --name $cluster_name
# kind load docker-image kafka.estudos.emails:latest --name $cluster_name

# visualizar as imagens dentro do cluster kind
docker exec -it $kind_node crictl images