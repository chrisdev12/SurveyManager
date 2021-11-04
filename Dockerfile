FROM mcr.microsoft.com/mssql/server:2019-latest
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD='Str0ngPa$$w0rd'
EXPOSE 1433
COPY ./Miscellaneous/DbScripts/dbSchemaSetup.sql .
COPY ./Miscellaneous/DbScripts/creationTables.sql .
COPY ./Miscellaneous/DbScripts/storedProcedures.sql .
#Init min db requirements:
# 1. Create the database.
# 2. Emulate the creation of a db schema needed for the creation of tables and stored procedures.
# 3. Create the tables.
# 4. Define the proper stored procedures.
RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Str0ngPa$$w0rd' -Q 'CREATE DATABASE IVR_Survey' \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Str0ngPa$$w0rd' -i dbSchemaSetup.sql \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Str0ngPa$$w0rd' -i creationTables.sql \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Str0ngPa$$w0rd' -i storedProcedures.sql \
    && pkill sqlservr