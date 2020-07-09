#!/bin/python3

import os
import subprocess
import re
import time
import json
import datetime
import hashlib
import signal

bind_dir = '/etc/bind/'
config_file = '/root/config.json'

os.system('echo "***** Bind DNS Server *****"')

default_gateway = os.environ.get('DEFAULT_GATEWAY', '')

if default_gateway != '':
  os.system('route del default')
  os.system(f'route add default gw {default_gateway} eth0')

arr_ip = subprocess.Popen('ifconfig eth0 | grep netmask', shell=True, stdout=subprocess.PIPE).stdout.readline().decode('utf-8').split(' ')
host_ip = arr_ip[arr_ip.index('inet')+1]
arr_ip = host_ip.split('.')

def update():
  with open(config_file) as f:
    config = json.loads(f.read())

  with open('./named.conf.options') as f:
    named_conf_options = f.read()
    named_conf_options = named_conf_options.replace('##HOST_IP_NETMASK##', f'{arr_ip[0]}.{arr_ip[1]}.{arr_ip[2]}.0/24', 99)
    
    forwarders = '; '.join(config['forwarders']) + ';'
    if forwarders == ';':
      forwarders = ''
    named_conf_options = named_conf_options.replace('##forwarders##', forwarders )

    transfer = '; '.join(config['transfer']) + ';'
    if transfer == ';':
      transfer = ''
    named_conf_options = named_conf_options.replace('##transfer##', transfer )

    query = '; '.join(config['query']) + ';'
    if query == ';':
      query = ''
    named_conf_options = named_conf_options.replace('##query##', query )

  with open(bind_dir + 'named.conf.options', 'w') as f:
    f.write(named_conf_options)


  named_conf_local = ''
  for z in config['zones']:
    with open('named.conf.local') as f:
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

    try:
      if 'hosts' in z:
        for h in z['hosts']:
          reverse += f"\n{h['ip'].split('.')[3]} IN PTR {h['subdomain']}"
          forward += f"\n{h['subdomain']} IN A {h['ip']}"
    except:
      return 1

    with open(bind_dir + 'reverse.' + z['domain'], 'w') as f:
      f.write(reverse + '\n')


    with open(bind_dir + 'forward.' + z['domain'], 'w') as f:
      f.write(forward + '\n')

  
  with open(bind_dir + 'named.conf.local', 'w') as f:
    f.write(named_conf_local)
  
  os.system('named-checkconf')

  for z in config['zones']:
    os.system(f"named-checkzone {z['domain']} {bind_dir}reverse.{z['domain']}")
    os.system(f"named-checkzone {z['domain']} {bind_dir}forward.{z['domain']}")
    
  os.system('echo "    Forwarders: ' + '; '.join(config['forwarders']) + '"')
  os.system('echo "    Domains:"')

  for z in config['zones']:
    os.system('echo "      ' + z['domain'] + ' ' + z['rev'] + '"')
    if 'hosts' in z:
      for h in z['hosts']:
        os.system('echo "        ' + h['subdomain'] + ' - ' + h['ip'] + '"')

  os.system('echo " ** Updated! ' + datetime.datetime.now().strftime('%H:%M:%S') + '"')
  return 0

with open(config_file, 'r', encoding='utf-8') as f:
  last_hash = hashlib.sha1(f.read().encode('utf-8')).hexdigest()

if update() == 0:
  os.system('service named start')
else:
  os.system('echo " *******  Error in config file  *********"')

class Killer:
  kill_now = False
  def __init__(self):
    signal.signal(signal.SIGINT, self.exit_gracefully)
    signal.signal(signal.SIGTERM, self.exit_gracefully)

  def exit_gracefully(self,signum, frame):
    self.kill_now = True

killer = Killer()

while not killer.kill_now:
  time.sleep(1)

  with open(config_file, 'r', encoding='utf-8') as f:
    new_hash = hashlib.sha1(f.read().encode('utf-8')).hexdigest()

  if new_hash != last_hash:
    os.system('\n\n\necho "*  Updating..."')

    if update() == 0:
      os.system('service named restart')
      last_hash = new_hash
    else:
      os.system('echo " *******  Error in config file  *********"')