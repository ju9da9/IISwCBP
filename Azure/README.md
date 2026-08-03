# Microsoft Azure README

## English Version

In this architecture, devices send telemetry to **Azure IoT Hub** (typically over MQTT or using the Node-RED Azure IoT Hub node).

- IoT Hub publishes events to **Event Grid**.
- **Azure Functions** consumes events, maps payload fields, and updates **Azure Digital Twins**.
- Data is then sent to **Event Hub** and ingested into **Azure Data Explorer** for historical analysis.

Follow this setup order:

1. [Node-RED to Azure IoT Hub](https://github.com/ju9da9/IISwCBP/blob/main/Azure/NodeRED_AzureIoTHub.md)
2. [Azure IoT Hub to Azure Digital Twins](https://github.com/ju9da9/IISwCBP/blob/main/Azure/AzureIoTHub_to_AzureDigitalTwins.md)
3. [Visualize historical data in Azure Digital Twins with Azure Data Explorer](https://github.com/ju9da9/IISwCBP/blob/main/Azure/VisualiseGraphicalData_In_AzureDigitalTwins_with_AzureDataExplorer.md)

---


Neste esquema abaixo, os dispositivos enviam a informação (telemetria) para o Azure IoT Hub, normalmente por MQTT com SAS Token ou através de um node do Azure IoT Hub no Node-RED. 

O Azure IoT Hub recebe esses dados e publica eventos no Event Grid, que serve para disparar notificações quando há nova informação. 

A Azure Functions consome esse evento, lê o payload e faz o mapeamento dos campos para o respetivo modelo no Azure Digital Twins. 

O Azure Digital Twins mantém o estado digital dos ativos ou objetos físicos. 

Depois, os dados seguem para o Event Hub, que funciona como transportador de eventos para processamento em grande volume, e finalmente são ingeridos no Azure Data Explorer, onde ficam guardados e disponíveis para análise histórica e consultas rápidas.



<img width="1126" height="281" alt="EsquemaDe_Ligacao_Azure" src="https://github.com/user-attachments/assets/4834d94a-0739-4d88-a465-718216623c67" />


Faça a configuração desta arquitetura na seguinte ordem:

1. [Node-RED to Azure IoT Hub](https://github.com/ju9da9/IISwCBP/blob/main/Azure/NodeRED_AzureIoTHub.md)
2. [Azure IoT Hub to Azure Digital Twins](https://github.com/ju9da9/IISwCBP/blob/main/Azure/AzureIoTHub_to_AzureDigitalTwins.md)
3. [How to visualise historical data in Azure Digital Twins with Azure Data Explorer](https://github.com/ju9da9/IISwCBP/blob/main/Azure/VisualiseGraphicalData_In_AzureDigitalTwins_with_AzureDataExplorer.md)