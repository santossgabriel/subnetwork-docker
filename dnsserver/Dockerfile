FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update && \
  apt upgrade -y && \
  apt install -y net-tools vim iputils-ping bind9 && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]