FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
COPY init.sh /root/
WORKDIR /root
RUN apt update && apt upgrade -y && \
  apt install -y net-tools iputils-ping openssh-server vim && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 threat) threat && \
  mkdir -p /run/sshd && \
  chmod +x /root/init.sh
CMD ["/usr/sbin/sshd", "-D"]