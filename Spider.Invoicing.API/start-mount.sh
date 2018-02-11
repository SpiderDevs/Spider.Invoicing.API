#!/bin/bash
imageName="spider-invoicing-api";
echo $imageName
docker stop $imageName || true && docker rm -f $imageName || true

BASE_DIR=`pwd`

# If we detect Windows, then replace some backslashes with double forward slashes
if [[ `uname -o` == 'Msys' ]]; then
	BASE_DIR=${BASE_DIR//\//\/\/}
	HOME_DIR='//c//Users//'`whoami`
else
	HOME_DIR='//Users//'`whoami`
fi

docker run  -d --name $imageName \
	-p 15030:80 \
	--mount source=logs-volume,target=/app \
	--restart always \
	$imageName