#!/bin/sh

LARGE_SECRET_PASSPHRASE=x

# decrypt data
bash ./decrypt_repo.sh

# dotnet restore project
dotnet restore ./api.engine-v2.sln

# Rename project file (temp)
mv ./docker-compose.dcproj ./docker-compose.dcproj_

# Generate migrations
datecode=$(date +%Y%m%d%H%M%S)
dotnet ef migrations add "AddLookupTables$datecode"

# run migrations
dotnet ef database update

# remove junk
rm -rf obj
rm -rf bin

# encrypt data
bash ./encrypt_repo.sh

# save the state
git add .
git commit -m "auto update $datecode"
git push

# clean up git repo locally
git reset --hard
git clean -fxd
