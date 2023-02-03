#!/bin/bash

# remove building directories
rm -rf bin
rm -rf obj

# build local with development setup
DOCKER_BUILD_VERSION="2.0-local"
DOCKER_IMAGE_NAME="optechx/engine.api.local"
docker stop optechx-engine.api.local
docker rmi "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION" --force
docker build --rm --no-cache --tag "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION" --file Dockerfile.local .
# run docker image
docker run --rm -it -d -p 5000:5000 --name optechx-engine.api.local "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION"

# build local with production setup
DOCKER_BUILD_VERSION="2.0-local-prod"
DOCKER_IMAGE_NAME="optechx/engine.api.local"
docker rmi "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION"
sed -i.bak -e '18d' Properties/launchSettings.json
FILE=Properties/launchSettings.json
if [ -f "$FILE" ]; then
  mv Properties/launchSettings.json.bak secrets/launchSettings.json.bak
fi
docker build --rm --no-cache --tag "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION" --file Dockerfile.prod .
rm -f "$FILE"
mv secrets/launchSettings.json.bak Properties/launchSettings.json
