FROM baselab:1.0
ARG DEBIAN_FRONTEND=noninteractive
COPY files /root/app
RUN wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
  dpkg -i packages-microsoft-prod.deb && \
  apt update && \
  curl -sL https://deb.nodesource.com/setup_12.x | bash - && \
  apt install -y aspnetcore-runtime-3.1 dotnet-sdk-3.1 nodejs && \
  dotnet publish -o /root/publish /root/app/ && \
  mv /root/app/wwwroot /root/publish/wwwroot && \
  apt remove dotnet-sdk-3.1 nodejs -y && \
  rm -rf app .npm .nuget .local && \
  apt clean
WORKDIR /root/publish
CMD [ "/usr/bin/dotnet", "/root/publish/Site.dll", "--urls=http://*" ]