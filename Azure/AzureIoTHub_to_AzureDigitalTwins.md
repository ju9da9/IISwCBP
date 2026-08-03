# Azure IoT Hub -> Azure Digital Twins

## English Version

To send data to Azure Digital Twins from Azure IoT Hub, you need to complete a series of steps.

## How to create a function app

In the Azure Portal, search for _Function App_.
When you are on the service page, go to the upper-left corner and click **"Create"**.

<p align="center">
<img width="546" height="246" alt="image" src="https://github.com/user-attachments/assets/8ab6dcff-4296-43cc-b20a-a4a89e33d440" />
</p>

From all available plans, choose the **Consumption** plan.

<p align="center">
<img width="1190" height="601" alt="image" src="https://github.com/user-attachments/assets/afb1bb64-fffa-4a33-a4c1-c04681721457" />
</p>

Fill in the fields for subscription, Resource Group, and Function App name.
In **Instance Details**, configure the remaining options exactly as shown:
 - Operating system: Windows
 - Runtime stack: .NET
 - Version: 8 (LTS), isolated worker model
 - Region: West Europe

After filling these in, go to the *Storage* tab.

<p align="center">
<img width="755" height="849" alt="image" src="https://github.com/user-attachments/assets/870fafa6-b0cf-450d-9141-5528dc51a60c" />
</p>

If you do not have a Storage Account, create a new one (if you already have one, keep using it).

<p align="center">
<img width="742" height="852" alt="image" src="https://github.com/user-attachments/assets/f1a8d355-abc3-4e6d-817f-0c5626c3d83a" />
</p>

In the **Monitoring** tab, in the **Application Insights** section, configure the options as in the image:
Enable Application Insights (**Yes**) and create a new Application Insights resource (if it is not already created automatically).
Confirm that the region is **West Europe** (usually filled automatically).

<p align="center">
<img width="750" height="449" alt="image" src="https://github.com/user-attachments/assets/7407323c-92c5-45b9-aecf-103eb24a2e8c" />
</p>

Then go to **Create + Review** and finish creating the Function App.

