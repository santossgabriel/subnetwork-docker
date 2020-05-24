## **Dns server in docker container**
1. Build image
```
docker build -t dns:1.0 . 
```
2. Run image
```
docker run -d -e DEFAULT_DNS_DOMAIN=example.local dns:1.0  
```
3. Add new host
```
docker exec <container_id> newhost <sub_domain> <ip>
```
Obs.: Ip in range [1-200] and only works in /24 networks
