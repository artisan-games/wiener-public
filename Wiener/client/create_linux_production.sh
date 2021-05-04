#!/bin/bash

cd `dirname $0`

Converter="$(pwd)/../tools/wiener/linux/wiener"
YamlPath="$(pwd)/yaml"
ExcelPath="$(pwd)/../excel"
TemplatePath="$(pwd)/../template"
OutputPath="$(pwd)/makes"
TimeZone="Asia/Tokyo"

if [ -e $OutputPath ]; then rm -r $OutputPath; fi

echo -n Tag: 
read Tag

$Converter \
	-output_format CSharp \
	-output_format Csv \
	-yaml_search_path $YamlPath \
	-excel_search_path $ExcelPath \
	-template_path $TemplatePath \
	-output_path $OutputPath \
	-timezone $TimeZone \
	-ignore_excel "TEST_.*.xlsm" \
	-tag $Tag
