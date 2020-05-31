#!/bin/bash

if [ "$DEFAULT_GATEWAY" != '' ];
then
  route del default
  if [ $? != 0 ];
  then
    echo "    Use: --cap-add=NET_ADMIN"
    exit
  fi

  route add default gw $DEFAULT_GATEWAY eth0

  if [ $? != 0 ];
  then
    echo "Is was not possible to change default gateway to $DEFAULT_GATEWAY"
    exit 1
  fi

  echo "Default gateway changed to $DEFAULT_GATEWAY"
fi

case "$USER_TYPE" in
  "1") cp internal_users users
  ;;
  "2") cp external_users users
  ;;
esac

if [ -e users ]
then
  for e in $(cat users);do
    useradd -m -s /bin/bash -p $(openssl passwd -1 123) $e
    cp .bash_profile /home/$e
  done
fi

exec "$@"