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


<img width="1830" height="829" alt="image" src="https://github.com/user-attachments/assets/7ff61382-4702-4eeb-95dd-8a476420ae62" />


Crie as variáveis que serão enviadas para a Cloud na DB criada.

> NOTA: Crie nomes sugestivos e que sejam os mesmos nomes que serão colocados na Cloud, para além de manter tipo de variável.

<img width="1006" height="449" alt="image" src="https://github.com/user-attachments/assets/02d09960-dc6e-4969-ba5a-661864dceb63" />

Implemente as alterações que forem necessárias no programa TIA Portal, de maneira a que se consiga transferir os valores do programa para a database e em seguida para o Node-RED.

<img width="1268" height="551" alt="image" src="https://github.com/user-attachments/assets/9b1352bf-377f-4e9b-96df-8ba80a16c462" />

O próximo passp passa em ativar o OPC UA Server no autómato. Por isso vá nas propriedades gerais do autómato em “Device Configuration" e entre na Janela OPC-UA Server, clicando em **Activate OPC-UA Server**,

<img width="1114" height="596" alt="image" src="https://github.com/user-attachments/assets/364f465e-6e94-457e-8e7e-dda915dd1c47" />

> NOTA: Deve fixar os seguintes nomes após a ativação do servidor:
> 
> 1. **OPC-UA Application name**
>    
> Encontra-se em “Device Configuration” -> Propriedades do autómato -> OPC UA -> General
> 
> <img width="828" height="165" alt="image" src="https://github.com/user-attachments/assets/f7909c56-457d-409d-bdd4-fbc8c78a4946" />
>
> 2. **Server Address**
> 
> Encontra-se em Device Configration -> Propriedades do Autómato -> OPC UA -> Server -> Server Address
>
> <img width="1000" height="274" alt="image" src="https://github.com/user-attachments/assets/6f6f0794-88b8-41f3-aaf9-a96c28e8c969" />
>
> Estes serão utilizados para a configuração do server no software UA Expert











