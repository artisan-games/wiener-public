@echo off

set Converter="%CD%\..\tools\wiener\windows\wiener.exe"
set YamlPath="%CD%\yaml"
set ExcelPath="%CD%\..\excel"
set TemplatePath="%CD%\..\template"
set OutputPath="%CD%\makes"
set TimeZone="Tokyo Standard Time"
set LocalizeExcelPath="Extra\Localize.xlsx"

if exist %OutputPath% rmdir /S /Q %OutputPath%

%Converter% ^
	-output_format CSharp ^
	-output_format Csv ^
	-yaml_search_path %YamlPath% ^
	-excel_search_path %ExcelPath% ^
	-template_path %TemplatePath% ^
	-output_path %OutputPath% ^
	-timezone %TimeZone% ^
	-localize_excel %LocalizeExcelPath%

pause
