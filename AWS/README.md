# Amazon Web Services README

## English Version

Industrial data from different devices is sent to AWS IoT Core via MQTT.

Through Rules, the payload variables received in IoT Core are redirected to their respective properties through the property alias, which is a unique property identifier that facilitates telemetry across AWS services.

AWS IoT SiteWise data is accessed by Grafana Cloud, which allows the data to be visualized graphically.

There are other possibilities to integrate AWS IoT SiteWise data with other AWS services, such as Lookout for Equipment, AWS TwinMaker, and Amazon S3.

<img width="1325" height="583" alt="EsquemaDe_Ligacao_AWS" src="https://github.com/user-attachments/assets/ad3619a1-9bed-4d7d-994e-b333383c625c" />

Set up this architecture in the following order:

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
