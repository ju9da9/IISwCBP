# Ligação Node-RED <-> AWS IoT Core

## English Version

(Write an initial introduction)

## 1. AWS IoT Core Configuration

From the AWS home menu, search for IoT Core.

<p align="center">
<img width="1715" height="866" alt="image_1" src="https://github.com/user-attachments/assets/20e13d16-5870-4e11-9c1b-277a445b4d5d" />
</p>

Select the *Things* option. A *Thing* is a representation of the physical device from which all required information will be extracted.
<p align="center">
<img width="1111" height="742" alt="image" src="https://github.com/user-attachments/assets/20e495a2-8cab-4d70-b14f-c982502e5e32" />
</p>

Click "*Create Things*" and select *Create single thing*.

<p align="center">
<img width="1573" height="375" alt="image" src="https://github.com/user-attachments/assets/ef7dcd17-cead-41f2-ac2c-67f1021a8b5b" />
</p>

<p align="center">
<img width="1812" height="375" alt="image" src="https://github.com/user-attachments/assets/4995268a-b828-423f-9ca4-cf08b1eba90f" />
</p>

Enter the device name in "Thing name*" and click *Next*.

<p align="center">
<img width="1228" height="748" alt="image" src="https://github.com/user-attachments/assets/55d07ff1-860d-4ca2-ae72-79dba9806748" />
</p>

Select the option to auto-generate a new certificate and click *Next*.

<p align="center">
<img width="1268" height="486" alt="image" src="https://github.com/user-attachments/assets/a4441cfb-b9a7-48ae-80db-242acbb03aa1" />
</p>

Create a new policy with publish, subscribe, connect, and receive actions in "*Create policy*", which will redirect you to a new tab.

Enter the *policy* name (for example, "SiteWiseTutorialDevicePolicy"). In the *policy documents* settings, choose the "JSON" option, insert the following code, and replace *region* and *account-id* with your region name (recommended: *Europe (Ireland):* eu-west-1) and your account ID (found in the upper-right corner next to the region selector).

```
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "iot:Connect",
        "iot:Publish",
        "iot:Subscribe",
        "iot:Receive"
      ],
      "Resource": "*"
    }
  ]
}

```

Download all certificates as soon as the *Thing* is created.

<p align="center">
<img width="583" height="801" alt="image" src="https://github.com/user-attachments/assets/6e38a66b-9c28-41b4-95f7-971fb2f6aeaa" />
</p>

You should also save the *domain name* (or *endpoint*), because it will be used to send data through *Message Queuing Telemetry Transport* (MQTT). To do this, go to "*Domain Configuration*" (in the side panel) and copy the value in the "*Domain name*" field.

<p align="center">
<img width="1027" height="291" alt="image" src="https://github.com/user-attachments/assets/d08e4d00-f003-4fd4-8221-7c7a75b5af38" />
</p>

## 2. Node-RED Configuration

> **Important note**: Before this setup, you must already have developed a program to extract data from the PLC in Node-RED (see Node-RED files).

<p align="center">
<img width="1079" height="858" alt="image" src="https://github.com/user-attachments/assets/89dc52df-e50a-4239-9509-1fede3b1a9bd" />
</p>

Add an "MQTT out" *node* and open its settings, as shown below:
 - In *Server*, enter the AWS *Thing* *endpoint*
 - The *port* must be __8883__ (not 1883)
 - Enable *Use TLS* and click the <img width="35" height="39" alt="image" src="https://github.com/user-attachments/assets/7369f4f2-9647-4ace-ac87-68022b2b2e02" /> symbol to configure TLS settings
 - 
<p align="center">
<img width="578" height="466" alt="image" src="https://github.com/user-attachments/assets/8a037293-33e2-430b-b5e2-1583cb5168b6" />
</p>

Add the following certificates in the TLS settings and click *Add*.

<p align="center">
<img width="1176" height="454" alt="config-image1" src="https://github.com/user-attachments/assets/02a01ccc-bed2-432d-a64b-77937328cd65" />
</p>

Finally, enter the topic name (for example, "AWS/Counters").

