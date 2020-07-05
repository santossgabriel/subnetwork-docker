#!/bin/bash
if [ -e eve.json ]
then
	echo "Using existing eve.json file."
else
	touch eve.json
	echo "File eve.json was created."
fi
docker-compose up -d --remove-orphans
