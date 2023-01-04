#!/bin/sh

for f in ./Controllers/*.cs.gpg;
do
    NEW_NAME="${f%.cs.gpg}.cs"
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
    --output $NEW_NAME $f
done