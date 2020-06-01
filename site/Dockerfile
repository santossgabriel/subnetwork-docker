FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
RUN wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
  dpkg -i packages-microsoft-prod.deb && \
  apt update && \
  apt install -y aspnetcore-runtime-3.1 dotnet-sdk-3.1 && \
  mkdir /root/app 
COPY files /root/app
RUN dotnet publish -o /root/publish /root/app/ && \
  rm -rf app
WORKDIR /root/publish
CMD [ "/usr/bin/dotnet", "/root/publish/Site.dll", "--urls=http://*" ]