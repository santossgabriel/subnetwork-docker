#!/bin/bash
service dovecot restart
service postfix restart
mkdir /var/run/apache2
source /etc/apache2/envvars
info "** Starting Apache **"
exec /usr/sbin/apache2 -D "FOREGROUND"