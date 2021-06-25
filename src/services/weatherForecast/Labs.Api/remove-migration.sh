#!/bin/bash

#teste=IFS=data: read -a migrationName < $(dotnet ef migrations list --no-build --prefix-output)

#echo $(dotnet ef migrations list --no-build --prefix-output)

#echo "'${migrationName[0]}'"
dotnet ef migrations remove -v
echo migration removido com sucesso