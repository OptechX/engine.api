#!/bin/sh

# NOTE: Quote it else use array to avoid problems #
for f in ./Controllers/*.cs;
do
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
    --output ./appsettings.json ./appsettings.json.gpg
  #echo -e "$LARGE_SECRET_PASSPHRASE" | gpg -c --pinentry-mode loopback --passphrase-fd 0 $f
done