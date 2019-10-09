#!/bin/bash
echo "mkdocs build"
mkdocs build
echo "upload"
ncftpput -R -v -u "ftpc52_iottul" ftp.iot-tul.p.lodz.pl /web/ ./site/*
