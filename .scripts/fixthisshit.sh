#!/bin/sh

for i in $(find . -name "toc.yml"); do
    "Fixing $i"
    rm "$i"
done
