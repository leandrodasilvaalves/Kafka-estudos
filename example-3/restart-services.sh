#!/bin/bash

CONTAINERS='orders emails payments logs'

docker-compose stop $CONTAINERS
docker-compose rm -f $CONTAINERS
docker-compose up -d $CONTAINERS
docker-compose logs -f --tail=all $CONTAINERS