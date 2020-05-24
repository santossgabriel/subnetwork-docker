FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update && apt upgrade -y && \
  apt install -y unzip apache2 php dovecot-imapd dovecot-pop3d net-tools iputils-ping postfix && \
  unzip /root/squirrelmail.zip && \
  rm /root/squirrelmail.zip && \
  apt remove --purge -y unzip && \
  mkdir -p /var/www/html/ && \
  mv /root/squirrelmail-webmail-1.4.22 /var/www/html/squirrelmail && \ 
  chown -R www-data:www-data /var/www/html/squirrelmail && \
  chmod 755 -R /var/www/html/squirrelmail && \
  useradd -p $(openssl passwd -1 admin) admin && \
  usermod -m -d /var/www/html/admin admin && \
  mkdir /var/www/html/admin && \
  chown -R admin:admin /var/www/html/admin && \
  mkdir -p /var/local/squirrelmail/data/ && \
  mkdir /var/local/squirrelmail/attach/ && \
  chown -R www-data:www-data /var/local/squirrelmail && \
  mv /root/config.php /var/www/html/squirrelmail/config/config.php && \
  mv /root/main.cf /etc/postfix/main.cf && \
  apt clean && \
  chmod +x /root/init.sh && \
  cp /root/newuser.sh /usr/bin/newuser && \
  chmod +x /usr/bin/newuser
CMD ["/root/init.sh"]