<p align="center">
<img width="467" height="285" alt="image" src="https://github.com/user-attachments/assets/ded75390-f444-4b26-87cc-ff284d1eab2c" />
</p>

The next step is creating a function to send a *payload* to AWS IoT Core. In the left sidebar of Node-RED, search for *function* and drag the node to the center of the page.

There are several ways to process data so it can be sent to the *Cloud*. In this case, because multiple variables are being sent, a *node* called *join* was used to combine several (non-random) variables into an *array* format.

<p align="center">
<img width="981" height="510" alt="image-config2" src="https://github.com/user-attachments/assets/18cb93fa-3c5c-4a1e-b41f-9afdcdea392d" />
</p>

After deploying in Node-RED, this is the final result:

<p align="center">
<img width="1030" height="115" alt="image" src="https://github.com/user-attachments/assets/a81fdc15-9edf-47af-9c9e-60c4797a24d3" />
</p>

## 3. View the *payload* in the MQTT *test client*

In the AWS IoT Core sidebar, go to *MQTT test client*.

<p align="center">
<img width="228" height="371" alt="iconfig2" src="https://github.com/user-attachments/assets/9ccd47cc-3e3d-4c11-a673-4d48fe0d4bff" />
</p>

In "Topic filter", enter the topic name you created in Node-RED and click *Subscribe*.

<p align="center">
<img width="673" height="432" alt="image" src="https://github.com/user-attachments/assets/d15e3367-75b2-4cd3-9960-d38e25c573c4" />
</p>

A panel will appear below *Topic filter* with the content currently in the topic, similar to the image below:
<p align="center">
<img width="605" height="607" alt="image" src="https://github.com/user-attachments/assets/a56f7f98-9dd1-48dc-874f-c0ecf954f5d3" />
</p>

---


(Escrever uma introdução inicial)

## 1. Configuração da AWS IoT Core



No menu Inicial da AWS, pesquise pela opção IoT Core.

<p align="center">
<img width="1715" height="866" alt="image_1" src="https://github.com/user-attachments/assets/20e13d16-5870-4e11-9c1b-277a445b4d5d" />
</p>

Selecione a opção *Things*. A *Thing* (ou coisa) é uma representação do dispositivo físico onde irá ser extraída toda a informação necessária.
<p align="center">
<img width="1111" height="742" alt="image" src="https://github.com/user-attachments/assets/20e495a2-8cab-4d70-b14f-c982502e5e32" />
</p>

Clique em "*Create Things*" e selecione a opção *Create single thing*.

<p align="center">
<img width="1573" height="375" alt="image" src="https://github.com/user-attachments/assets/ef7dcd17-cead-41f2-ac2c-67f1021a8b5b" />
</p>

<p align="center">
<img width="1812" height="375" alt="image" src="https://github.com/user-attachments/assets/4995268a-b828-423f-9ca4-cf08b1eba90f" />
</p>

Escreva o nome do dispositivo na "Thing name* e clique em *Next*.

<p align="center">
<img width="1228" height="748" alt="image" src="https://github.com/user-attachments/assets/55d07ff1-860d-4ca2-ae72-79dba9806748" />
</p>

Selecione a opção para auto-gerar um novo certificado e clique em *Next*.

<p align="center">
<img width="1268" height="486" alt="image" src="https://github.com/user-attachments/assets/a4441cfb-b9a7-48ae-80db-242acbb03aa1" />
</p>

Crie uma nova politica com as ações de publicar, subscrever, conectar e receber em "*Create policy*", no qual irá ser redirecionado para um novo separador.

