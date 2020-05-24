#!/bin/bash
if [ "$1" = "" ] || [ "$2" = "" ];
then
  echo "Invalid subdomain or last octect ip 1-254"
	echo "Ex: mail 100"
  exit
fi

echo $1 |egrep "^[a-zA-Z0-9-]{1,}$"|grep -q -v grep
if [ $? -ne 0 ];
then
	echo "Invalid subdomain"
	exit
fi

echo $2|egrep "^[0-9]{1,3}$"|grep -q -v grep
if [ $? -ne 0 ];
then
	echo "Invalid host octect"
	exit
fi

HOST_IP=`ifconfig eth0 |egrep netmask |sed -E "s/[a-zA-Z]*//g" |sed "s/   /|/g" |cut -d "|" -f4`
HOST_IP_FIRST_OCTECTS=`echo $HOST_IP |sed -E "s/\.[0-9]{3}$//g"`
HOST_IP_LAST_OCTECT=`echo $HOST_IP |sed -E "s/^([0-9]{1,3}.){3}//g"`

if [[ $2 -ge 1 && $2 -le 254 ]];
then
	
	if [ "$DEFAULT_DNS_DOMAIN" = "" ];
	then 
		DEFAULT_DNS_DOMAIN=example.local
	fi

	echo $1 IN A $HOST_IP_FIRST_OCTECTS.$2 >> /etc/bind/forward.$DEFAULT_DNS_DOMAIN
	echo $2 IN PTR $1.$DEFAULT_DNS_DOMAIN. >> /etc/bind/reverse.$DEFAULT_DNS_DOMAIN
	echo "Host added successfully."
else
	echo "Host octect out of range allowed in this network."
fi
