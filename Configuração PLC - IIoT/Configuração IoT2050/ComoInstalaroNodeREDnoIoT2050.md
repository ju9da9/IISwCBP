

```
┌─────────────────────────────┐
│  Node.js                    │
│  Node-RED  (porta 1880)     │
│  Mosquitto (porta 1883)     │
└─────────────────────────────┘
```

1️⃣ Preparar diretórios no HOST (IOT2050)



```
mkdir -p /data/iot-stack/node-red
mkdir -p /data/iot-stack/mosquitto/config
mkdir -p /data/iot-stack/mosquitto/data
mkdir -p /data/iot-stack/mosquitto/log
```

Permissões (MUITO IMPORTANTE):

```
chown -R 1000:1000 /data/iot-stack
chmod -R 755 /data/iot-stack
```


2️⃣ Criar configuração básica do Mosquitto

```
nano /data/iot-stack/mosquitto/config/mosquitto.conf
```

Este é o conteúdo a ser inserido no ficheiro:


```
persistence true
persistence_location /mosquitto/data/

log_dest stdout

listener 1883
allow_anonymous true
```
(Sem autenticação por enquanto — depois podemos endurecer)


3️⃣ Criar o Dockerfile

Crie uma pasta de build:

```
mkdir ~/iot-docker
cd ~/iot-docker
```
Crie o Dockerfile:

```
nano Dockerfile
```

Com o seguinte conteúdo:

```
FROM node:22-bookworm

# -------------------------
# Instalar Mosquitto
# -------------------------
USER root
RUN apt-get update && \
    apt-get install -y mosquitto mosquitto-clients && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# -------------------------
# Instalar Node-RED
# -------------------------
RUN npm install -g --unsafe-perm node-red

# -------------------------
# Criar diretórios e permissões
# -------------------------
RUN mkdir -p /data \
    /mosquitto/config \
    /mosquitto/data \
    /mosquitto/log && \
    chown -R node:node /data /mosquitto

# -------------------------
# Copiar entrypoint
# -------------------------
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# -------------------------
# Portas
# -------------------------
EXPOSE 1880 1883

# -------------------------
# Usar utilizador node (UID 1000)
# -------------------------
USER node

ENTRYPOINT ["/entrypoint.sh"]
```

4️⃣ Criar o entrypoint (inicia Mosquitto + Node-RED)


```
nano entrypoint.sh
```
Com o seguinte conteúdo:

```
#!/bin/bash

# Iniciar Mosquitto em background
mosquitto -c /mosquitto/config/mosquitto.conf &

# Iniciar Node-RED
node-red --userDir /data
```

5️⃣ Build da imagem Docker


```
docker build --no-cache -t iot-nodered-mqtt .
```

Confirme:

```
docker images
```

6️⃣ Criar e executar o container

```
docker run -d \
  --name iot-stack \
  -p 1880:1880 \
  -p 1883:1883 \
  -v /data/iot-stack/node-red:/data \
  -v /data/iot-stack/mosquitto/config:/mosquitto/config \
  -v /data/iot-stack/mosquitto/data:/mosquitto/data \
  -v /data/iot-stack/mosquitto/log:/mosquitto/log \
  iot-nodered-mqtt
``` 

7️⃣ Verificar se está tudo a correr


Logs do container

```
docker logs -f iot-stack
```

Deverá ver:

```
Server now running at http://127.0.0.1:1880
```

Testar MQTT no host

```
mosquitto_sub -h localhost -t teste
```
Noutro terminal:

```
mosquitto_pub -h localhost -t teste -m "Olá IOT2050"
```


8️⃣ Testar no Node-RED

No browser:

```
http://IP_DO_IOT2050:1880
```

Comandos a serem usados

| Ação                | Comando                               |
| ------------------- | ------------------------------------- |
| Iniciar             | `docker start iot-stack`              |
| Parar               | `docker stop iot-stack`               |
| Reiniciar           | `docker restart iot-stack`            |
| Logs                | `docker logs -f iot-stack`            |
| Entrar no container | `docker exec -it iot-stack /bin/bash` |
| Criar com volumes   | `docker run -d -v ...`                |
| Atualizar imagem    | `docker build --no-cache`             |
























