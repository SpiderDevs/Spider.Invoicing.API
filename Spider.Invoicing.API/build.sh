#!/bin/bash
imageName="spider-invoicing-api";
docker stop $imageName || true && docker rm -f $imageName || true
docker build . --tag $imageName