# 1.1. AWS IoT Core -> AWS IoT SiteWise

A AWS IoT SiteWise é um serviço no qual permite a obtenção, o armazenamento, organização e monitorização de dados vindos de equipamentos industriais.
Com este serviço é possível monitorizar várias operações nas várias instalações, criar métricas e indicadores de desempenho, realizar cálculos automáticos sobre os dados obtidos e

(Falar como funciona os Assets, os Modelos da AWS IoT SiteWise)

<img width="1181" height="445" alt="image" src="https://github.com/user-attachments/assets/945cc6fe-9676-4ba5-b39b-c2e056ea2529" />
Imagem retirada de: [O que é o AWS IoT SiteWise? - AWS IoT SiteWise](https://docs.aws.amazon.com/iot-sitewise/latest/userguide/what-is-sitewise.html#how-sitewise-works) .




| Property Name (SiteWise) | Property Alias                                      | Tipo    |
|--------------------------|----------------------------------------------------|---------|
| Count_Distro_1           | /Factory_1/Distribution_System_1/Count_Distro_1    | integer |
| Count_Distro_2           | /Factory_1/Distribution_System_1/Count_Distro_2    | integer |
| Count_Distro_3           | /Factory_1/Distribution_System_1/Count_Distro_3    | integer |
| Count_Distro_4           | /Factory_1/Distribution_System_1/Count_Distro_4    | integer |
| Count_Distro_5           | /Factory_1/Distribution_System_1/Count_Distro_5    | integer |
| Count_Distro_6           | /Factory_1/Distribution_System_1/Count_Distro_6    | integer |
| Count_Distro_Total       | /Factory_1/Distribution_System_1/Count_Distro_Total| integer |




| Property Name (SiteWise)     | Property Alias                                | Tipo    |
|------------------------------|-----------------------------------------------|---------|
| No_Distro_Active             | /Factory_1/No_Distro_Active                  | boolean |
| No_Machine_Active            | /Factory_1/No_Machine_Active                 | boolean |
| No_Conditions_toStack        | /Factory_1/No_Conditions_toStack             | boolean |



| Property Name (SiteWise)     | Property Alias                                   | Tipo    |
|------------------------------|-------------------------------------------------|---------|
| Level_Tank                  | /Factory_1/Machine_1/Level_Tank                 | double  |
| Valv_Discharge              | /Factory_1/Machine_1/Valv_Discharge             | double |
| Valv_Filling                | /Factory_1/Machine_1/Valv_Filling               | double |
| Counter_Part_Machine        | /Factory_1/Machine_1/Counter_Part_Machine       | integer |

> *Esta tabela aplica-se para `Machine_2`*


| Property Name (SiteWise) | Property Alias                                   | Tipo   |
|--------------------------|-------------------------------------------------|--------|
| vel_CT3                 | /Factory_1/Conveyor_Tracking_1/vel_CT3          | double |
| vel_CT4                 | /Factory_1/Conveyor_Tracking_1/vel_CT4          | double |
| vel_CT5                 | /Factory_1/Conveyor_Tracking_1/vel_CT5          | double |
| vel_CT6                 | /Factory_1/Conveyor_Tracking_1/vel_CT6          | double |
| vel_CT7                 | /Factory_1/Conveyor_Tracking_1/vel_CT7          | double |
