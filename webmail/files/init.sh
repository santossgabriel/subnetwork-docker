#!/bin/bash
echo "***** Squirrel Webmail Server *****"

mkdir -p /var/run/apache2
HOST_IP=`ifconfig eth0 |egrep netmask |sed -E "s/[a-zA-Z]*//g" |sed "s/   /|/g" |cut -d "|" -f4`
echo ServerName $HOST_IP >> /etc/apache2/apache2.conf 
source /etc/apache2/envvars
echo "* Starting Apache HTTP Server"

if [ "$DOMAIN" = "" ];
then
  DOMAIN=example.lab
fi


sed -i "s/##DOMAIN##/$DOMAIN/g" /var/www/html/squirrelmail/config/config.php
sed -i "s/##DOMAIN##/$DOMAIN/g" /etc/postfix/main.cf
sed -i "s/##DOMAIN##/mail.$DOMAIN/g" /etc/apache2/sites-available/squirrelmail.conf

a2ensite squirrelmail
service dovecot start
service postfix start

exec /usr/sbin/apache2 -D "FOREGROUND"