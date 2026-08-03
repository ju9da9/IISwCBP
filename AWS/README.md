# Amazon Web Services README

## English Version

Industrial data from different devices is sent to **AWS IoT Core** using MQTT.

Using **IoT Rules**, payload variables are routed to their respective properties through **property aliases**, which are unique property identifiers that simplify telemetry integration across AWS services.

Data stored in **AWS IoT SiteWise** is then accessed in **Grafana Cloud** for graphical visualization.

Other integration options with SiteWise data include **Lookout for Equipment**, **AWS TwinMaker**, and **Amazon S3**.

Follow this architecture setup order:

1. [Node-RED to AWS IoT Core](AWS_NodeRED_To_AWSIoTCore.md)
2. [AWS IoT Core to AWS IoT SiteWise](AWS_IoTCore_To_AWS_IoTSiteWise.md)
3. [AWS IoT SiteWise to Grafana](AWS_IoTSiteWise_To_Grafana.md)

---


Os dados industriais vindos de diferentes dispositivos são enviados para o a AWS IoT Core por MQTT.

Através de Rules, as variáveis do payload recebido na IoT Core são redirecionadas para as respetivas propriedades através da property alias, que é um identificador único da propriedade no qual facilita a telemetria entre serviços dentro da AWS.

Os dados da AWS IoT SiteWise são acedidos pela Grafana cloud, que permite visualisar os dados de forma gráfica. 

Existem outras possibilidade para integrar os dados da AWS IoT SiteWise com outros serviços da AWS, com a Lookout for equipment, a AWS TwinMaker e a Amazon S3.


<img width="1325" height="583" alt="EsquemaDe_Ligacao_AWS" src="https://github.com/user-attachments/assets/ad3619a1-9bed-4d7d-994e-b333383c625c" />




Faça a configuração desta arquitetura na seguinte ordem:

1. [Node-RED to AWS IoT Core](AWS_NodeRED_To_AWSIoTCore.md)
2. [AWS IoT Core to AWS IoT SiteWise](AWS_IoTCore_To_AWS_IoTSiteWise.md)
3. [AWS IoT SiteWise to Grafana](AWS_IoTSiteWise_To_Grafana.md)

