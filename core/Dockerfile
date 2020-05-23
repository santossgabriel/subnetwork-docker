FROM ubuntu:18.04
RUN apt update -y && \
  apt upgrade -y && \
  apt install -y net-tools iputils-ping wget curl vim traceroute zsh && \
  apt install git -y \
  && sh -c "$(curl -fsSL https://raw.github.com/ohmyzsh/ohmyzsh/master/tools/install.sh)" && \
  apt remove --purge git -y
COPY ./.zshrc /root