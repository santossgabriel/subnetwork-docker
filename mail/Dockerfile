FROM core:1.0
RUN apt install -y apache2
COPY squirrelmail-1.4.13.tar.gz .
COPY squirrelmail.conf .
RUN mkdir /usr/local/squirrelmail
RUN cp squirrelmail.conf /etc/apache2/sites-available/
RUN tar -xvf squirrelmail-1.4.13.tar.gz
RUN mv squirrelmail-1.4.13 /usr/local/squirrelmail/www
RUN cd /usr/local/squirrelmail
RUN mkdir data temp attachments
RUN chgrp nogroup data temp attachments
RUN chmod 0730 data temp attachments
RUN a2ensite squirrelmail
RUN /etc/init.d/apache2 reload