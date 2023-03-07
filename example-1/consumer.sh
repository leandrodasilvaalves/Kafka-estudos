#!/bin/bash

dotnet run --project consumer $(pwd)/getting-started.properties cg1

# rodar consumers em outro consumer group
# dotnet consumer/bin/Release/net6.0/consumer.dll $(pwd)/getting-started.properties cg1 

# dotnet consumer/bin/Release/net6.0/consumer.dll $(pwd)/getting-started.properties cg2 