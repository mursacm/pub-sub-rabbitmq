# pub-sub-rabbitmq
Publish Subscribe design pattern with RabbitMQ
https://www.rabbitmq.com/

step 1
open a terminal and execute command
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.11-management

- creates a docker image on your machine 

step 2
open a terminal and locate the Subscriber Folder
> cd .\Subscriber\
> dotnet run 

- the subscriber will listen to the EventConsumer for any message

step 3
open a terminal and locate the Publisher Folder
> cd .\Publisher\
> dotnet run "test 231343" "sadasd asdwe54345" "asdasd 234hg23khj4fg23khj4"

- this will start the Publisher and Transform (our case it's just an uppercase) and send each message from args
you can now see in the Subscriber's terminal all received messages
