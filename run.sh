docker network create --subnet=172.20.20.0/24 in-lab
docker network create --subnet=172.30.30.0/24 ex-lab
docker run -d --name mail --net in-lab --ip 172.20.20.10 mail:1.0 
docker run -d --name dns -e DEFAULT_DNS_DOMAIN=test.lab --net in-lab --ip 172.20.20.20 dns:1.0 
docker run -it --name client1 --net in-lab --dns 172.20.20.20 ubuntu:1.0 /bin/bash