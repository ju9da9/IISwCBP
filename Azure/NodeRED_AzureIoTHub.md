# Ligação Node-RED -> Azure IoT Hub



O primeiro passo desta ligação passa pela criação e configuração da Azure IoT Hub. 


Quando estiver na página, clique em *create*

<p align="center">
<img width="294" height="151" alt="image" src="https://github.com/user-attachments/assets/16101cbe-17a9-4fd5-ba68-773c8f9115ea" />
</p>

Clique em *Create New* para inserir o Resource Group. Para ser mais fácil use este grupo em todos os restantes serviços se for possível. Clica em *Review and create*.

Preenche o restante de acordo com a imagem seguinte.

<p align="center">
<img width="805" height="668" alt="image" src="https://github.com/user-attachments/assets/e8b0653a-4333-46ef-8886-6475a3c1b247" />
</p>


O passo seguinte passa pela criação de *devices*. Um device é.... __(explicar como "vocabulário" da Microsoft Azure)__. Vá na barra lateral do lado esquerdo e em *Device management*, entre em *Devices* 

<p align="center">
<img width="287" height="456" alt="image" src="https://github.com/user-attachments/assets/06a92a06-aad7-4411-a2fd-4f7579ccb282" />
</p>

Na página clique em *Add device* .

<img width="830" height="196" alt="image" src="https://github.com/user-attachments/assets/0c63aec8-50b5-4c18-b668-00f37e07189b" />
</p>

Insira um nome para o *device* e selecione as restantes opções de acordo como está na imagem.

<p align="center">
<img width="415" height="702" alt="image" src="https://github.com/user-attachments/assets/41717999-4001-483b-adcb-06bb4d5cb4b3" />
</p>

Quando estiver criado pode clicar no nome do dispositivo, onde poderá ver as credenciais como na imagem abaixo.

A Primary key setrá importante para quando realizar o processo de onboarding. Copie e guarde esta chave para ser utilizada posteriormente.

<p align="center">
<img width="1324" height="627" alt="image" src="https://github.com/user-attachments/assets/7c8709f2-b547-4981-a010-c6e32a75e9a5" />
</p>


Existem duas maneira para enviar dados para a Azure IoT Hub no Node-RED: Por __*Azure IoT Hub*__ node e do __*MQTT Out*__ , descritas nas subsecções seguintes.
O *MQTT out* node oferece maior flexibilidade e controlo sobre a comunicação e o payload, mas exige configuração manual e a criação de SAS token, enquanto o *Azure IoT Hub* node simplifica a integração e autenticação com o Azure, embora com menos liberdade para personalizar o payload.

---------------------------------------------------------------------
## *Azure IoT Hub* node

