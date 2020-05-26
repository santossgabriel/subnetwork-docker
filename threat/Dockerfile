FROM ubuntu:latest
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
RUN apt update && apt upgrade -y && \
  apt install -y net-tools iputils-ping openssh-server vim dnsutils && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 threat) threat && \
  mkdir -p /run/sshd
CMD ["/usr/sbin/sshd", "-D"]