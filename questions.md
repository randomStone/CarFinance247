# TASK 3 Questions

## Be deployed to a live environment

I would use an CI server such as Jenkins or Teamcity to create a pipeline that would build, test and deploy the app to production. Using docker it would be as simple as setting the env variable DOCKER_HOST to the prod server and running docker-compose to actually deploy the app. I would have to include some logic in the dbup scripts so that it does not seed the production db with test data.

## Handle a large volume of requests, including concurrent creation and update operations

First of all I would consider using a in-memory cache such as Radis that would store regularly requested Customers to decrease read requests on the db.Also we could replicate the db which most Database engines support in some way. We can then distribute the reads across multiple read databases.

For concurrent writing to the db I would use an optimistic approach to concurrently as locking rows that are being read and writing toW would lead to performance degradation. In MS Sql Server there is a column type called rowversion is increments everytime the row is changed. If we include this column in the where clause of an update then if the rowversion changes then the update can not find the row and the update will fail. We would be able to tell if the update is successful or not as the dapper ExecuteAsync function will return number of rows affected.

## Continue operating in the event of problems reading and writing from the database

Again the use of a cache can be quite useful here especially if you used write-through strategy (where you write to cache when you write to the database) as the app could still read from that.
and this is another place where replication could come in useful as you can failover to another replica db with hopefully better connection.

## Ensure the security of the user information

First of all the password field needs to be hashed and salted with a secure hashing algorithm. Here I would try and outsource storing sensitive data like that to a service such as IdentityServer or AWS Cognito or Auth0  to actually deal with authentication and passwords as the risk of getting something wrong with your own homegrown solution is not worth taking. Second of all I would enable https on the server so no data is leaked in transport. Third of lock down the endpoints so only those who are authorized and authenticated to use them. And finally I would not return the Customer Password as part of any response.
