#!/bin/bash

CONTAINES='orders emails payments logs'

docker-compose stop $CONTAINES
docker-compose rm -f $CONTAINES
docker-compose up -d $CONTAINES
docker-compose logs -f --tail=all $CONTAINES