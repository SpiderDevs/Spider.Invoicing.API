#!/bin/bash
imageName="spider-invoicing-api";
docker stop $imageName || true && docker rmi -f $imageName || true
docker build . --tag $imageName