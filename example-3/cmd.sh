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

destroy="kubectl $command -f K8S/Broker"
$destroy/Kafka-UI 
$destroy/Kafka  
$destroy/Zookeeper 

destroy="kubectl $command -f K8S/Services"
$destroy/Payments 
$destroy/Logs  
$destroy/Emails   
$destroy/Orders 
$destroy/Configs 