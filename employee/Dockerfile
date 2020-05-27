FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update && apt upgrade -y && \
  apt install -y net-tools traceroute iputils-ping openssh-server vim dnsutils && \
  mkdir -p /run/sshd && \
  chmod +x /root/init.sh
  
CMD ["/root/init.sh"]