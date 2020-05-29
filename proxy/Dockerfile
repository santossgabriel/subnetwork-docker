FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
RUN apt install -y squid apache2 && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]