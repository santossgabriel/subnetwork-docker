import ftplib
import os
import time
import datetime

user = os.environ.get('BOT_NAME', '')
password = os.environ.get('BOT_PASSWORD', '')
server = os.environ.get('FTP_SERVER', 'ftp.fakebank.lab')
timer_sec = int(os.environ.get('TIMER_SECONDS', '10'))

def ftp_run():
    time.sleep(timer_sec)
    os.system('echo " ** ' + datetime.datetime.now().strftime('%H:%M:%S') + '"')
    try:
        ftp = ftplib.FTP(server)
        ftp.login(user, password)
        data = []
        ftp.dir(data.append)
        ftp.quit()
        for line in data:
            os.system('echo "- ' + line + '"')
    except ConnectionRefusedError:
        print('Connection refused server ' + server)

if user != '' and password != '' and server != '':
    while True:
        ftp_run()

else:
    print('User or password not provided.')