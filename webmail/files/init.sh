#!/bin/bash
service dovecot restart
service postfix restart
mkdir -p /var/run/apache2
source /etc/apache2/envvars
echo "** Starting Apache **"
exec /usr/sbin/apache2 -D "FOREGROUND"