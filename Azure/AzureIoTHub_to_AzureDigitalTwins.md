# Azure IoT Hub -> Azure Digital Twins

Para poder enviar dados para a Azure Digital twins a partir da Azure IoT é preciso uma série de passos para poder até lá.






## Como publicar uma função no VS Code

1º) Caso tenha no projeto as seguintes pastas, apague-as uma vez que o comando seguinte, irá gerar estas pastas novamente:

- bin
- obj

Através da linha de comandos do VS Code, faça os seguintes passos:

2º) `dotnet publish -c Release` -> p/ fazer debug

>> *NOTA IMPORTANTE:* é necessário que assim que for feito o 1º comando, para ir à pasta "publish", clicar no botão direito do rato em cima da pasta mencionada e selecionar a opção "Reveal in File Explorer"

<img width="1271" height="1012" alt="image" src="https://github.com/user-attachments/assets/5fb9a2d1-7412-47d7-a872-97611f41eb7e" />

Entrar na pasta *publish*.

<img width="864" height="317" alt="image" src="https://github.com/user-attachments/assets/d3131ad4-804d-4d98-8c4a-e768b5517e53" />


Selecione todos os ficheiros que se encontram na pasta e comprima-os. O ficheiro zipado será enviado pela linha de comandos para a cloud

<img width="820" height="591" alt="image" src="https://github.com/user-attachments/assets/5b562e94-76f7-4c8d-8e38-21679c416349" />



3ºp) Já c/ o ficheiro zipado, deve ir à pasta pela linha de comandos do VS Code, e ir à pasta do ficheiro zipado.

´´´
cd bin/release/net6.0/publish
´´´

4ºp) Publique o ficheiro zipado e envie para a cloud através do seguinte comando

´´´
az functionapp deployment source config-zip -g <nome-do-grupo-na-cloud> -n <nome-da-function-app> --src <Nome-da-função.zip>
´´´
