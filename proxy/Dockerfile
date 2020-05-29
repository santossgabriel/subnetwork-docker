FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
RUN apt install -y squid openssh-server && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 threat) threat && \
  mkdir -p /run/sshd && \
  chmod +x /root/init.sh
CMD ["/root/init.sh"]