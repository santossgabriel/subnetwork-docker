FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
COPY files/ssl /root/
RUN apt install -y squid apache2 postfix && \
  cp /root/default-ssl.conf /etc/apache2/sites-available/default-ssl.conf && \
  mkdir /root/ssl /etc/apache2/ssl && \
  mv /root/apache.crt /etc/apache2/ssl && \
  mv /root/apache.key /etc/apache2/ssl && \
  mv /root/main.cf /etc/postfix/main.cf && \
  a2enmod proxy proxy_http ssl rewrite && \
  a2dissite 000-default.conf && \
  a2ensite default-ssl.conf && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]