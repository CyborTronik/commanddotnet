#!/usr/bin/env bash

# use this line on mac/linux.
#docker run --rm --name mkdocs-material -it -v ${PWD}:/docs squidfunk/mkdocs-material build

# use this line on windows to escape the path conversion on windows.  
# https://stackoverflow.com/questions/50608301/docker-mounted-volume-adds-c-to-end-of-windows-path-when-translating-from-linux
docker run --rm --name mkdocs-material -it -v /${PWD}:/docs squidfunk/mkdocs-material build --strict