import ftplib
import os
import time
import datetime

user = os.environ.get('BOT_NAME', '')
password = os.environ.get('BOT_PASSWORD', '')
server = os.environ.get('FTP_SERVER', '')

if user != '' and password != '' and server != '':

    time.sleep(10)

    while True:

        ftp = ftplib.FTP(server)
        ftp.login(user, password)

        data = []

        ftp.dir(data.append)

        ftp.quit()

        os.system('echo " ** ' + datetime.datetime.now().strftime('%H:%M:%S') + '"')

        for line in data:
            os.system('echo "- ' + line + '"')
        time.sleep(10)

else:
    print('Server, user or password not provided.')