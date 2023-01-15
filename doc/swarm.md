# Starta swarm mode
docker swarm init

# Dra upp stacken

docker stack deploy -f docker-compose-prod.yml containerdemo


# Ta ner stacken

docker stack rm containerdemo
