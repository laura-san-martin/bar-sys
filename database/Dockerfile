FROM mongo
WORKDIR /jsondata

COPY ./jsondata/ .
COPY ./seed.sh .

CMD mongoimport --drop --host mongo --db bar --collection users --type json --file /users.json --jsonArray