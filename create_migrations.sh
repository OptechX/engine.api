#!/bin/bash

# Get the current directory
current_dir=$PWD

# remove building directories
rm -rf "$PWD/bin"
rm -rf "$PWD/obj"

# Clean all the project data
dotnet clean "$PWD/engine.api.sln"

# hide the current DockerCompose project
mv "$PWD/docker-compose.dcproj" "$PWD/docker-compose.dcpro_"

# update the dotnet ef tools
dotnet tool update dotnet-ef --global

# restore the project
dotnet restore

# create the initial migrations
dotnet ef migrations add LookupTables

# migrate to the target DB server
dotnet ef database update

# unhide the current DockerCompose project
mv "$PWD/docker-compose.dcpro_" "$PWD/docker-compose.dcproj"