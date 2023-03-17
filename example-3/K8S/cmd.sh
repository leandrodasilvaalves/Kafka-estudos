#!/bin/bash
echo Informe [a] para 'apply' ou [d] para 'delete'
read arg

if [[ $arg = 'a' ]]
then
  command="apply"
elif [[ $arg = 'd' ]]
then
  command="delete"
else
  echo "argumento invalido"
  exit
fi

kbctaction="kubectl $command -f K8S/Broker"
$kbctaction/Kafka-UI 
$kbctaction/Kafka  
$kbctaction/Zookeeper 

kbctaction="kubectl $command -f K8S/Services"
$kbctaction/Configs 
$kbctaction/Payments 
$kbctaction/Logs  
$kbctaction/Emails   
$kbctaction/Orders 
$kbctaction/Configs 