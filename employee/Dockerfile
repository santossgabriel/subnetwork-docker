FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt install -y openssh-server && \
  mkdir -p /run/sshd && \
  chmod +x /root/init.sh

CMD ["/root/init.sh"]