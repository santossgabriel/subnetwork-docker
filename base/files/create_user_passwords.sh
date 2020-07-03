#!/bin/bash

rm -rf users_password

for u in $(cat external_users > users_temp && echo "" >> users_temp && cat internal_users >> users_temp && cat users_temp && rm users_temp);do
  USER_PASSWORD=`uuidgen |sed "s/-//g"`
  echo "$u-$USER_PASSWORD" >> users_password
done