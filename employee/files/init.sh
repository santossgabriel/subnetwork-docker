#!/bin/bash
for e in $(cat employees);do
  useradd -m -s /bin/bash -p $(openssl passwd -1 123) $e
  cp .bash_profile /home/$e
done

exec /usr/sbin/sshd -D