#!/bin/bash

rm -rf bin
rm -rf obj

DOCKER_BUILD_VERSION="2.0-local"
DOCKER_IMAGE_NAME="repasscloud/optechx.engine.api.local"
docker build --rm --no-cache --tag "$DOCKER_IMAGE_NAME:$DOCKER_BUILD_VERSION" --file Dockerfile.local .