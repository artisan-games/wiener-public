#!/bin/bash

SRC_PATH="$(pwd)/makes/bytes/basic.bytes"
DST_PATH="$(pwd)/XXX/basic.bytes"

rm -rf $DST_PATH
cp $SRC_PATH $DST_PATH
