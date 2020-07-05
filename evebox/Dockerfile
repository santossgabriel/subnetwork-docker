FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
RUN wget -qO - https://evebox.org/files/GPG-KEY-evebox | apt-key add - && \
  echo "deb http://evebox.org/files/debian stable main" | tee /etc/apt/sources.list.d/evebox.list && \
  apt update && \
  apt install apache2 evebox -y && \
  cp /root/000-default.conf /etc/apache2/sites-available && \
  a2enmod proxy proxy_http && \
  mv /root/evebox.yaml /etc/evebox/ && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]