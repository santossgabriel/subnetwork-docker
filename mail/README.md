## **Webmail server for dev tests**

****
**Credentials:** admin:admin

1. Build image:
```
docker build -t mail:1.0 .
```
2. Run image:
```
docker run -d mail:1.0
```
3. Create new user:
```
docker exec <container_id|name> sh new-user.sh <user> <password>
```
Source: <a href="https://sourceforge.net/projects/squirrelmail/files/stable/1.4.22/squirrelmail-webmail-1.4.22.zip">Squirrel Mail</a>