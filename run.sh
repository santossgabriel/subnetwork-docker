docker network create --subnet=172.18.0.0/16 hack-network

docker run -it -d --net hack-network --name client_1 ubuntu:1.0 bash