#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
	CREATE USER travels WITH PASSWORD '1234';
    CREATE DATABASE travels;
    GRANT ALL PRIVILEGES ON DATABASE travels TO travels;
EOSQL