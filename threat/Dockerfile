FROM archlinux
ARG DEBIAN_FRONTEND=noninteractive
COPY files/* /root/
WORKDIR /root
RUN pacman -Syu --noconfirm && \
  pacman -S --noconfirm openssh community/netcat net-tools iputils wget curl vim traceroute dnsutils python3 tcpdump sslstrip && \
  curl -O https://blackarch.org/strap.sh && sh strap.sh && \
  ssh-keygen -A && \
  mkdir -p /run/sshd && \
  cp /root/sshd_config /etc/ssh/sshd_config && \
  useradd -m -s /bin/bash -p $(openssl passwd -1 123) pentester && \
  cp /root/sshd_config /etc/ssh/
CMD ["/usr/sbin/sshd", "-D"]