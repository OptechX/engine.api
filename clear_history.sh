#!/bin/sh

rm -rf .git
git init
git add .
git commit -m "Removed history, due to sensitive data"
git remote add origin git@github.com:optechx/engine.api.git
git push -u --force origin main