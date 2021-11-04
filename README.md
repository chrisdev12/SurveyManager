#WebService Survey

#Test integration enviroment setup | also works for local MSSQL server docker setup if is needed.
alias docker="winpty docker"
1. docker build -q --rm -t mssqltest .
2. docker run -it -d --rm --name mssqltestserver -p 1433:1433 mssqltest
shortcut: docker build -q --rm -t mssqltest . && docker run -it -d --rm --name mssqltestserver -p 1433:1433 mssqltest (will generate multiple images if the command is run several times)