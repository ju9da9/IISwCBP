# Ligação Node-RED -> Azure IoT Hub

## English Version

The first step in this connection is creating and configuring Azure IoT Hub.

When you are on the page, click *create*.

<p align="center">
<img width="294" height="151" alt="image" src="https://github.com/user-attachments/assets/16101cbe-17a9-4fd5-ba68-773c8f9115ea" />
</p>

Click *Create New* to enter the Resource Group. To make things easier, use this same group for all the other services whenever possible. Click *Review and create*.

Fill in the rest according to the next image.

<p align="center">
<img width="805" height="668" alt="image" src="https://github.com/user-attachments/assets/e8b0653a-4333-46ef-8886-6475a3c1b247" />
</p>

The next step is creating *devices*. A device is.... __(explain as Microsoft Azure "vocabulary")__. In the left sidebar, under *Device management*, go to *Devices*.

<p align="center">
<img width="287" height="456" alt="image" src="https://github.com/user-attachments/assets/06a92a06-aad7-4411-a2fd-4f7579ccb282" />
</p>

On the page, click *Add device*.

<img width="830" height="196" alt="image" src="https://github.com/user-attachments/assets/0c63aec8-50b5-4c18-b668-00f37e07189b" />
</p>

Enter a name for the *device* and select the remaining options as shown in the image.

<p align="center">
<img width="415" height="702" alt="image" src="https://github.com/user-attachments/assets/41717999-4001-483b-adcb-06bb4d5cb4b3" />
</p>

Once it is created, you can click the device name, where you can see the credentials as shown below.

The Primary key will be important during onboarding. Copy and save this key to use later.

<p align="center">
<img width="1324" height="627" alt="image" src="https://github.com/user-attachments/assets/7c8709f2-b547-4981-a010-c6e32a75e9a5" />
</p>

