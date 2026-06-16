# IISwCBP

This repository is dedicated for the development of the MSc. Dissertation named "Integrating Industrial Systems with Cloud-based Platforms for Enhanced Connectivity and Efficiency" made by the Polytechnic University of Leiria's student Judá Imbó during 2024 and 2026.

It contains a set of manuals/tutorials that allows to connect Programmable Logic Controllers (PLC) with cloud platforms such as AWS, Microsoft Azure and Siemens Insights Hub, as some of the code used in this dissertation.

The following image shows the hardware necessary to make a similiar implementation as was made in this dissertation:
 


<img width="1920" height="1080" alt="EsquemaDeMontagemhardware" src="https://github.com/user-attachments/assets/b955502e-ad48-4143-923b-ebe6a054d9e1" />


> It is important to note that it is not required a IIoT gateway to receive data from PLC's and send it to the clouds. It is possible to install Node-RED in a PC, and do the same things as in a Siemens SIMATIC IOT2050

To make these implementations it is required the following software:

- Siemens TIA Portal v18
- Siemens PLCSIM Advanced v5.0
- Factory IO
- Node-RED
- UAExpert
- Putty
- Visual Studio Code
- Azure CLI **(falta a versão)**
- .NET SDK **(falta a versão)**



Here is the structure of this repository:


- **[AWS](https://github.com/ju9da9/IISwCBP/tree/main/AWS)**: Contains tutorials and documentation for integrating PLCs with Amazon Web Services
  - [AWS_NodeRED_To_AWSIoTCore.md](https://github.com/ju9da9/IISwCBP/blob/main/AWS/AWS_NodeRED_To_AWSIoTCore.md) - Guide for connecting Node-RED to AWS IoT Core
  - [AWS_IoTCore_To_AWS_IoTSiteWise.md](https://github.com/ju9da9/IISwCBP/blob/main/AWS/AWS_IoTCore_To_AWS_IoTSiteWise.md) - Tutorial for routing data from AWS IoT Core to AWS IoT SiteWise
  - [AWS_IoTSiteWise_To_Grafana.md](https://github.com/ju9da9/IISwCBP/blob/main/AWS/AWS_IoTSiteWise_To_Grafana.md) - Instructions for visualizing AWS IoT SiteWise data in Grafana
  - [Backup Dashboard grafana AWS](https://github.com/ju9da9/IISwCBP/tree/main/AWS/Backup%20Dashboard%20grafana%20AWS) - Grafana dashboard backups for AWS implementation
  - [README.md](https://github.com/ju9da9/IISwCBP/blob/main/AWS/README.md) - AWS-specific documentation index

- **[Azure](https://github.com/ju9da9/IISwCBP/tree/main/Azure)**: Contains documentation for Microsoft Azure cloud platform integration
  - [NodeRED_AzureIoTHub.md](https://github.com/ju9da9/IISwCBP/blob/main/Azure/NodeRED_AzureIoTHub.md) - Guide for connecting Node-RED to Azure IoT Hub
  - [AzureIoTHub_to_AzureDigitalTwins.md](https://github.com/ju9da9/IISwCBP/blob/main/Azure/AzureIoTHub_to_AzureDigitalTwins.md) - Tutorial for integrating Azure IoT Hub with Azure Digital Twins
  - [VisualiseGraphicalData_In_AzureDigitalTwins_with_AzureDataExplorer.md](https://github.com/ju9da9/IISwCBP/blob/main/Azure/VisualiseGraphicalData_In_AzureDigitalTwins_with_AzureDataExplorer.md) - Instructions for visualizing data using Azure Data Explorer
  - [Azure Digital Twin Models](https://github.com/ju9da9/IISwCBP/tree/main/Azure/Azure%20Digital%20Twin%20Models) - Azure Digital Twin model definitions
  - [Project Azure Functions Uploads](https://github.com/ju9da9/IISwCBP/tree/main/Azure/Project%20Azure%20Functions%20Uploads) - Azure Functions project files
  - [README.md](https://github.com/ju9da9/IISwCBP/blob/main/Azure/README.md) - Azure-specific documentation index

- **[Insights Hub](https://github.com/ju9da9/IISwCBP/tree/main/Insights%20Hub)**: Contains documentation for Siemens Insights Hub integration
  - [Node-RED_to_SiemensInsightsHub.md](https://github.com/ju9da9/IISwCBP/blob/main/Insights%20Hub/Node-RED_to_SiemensInsightsHub.md) - Guide for connecting Node-RED to Siemens Insights Hub

- **[PLC Configuration - IIoT](https://github.com/ju9da9/IISwCBP/tree/main/PLC%20Configuration%20-%20IIoT)**: Contains PLC setup, configuration files, and hardware documentation
  - [README.md](https://github.com/ju9da9/IISwCBP/blob/main/PLC%20Configuration%20-%20IIoT/README.md) - Comprehensive PLC configuration guide
  - [TIA Portal Project](https://github.com/ju9da9/IISwCBP/tree/main/PLC%20Configuration%20-%20IIoT/TIA%20Portal%20Project) - Siemens TIA Portal project files
  - [Factory IO File](https://github.com/ju9da9/IISwCBP/tree/main/PLC%20Configuration%20-%20IIoT/Factory%20IO%20File) - Factory IO simulation files
  - [Node-RED Files](https://github.com/ju9da9/IISwCBP/tree/main/PLC%20Configuration%20-%20IIoT/Node-RED%20Files) - Node-RED flow configurations and deployments
  - [iot2050_operating_instructions_en_en-US.pdf](https://github.com/ju9da9/IISwCBP/blob/main/PLC%20Configuration%20-%20IIoT/iot2050_operating_instructions_en_en-US.pdf) - Siemens IoT2050 device operating manual



---

## Contact

For more information, please contact: [juda.imbo99@gmail.com](mailto:juda.imbo99@gmail.com)







