# AWS IoT Core -> AWS IoT SiteWise

A AWS IoT SiteWise é um serviço no qual permite a obtenção, o armazenamento, organização e monitorização de dados vindos de equipamentos industriais.
Com este serviço é possível monitorizar várias operações nas várias instalações, criar métricas e indicadores de desempenho, realizar cálculos automáticos sobre os dados obtidos e

(Falar como funciona os Assets, os Modelos da AWS IoT SiteWise)

<img width="1181" height="445" alt="image" src="https://github.com/user-attachments/assets/945cc6fe-9676-4ba5-b39b-c2e056ea2529" />
Imagem retirada de: [What is AWS IoT SiteWise](https://docs.aws.amazon.com/iot-sitewise/latest/userguide/what-is-sitewise.html#how-sitewise-works/)

## 1. Criação de Modelos e Assets

O primeiro passo passa por criar os modelos para os Assets. 

<img width="1618" height="535" alt="image" src="https://github.com/user-attachments/assets/a8d0c3cc-e3ea-409f-81c5-92e502af5cdf" />

<img width="1359" height="744" alt="image" src="https://github.com/user-attachments/assets/62277c0d-3341-4227-9c8d-24467c781ef6" />



No caso criado, estas foram as tabelas utilizadas para criar os Modelos:



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


Fazer o mesmo para o modelo das máquinas e para o sistema de distribuição. Deve ser feito o mesmo processo para o modelo da fábrica, só que neste caso deve ser adicionada definições de hierarquia.
Vá nas "Hierarchy Definitions" e adiciona as seguintes hierarquias:
(Mencionar o que são hierarchy definitions)


<img width="1301" height="447" alt="image" src="https://github.com/user-attachments/assets/c8d6be30-53bd-4f10-acf6-b3635af10a2d" />



O segundo passa pela criação de assets através da janela lateral da AWS IoT SiteWise e vá em Assets.
Selecione o modelo e dê o nome ao asset. Terá de fazer isto pelas seguintes quantidades:

Machines → 2x
Distribution_System → 1x
Conveyor_Tracking → 1x
Factory → 1x

<img width="1122" height="508" alt="image" src="https://github.com/user-attachments/assets/b3998a56-9312-47a3-a094-454b38328fc1" />



3º passo: Editar os assets para adicionar os "property alias".
Um property alias é um caminho de texto que o AWS IoT Core vai usar para identificar onde os dados devem ir.

Cada propriedade do asset (número, boolean, string) pode ter um único alias.
Esse alias é o que vai ter que referenciar na ação da IoT Rule.

Vá a um asset (por exemplo, "Machine-1") e vá em "Edit".
Nas properties, onde foram criadas propriedades, insira os aliases às propriedades correspondentes. Salve no fim.


<img width="1589" height="700" alt="image" src="https://github.com/user-attachments/assets/b859517e-75f4-4fa3-b56a-691439548ac5" />


Faça o mesmo para os restantes assets.

Assim que tiver todos os assets criados, vá ao asset destinado ao Factory e clique em "Edit".
Associe todos os assets a este em "Add associated asset". A imagem seguinte mostra como deve ficar no final.

<img width="1327" height="285" alt="image" src="https://github.com/user-attachments/assets/e76a4d92-3a55-43c5-9fbf-2a7823c18bfa" />


Clique em "Save".

<img width="284" height="356" alt="image" src="https://github.com/user-attachments/assets/6467d983-2129-44d0-af88-0d2f59eac470" />


## 2. Criação de Rules

O próximo passo passa pela criação de Rules (Regras), que permitem o envio dos dados vindos dos tópicos que entraram no AWS IoT Core para o Serviço pretendido ( neste caso a AWS SiteWise).

No menu da AWS IoT, vá na opção "Rules"


<img width="283" height="533" alt="image" src="https://github.com/user-attachments/assets/d905c5ef-fded-4ca6-9aaa-3bd63f34ee70" />




Clique em "Create rule", onde vai ser redirecionado para uma nova página. Insira o nome da rule ( por exemplo "Send_Counter_Topic_To_Sitewise") e uma descrição da regra, se achar necessário. Posteriormente, clique em "Next"


<img width="1506" height="598" alt="image" src="https://github.com/user-attachments/assets/079064d5-9f95-4f51-b94d-a4f30439a026" />



De seguida, é necessário criar um SQL Statement dentro da rule, que define quais os parâmetros ou variáveis do tópico devem ser considerados para envio ao AWS SiteWise. Ao utilizar o caracter * no SQL, aplicado ao tópico AWS/Counters, estamos a selecionar todas as variáveis publicadas nesse tópico. É importante notar que, para o correto funcionamento da integração, os dados devem ser inseridos e processados respeitando a mesma ordem em que foram definidos no payload do tópico.


<img width="1273" height="702" alt="image" src="https://github.com/user-attachments/assets/b18a0468-43b1-45b7-9b11-9d051462f2b9" />


No passo seguinte, é necessário associar os dados selecionados na regra ao property alias previamente criado no AWS IoT SiteWise. Para isso, definimos cada entrada (Entry) que representa a ligação entre uma variável recebida no tópico do IoT Core e a propriedade correspondente no modelo de ativos do SiteWise.
É fundamental manter a mesma ordem em que as variáveis foram estruturadas no tópico, de forma a garantir a correta correspondência entre os valores recebidos e as propriedades configuradas. No exemplo apresentado, o property alias /Factory_1/Distribution_System_1/Count_Distro_1 foi associado ao campo ${Count_Distro_1}, sendo especificado ainda o tipo de dado (INTEGER) e o timestamp (${timeInSeconds}), o que permite ao SiteWise armazenar os valores com a devida referência temporal.


<img width="1282" height="826" alt="image" src="https://github.com/user-attachments/assets/563bcfcf-6317-4535-a1ae-c7efb6293387" />


(Falta falar da IAM Role no fim)

<img width="576" height="82" alt="image" src="https://github.com/user-attachments/assets/3c792c9d-8349-4f87-a55e-a1aea1156aa2" />

<img width="1597" height="882" alt="image" src="https://github.com/user-attachments/assets/8f9695a1-f0d9-4374-8292-24f89ce2cbd7" />



