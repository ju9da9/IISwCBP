# Azure IoT Hub -> Azure Digital Twins

Para poder enviar dados para a Azure Digital twins a partir da Azure IoT é preciso uma série de passos para poder até lá.





## How to create a function app

Na Azure Portal, pesquise por _Function App_.
Quando estiver na página referente ao serviço, vá ao canto superior esquerdo da página e clique em "Create".

<p align="center">
<img width="546" height="246" alt="image" src="https://github.com/user-attachments/assets/8ab6dcff-4296-43cc-b20a-a4a89e33d440" />
</p>

Escolha a opção Consumption

<p align="center">
<img width="1190" height="601" alt="image" src="https://github.com/user-attachments/assets/afb1bb64-fffa-4a33-a4c1-c04681721457" />
</p>


<p align="center">
<img width="755" height="849" alt="image" src="https://github.com/user-attachments/assets/870fafa6-b0cf-450d-9141-5528dc51a60c" />
</p>

<p align="center">
<img width="742" height="852" alt="image" src="https://github.com/user-attachments/assets/f1a8d355-abc3-4e6d-817f-0c5626c3d83a" />
</p>

<p align="center">
<img width="750" height="449" alt="image" src="https://github.com/user-attachments/assets/7407323c-92c5-45b9-aecf-103eb24a2e8c" />
</p>




## Como publicar uma função no VS Code

Caso tenha no projeto as seguintes pastas, apague-as uma vez que o comando seguinte, irá gerar estas pastas novamente:

- bin
- obj

Através da linha de comandos do VS Code, faça os seguintes passos:

Para fazer debug deverá colocar o seguinte na linha de comandos:

```
dotnet publish -c Release
```
Este comando fará gerar de volta as pastas que foram apagadas anteriormente.

> *NOTA IMPORTANTE:* é necessário que assim que for feito o 1º comando, para ir à pasta "publish", clicar no botão direito do rato em cima da pasta mencionada e selecionar a opção "Reveal in File Explorer"

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
