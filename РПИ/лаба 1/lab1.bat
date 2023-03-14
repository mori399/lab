@echo off
:start
echo you at main menu
echo 1 - registration 12
echo 2 - login 13
set /p var=input:
if "%var%" == "1" goto 12
if "%var%" == "2" goto 13
:12
echo you at registration 12
echo 1 - exit 23
echo 2 - accept user agreement 24
set /p var=input:
if "%var%" == "1" goto 23
if "%var%" == "2" goto 24
	:23
	goto exit
	:24
	echo you accept user agreement 22
	echo 1 - create a new profile 11
	set /p var=input:
	if "%var%" == "1" goto 11
		:11
		echo you create a new profile 11
		echo 1 - exit 21
		echo 2 - edit profile 22
                echo 3 - main menu
		set /p var=input:
 		if "%var%" == "1" goto 21
		if "%var%" == "2" goto 22
                if "%var%" == "3" goto start
			:21
			goto exit
			:22
			echo you edit profile 22
			echo 1 - main menu
			set /p var=input:
			if "%var%" == "1" goto start
                   
:13
echo you login 13
echo 1 - exit 25
echo 2 - enter password 26
set /p var=input:
if "%var%" == "1" goto 25
if "%var%" == "2" goto 26
		:25
		goto exit
		:26
		echo you enter password 26
		echo 1 - main menu
		set /p var=input:
		if "%var%" == "1" goto start
:exit
