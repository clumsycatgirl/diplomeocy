@echo off
start npm --prefix Scripts run css:watch
start docker-compose up
start npm --prefix Scripts run watch
