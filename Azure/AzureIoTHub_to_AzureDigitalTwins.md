# Azure IoT Hub -> Azure Digital Twins

Para poder enviar dados para a Azure Digital twins a partir da Azure IoT é preciso uma série de passos para poder até lá.





## How to create a function app

Na Azure Portal, pesquise por _Function App_.
Quando estiver na página referente ao serviço, vá ao canto superior esquerdo da página e clique em "Create".

<p align="center">
<img width="546" height="246" alt="image" src="https://github.com/user-attachments/assets/8ab6dcff-4296-43cc-b20a-a4a89e33d440" />
</p>

De todos os planos disponíveis, escolha o plano Consumption.

<p align="center">
<img width="1190" height="601" alt="image" src="https://github.com/user-attachments/assets/afb1bb64-fffa-4a33-a4c1-c04681721457" />
</p>

Preencha os campos referentes à subscrição, ao Resource Group e ao nome da Function App. 
Em Instance Details, configure as restantes opções exatamente como na imagem:
 - Sistema operativo: Windows
 - Runtime stack: .NET
 - Versão: 8 (LTS), isolated worker model
 - Região: West Europe

Após preencher, vá ao separador *Storage*.

<p align="center">
<img width="755" height="849" alt="image" src="https://github.com/user-attachments/assets/870fafa6-b0cf-450d-9141-5528dc51a60c" />
</p>

Caso não tenha uma Storage Account crie uma nova (caso já tenha continue a utilizar a que já tinha antes).

<p align="center">
<img width="742" height="852" alt="image" src="https://github.com/user-attachments/assets/f1a8d355-abc3-4e6d-817f-0c5626c3d83a" />
</p>

No separador Monitoring, na secção Application Insights, configure as opções como na imagem:
Ative o Application Insights (Yes) e crie um novo recurso do Application Insights (caso nãoesteja criado automaticamente).
Confirme que a região esteja em West Europe (normalmente preenchido automaticamente).

<p align="center">
<img width="750" height="449" alt="image" src="https://github.com/user-attachments/assets/7407323c-92c5-45b9-aecf-103eb24a2e8c" />
</p>

Depois vá em *Create + Review* e conclua a criação da Function App.

O próximo passo será criar uma função dentro da Function App. Existem três opções disponíveis como indica a imagem de baixo. Neste caso, irá ser criada uma função no VS Code recurso a .NET 8.0 SDK e a Azure CLI, uma vez que a Microsoft disponibiliza um template de uma função para enviar os dados da Azure IoT Hub para a Azure Digital Twin onde observar [aqui](https://learn.microsoft.com/en-us/azure/digital-twins/how-to-ingest-iot-hub-data). No entanto, na pasta [Project Azure Functions Uploads](https://github.com/ju9da9/IISwCBP/tree/main/Azure/Project%20Azure%20Functions%20Uploads), pode encontrar o projeto em C# usado para criar as funções, juntamente com instruções a serem realizadas ao criar uma função destas.

<p align="center">
<img width="835" height="207" alt="image" src="https://github.com/user-attachments/assets/62ef0e25-a96c-4730-a57f-f0c1550efe1e" />
</p>


> É Recomendável que antes de seguir os próximos passos já tenha instalado o seguinte:
>
> - [Visual Studio Code](https://code.visualstudio.com/)
> - [C# Extention](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) para o Visual Studio Code
> - [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
> - [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest&pivots=msi)








## Como publicar uma função no VS Code


Abra o projeto no VS Code.
Caso tenha no projeto as seguintes pastas, apague-as uma vez que nos passos seguintes, irá gerar estas pastas novamente:

- bin
- obj

Através da linha de comandos do VS Code, faça os seguintes passos:

Faça o debug através do seguinte comando:

```
dotnet publish -c Release
```
Este comando fará gerar de volta as pastas que foram apagadas anteriormente.

Assim que for feito o 1º comando, para ir à pasta "publish", clicar no botão direito do rato em cima da pasta mencionada e selecionar a opção "Reveal in File Explorer"

<p align="center">
<img width="1271" height="1012" alt="image" src="https://github.com/user-attachments/assets/5fb9a2d1-7412-47d7-a872-97611f41eb7e" />
</p>

Entre na pasta *publish*.

<p align="center">
<img width="864" height="317" alt="image" src="https://github.com/user-attachments/assets/d3131ad4-804d-4d98-8c4a-e768b5517e53" />
</p>

Selecione todos os ficheiros que se encontram na pasta e comprima-os. O ficheiro zipado será enviado pela linha de comandos para a cloud

<p align="center">
<img width="820" height="591" alt="image" src="https://github.com/user-attachments/assets/5b562e94-76f7-4c8d-8e38-21679c416349" />
</p>


Já com o ficheiro zipado, deve ir à pasta pela linha de comandos do VS Code, e ir à pasta do ficheiro zipado.

```
cd bin/release/net6.0/publish
```

Publique o ficheiro zipado e envie para a cloud através do seguinte comando

```
az functionapp deployment source config-zip -g <nome-do-grupo-na-cloud> -n <nome-da-function-app> --src <Nome-da-função.zip>
```
