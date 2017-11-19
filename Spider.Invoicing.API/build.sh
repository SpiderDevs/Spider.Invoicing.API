#!/bin/bash
docker rmi -f spider-invoicing-api
docker image  build . --tag spider-invoicing-api 