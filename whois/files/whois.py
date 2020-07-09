import socket
import traceback
from pathlib import Path

host_ip = socket.gethostbyname(socket.gethostname())

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

s.bind((host_ip, 43))
s.listen(1)

print('Waiting queries...')

str_format = 'utf-8'

while True:
    try:
        c, client_address = s.accept()
        print('Query from: ' + str(client_address))
        domain = c.recv(1024).decode(str_format).replace('\n', '').replace('\r', '')
        print('Domain: |' + domain + '|')
        answer = 'No whois server is known for this kind of object.'
        if Path(domain).is_file():
            with open(domain) as f:
                answer = ''
                for l in f.readlines():
                    answer += l
        c.send(bytes(answer, str_format))
    except Exception as e:
        print(traceback.format_exc())
    finally:
        c.shutdown(socket.SHUT_RDWR)
        c.close() 