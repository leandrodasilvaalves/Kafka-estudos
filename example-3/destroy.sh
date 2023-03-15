#!/bin/bash

destroy="kubectl delete -f K8S/Services"
$destroy/Payments 
$destroy/Logs  
$destroy/Emails   
$destroy/Orders 
$destroy/Configs 

destroy="kubectl delete -f K8S/Broker"
$destroy/Kafka-UI 
$destroy/Kafka  
$destroy/Zookeeper 