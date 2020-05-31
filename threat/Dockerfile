FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
RUN apt install -y openssh-server && \
  mkdir -p /run/sshd
CMD ["/usr/sbin/sshd", "-D"]