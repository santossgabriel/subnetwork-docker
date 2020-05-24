#!/bin/bash
echo "***** Squirrel Webmail Server *****"
service dovecot start
service postfix start
mkdir -p /var/run/apache2
HOST_IP=`ifconfig eth0 |egrep netmask |sed -E "s/[a-zA-Z]*//g" |sed "s/   /|/g" |cut -d "|" -f4`
echo ServerName $HOST_IP >> /etc/apache2/apache2.conf 
source /etc/apache2/envvars
echo "* Starting Apache HTTP Server"
exec /usr/sbin/apache2 -D "FOREGROUND"