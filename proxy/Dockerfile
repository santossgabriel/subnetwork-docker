FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
RUN apt update && \
  apt upgrade -y && \
  apt install -y squid openssh-server && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 threat) threat && \
  mkdir -p /run/sshd
CMD ["/usr/sbin/sshd", "-D"]