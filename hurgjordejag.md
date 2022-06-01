# API

## Installerade 
> dotnet new web -o DemoAPI
> dotnew new gitignore
> dotnet dev-certs https --trust
> cd DemoAPI

## La till Swagger
> dotnet add package Swashbuckle.AspNetCore

I koden efter var builder..
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

efter var app
app.UseSwagger();

innan app.run
app.UseSwaggerUI();

# FrontEnd

## Installerade

 > npx create-react-app client --template typescript

## Ändrade lite kod i App.tsx

Hämtade data från min backend

## cors-fel så la till i API:
builder.Services.AddCors();

app.UseCors(c => c.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials());

## react strict.mode runt app gjorde att det renderades dubbelt

# Docker

## API

La till Dockerfile manuellt
Pekar på min DLL
docker build -t api:latest .
docker run -p 5111:80 api:latest

## Client

La till Dockerfile manuellt
docker build -t frontend:latest .

docker run -p 3000:3000 client:latest

# Nu vill vi starta båda samtidigt

## Docker-compose

Skapade compose fil manuellt
fick lägga in context som pekar på byggen

# Kubernetes

Skapade service + deploy filer

# Slå på en ingress

## Först en standard ingress nginx-controller 
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.2.0/deploy/static/provider/cloud/deploy.yaml
kubectl wait --namespace ingress-nginx \
  --for=condition=ready pod \
  --selector=app.kubernetes.io/component=controller \
  --timeout=120s

## Gör en egen ingress

Skapade ingress med mina sökvägar

## Komma åt den

Gör port-fw till porten som api ligger på för att matcha hårdkodat i clienten

 kubectl port-forward service/ingress-nginx-controller -n ingress-nginx 5111:80

# Registry
http://portal.azure.com skapa ett registry
docker login -u containerdemotsja -p 5XTXmXY=k99nHttxaJZPkdYrNlz88dNe containerdemotsja.azurecr.io
docker-compose push 

kubectl create secret docker-registry containerdemo --docker-server=containerdemotsja.azurecr.io --docker-username=containerdemotsja --docker-password=5XTXmXY=k99nHttxaJZPkdYrNlz88dNe 

# AKS

az login
az account set --subscription "Visual Studio Professional"

.. sen samma med ingress
kubectl create secret docker-registry containerdemo --docker-server=containerdemotsja.azurecr.io --docker-username=containerdemotsja --docker-password=5XTXmXY=k99nHttxaJZPkdYrNlz88dNe 



# Överkurs, servicemesh

curl --proto '=https' --tlsv1.2 -sSfL https://run.linkerd.io/install | sh

linkerd check --pre
 ( på windows sa den: try installing with --set proxyInit.runAsRoot=true)

linkerd install --set proxyInit.runAsRoot=true | kubectl apply -f -

linkerd check

linkerd inject k8s/client-deploy.yaml | kubectl apply -f -
linkerd inject k8s/api-deploy.yaml | kubectl apply -f -

om man vill ha en dashboard: linkerd viz install | kubectl apply -f -

linkerd viz dashboard