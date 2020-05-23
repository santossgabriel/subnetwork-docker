FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
RUN mkdir /root/app
COPY app /root/app
WORKDIR /root/app
RUN apt update && apt upgrade -y && \
  apt install -y unzip apache2 php dovecot-imapd dovecot-pop3d postfix && \
  unzip /root/app/squirrelmail.zip && \
  rm /root/app/squirrelmail.zip && \
  apt remove --purge -y unzip && \
  mkdir -p /var/www/html/ && \
  mv /root/app/squirrelmail-webmail-1.4.22 /var/www/html/squirrelmail && \ 
  chown -R www-data:www-data /var/www/html/squirrelmail && \
  chmod 755 -R /var/www/html/squirrelmail && \
  useradd -p $(openssl passwd -1 admin) admin && \
  usermod -m -d /var/www/html/admin admin && \
  mkdir /var/www/html/admin && \
  chown -R admin:admin /var/www/html/admin && \
  mkdir -p /var/local/squirrelmail/data/ && \
  mkdir /var/local/squirrelmail/attach/ && \
  chown -R www-data:www-data /var/local/squirrelmail && \
  mv /root/app/config.php /var/www/html/squirrelmail/config/config.php && \
  mv /root/app/main.cf /etc/postfix/main.cf && \
  apt clean && \
  chmod +x /root/app/init.sh
CMD ["/root/app/init.sh"]