There are two ways to send data to Azure IoT Hub from Node-RED: through the [__*Azure IoT Hub*__ node](#azure-iot-hub-node) and through the [__*MQTT Out*__ node](#mqtt-out-node), described in the following subsections.
The *MQTT out* node offers greater flexibility and control over communication and payload, but requires manual configuration and SAS token creation, while the *Azure IoT Hub* node simplifies Azure integration and authentication, although with less freedom to customize the payload.

---------------------------------------------------------------------
## *Azure IoT Hub* node

In Node-RED, install the [@node-red-contrib-azure-iothub](https://flows.nodered.org/node/node-red-contrib-azure-iot-hub) palette and look for the *Azure IoT Hub* node.

You should select *MQTT* as the communication protocol, and in *Hostname* enter the following:
```

[IoT Hub Name].azure-devices.net

```
The next image helps you find the Hostname in the Azure Portal.

<p align="center">
<img width="1280" height="720" alt="PreencherIoTHubNode" src="https://github.com/user-attachments/assets/50971d1a-d000-4827-adf4-bea598172ffa" />
</p>

Next, configure the payload to be sent. To do this, use the *function* node and structure it as indicated below and in the next image:

1. It must include the "deviceId" parameter, which represents the device name (identified as DeviceId in Azure).
2. It must include the "key" parameter, which is the primary key of the device created in the platform (identified as Primary Key in Azure).
3. You must indicate the communication protocol to use (mqtt, http, amqp, amqps).
4. You must insert the data to be sent in the format shown below.

<p align="center">
<img width="1280" height="720" alt="FunctionAzureIoTHubnode" src="https://github.com/user-attachments/assets/028f88f3-a51f-4ec5-a2bc-5553c78d47fd" />
</p>

With these settings, you are ready to communicate between the device and Azure through the *Azure IoT Hub* node.

------------------------------------------
## *MQTT Out* node

To use MQTT through its nodes, you need a SAS token. A SAS token is a temporary credential generated from the device security key,
it works like a password for connecting to the Azure IoT Hub endpoint through MQTT, and
it can be generated in the cloud using the Azure command-line interface or the VS Code Azure IoT Hub extension.

Use the MQTT out node, enter the topic as shown in the image below, and create a new server.

<p align="center">
<img width="1280" height="720" alt="Configração do MQTTNode-part1pptx" src="https://github.com/user-attachments/assets/e6a6287d-5e64-4397-8f75-83c99e4d5180" />
</p>

Inside the new server settings, follow these steps:

1. Enter the hostname of the IoT Hub you created.
2. Use port 8883 for the connection.
3. As Client Id, use the name of the created device.
4. Enable TLS connection and open its settings.

<p align="center">
<img width="1280" height="720" alt="Configração do MQTTNode-part2" src="https://github.com/user-attachments/assets/31468482-da8d-43c4-a2b9-811ebad1c810" />
</p>

Select *Verify server certificate* and you do not need to fill in any other options except the TLS configuration name. Click *Add*/*Update* and then *Done* to finish configuring the *MQTT out* node.

<p align="center">
<img width="503" height="567" alt="ConfiguracaoMQTTNode-part3" src="https://github.com/user-attachments/assets/e9ce5c88-f05e-4668-89c1-820e85be117c" />
</p>

With the Node-RED tab open, add another browser tab, go to Azure Portal, and open Azure CLI.

<p align="center">
<img width="1433" height="621" alt="image" src="https://github.com/user-attachments/assets/3e84074f-322e-4b96-b8ad-8fceb20aaad7" />
</p>

When CLI is open, run the following command to generate the SAS Token:

```
az iot hub generate-sas-token \
  --hub-name <nome do IoT Hub> \
  --device-id <nome do device> \
  --duration 3600

```
Explanation:
* --hub-name <nome do IoT Hub>  --> your IoT Hub name
* --device-id <nome do device>  --> exact device name
* --duration 3600 --> token duration in seconds (in this case valid for 1 hour, but you can set more, e.g., 86400 = 24h)

Accept everything requested by CLI for downloads by typing 'Y' and pressing *Enter*.

<p align="center">
<img width="1247" height="252" alt="image" src="https://github.com/user-attachments/assets/e905283e-f8be-4fe0-87b9-2ef1cc6fb8f9" />
</p>

After download, a key similar to the one below will appear. Copy the value inside quotes from the __"sas"__ parameter and save it to use as the password.

```
{
  "sas": "SharedAccessSignature sr=<YourIoTHubName>.azure-devices.net%2Fdevices%2F<YourDeviceName>&sig=<SomeRandomSignatureString>&se=1762399972"
}
```

> NOTE: You can also generate a SAS Token by installing the Azure IoT Hub Extension in VS Code and signing in with your account. After installing the extension, go to the "Explorer" tab <img width="53" height="52" alt="image" src="https://github.com/user-attachments/assets/2d0e81f5-b10e-4ad2-93fa-75c6757bec38" /> , where a dedicated Azure IoT Hub section will appear, go to "Devices", right-click the device you want, and click *Generate SAS Token for Device*.
>
> <p align="center">
> <img width="483" height="575" alt="image" src="https://github.com/user-attachments/assets/c1b44021-6086-4dae-ac60-e5e4b80c08d0" />
> </p>
>
>
> Enter the token duration in hours and press *Enter*. The generated key will appear in the VS Code command line.
>
> <p align="center">
> <img width="728" height="80" alt="image" src="https://github.com/user-attachments/assets/67955697-b828-4d52-b4a9-7dab14af02a3" />
> </p>
>

Go back to the Node-RED tab in your browser, go to the *MQTT Out* node, enter server settings, open the "Security" tab, and write the *username* as shown below and paste the key obtained in the *password* field.

<p align="center">
<img width="976" height="541" alt="image" src="https://github.com/user-attachments/assets/0c7595e9-b52a-4306-800c-7f90a5a691d7" />
</p>

This configures the connection through the *MQTT Out* node.

-----------------------------------------

Add the *function* node and write your payload similarly to what is shown in the following image.

<p align="center">
<img width="479" height="569" alt="MQTT_funcao" src="https://github.com/user-attachments/assets/48adf118-6fc9-4ff3-85fd-a5756f08c2c1" />
</p>

Connect the nodes and click *Deploy*.

<p align="center">
<img width="1313" height="214" alt="image" src="https://github.com/user-attachments/assets/25fe9181-628f-46c0-947b-c6e0f49eb176" />
</p>

> IMPORTANT NOTE: Choose only one of these methods to communicate between your device and Azure.

# How to view the payload in Azure portal

Visualizing data in Microsoft Azure is not direct — you need to follow a set of steps to make it possible.

What you can do before completing those steps is test connectivity and view the Node-RED payload in Azure.

To do that, use Cloud Shell (which is the command line, but from the cloud itself).

<p align="center">
<img width="1433" height="621" alt="image" src="https://github.com/user-attachments/assets/3e84074f-322e-4b96-b8ad-8fceb20aaad7" />
</p>

The command to use is:

```
az iot hub monitor-events --hub-name [nome do iot hub criado] --output json

```

Use the *Bash session* to run the command.

<p align="center">
<img width="1270" height="916" alt="image" src="https://github.com/user-attachments/assets/f32b303f-2b5c-4716-b579-9ad497ee0b41" />
</p>

After accepting extension installation and after the first data set is sent, the following image will appear:

<p align="center">
<img width="1891" height="220" alt="image" src="https://github.com/user-attachments/assets/19160cae-f138-4eac-841f-049763e2f964" />
</p>

This image confirms that data is being sent to the Cloud.

# References

[Connecting Node-Red to Azure IoT Hub using MQTT nodes. | by Nikhil Kinkar | Medium](https://medium.com/@nikhilkinkar/connecting-node-red-to-azure-iot-hub-using-mqtt-nodes-6e9160549348)

[Azure IoT - The Complete Guide](https://www.udemy.com/course/az-220-microsoft-azure-iot-developer-certification-2022/)

---
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


Existem duas maneira para enviar dados para a Azure IoT Hub no Node-RED: Por [__*Azure IoT Hub*__ node](#azure-iot-hub-node) e do [__*MQTT Out*__ node](#mqtt-out-node) , descritas nas subsecções seguintes.
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

Com estas configurações, está pronto para realizar a comunicação entre o dispositivo e a Azure através do *Azure IoT Hub* node.

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

<p align="center">
<img width="1247" height="252" alt="image" src="https://github.com/user-attachments/assets/e905283e-f8be-4fe0-87b9-2ef1cc6fb8f9" />
</p>

Após a realização do download irá aparecer uma chave semelhante ao que está em baixo. Deverá copiar o conteúdo dentro das aspas do parâmetro __"sas"__ e guardar esta chave para utilizá-la enquanto password.

```
{
  "sas": "SharedAccessSignature sr=<YourIoTHubName>.azure-devices.net%2Fdevices%2F<YourDeviceName>&sig=<SomeRandomSignatureString>&se=1762399972"
}
```

> NOTA: Também pode gerar um SAS Token se instalar a Azure IoT Hub Extension no VS Code e iniciar sessão com a sua conta. Tendo instalado a extensão, vá ao separdor "Explorer" <img width="53" height="52" alt="image" src="https://github.com/user-attachments/assets/2d0e81f5-b10e-4ad2-93fa-75c6757bec38" /> , onde irá aparecer um separador dedicado à Azure IoT Hub, vá em "Devices", clique no botão direito em cima do device que deseja, e clique em *Generate SAS Token for Device*.
>
> <p align="center">
> <img width="483" height="575" alt="image" src="https://github.com/user-attachments/assets/c1b44021-6086-4dae-ac60-e5e4b80c08d0" />
> </p>
>
> 
> Insira a duração do token em horas e clique em *Enter*. Irá aparecer na linha de comandos do VS Code a chave gerada.
>
> <p align="center">
> <img width="728" height="80" alt="image" src="https://github.com/user-attachments/assets/67955697-b828-4d52-b4a9-7dab14af02a3" />
> </p>
>

Volte ao separador do Node-RED no seu browser, e vá ao *MQTT Out* node, entre nas configurações do server, entre separador "Security" e escreva o *username* conforme está na imagem abaixo e cole a chave obtida no parâmetro *password*.

<p align="center">
<img width="976" height="541" alt="image" src="https://github.com/user-attachments/assets/0c7595e9-b52a-4306-800c-7f90a5a691d7" />
</p>

Assim está configurada a ligação através do *MQTT Out* node.

-----------------------------------------


Adicione o node *function* e escreva o seu payload de maneira semelhante ao que está na imagem seguinte.

<p align="center">
<img width="479" height="569" alt="MQTT_funcao" src="https://github.com/user-attachments/assets/48adf118-6fc9-4ff3-85fd-a5756f08c2c1" />
</p>


Faça a ligação entre os nodes e clique em *Deploy*.

<p align="center">
<img width="1313" height="214" alt="image" src="https://github.com/user-attachments/assets/25fe9181-628f-46c0-947b-c6e0f49eb176" />
</p>


> NOTA IMPORTANTE: Escolha apenas um destes métodos para poder realizar a comunicação entre o seu dispositivo e a Azure.








# Como visualizar o payload na Azure portal


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