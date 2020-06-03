FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
RUN apt install -y squid apache2 postfix && \
  cp /root/000-default.conf /etc/apache2/sites-available/000-default.conf && \
  mv /root/main.cf /etc/postfix/main.cf && \
  a2enmod proxy && \
  a2enmod proxy_http && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]