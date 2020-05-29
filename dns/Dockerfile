FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
WORKDIR /root
COPY files/* /root/
RUN apt update && \
  apt upgrade -y && \
  apt install -y bind9 && \
  chmod +x /root/init.py
CMD ["/root/init.py"]