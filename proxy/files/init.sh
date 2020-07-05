#!/bin/bash

echo "***** Proxy Server *****"

service squid start
mkdir -p /var/run/apache2

HOST_IP=`ifconfig eth0 |egrep netmask |sed -E "s/[a-zA-Z]*//g" |sed "s/   /|/g" |cut -d "|" -f4`
echo ServerName $HOST_IP >> /etc/apache2/apache2.conf 
source /etc/apache2/envvars

service postfix start
if [ $? != 0 ];
then
  exit 1
fi

service suricata start
if [ $? != 0 ];
then
  exit 1
fi

if [ "$EMAIL_GATEWAY" != "" ];
then
  echo $EMAIL_GATEWAY | sed "s/;/\n/g" | sed "s/|/ /" > /etc/postfix/transport
  echo "Email gateways $EMAIL_GATEWAY"
  postmap /etc/postfix/transport
fi

echo "* Starting Apache HTTP Server"

exec /usr/sbin/apache2 -D "FOREGROUND"