No Node-RED deverá instalar a pallete [@node-red-contrib-azure-iothub](https://flows.nodered.org/node/node-red-contrib-azure-iot-hub) e procurar pelo node *Azure IoT Hub*.

Deverá escolher selecionar como protocolo de comunicação a opção *MQTT* e no *Hostname*, deverá ser escrito o seguinte:
```

[IoT Hub Name].azure-devices.net

```
A imagem seguinte ajudará a encontrar o Hostname na Azure Portal.

<p align="center">
<img width="1280" height="720" alt="PreencherIoTHubNode" src="https://github.com/user-attachments/assets/50971d1a-d000-4827-adf4-bea598172ffa" />
</p>


De seguida deve ser parametrizado o payload a ser enviado. Para tal, deve usar o nó *function*, e estruturá-lo da maneira indicada abaixo e na imagem seguinte:

1. Deve ter o parâmetro "deviceId" que representa o nome do dispositivo (identificado como DeviceId na plataforma Azure).
2. Deve ter o parâmetro "key", que é a chave primária do dispositivo criado na plataforma (identificado como Primary Key na plataforma Azure).
3. Deve indicar o protocolo de comunicação a ser usado (mqtt, http, amqp, amqps).
4. Deve inserir os dados a serem enviados no formato indicado abaixo.

<p align="center">
<img width="1280" height="720" alt="FunctionAzureIoTHubnode" src="https://github.com/user-attachments/assets/028f88f3-a51f-4ec5-a2bc-5553c78d47fd" />
</p>

------------------------------------------
## *MQTT Out* node

Para usar MQTT através dos seus nodes é preciso recorrer ao uso do SAS token. O SAS token é uma credencial temporária gerada a partir da chave de segurança do dispositivo,
funciona como umaa palavra-passe para a ligação ao ponto de extremidade do Azure IoT Hub através do protocolo MQTT e 
pode ser gerado na nuvem utilizando a interface de linha de comandos do Azure ou a extensão do VS Code para o Azure IoT Hub.

Use o MQTT out node, e escreva o tópico consoante a imagem abaixo e crie um novo server.



<p align="center">
<img width="1280" height="720" alt="Configração do MQTTNode-part1pptx" src="https://github.com/user-attachments/assets/e6a6287d-5e64-4397-8f75-83c99e4d5180" />
</p>

Dentro das configurações do novo server, faça os seguintes passos:

1. Escreva o hostname do IoT Hub criado.
2. Utilize o port 8883 para a ligação.
3. Como Client Id, use o nome do device criado.
4. Ative a conexão TLS e entre nas suas configurações.


<p align="center">
<img width="1280" height="720" alt="Configração do MQTTNode-part2" src="https://github.com/user-attachments/assets/31468482-da8d-43c4-a2b9-811ebad1c810" />
</p>

Selecione na opção *Verify server certificate* e não necessita de preencher nada das opções para além no nome da configuração TLS. Clique em *Add*/*Update* e depois em *Done* para terminar a configuração do *MQTT out* node.

<p align="center">
<img width="503" height="567" alt="ConfiguracaoMQTTNode-part3" src="https://github.com/user-attachments/assets/e9ce5c88-f05e-4668-89c1-820e85be117c" />
</p>

Com o separador do Node-RED aberto, adicione outro separador do seu browser, vá á Azure portal e abra a CLI da Azure.

<p align="center">
<img width="1433" height="621" alt="image" src="https://github.com/user-attachments/assets/3e84074f-322e-4b96-b8ad-8fceb20aaad7" />
</p>


Quando a CLI estiver aberta, escreva o seguinte comando que permite gerar o SAS Token

```
az iot hub generate-sas-token \
  --hub-name <nome do IoT Hub> \
  --device-id <nome do device> \
  --duration 3600

```
Explicação:
* --hub-name <nome do IoT Hub>  --> o nome do teu IoT Hub
* --device-id <nome do device>  --> nome exato do dispositivo
* --duration 3600 --> duração do token em segundos (neste caso válido por 1 hora, mas pode pôr-se mais, ex: 86400 = 24h)

Aceite tudo o que é pedido pelo CLI para realizar downloads ao escrever 'Y' e clicar em *Enter*.

<img width="1247" height="252" alt="image" src="https://github.com/user-attachments/assets/e905283e-f8be-4fe0-87b9-2ef1cc6fb8f9" />

Após a realização do download irá aparecer uma chave semelhante ao que está em baixo. Deverá copiar inteiramente e guardar esta chave para utilizá-la enquanto password.

```
{
  "sas": "SharedAccessSignature sr=<YourIoTHubName>.azure-devices.net%2Fdevices%2F<YourDeviceName>&sig=<SomeRandomSignatureString>&se=1762399972"
}
```

<p align="center">
<img width="479" height="569" alt="MQTT_funcao" src="https://github.com/user-attachments/assets/48adf118-6fc9-4ff3-85fd-a5756f08c2c1" />
</p>

-----------------------------------------


































































































A visualização dos dados na Microsoft Azure não é direta – é preciso fazer um conjunto de passos para ser possível.

O que pode-se fazer antes da realização desses passos é testar a conectividade e visualizar o payload do Node-RED na plataforma Azure.

Para tal, é necessário usar o cloud shell (correspondente à linha de comandos, mas da própria cloud).

<p align="center">
<img width="1433" height="621" alt="image" src="https://github.com/user-attachments/assets/3e84074f-322e-4b96-b8ad-8fceb20aaad7" />
</p>

O comando a ser usado é o seguinte:

```
az iot hub monitor-events --hub-name [nome do iot hub criado] --output json

```

Deve ser utilizada a *Bash session* para executar o comando.

<p align="center">
<img width="1270" height="916" alt="image" src="https://github.com/user-attachments/assets/f32b303f-2b5c-4716-b579-9ad497ee0b41" />
</p>


Após aceitar a instalação das extensões e do primeiro conjunto de dados foi enviado, irá aparecer a seguinte imagem:

<p align="center">
<img width="1891" height="220" alt="image" src="https://github.com/user-attachments/assets/19160cae-f138-4eac-841f-049763e2f964" />
</p>

Esta imagem confima que os dados estão a ser enviados para a Cloud.




# Referências

[Connecting Node-Red to Azure IoT Hub using MQTT nodes. | by Nikhil Kinkar | Medium](https://medium.com/@nikhilkinkar/connecting-node-red-to-azure-iot-hub-using-mqtt-nodes-6e9160549348)

[Azure IoT - The Complete Guide](https://www.udemy.com/course/az-220-microsoft-azure-iot-developer-certification-2022/)
