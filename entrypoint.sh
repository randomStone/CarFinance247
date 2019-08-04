#!/bin/bash

set -e
run_cmd="dotnet run --project ./CarFinance247TechTest"

dotnet run --project ./CarFinance247DBUpScripts


>&2 echo "Starting Server"
exec $run_cmd