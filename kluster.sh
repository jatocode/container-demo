#!/bin/sh

# Visa vilket context vi kör
kubectl config current-context

# Installera ingress-nginx
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.2.0/deploy/static/provider/cloud/deploy.yaml
kubectl wait --namespace ingress-nginx   --for=condition=ready pod   --selector=app.kubernetes.io/component=controller   --timeout=120s

# Lägg in vår nyckel
kubectl create secret docker-registry containerdemo --docker-server=containerdemotsja.azurecr.io --docker-username=containerdemotsja --docker-password=5XTXmXY=k99nHttxaJZPkdYrNlz88dNe

# Kolla extern IP-address
kubectl get service -n ingress-nginx
