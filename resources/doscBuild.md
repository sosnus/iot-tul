#if it is necessary
## sudo apt-get install ncftp
mkdocs build
ls ./site

ncftpput -R -v -u "ftpc52_iottul" ftp.iot-tul.p.lodz.pl /web/ ./site/*

