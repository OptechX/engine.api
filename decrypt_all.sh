#!/bin/sh

# for i in ./Controllers/*.cs;
# do
#     LARGE_SECRET_PASSPHRASE=x
#     gpg --passphrase=$LARGE_SECRET_PASSPHRASE --pinentry-mode loopback --symmetric --cipher-algo AES256 $i
# done

for x in ./Controllers/*.cs.gpg;
do
    mv $x ./Controllers2/
done

for f in ./Controllers2/*.cs.gpg;
do
    NEW_NAME="${f%.cs.gpg}.cs"
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" --pinentry-mode loopback \
    --output $NEW_NAME $f
done

for z in ./Controllers2/*.cs.gpg;
do
    rm -rf $z
done

for z in ./Controllers/*.cs.gpg;
do
    rm -rf $z
done

for x in ./Controllers2/*.cs;
do
    mv $x ./Controllers/
done