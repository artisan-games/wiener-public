#!/bin/bash

SRC_PATH="$(pwd)/makes/csharp"
DST_PATH="$(pwd)/XXX"
DST_FOLDER="csharp";

if [ ! -e $DST_PATH ] ; then
	mkdir -p $DST_PATH
fi

rm -rf $DST_PATH/$DST_FOLDER/**/*.cs
rm -rf $DST_PATH/$DST_FOLDER/*.cs

rsync -a --inplace $SRC_PATH/ $DST_PATH/$DST_FOLDER
