@echo off
:start
echo you at start
echo 1 - node 12
echo 2 - node 13
set /p var=input:
if "%var%" == "1" goto 12
if "%var%" == "2" goto 13
:12
echo you at 12
echo 1 - node 23(exit)
echo 2 - node 24
set /p var=input:
if "%var%" == "1" goto 23
if "%var%" == "2" goto 24
	:23
	goto exit
	:24
	echo you at 22
	echo 1 - node 31
	set /p var=input:
	if "%var%" == "1" goto 11
		:11
		echo you at 11
		echo 1 - node 21(exit)
		echo 2 - node 22
		set /p var=input:
 		if "%var%" == "1" goto 21
		if "%var%" == "2" goto 22
			:21
			goto exit
			:22
			echo you at 22
			echo 1 - start node
			set /p var=input:
			if "%var%" == "1" goto start
                   
:13
echo you at 13
echo 1 - node 25(exit)
echo 2 - node 26
set /p var=input:
if "%var%" == "1" goto 25
if "%var%" == "2" goto 26
		:25
		goto exit
		:26
		echo you at 26
		echo 1 - start node
		set /p var=input:
		if "%var%" == "1" goto start
:exit
