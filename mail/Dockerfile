FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
COPY squirrelmail.zip .
COPY init.sh .
COPY new-user.sh .
RUN apt update && apt upgrade -y && \
  apt install -y apache2 php unzip dovecot-imapd dovecot-pop3d postfix && \
  unzip squirrelmail.zip && \
  mkdir -p /var/www/html/ && \
  mv squirrelmail-webmail-1.4.22 /var/www/html/squirrelmail && \ 
  chown -R www-data:www-data /var/www/html/squirrelmail && \
  chmod 755 -R /var/www/html/squirrelmail && \
  useradd -p $(openssl passwd -1 admin) admin && \
  usermod -m -d /var/www/html/admin admin && \
  mkdir /var/www/html/admin && \
  chown -R admin:admin /var/www/html/admin && \
  mkdir -p /var/local/squirrelmail/data/ && \
  mkdir /var/local/squirrelmail/attach/ && \
  chown -R www-data:www-data /var/local/squirrelmail
COPY config.php /var/www/html/squirrelmail/config/config.php