The next step is creating a function inside the Function App. There are three available options, as shown in the image below. In this case, a function will be created in VS Code using .NET 8.0 SDK and Azure CLI, because Microsoft provides a function template to send data from Azure IoT Hub to Azure Digital Twins, available [here](https://learn.microsoft.com/en-us/azure/digital-twins/how-to-ingest-iot-hub-data). However, in the folder [Project Azure Functions Uploads](https://github.com/ju9da9/IISwCBP/tree/main/Azure/Project%20Azure%20Functions%20Uploads), you can find the C# project used to create these functions, along with instructions to follow when creating one.

<p align="center">
<img width="835" height="207" alt="image" src="https://github.com/user-attachments/assets/62ef0e25-a96c-4730-a57f-f0c1550efe1e" />
</p>


> It is recommended that before continuing with the next steps, you already have the following installed:
>
> - [Visual Studio Code](https://code.visualstudio.com/)
> - [C# Extention](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code
> - [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
> - [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest&pivots=msi)








## How to publish a function in VS Code

Before continuing with the next steps, a few more changes are required so that data from IoT Hub can be sent to the created Azure Digital Twins instance.

1) Add `ADT_SERVICE_URL` as an *application setting*.

1 -> Go to the Function App  
2 -> Go to the created function  
3 -> In the left pop-up panel, go to **settings** and then **Environment variables**  
4 -> In **app settings**, click **"Add"**  
5 -> Fill it in as follows

<p align="center">
<img width="1107" height="251" alt="image" src="https://github.com/user-attachments/assets/ed95df89-f417-4d17-81c4-696d233a597c" />
</p>

>`<your-digital-twins-name>` → name of the created digital twin

>`<region>` → the region used when creating the IoT Hub, Digital Twin, and Function App instances

6 -> Click **"Apply"** 2x


2) Grant the Function App permissions to Azure Digital Twins

1 -> Go to the created Function App and, in the pop-up panel, go to **Settings** -> **Identity**  
2 -> Set the option to **"ON"** and save the change, as shown in the next image

<p align="center">
<img width="1302" height="284" alt="image" src="https://github.com/user-attachments/assets/2feecea6-a81c-4d98-8b0a-c1af4914d3a6" />
</p>

3 -> Go to the created **Azure Digital Twins** instance.  
→ Go to **Access control (IAM)** -> **"Add role assignment"**

<p align="center">
<img width="1221" height="619" alt="image" src="https://github.com/user-attachments/assets/b66aeedc-4755-47d3-92d0-ec3a1b8bc943" />
</p>

4 -> Select **"Azure Digital Twins Data Owner"** and click **"Next"**.

<p align="center">
<img width="874" height="618" alt="image" src="https://github.com/user-attachments/assets/9abd7ff1-95bc-43df-aa87-e5f25312b7e9" />
</p>

5 -> In **"Assign access to"**, select **"Managed identity"**.

<p align="center">
<img width="608" height="487" alt="image" src="https://github.com/user-attachments/assets/0db7e8cc-e49c-401a-9dc1-284b99cfa1f1" />
</p>

Click **"Select members"** and a pop-up panel will appear on the right.

6 -> In the pop-up panel, under **"Managed identity"**, choose **"Function App"**. Under **"Select"**, choose the created function and click **"Select"**.

<p align="center">
<img width="567" height="416" alt="image" src="https://github.com/user-attachments/assets/c883340e-4d30-4132-8fdd-77df7f9602b7" />
</p>

7 -> Go to **Function App**


-----
Open the project in VS Code.
If the project contains the following folders, delete them because the next steps will generate them again:

- bin
- obj

Using the VS Code command line, do the following steps:

Run the following command:

```
dotnet publish -c Release
```
This command regenerates the folders deleted previously.

After running the first command, to go to the "publish" folder, right-click that folder and select **"Reveal in File Explorer"**.

<p align="center">
<img width="1271" height="1012" alt="image" src="https://github.com/user-attachments/assets/5fb9a2d1-7412-47d7-a872-97611f41eb7e" />
</p>

Enter the *publish* folder.

<p align="center">
<img width="864" height="317" alt="image" src="https://github.com/user-attachments/assets/d3131ad4-804d-4d98-8c4a-e768b5517e53" />
</p>

Select all files in the folder and compress them. The zipped file will be sent to the cloud via command line.

<p align="center">
<img width="820" height="591" alt="image" src="https://github.com/user-attachments/assets/5b562e94-76f7-4c8d-8e38-21679c416349" />
</p>


With the zipped file ready, go to that folder from the VS Code command line.

```
cd bin/release/net6.0/publish
```

Publish the zipped file and send it to the cloud with the following command:

```
az functionapp deployment source config-zip -g <nome-do-grupo-na-cloud> -n <nome-da-function-app> --src <Nome-da-função.zip>
```

---
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

Antes de avançar com os próximos passos, Será necessário realizar mais algumas alterações para que seja possível enviar os dados vindos do IoT hub para a Azure Digital twin instance criada.

1) Deve-se colocar `ADT_SERVICE_URL` como *application setting*.

1 -> Ir na Function App  
2 -> Ir na função criada  
3 -> Na janela pop-up da esquerda, ir em **settings** e de seguida ir em **Environment variables**  
4 -> Nas **app settings**, clicar em **"Add"**  
5 -> Preencha da seguinte maneira

<p align="center">
<img width="1107" height="251" alt="image" src="https://github.com/user-attachments/assets/ed95df89-f417-4d17-81c4-696d233a597c" />
</p>

>`<your-digital-twins-name>` → nome do digital twin criado

>`<region>` → a região que foi inserida quando foi criado as instâncias do IoT hub, o digital twin e a Function App

6 -> Clique em **"Apply"** 2x


2) Dar à Function App permissão para a Azure Digital twins

1 -> Ir à Function App criada e, na janela pop-up, ir a **Settings** -> **Identity**  
2 -> Colocar a opção em **"ON"** e salvar a alteração, como indica a imagem seguinte

<p align="center">
<img width="1302" height="284" alt="image" src="https://github.com/user-attachments/assets/2feecea6-a81c-4d98-8b0a-c1af4914d3a6" />
</p>

3 -> Ir à instância criada no **Azure Digital Twins**.  
→ Ir a **Access control (IAM)** -> **"Add role assignment"**

<p align="center">
<img width="1221" height="619" alt="image" src="https://github.com/user-attachments/assets/b66aeedc-4755-47d3-92d0-ec3a1b8bc943" />
</p>

4 -> Selecionar a opção **"Azure Digital Twins Data Owner"** e clicar em **"Next"**.

<p align="center">
<img width="874" height="618" alt="image" src="https://github.com/user-attachments/assets/9abd7ff1-95bc-43df-aa87-e5f25312b7e9" />
</p>

5 -> Selecione em **"Assign access to"** a opção **"Managed identity"**.

<p align="center">
<img width="608" height="487" alt="image" src="https://github.com/user-attachments/assets/0db7e8cc-e49c-401a-9dc1-284b99cfa1f1" />
</p>

Clique em **"Select members"** e aparecerá uma janela pop-up à direita.

6 -> Na janela pop-up, selecione em **"Managed identity"** e escolha a opção **"Function App"**. No **"Select"**, escolha a função criada e clique em **"Select"**.

<p align="center">
<img width="567" height="416" alt="image" src="https://github.com/user-attachments/assets/c883340e-4d30-4132-8fdd-77df7f9602b7" />
</p>

7 -> Vá a **Function App**


-----
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