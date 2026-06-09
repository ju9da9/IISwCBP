# README

Esta pasta contém o projeto desenvolvido em **Node-RED** para a integração de **Programmable Logic Controllers (PLC)** com plataformas Cloud.

O projeto utiliza diferentes palettes do Node-RED para permitir:
- Comunicação industrial com PLCs através do protocolo **OPC UA**;
- Envio e receção de dados para plataformas Cloud como **AWS IoT Core**, **Microsoft Azure IoT Hub** e **Siemens Insights Hub**;
- Processamento e organização de dados industriais;
- Desenvolvimento de dashboards SCADA para monitorização e controlo em tempo real.

### Lista das palettes instaladas

| Palette | Descrição |
|---------|-----------|
| **@flowfuse/node-red-dashboard** | Framework moderna para criação de dashboards no Node-RED. Permite desenvolver interfaces gráficas para monitorização e controlo de processos industriais, incluindo gráficos, indicadores e elementos interativos. |
| **node-red-dashboard** | Dashboard original do Node-RED utilizado para criar interfaces gráficas de supervisão (SCADA), permitindo visualizar dados provenientes dos PLCs e sistemas Cloud. |
| **@flowfuse/node-red-dashboard-2-ui-led** | Extensão para o FlowFuse Dashboard 2.0 que adiciona componentes LED aos dashboards, permitindo representar estados digitais, alarmes e estados de funcionamento de equipamentos. |
| **node-red-contrib-ui-led** | Permite adicionar indicadores LED aos dashboards do Node-RED para representar estados booleanos, alarmes ou condições do processo industrial. |
| **node-red-contrib-ui-level** | Disponibiliza indicadores gráficos de nível para representação de variáveis analógicas como temperatura, pressão, velocidade ou níveis de tanques. |
| **node-red-contrib-opcua** | Implementa comunicação através do protocolo industrial **OPC UA**, permitindo a aquisição e escrita de dados entre PLCs e Node-RED. É utilizado para comunicação direta com equipamentos industriais. |
| **node-red-contrib-azure-iot-hub** | Permite a integração entre Node-RED e o **Microsoft Azure IoT Hub**, possibilitando o envio de dados industriais para a Cloud através de MQTT. |
| **@mindconnect/node-red-contrib-mindconnect** | Permite comunicação com o **Siemens Insights Hub**, possibilitando o envio de dados de equipamentos industriais para a plataforma Cloud da Siemens através do MindConnect. |
| **node-red-contrib-batcher** | Permite agrupar e processar mensagens antes do envio para outros sistemas, sendo útil para organizar dados provenientes dos PLCs ou sensores. |

