#!/bin/python3

import os
import subprocess
import re
import time
import json

bind_dir = './bind/'

print('***** Bind DNS Server *****')

arr_ip = subprocess.Popen('ifconfig docker0 | grep netmask', shell=True, stdout=subprocess.PIPE).stdout.readline().decode('utf-8').split(' ')
host_ip = arr_ip[arr_ip.index('inet')+1]
arr_ip = host_ip.split('.')

def update():
  with open('../config.json') as f:
    config = json.loads(f.read())

  with open('./named.conf.options') as f:
    named_conf_options = f.read()
    named_conf_options = named_conf_options.replace('##HOST_IP_NETMASK##', f'{arr_ip[0]}.{arr_ip[1]}.{arr_ip[2]}.0/24', 99)
    named_conf_options = named_conf_options.replace('##forwarders##', '; '.join(config['forwarders']) + ';' )

  with open(bind_dir + 'named.conf.options', 'w') as f:
    f.write(named_conf_options)


  named_conf_local = ''
  for z in config['zones']:
    with open('named.conf.local') as f:
      print(z['domain'])
      ncl = f.read().replace('##DNS_DOMAIN##', z['domain'])
      ncl = ncl.replace('##REV_IP##', z['rev'])

    named_conf_local += ncl + '\n\n'

    with open('reverse.template.local') as f:
      reverse = f.read().replace('##HOST_IP_LAST_OCTECT##', arr_ip[3])
    reverse = reverse.replace('##DNS_DOMAIN##', z['domain'])
    reverse = reverse.replace('##HOST_IP##', host_ip)

    with open('forward.template.local') as f:
      forward = f.read().replace('##DNS_DOMAIN##', z['domain'])
    forward = forward.replace('##HOST_IP##', host_ip)

    for h in z['hosts']:
      reverse += f"\n{h['ip']} IN PTR {h['subdomain']}"
      forward += f"\n{h['ip']} IN A {h['subdomain']}"

    with open(bind_dir + 'reverse.' + z['domain'], 'w') as f:
      f.write(reverse)


    with open(bind_dir + 'forward.' + z['domain'], 'w') as f:
      f.write(forward)

  
  with open(bind_dir + 'named.conf.local', 'w') as f:
    f.write(named_conf_local)

  
    


update()


# for i in zones:
#   print(i['domain'])


# content = ''
# with open('./forward.example.local') as f:
#   for l in f.readlines():
#     x.replace('##DNS_DOMAIN##', dns_domain, 99).replace()

# content = [x.replace('##DNS_DOMAIN##', dns_domain, 99) for x in content]
# print(content)

# sed -i "s/{HOST_IP}/$HOST_IP/g" /etc/bind/*
# sed -i "s/{HOST_IP_LAST_OCTECT}/$HOST_IP_LAST_OCTECT/g" /etc/bind/*
# sed -i "s/{HOST_IP_FIRST_OCTECTS}/$HOST_IP_FIRST_OCTECTS/g" /etc/bind/*
# sed -i "s/{REV_HOST_IP_FIRST_OCTECTS}/$REV_HOST_IP_FIRST_OCTECTS/g" /etc/bind/*


# print(domain)

# i = 0
# while True:
#   time.sleep(1)
#   # print(++i)
