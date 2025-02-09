minikube start 
kubectl get nodes
kubectl create namespace gym-app

kubectl apply -f kubernetes/
kubectl get all -n gym-app
kubectl logs -n gym-app -l app=gym-app
# kubectl port-forward svc/gym-app-service 8080:80 -n gym-app
