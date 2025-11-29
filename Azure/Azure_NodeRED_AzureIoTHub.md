# Ligação Node-RED -> Azure IoT Hub



O primeiro passo desta ligação passa pela criação e configuração da Azure IoT Hub. 


Quando estiver na página, clique em *create*

<img width="294" height="151" alt="image" src="https://github.com/user-attachments/assets/16101cbe-17a9-4fd5-ba68-773c8f9115ea" />

Clique em *Create New* para inserir o Resource Group. Para ser mais fácil use este grupo em todos os restantes serviços se for possível. Clica em *Review and create*.

Preenche o restante de acordo com a imagem seguinte.

<img width="805" height="668" alt="image" src="https://github.com/user-attachments/assets/e8b0653a-4333-46ef-8886-6475a3c1b247" />



O passo seguinte passa pela criação de *devices*. Um device é.... __(explicar como "vocabulário" da Microsoft Azure)__. Vá na barra lateral do lado esquerdo e em *Device management*, entre em *Devices* 


<img width="287" height="456" alt="image" src="https://github.com/user-attachments/assets/06a92a06-aad7-4411-a2fd-4f7579ccb282" />

Na página clique em *Add device*.

<img width="415" height="702" alt="image" src="https://github.com/user-attachments/assets/492867a4-305f-47f2-8172-1f24eef3441b" />

Insira um nome para o *device* e selecione as restantes opções de acordo como está na imagem.

<img width="415" height="702" alt="image" src="https://github.com/user-attachments/assets/41717999-4001-483b-adcb-06bb4d5cb4b3" />


Quando estiver criado pode clicar no nome do dispositivo, onde poderá ver as credenciais como na imagem abaixo

<img width="1324" height="627" alt="image" src="https://github.com/user-attachments/assets/7c8709f2-b547-4981-a010-c6e32a75e9a5" />
























































































































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
