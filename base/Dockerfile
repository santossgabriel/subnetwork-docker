FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update -y && \
  apt upgrade -y && \
  apt install -y net-tools iputils-ping wget curl vim traceroute dnsutils python3 tcpdump && \
  apt clean && \
  chmod +x /root/base_init.sh
ENTRYPOINT [ "/root/base_init.sh"]