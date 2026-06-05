# PLC - IIoT Configuration

Esta pasta é dedicada para a documentação relacionada com a configuração do programa TIA Portal para establecer uma comunicação OPC UA com o IIoT Gateway, ao criar um OPC UA Server no autómato.

É de notar que o programa TIA Portal que está neste repositório está configurado para conectar o S7-1500 com CPU X simulado - para o PLC (S7-1500) físico, no caso de ter apenas o PLC físico utilizado neste trabalho Foi realizado desta maneira devido às condições em que o autor deste repositório, no qual apenas tinha CPU A (físico) disponível, um autómato com menores capacidades que o CPU X que até apenas simulado poderia funcionar mas não com OPC UA, uma vez que a Siemens PLCSIM Advanced v5.0 não suporta a comunicação entre um PLC Simulado e um Dispositivo IIoT Físico - apenas se o Node-RED e o programa simulado estiverem num único PC. Mas se tiver o CPU simulado neste trabalho em formato hardware, não necessita de utilizar o TRCV_C e o TSEND_C (utilizados no programa TIA Portal deste repositório - removendo-os se achar necessário), fazendo todos os procedimentos de configuração de um OPC UA Server neste PLC.**

Para fazer a configuração do IOT2050 pode seguir os tutoriais da página [Git Hub da Siemens](https://github.com/SIMATICmeetsLinux/IOT2050-Setting-Up-Example-Image), onde explica com detalhe todos os passos necessários para o funcionamento do IIoT Gateway. Caso seja mais prático, pode utilizar o [PDF](https://github.com/ju9da9/IISwCBP/blob/main/PLC%20Configuration%20-%20IIoT/iot2050_operating_instructions_en_en-US.pdf) da Siemens guardado no repositório com os mesmos procedimentos.

## Como estabelecer uma comunicação OPC UA entre um PLC da Siemens e Node-RED integrado num IIoT Gateway

### Requerimentos:
- TIA Portal v16 ou superior
- UA Expert
- Node-RED (Baixar as seguintes pallets: @mindconnect/node-red-contrib-mindconnect e @node-red-contrib-opcua)
- Autómato SIMATIC S7-1500 (com PROFINET e um IP atribuído)

### Procedimentos:

No TIA Portal, crie uma Global DB, selecionando a opção **“Add new block”**.
Vá às propriedades da DB criada, clicar na janela “attributes” e **desativar** a opção **“Optimized block access”**.

<p align="center">
<img width="1830" height="829" alt="image" src="https://github.com/user-attachments/assets/7ff61382-4702-4eeb-95dd-8a476420ae62" />
</p>

Crie as variáveis que serão enviadas para a Cloud na DB criada.

> NOTA: Crie nomes sugestivos e que sejam os mesmos nomes que serão colocados na Cloud, para além de manter tipo de variável.

<p align="center">
<img width="1006" height="449" alt="image" src="https://github.com/user-attachments/assets/02d09960-dc6e-4969-ba5a-661864dceb63" />
</p>


Implemente as alterações que forem necessárias no programa TIA Portal, de maneira a que se consiga transferir os valores do programa para a database e em seguida para o Node-RED.

<p align="center">
<img width="1268" height="551" alt="image" src="https://github.com/user-attachments/assets/9b1352bf-377f-4e9b-96df-8ba80a16c462" />
</p>

O próximo passos passa em ativar o OPC UA Server no autómato. Por isso vá nas propriedades gerais do autómato em “Device Configuration" e entre na Janela OPC-UA Server, clicando em **Activate OPC-UA Server**,

<p align="center">
<img width="1114" height="596" alt="image" src="https://github.com/user-attachments/assets/364f465e-6e94-457e-8e7e-dda915dd1c47" />
</p>


> NOTA: Deve fixar os seguintes nomes após a ativação do servidor:
> 
> 1. **OPC-UA Application name**
>    
> Encontra-se em “Device Configuration” -> Propriedades do autómato -> OPC UA -> General
>
> <p align="center">
> <img width="828" height="165" alt="image" src="https://github.com/user-attachments/assets/f7909c56-457d-409d-bdd4-fbc8c78a4946" />
> </p>
> 
> 2. **Server Address**
> 
> Encontra-se em Device Configration -> Propriedades do Autómato -> OPC UA -> Server -> Server Address
>
> <p align="center">
> <img width="1000" height="274" alt="image" src="https://github.com/user-attachments/assets/6f6f0794-88b8-41f3-aaf9-a96c28e8c969" />
> </p>
> 
> Estes serão utilizados para a configuração do server no software UA Expert

O passo seguinte passa por configurar as propriedades do OPC-UA ao ativar ou verificar se estão ligados os seguintes parâmetros:
	- “Enable guest authentication” (Isto permitirá aceder ao OPC UA Server sem o uso de username e password);

  <p align="center">
  <img width="1096" height="294" alt="image" src="https://github.com/user-attachments/assets/9ed203d2-66c1-45b2-a847-67024e0609be" />
  </p>

  - Nas “Security policies available on the server” a opção “No security”;

  <p align="center">
  <img width="1453" height="387" alt="image" src="https://github.com/user-attachments/assets/34a7b079-ed84-4a81-a4dd-94d62293ff22" />
  </p>

  - Nas propriedades gerais do autómato selecione a licença do OPC-UA requrida e compilar

  <p align="center">
  <img width="1294" height="880" alt="image" src="https://github.com/user-attachments/assets/bf7ed43d-403d-40be-9c71-7339c301f59a" />
  </p>

Neste momento, o autómato já tem as condições reunidas para adicionar um OPC UA Server. Na “project tree”, desloque à janela “OPC UA Communication” e clique em “Add new server interface”;
Escreva um nome para o server e selecione “Interface” como seu tipo de server;
Clique em “Ok”.

<p align="center">
<img width="1122" height="857" alt="image" src="https://github.com/user-attachments/assets/c742c191-c729-49db-a4ab-47033ea8253b" />
</p>

Irá aparecer duas janelas com o server e todas as variáveis e DBs existentes no programa. Selecione as variáveis quer enviar pelo protocolo e arraste-as para a janela do server.

<p align="center">
<img width="1317" height="687" alt="image" src="https://github.com/user-attachments/assets/5f11bd14-f0bb-4090-8ce4-f116c201fe83" />
</p>

A imagem abaixo o resultado

<p align="center">
<img width="792" height="248" alt="image" src="https://github.com/user-attachments/assets/46f7cc55-ec38-40bf-a03d-125ae838b5f7" />
</p>

Faça o download do programa <img width="94" height="92" alt="image" src="https://github.com/user-attachments/assets/8e63463a-fcb9-4e0e-ad0e-fbc9221e4f8d" />

No Software UA Expert, clique em <img width="119" height="120" alt="image" src="https://github.com/user-attachments/assets/124cf71c-e7e4-4613-ba32-367780c0fedb" />

<p align="center">
<img width="1132" height="902" alt="image" src="https://github.com/user-attachments/assets/94cc6d13-70a1-4ac7-a907-088fe95410f6" />
</p>

Ao clicar, Irá aparecer a seguinte Imagem abaixo. Clique em “Double click to Add Server”. Irá ser pedido um URL que de facto, é o endereço do Server **(Server address mencionado anteriormente)**.

<p align="center">
<img width="1133" height="905" alt="image" src="https://github.com/user-attachments/assets/b2ae6022-a7e5-41f5-bda5-cf1514f6ba03" />
</p>

De seguida, deve verificar se o nome que está debaixo do server address corresponde ao OPC UA Application name.

<p align="center">
<img width="1028" height="719" alt="image" src="https://github.com/user-attachments/assets/462876a2-a596-460b-a9c3-aea50f361ed5" />
</p>

Na janela project, clique com o botão direito do rato em cima do server criado e clique em “Connect”.

Confirme se o nome que aparece em “Certificate Chain” corresponde ao mesmo nome do “Server Certificate” no TIA Portal”
Como o server criado não tem um “nível” de segurança definido, aparece como “Untrusted”.
No entanto clique em “Trust Server Certificate”, e de seguida clique em “Continue”

<p align="center">
<img width="1491" height="805" alt="image" src="https://github.com/user-attachments/assets/1560fe2c-cbb0-48cd-b06d-2f34344e7d49" />
</p>

O próximo passo passa por Configurar o UA Expert para visualizar os valores das variáveis no servidor. Para isso, arraste todas as variáveis que estão no “Server interfaces” para a Janela “Data acess view” (ou apenas as variáveis que deseja).

<p align="center">
<img width="1092" height="712" alt="image" src="https://github.com/user-attachments/assets/3c1e3a8e-4627-4c24-a8e1-6887b2361c4b" />
</p>

É possível verificar se o servidor está funcional ou não. Para isso, precisa de ir ao TIA Portal.
Clique em “Go Online”, vá à DB onde se encontram as variáveis que vão ser enviadas para a cloud e modifique o valor atual de uma das variáveis.

<p align="center">
<img width="944" height="596" alt="image" src="https://github.com/user-attachments/assets/c40ffa16-0ad5-411b-9b0a-1e6fec4c7a11" />
</p>

Se os valores atuais aparecerem no UA Expert, significa que o servidor se encontra funcional.

<p align="center">
<img width="772" height="241" alt="image" src="https://github.com/user-attachments/assets/914fc49f-719b-4927-816e-5ce8f0eae6d2" />
</p>

Na janela “ Data Access View”, existe um separador que permite identificar as variáveis no Node-RED, o “Node Id”.
A declaração das variáveis no Node-RED é feita pela seguinte maneira:

<p align="center">
<img width="1692" height="499" alt="image" src="https://github.com/user-attachments/assets/e719900c-4f04-47ad-ac33-1c456d146307" />
</p>

No Node-RED para poder receber vários dados de uma vez só numa função pode ser usado um esquema similar à imagem de baixo, onde iremos falar por parte como configurar até à função.

<p align="center">
<img width="1568" height="495" alt="image" src="https://github.com/user-attachments/assets/9a39f479-ce54-41c0-88f7-aebc491fce07" />
</p>

O node “Inject serve para dar o pulso para que as variáveis sejam enviadas para a cloud. É possivel injetar as variáveis várias vezes, usando intervalos de tempo nas propriedades do node.


<img width="1690" height="642" alt="image" src="https://github.com/user-attachments/assets/7d5a8eb9-8e88-4509-be88-6ac28923f1d2" />

O node “OpcUa-Item” serve para identificar a variável que deseja ler (read), escrever (write) ou outra função que esteja disponível através do node “OpcUa- Client”. Tal como visto anteriormente, a declaração das variáveis (ou items) é feita da seguinte maneira no Node-RED:

<img width="1605" height="819" alt="image" src="https://github.com/user-attachments/assets/bc681547-5ea0-47be-9562-9a985fa99f82" />

Clique em " Done apoós realizar a declaração.

O node "Opc-Ua Client" tem múltiplas funções como ler, escrever e entre outras. Como neste caso pretende-se ler os dados para serem enviados para a cloud, a sua configuração tem de ser realizada da seguinte forma:

<img width="1789" height="617" alt="image" src="https://github.com/user-attachments/assets/6a81386e-e532-4607-a944-8e4d5e053d84" />

No Parâmetro “EndPoint” cole ou escreva o server Address utilizado em passos anteriores para aceder ao Server.
Escolha a opção “None” nos parâmetros “SecurityPolicy” 3 SecurityMode”.
Selecione a opção “Anonymous” e clique em upgrade.

<img width="1215" height="796" alt="image" src="https://github.com/user-attachments/assets/cc69a091-d863-4e61-bef5-d94eb5a1029b" />

Como os valores das variáveis aparecem em mensagens separadas no debug (dificultuando a obtenção dos mesmos para a colocação dos dados no formato Mindsphere) foi utilizado o node “Join” para juntar os valores  em forma de array. A imagem segunte mostra como deve ser feita a configuração.

<img width="1346" height="783" alt="image" src="https://github.com/user-attachments/assets/ffa5654d-2833-4f6d-ba97-4d421aea0c1c" />

Crie uma função com um modelo de registo de dados em tempo real, onde no qual terá de chamar a variáveis do OPC UA Server da seguinte forma:

<img width="572" height="184" alt="image" src="https://github.com/user-attachments/assets/41119d96-39df-4305-85a5-dc8b126e2e61" />

O resto da função dependerá como devem ser enviados os dados em cada cloud. Vá às pastas dedicadas às clouds para ver como são enviados os dados do Node-RED.




