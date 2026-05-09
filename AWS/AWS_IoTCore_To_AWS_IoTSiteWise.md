# AWS IoT Core -> AWS IoT SiteWise

A AWS IoT SiteWise é um serviço no qual permite a obtenção, o armazenamento, organização e monitorização de dados vindos de equipamentos industriais.
Com este serviço é possível monitorizar várias operações nas várias instalações, criar métricas e indicadores de desempenho, realizar cálculos automáticos sobre os dados obtidos e

__(Falar como funciona os Assets, os Modelos da AWS IoT SiteWise)__

<p align="center">
<img width="1181" height="445" alt="image" src="https://github.com/user-attachments/assets/945cc6fe-9676-4ba5-b39b-c2e056ea2529" />
</p>
Imagem retirada de [O que é o AWS IoT SiteWise? - AWS IoT SiteWise](https://docs.aws.amazon.com/iot-sitewise/latest/userguide/what-is-sitewise.html#how-sitewise-works)

## 1. Criação de Modelos e Assets

O primeiro passo passa por criar os modelos para os Assets. 
<p align="center">
<img width="1618" height="535" alt="image" src="https://github.com/user-attachments/assets/a8d0c3cc-e3ea-409f-81c5-92e502af5cdf" />
</p>

<p align="center">
<img width="1359" height="744" alt="image" src="https://github.com/user-attachments/assets/62277c0d-3341-4227-9c8d-24467c781ef6" />
</p>

> NOTA IMPORTANTE: Caso queira criar notificações e alertas com o grafana, __Não use 'Units'__, uma vez que impossibilita que isto seja possível.

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

<p align="center">
<img width="1301" height="447" alt="image" src="https://github.com/user-attachments/assets/c8d6be30-53bd-4f10-acf6-b3635af10a2d" />
</p>


O segundo passa pela criação de assets através da janela lateral da AWS IoT SiteWise e vá em Assets.
Selecione o modelo e dê o nome ao asset. Terá de fazer isto pelas seguintes quantidades:

Machines → 2x
Distribution_System → 1x
Conveyor_Tracking → 1x
Factory → 1x

<p align="center">
<img width="1122" height="508" alt="image" src="https://github.com/user-attachments/assets/b3998a56-9312-47a3-a094-454b38328fc1" />
</p>


3º passo: Editar os assets para adicionar os "property alias".
Um property alias é um caminho de texto que o AWS IoT Core vai usar para identificar onde os dados devem ir.

Cada propriedade do asset (número, boolean, string) pode ter um único alias.
Esse alias é o que vai ter que referenciar na ação da IoT Rule.

Vá a um asset (por exemplo, "Machine-1") e vá em "Edit".
Nas properties, onde foram criadas propriedades, insira os aliases às propriedades correspondentes. Salve no fim.

<p align="center">
<img width="1589" height="700" alt="image" src="https://github.com/user-attachments/assets/b859517e-75f4-4fa3-b56a-691439548ac5" />
</p>

Faça o mesmo para os restantes assets.

Assim que tiver todos os assets criados, vá ao asset destinado ao Factory e clique em "Edit".
Associe todos os assets a este em "Add associated asset". A imagem seguinte mostra como deve ficar no final.

<p align="center">
<img width="1327" height="285" alt="image" src="https://github.com/user-attachments/assets/e76a4d92-3a55-43c5-9fbf-2a7823c18bfa" />
</p>

Clique em "Save".

<p align="center">
<img width="284" height="356" alt="image" src="https://github.com/user-attachments/assets/6467d983-2129-44d0-af88-0d2f59eac470" />
</p>

## 2. Criação de Rules

O próximo passo passa pela criação de Rules (Regras), que permitem o envio dos dados vindos dos tópicos que entraram no AWS IoT Core para o Serviço pretendido ( neste caso a AWS SiteWise).

No menu da AWS IoT, vá na opção "Rules"

<p align="center">
<img width="283" height="533" alt="image" src="https://github.com/user-attachments/assets/d905c5ef-fded-4ca6-9aaa-3bd63f34ee70" />
</p>



Clique em "Create rule", onde vai ser redirecionado para uma nova página. Insira o nome da rule ( por exemplo "Send_Counter_Topic_To_Sitewise") e uma descrição da regra, se achar necessário. Posteriormente, clique em "Next"

<p align="center">
<img width="1506" height="598" alt="image" src="https://github.com/user-attachments/assets/079064d5-9f95-4f51-b94d-a4f30439a026" />
</p>


De seguida, é necessário criar um SQL Statement dentro da rule, que define quais os parâmetros ou variáveis do tópico devem ser considerados para envio ao AWS SiteWise. Ao utilizar o caracter * no SQL, aplicado ao tópico AWS/Counters, estamos a selecionar todas as variáveis publicadas nesse tópico. É importante notar que, para o correto funcionamento da integração, os dados devem ser inseridos e processados respeitando a mesma ordem em que foram definidos no payload do tópico.

<p align="center">
<img width="1273" height="702" alt="image" src="https://github.com/user-attachments/assets/b18a0468-43b1-45b7-9b11-9d051462f2b9" />
</p>

No passo seguinte, é necessário associar os dados selecionados na regra ao property alias previamente criado no AWS IoT SiteWise. Para isso, definimos cada entrada (Entry) que representa a ligação entre uma variável recebida no tópico do IoT Core e a propriedade correspondente no modelo de ativos do SiteWise.
É fundamental manter a mesma ordem em que as variáveis foram estruturadas no tópico, de forma a garantir a correta correspondência entre os valores recebidos e as propriedades configuradas. No exemplo apresentado, o property alias /Factory_1/Distribution_System_1/Count_Distro_1 foi associado ao campo ${Count_Distro_1}, sendo especificado ainda o tipo de dado (INTEGER) e o timestamp (${timeInSeconds}), o que permite ao SiteWise armazenar os valores com a devida referência temporal.

<p align="center">
<img width="1282" height="826" alt="image" src="https://github.com/user-attachments/assets/563bcfcf-6317-4535-a1ae-c7efb6293387" />
</p>

__(Falta falar da IAM Role no fim)__
__No final de  adicionar todas as variáveis que estão inseridas no tópico, deve ser adicionada uma IAM Role com uma *policy* acossiada. ( Escrever a seguir o que é) uma IAM Role é uma regra... Uma policy é..... Neste caso, é preciso uma IAM role para permitir que sejam escritos os dados na propriedades dos assets na IoT SiteWise.__

Como é muito provável que não terá uma uma IAM Role criada para esta funcionalidade, vá até ao fundo da páginam donde terá um separador chamado *IAM Role*, e clique em  *Create an new role*, onde deverá inserir um novo nome para a role e clicar em *Create*.

<p align="center">
<img width="526" height="226" alt="image" src="https://github.com/user-attachments/assets/40442779-c9f2-4223-8083-ccef1fcb16ac" />
</p>

Para que haja permissão para que os dados sejam redirecionados para a  IoT SiteWise, deve ser editada a role recentemente criada. Cique em "view", onde será redirecionado para uma nova página.

<img width="576" height="82" alt="image" src="https://github.com/user-attachments/assets/3c792c9d-8349-4f87-a55e-a1aea1156aa2" />
</p>
Na página que foi aberta, vá a *Permissions policies*, e em "Add permissions", escolha a opção *Create inline policy*.

<p align="center">
<img width="1472" height="284" alt="image" src="https://github.com/user-attachments/assets/1f5ecd36-4057-4e63-a489-0e3580b057ca" />
</p>

Você será redirecionado para uma página para especificar permissões, onde tem duas maneiras para adicioná-las: Ou através de uma declaração JSON ou por método visual, onde escolherá os níveis de acesso (List, Read, Write, Tagging) e recursos ARN (__*All*__ OR __*Specific*__). Neste caso, só é necessário a ação __"BatchPutAssetPropertyValue"__ , onde "Grants permission to put property values for asset properties". Nestes casos normalmente os recursos não são específicos, entãom em *Resources*, selecione a opção "All".

<p align="center">
<img width="987" height="746" alt="image" src="https://github.com/user-attachments/assets/aa972b01-9606-4075-8f97-ff6a20f6c3c6" />
</p>


Se quiser fazer em formato JSON poderá usar a seguinte declaração:

``` 
{
	"Version": "2012-10-17",
	"Statement": [
		{
			"Effect": "Allow",
			"Action": "iotsitewise:BatchPutAssetPropertyValue",
			"Resource": "*"
		}
	]
}
```

Clique em Next.

Insira uma nome para a policy e clique em *Create policy*.

<p align="center">
<img width="1638" height="502" alt="image" src="https://github.com/user-attachments/assets/22b726ee-0921-4baa-acea-7d2a8abd5dfd" />
</p>
E assim temos a IAM role criada.

<p align="center">
<img width="1597" height="882" alt="image" src="https://github.com/user-attachments/assets/8f9695a1-f0d9-4374-8292-24f89ce2cbd7" />
</p>

Volte de novo à página onde estava a criar a rule. Use o ícone <img width="32" height="38" alt="image" src="https://github.com/user-attachments/assets/38c264e1-662e-49a2-a39e-e40ecb06214b" /> para atualizar a lista de roles e volte a inserir a role criada. De seguida Clique em "Next" e depois em "Create". Faça o mesmo com os restantes tópicos e assim poderá redirecionar os dados que estão na AWS IoT Core para a AWS IoT SiteWise.

