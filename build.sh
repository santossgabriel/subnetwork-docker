#!/bin/bash

case $1 in base|dns|employee|ftp|proxy|threat|webmail|site|database)
  ;;
  *)
  echo " base | dns | employee | ftp | proxy | threat | webmail | site | database "
  echo "Ex.: .\build.sh base"
  exit
  ;;
esac

echo "******* Building $1 *********"

docker images |grep $1 |grep 1.0
if [ $? = 0 ];
then
  echo "Removing image..."
  docker rmi $1"lab:1.0"
  if [ $? != 0 ];
  then
    echo "Image $1""lab:1.0 be using."
    exit 1
  fi
fi
docker build -t $1"lab:1.0" ./$1
date