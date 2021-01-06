# How to run

## Build Image
```
docker build -t {image_name} .
```

## Run
```
docker run -it --rm -p {host_port}:5000 --name {container_name} {image_name}
```

## Resources
http://localhost:7000/api/Department   
http://localhost:7000/api/Department/1  
http://localhost:7000/api/Student  
http://localhost:7000/api/Student/1
