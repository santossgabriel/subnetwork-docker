#!/bin/bash

TZ='America/Sao_Paulo'
export TZ

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
  "3") cat external_users > users && echo "" >> users && cat internal_users >> users
  ;;
esac

if [ -e users ]
then
  for u in $(cat users);do
    USER_PASSWORD=`cat users_password | grep $u | cut -d "-" -f2`
    echo "$u - $USER_PASSWORD"
    useradd -m -s /bin/bash -p $(openssl passwd -1 $USER_PASSWORD) $u
    cp .bash_profile /home/$u

    if [ "$BOT_NAME" = "$u" ];
    then
      USING_BOT_NAME=$BOT_NAME
      echo "" >> /home/$u/.bash_profile
      echo "export BOT_NAME=$BOT_NAME" >> /home/$u/.bash_profile
      echo "export BOT_PASSWORD=$USER_PASSWORD" >> /home/$u/.bash_profile
      source /home/$u/.bash_profile
    fi
  done

  rm users_password
fi

if [ "$BOT_NAME" != "" ];
then
  echo "Using bot $USING_BOT_NAME"
fi

exec "$@"