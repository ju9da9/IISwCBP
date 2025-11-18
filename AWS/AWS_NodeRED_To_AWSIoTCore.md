# Ligação Node-RED <-> AWS IoT Core

## 1. Configuração da AWS IoT Core

(Escrever uma introdução inicial)

No menu Inicial da AWS, pesquise pela opção IoT Core.

<img width="1715" height="866" alt="image_1" src="https://github.com/user-attachments/assets/20e13d16-5870-4e11-9c1b-277a445b4d5d" />

Selecione a opção "*Things*". A *Thing* (ou coisa) é uma representação do dispositivo físico onde irá ser extraída toda a informação necessária.</p>  

<img width="1111" height="742" alt="image" src="https://github.com/user-attachments/assets/20e495a2-8cab-4d70-b14f-c982502e5e32" />

Clique em "*Create Things*" e selecione a opção "*Create single thing*".

<img width="1573" height="375" alt="image" src="https://github.com/user-attachments/assets/ef7dcd17-cead-41f2-ac2c-67f1021a8b5b" />

<img width="1812" height="375" alt="image" src="https://github.com/user-attachments/assets/4995268a-b828-423f-9ca4-cf08b1eba90f" />

Escreva o nome do dispositivo na "*Thing name*" e clique em "*Next**"

<img width="1228" height="748" alt="image" src="https://github.com/user-attachments/assets/55d07ff1-860d-4ca2-ae72-79dba9806748" />

Selecione a opção para auto-gerar um novo certificado e clique em "Next"

<img width="1268" height="486" alt="image" src="https://github.com/user-attachments/assets/a4441cfb-b9a7-48ae-80db-242acbb03aa1" />

Crie uma nova politica com as ações de publicar, subscrever, conectar e receber em "*Create policy*", no qual irá ser redirecionado para um novo separador.

Insira o nome da *policy* (por exemplo, "SiteWiseTutorialDevicePolicy). Dentro das definições relacionadas com a "*policy documents*", escolha a opção "JSON", insira o seguinte código e substitua os parâmetros "region" e "account-id", pelo nome da região (recomendável que seja Europe (Ireland): eu-west-1) e pelo id da conta (onde pode ser encontrado no canto superior direito, ao lado da região).


<img width="203" height="243" alt="image" src="https://github.com/user-attachments/assets/c173b3f2-6254-4f9c-8e8c-14e7f1c501a0" />

Faça o download de todos os certificados assim que for criada a *Thing*.

<img width="583" height="801" alt="image" src="https://github.com/user-attachments/assets/6e38a66b-9c28-41b4-95f7-971fb2f6aeaa" />

Deve ser guardada também o nosso *domain name* (ou *endpoint*), uma vez que vai ser por ele que vamos conseguir enviar os dados por *Message Queuing Telemetry Transport* (MQTT). Para tal, dever ir a "*Domain Configuration*" (na janela lateral da página) e copiar a informação que está no parâmeto "*Domain name*".

<img width="1027" height="291" alt="image" src="https://github.com/user-attachments/assets/d08e4d00-f003-4fd4-8221-7c7a75b5af38" />







## 2. Configuração do Node-RED



> **Nota importante**: Antes da configuração em si, é necessário que tenha já desenvolvido um programa para extrair os dados do autómato a partir do Node-RED (ver ficheiros Node-RED)


