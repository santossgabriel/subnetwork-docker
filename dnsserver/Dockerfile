FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update && \
  apt upgrade -y && \
  apt install -y net-tools vim iputils-ping bind9 apache2 && \
  chmod +x /root/init.sh && \
  cp newhost.sh /usr/bin/newhost && \
  chmod +x /usr/bin/newhost
CMD ["/root/init.sh"]