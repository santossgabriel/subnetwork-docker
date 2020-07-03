FROM baselab:1.0
COPY files/* /root/
RUN apt install -y vsftpd && \
  apt clean && \
  mkdir /home/public && \
  chmod 777 /home/public && \
  cp /root/vsftpd.conf /etc && \
  mkdir -p /var/run/vsftpd/empty
CMD ["/usr/bin/python3", "/root/init.py"]