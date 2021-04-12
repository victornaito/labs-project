#!/bin/bash

read migrationName

dotnet ef migrations add $migrationName -v
echo "migration" + $migrationName + "criado com sucesso"