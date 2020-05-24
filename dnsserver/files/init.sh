#!/bin/bash
echo "***** Bind DNS Server *****"
if [ "$DEFAULT_DNS_DOMAIN" = "" ];
then 
	DEFAULT_DNS_DOMAIN=example.local
fi

cp /root/forward.example.local /etc/bind/forward.$DEFAULT_DNS_DOMAIN
cp /root/named.conf.local /etc/bind/named.conf.local
cp /root/named.conf.options /etc/bind/named.conf.options
cp /root/reverse.example.local /etc/bind/reverse.$DEFAULT_DNS_DOMAIN

sed -i "s/{DEFAULT_DNS_DOMAIN}/$DEFAULT_DNS_DOMAIN/g" /etc/bind/*

HOST_IP=`ifconfig eth0 |egrep netmask |sed -E "s/[a-zA-Z]*//g" |sed "s/   /|/g" |cut -d "|" -f4`
HOST_IP_LAST_OCTECT=`echo $HOST_IP |sed -E "s/^([0-9]{1,3}.){3}//g"`
HOST_IP_FIRST_OCTECTS=`echo $HOST_IP |sed -E "s/\.[0-9]{1,3}$//g"`
REV_HOST_IP_FIRST_OCTECTS=`echo $HOST_IP_FIRST_OCTECTS | sed -E "s/^([0-9]{1,3}.){2}//g"`.`echo $HOST_IP_FIRST_OCTECTS | sed -E "s/^[0-9]{1,3}.//g" |sed -E "s/.[0-9]{1,3}$//g"`.`echo $HOST_IP_FIRST_OCTECTS | sed -E "s/(.[0-9]{1,3}){2}$//g"`

sed -i "s/{HOST_IP}/$HOST_IP/g" /etc/bind/*
sed -i "s/{HOST_IP_LAST_OCTECT}/$HOST_IP_LAST_OCTECT/g" /etc/bind/*
sed -i "s/{HOST_IP_FIRST_OCTECTS}/$HOST_IP_FIRST_OCTECTS/g" /etc/bind/*
sed -i "s/{REV_HOST_IP_FIRST_OCTECTS}/$REV_HOST_IP_FIRST_OCTECTS/g" /etc/bind/*

echo DOMAIN: $DEFAULT_DNS_DOMAIN
echo IP: $HOST_IP

service named start

echo ServerName $HOST_IP >> /etc/apache2/apache2.conf 
mkdir -p /var/run/apache2
source /etc/apache2/envvars
echo "* Starting Apache HTTP Server"
exec /usr/sbin/apache2 -D "FOREGROUND"