Insira o nome da *policy* (por exemplo, "SiteWiseTutorialDevicePolicy). Dentro das definições relacionadas com a *policy documents*, escolha a opção "JSON", insira o seguinte código e substitua os parâmetros *region* e *account-id*, pelo nome da região (recomendável que seja *Europe (Ireland):* eu-west-1) e pelo id da conta (onde pode ser encontrado no canto superior direito, ao lado da região).


```
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": [
        "iot:Connect",
        "iot:Publish",
        "iot:Subscribe",
        "iot:Receive"
      ],
      "Resource": "*"
    }
  ]
}

```

Faça o download de todos os certificados assim que for criada a *Thing*.

<p align="center">
<img width="583" height="801" alt="image" src="https://github.com/user-attachments/assets/6e38a66b-9c28-41b4-95f7-971fb2f6aeaa" />
</p>

Deve ser guardada também o nosso *domain name* (ou *endpoint*), uma vez que vai ser por ele que vamos conseguir enviar os dados por *Message Queuing Telemetry Transport* (MQTT). Para tal, dever ir a "*Domain Configuration*" (na janela lateral da página) e copiar a informação que está no parâmeto "*Domain name*".

<p align="center">
<img width="1027" height="291" alt="image" src="https://github.com/user-attachments/assets/d08e4d00-f003-4fd4-8221-7c7a75b5af38" />
</p>






## 2. Configuração do Node-RED



> **Nota importante**: Antes da configuração em si, é necessário que tenha já desenvolvido um programa para extrair os dados do autómato a partir do Node-RED (ver ficheiros Node-RED)

<p align="center">
<img width="1079" height="858" alt="image" src="https://github.com/user-attachments/assets/89dc52df-e50a-4239-9509-1fede3b1a9bd" />
</p>

Adicione um *node* "MQTT out" e entre nas suas configurações. Segundo a imagem seguinte:
 - No *Server*, deverá colocar o *endpoint* da AWS *Thing*
 - O *port* a ser inserido é __8883__ (não 1883)
 - Ative a opção *Use TLS* e clique no símbolo <img width="35" height="39" alt="image" src="https://github.com/user-attachments/assets/7369f4f2-9647-4ace-ac87-68022b2b2e02" /> para configurar as definições do TLS
 - 
<p align="center">
<img width="578" height="466" alt="image" src="https://github.com/user-attachments/assets/8a037293-33e2-430b-b5e2-1583cb5168b6" />
</p>

Adicione os seguintes certificados nas definições da TLS e clique em *Add*.

<p align="center">
<img width="1176" height="454" alt="config-image1" src="https://github.com/user-attachments/assets/02a01ccc-bed2-432d-a64b-77937328cd65" />
</p>

No final, escreva o nome do tópico (por exemplo, "AWS/Counters").

<p align="center">
<img width="467" height="285" alt="image" src="https://github.com/user-attachments/assets/ded75390-f444-4b26-87cc-ff284d1eab2c" />
</p>

O próximo passo passa pela criação de uma função para enviar um *payload* para a AWS IoT Core. Vá na janela lateral do lado esquerdo do Node-RED, pesquise por *function* e arraste o node para o centro da página.

Existem várias formas para processar os dados de maneira a serem enviados para a *Cloud*. Neste caso, como está a ser enviadas várias variáveis, foi utilizado um *node* chamado *join*, no qual junta várias variáveis (não aleatórias) num formato de *array*.

<p align="center">
<img width="981" height="510" alt="image-config2" src="https://github.com/user-attachments/assets/18cb93fa-3c5c-4a1e-b41f-9afdcdea392d" />
</p>

Após fazer *deploy* no Node-RED, este será o resultado final:

<p align="center">
<img width="1030" height="115" alt="image" src="https://github.com/user-attachments/assets/a81fdc15-9edf-47af-9c9e-60c4797a24d3" />
</p>

## 3. Ver o *payload* no MQTT *test client*

Vá na barra lateral da AWS IoT Core e ir em *MQTT test client*.

<p align="center">
<img width="228" height="371" alt="iconfig2" src="https://github.com/user-attachments/assets/9ccd47cc-3e3d-4c11-a673-4d48fe0d4bff" />
</p>

Em "Topic filter", escreva o nome do tópico que criou no Node-RED e clique em *Subscribe*.

<p align="center">
<img width="673" height="432" alt="image" src="https://github.com/user-attachments/assets/d15e3367-75b2-4cd3-9960-d38e25c573c4" />
</p>

Irá aparecer uma janela em baixo do *Topic filter* com o conteúdo existente dentro do tópico, com algo semelhante à imagem seguinte:
<p align="center">
<img width="605" height="607" alt="image" src="https://github.com/user-attachments/assets/a56f7f98-9dd1-48dc-874f-c0ecf954f5d3" />
</p>
