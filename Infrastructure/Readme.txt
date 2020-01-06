Infrastructure has all external (async) dependencies.

It is used by Application layer to persist entities, and to send email, sms, or communicate with other APIs.

We create  MySQL and InMemory (non-relational) repositories, for production and testing.
Any database or data-source can be implemented by a Repository - ie fetch data from another API.

We don't want to force data to be stored in same way as the domain model, so we have 1:1 Dao Models which are mapped to the domain entities.