#!/bin/bash
for e in $(cat employees);do
  useradd -m -s /bin/bash -p $(openssl passwd -1 123456) $e
done

route del default
route add default gw 172.20.20.50 eth0

exec /usr/sbin/sshd -D