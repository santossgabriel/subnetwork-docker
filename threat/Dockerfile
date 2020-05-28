FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
RUN apt install -y openssh-server && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 threat) threat && \
  mkdir -p /run/sshd
CMD ["/usr/sbin/sshd", "-D"]