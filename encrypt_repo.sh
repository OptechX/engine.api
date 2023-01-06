#!/bin/sh

# define the decryption key
SECRET_PASSWORD=X
#LARGE_SECRET_PASSPHRASE=$SECRET_PASSWORD

# find all files to encrypt
toEncrypt=`find . -name "*.cs"`

# iterate each file and encrypt using gpg
for file in ${toEncrypt[@]}
do
  # file to target
  f="$file"

  # output file
  g="$f.gpg"

  # remove exising gpg file if found
  if [ -f "$g" ]; then
    rm -rf "$g"
  fi

  # encrypt the file
  gpg --passphrase="$LARGE_SECRET_PASSPHRASE" --pinentry-mode loopback --symmetric --cipher-algo AES256 "$f"

  # remove old file
  if [ -f "$g" ]; then
    rm -f $f
  fi
done

# declare array of files to encrypt  <~ does NOT use comma between articles!
toEncrypt=(
    "secrets/data/caddy/nginx/index.html"
    "secrets/data/caddy/Caddyfile"
    "secrets/docker-compose.yml"
    "secrets/user_host_rsa"
    "appsettings.json"
    "appsettings.dev.json"
)

# iterate each file and encrypt using gpg
for file in ${toEncrypt[@]}
do
  # file to target
  f="$file"

  # output file
  g="$f.gpg"

  # remove exising gpg file if found
  if [ -f "$g" ]; then
    rm -rf "$g"
  fi

  # encrypt the file
  gpg --passphrase=$LARGE_SECRET_PASSPHRASE --pinentry-mode loopback --symmetric --cipher-algo AES256 "$f"

  # remove old file
  if [ -f "$g" ]; then
    rm -f $f
  fi
done
