# Ligação Node-RED -> Azure IoT Hub








A visualização dos dados na Microsoft Azure não é direta – é preciso fazer um conjunto de passos para ser possível.

O que pode-se fazer antes da realização desses passos é testar a conectividade e visualizar o payload do Node-RED na plataforma Azure.

Para tal, é necessário usar o cloud shell (correspondente à linha de comandos, mas da própria cloud).

<img width="1433" height="621" alt="image" src="https://github.com/user-attachments/assets/3e84074f-322e-4b96-b8ad-8fceb20aaad7" />

O comando a ser usado é o seguinte:

```
az iot hub monitor-events --hub-name [nome do iot hub criado] --output json

```

Deve ser utilizada a *Bash session* para executar o comando.

<img width="1270" height="916" alt="image" src="https://github.com/user-attachments/assets/f32b303f-2b5c-4716-b579-9ad497ee0b41" />



Após aceitar a instalação das extensões e do primeiro conjunto de dados foi enviado, irá aparecer a seguinte imagem:

<img width="1891" height="220" alt="image" src="https://github.com/user-attachments/assets/19160cae-f138-4eac-841f-049763e2f964" />

Esta imagem confima que os dados estão a ser enviados para a Cloud.
