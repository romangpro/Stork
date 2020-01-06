Requirements
===========

Must make separate test environment. Use DI for everything. 
Should be one solution for all of ingestion and delivery. Seperation of bound context not needed. 
Logging/Editing etc can remain separate.

Current VideoExpress has functionality to:
* Upload 
* Download 
* Share-Video (invite access code)

1. Login
	- valid user/password
	- forgot password/ reset
	- invite access code.
		- create account ???
		- attach account ??? 

2. Home Page
	+ cluttered.. too much going on. make upload and download seperate pages 
	- your uploads  (from database or whats on hard drive?)
		+ hide, sort by league, season, team, start, game, game-date
		+ you want to hide the finished ones
		+ you want to quickly be able to upload to similar game/league/season
		+ game name -> IMPROVE
		+ show your comment (maybe in details)
		- start, end, progress %->complete, speed (combine? - colour green)
		********** cluttered.. put some details like start, end in "details", whats important is "what" and progress.
		x gameid -> bad to expose!
		x uploadid -> bad to expose!
		- rip video progress?
	
	- your downloads (from database or whats on hard drive?)
		+ hide, sort by league, season, team, start, game, game-date
		+ instead of double click, "Open Folder"

    - non-game uploads (button, screen)
		- dont restrict?
		- tag which team, game, league etc?
		- comment
	- non-game downloads (button, screen)


3. "Game Name" / "File Name" -> shared in common library used by all products
	- date localization (user setup, preference)
	- 2016.01.31 - CaseWestern at NewYorkU. - Test (1836502)


	game, non-game boxscore


2. Upload  (TUS)
	- auth to upload. which league. etc (restrict)
	- pause/resume
	- stop/cancel
	- log and display progress
	- notify external process - ie ops


	
	/	- different permissions for upload/download
