## **Dns server in docker container**
1. Build image
```
docker build -t dns:1.0 . 
```
2. Run image
```
docker run -d --name dns -e DEFAULT_DNS_DOMAIN=example.local dns:1.0  
```
**Obs:** Default network is 172.17.0.0/16