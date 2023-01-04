#!/bin/sh

LARGE_SECRET_PASSPHRASE=x

# move the files to be decrypted to a temp folder
for x in ./Controllers/*.cs.gpg;
do
    mv $x ./_tmp_decrypt/
done

# decrypt and rename the files
for f in ./_tmp_decrypt/*.cs.gpg;
do
    NEW_NAME="${f%.cs.gpg}.cs"
    gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" --pinentry-mode loopback \
    --output $NEW_NAME $f
done

# move the decrypted files back
for x in ./_tmp_decrypt/*.cs;
do
    mv $x ./Controllers/
done

# Decrypt the appsettings.json file
gpg --quiet --batch --yes --decrypt --passphrase="$LARGE_SECRET_PASSPHRASE" \
--output ./appsettings.json ./appsettings.json.gpg

# dotnet restore project
dotnet restore ./api.engine-v2.sln

# Rename project file (temp)
mv ./docker-compose.dcproj ./docker-compose.dcproj_

Generate migrations
dotnet ef migrations add AddLookupTables