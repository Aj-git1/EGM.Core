#Prerequisites:

*.NET SDK 9.0+

#Implements:

*State machine (IDLE, RUNNING, MAINTENANCE, UPDATING, ERROR)
*Game update with rollback
*Door open → maintenance transition
*Bill validator keep-alive (10s ping + timeout)
*Controlled OS timezone change with audit logging
*Centralized CLI simulation harness

#Supported Commands:

*start_game
*stop_game
*signal door_open
*device bill_validator ack on
*device bill_validator ack off
*update --package v2
*version
*os set-timezone Africa/Conakry
*os show
*status
*exit

#Example Demo Flow:

*start_game
*signal door_open
*device bill_validator ack off
*update --package v2.txt
*os set-timezone Africa/Conakry
*status
