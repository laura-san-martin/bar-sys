FROM mongo

COPY ./jsondata/users.json /users.json
CMD mongoimport --drop --host mongo_db --db aada_backend --collection users --type json --file /users.json --jsonArray
