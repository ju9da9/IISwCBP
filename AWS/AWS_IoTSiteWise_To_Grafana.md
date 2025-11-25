# AWS IoT SiteWise <-> Grafana (Local)



O objetivo desta fase é o acesso aos dados do AWS IoT Sitewise a partir da Grafana, uma plataforma de visualização de dados a partir de dashboards. Para isso, será necessário criar uma nova data source na grafana para poder ter acesso aos dados da AWS.
Para tal é necessário criar uma conta na Grafana. Em relação à região, pode escolher "EU Germany". É de notificar que ao usar a Grafana local, o utilizador tem acesso a uma unlimited usage trial por 12 dias.

Clique em *Get Started*.

<img width="1129" height="629" alt="image" src="https://github.com/user-attachments/assets/e06bc6e2-1364-401b-8767-9bea95a832f2" />

Vá em *Connect and Visualize Data*.

<img width="1836" height="730" alt="image" src="https://github.com/user-attachments/assets/19456a47-2ca5-4f44-923e-06b415f314ad" />


O próximo passo passa por pesquisar qual o sistema ou serviço a ser utilizado para fazer esta conexão. Pesquise pela opção "AWS" e selecione-a.

<img width="1021" height="509" alt="image" src="https://github.com/user-attachments/assets/d6d1ff6a-c403-49e8-b9f0-a789c9858d05" />

De seguida, selecione a opção "Visualize your AWS Datasource data" e escolha a opção "AWS Sitewise", e clique em "Continue".

<img width="929" height="826" alt="image" src="https://github.com/user-attachments/assets/7f1bdaa7-abce-49cc-b1ea-a1c8a843c7b1" />


Ao seguir estes passos, clique em *Install*.

<img width="1578" height="553" alt="image" src="https://github.com/user-attachments/assets/947f9786-86a4-49d4-aa71-104102489aea" />


Na barra lateral, abra o separador "Connections" e clique em "Data Sources".

<img width="302" height="666" alt="image" src="https://github.com/user-attachments/assets/cd1a4743-69df-4a11-a458-1f1a3f8ddb24" />

Estando uma vez na página de data sources, clique em "Add new data source".

<img width="1575" height="218" alt="image" src="https://github.com/user-attachments/assets/6fe10e5e-e45a-4076-853d-d15e76005ef9" />


Pesquise por "AWS IoT SiteWise", e clique na opção *AWS IoT SiteWise*.

<img width="672" height="147" alt="image" src="https://github.com/user-attachments/assets/4a88ac18-ffe1-441a-93cc-269666d685ef" />

Para poder aceder aos dados da AWS IoT SiteWise, é necessário ter uma chave de acesso juntamente com o endpoint e a região do do serviço. Para tal, deve ser criar um *IAM User* que tenha permissões de:
  1. Poder obter o valor atual das propriedades dos assets;
  2. Obter o histórico dos valores das propriedades;
  3. Poder obter a estampa de tempo (*timestamp*) para as propriedades dos assets;

Para poder fazer isso, Volte à AWS e pesquise por IAM. Quando chegar à página, vá a *Users* e crie um novo *user*.

<img width="1584" height="274" alt="image" src="https://github.com/user-attachments/assets/9bdd2999-a1c9-4b88-aae0-1b7a12aca63a" />

Insira um *User name* e clique em *Next*.

<img width="1502" height="457" alt="image" src="https://github.com/user-attachments/assets/1e0aa7ee-9b41-431d-8c2a-63e1f3b11f66" />

Seleccione na opção *Attatch policies directly*, e crie uma nova policy em *Create policy*. Insira um nome (por exemplo, "GrafanaSiteWiseReadOnly").

<img width="1477" height="298" alt="image" src="https://github.com/user-attachments/assets/1fba5800-9232-42e5-96c0-e909252a091e" />

Insira as seguintes ações conforme se encontra nno comando seguinte:

```
{
    "Version": "2012-10-17",
    "Statement": [
        {
            "Effect": "Allow",
            "Action": [
                "iotsitewise:Describe*",
                "iotsitewise:Get*",
                "iotsitewise:List*",
                "iotsitewise:BatchGetAssetPropertyValue",
                "iotsitewise:BatchGetAssetPropertyValueHistory"
            ],
            "Resource": "*"
        }
    ]
}

```

Salve a *policy* criada.

Volte à página da criação do *IAM User* (na parte das *policies*), Selecione a policy criada e clique em *Next*.

<img width="1490" height="409" alt="image" src="https://github.com/user-attachments/assets/40244f69-e858-4cd1-9e8e-81d8a4a6cfe5" />


No final, clique em *Create user*.

<img width="1516" height="694" alt="image" src="https://github.com/user-attachments/assets/0d19b020-0b86-44ee-98e2-ed19bdd368c4" />


Ainda nas definições do IAM, vá a users e entre no user criado. No separador "security credentials", e em access keys crie uma nova.

<img width="1554" height="219" alt="image" src="https://github.com/user-attachments/assets/f0758922-76eb-4112-83a4-03d4ab7d2d59" />


Selecione a opção *Application running outside AWS* e clique em *Next*. Como a página seguinte é opcional, clique em *Create access Key*.

<img width="1582" height="764" alt="image" src="https://github.com/user-attachments/assets/35428fda-bcc8-43ff-82d7-94ab7a449925" />




Assim que cria uma nova *access key*, é importante guardar tanto a *access key* como a *secret access key*, por que uma vez que clica em *Done*,  não conseguirá ter acesso a esta página, obrigando a ter que criar uma nova chave. Por isso faça o download .CSV das chaves e guarde-as.


<img width="1532" height="690" alt="image" src="https://github.com/user-attachments/assets/346e1227-48a7-443b-b12a-27328652497b" />


Uma vez que tem a access key pode voltar à grafana para poder fazer a comunicação, inserindo as chaves nos locais pedidos e clique em *Save*.

Opcionalmente, também pode adicionar o *Endpoint* e a região do serviço da AWS IoT SiteWise.

<img width="506" height="206" alt="image" src="https://github.com/user-attachments/assets/c6d104e1-341f-4b11-80b0-ee310ad4bedd" />

Se aparecer esta notificação, significa que está pronto para retirar informação do AWS IoT SiteWise e criar uma dashboard ou fazer querying dos dados.


<img width="790" height="113" alt="image" src="https://github.com/user-attachments/assets/4ff895d3-3590-4569-8339-768fcc4f8a6b" />

Se voltar na página das data sources, pode ver que foi adicionada a data source que criou. Clique em "Build a dashboard" criar uma dashboard nova.

<img width="1564" height="98" alt="image" src="https://github.com/user-attachments/assets/a51cc33b-63b2-49f9-b929-4142c2c011a1" />

Na página da nova dashboard, nós iremos adicionar um painel. Para isso, clique em "add visualization"

<img width="960" height="494" alt="image" src="https://github.com/user-attachments/assets/d7cbb13f-a940-4c69-bde1-f82c86fcf378" />

Irá aparecer uma janela para selecionar uma data source. Escolha na data source que criou "grafana-iot-sitewise-datasource".

<img width="1186" height="687" alt="image" src="https://github.com/user-attachments/assets/23cdd78e-43bb-434a-b3ee-f0b815b6a516" />


Caso queira ver o histórico de valores num formato Time Series e queira mudar o nome do gráfico, vá na barra lateral à direita nos parâmetros "Visualization" e "Panel options" - Title


<img width="282" height="290" alt="image" src="https://github.com/user-attachments/assets/62e7d8d1-4f63-479d-8ebb-c11821390519" />

dfghgfdsg METER ALGUM TEXTO AQUI!

<img width="379" height="72" alt="image" src="https://github.com/user-attachments/assets/6a1f8c64-3e9e-4c68-9919-b4d2058ddbc6" />

De seguida deve selecionar o Asset pretendido, ao ir no parâmetro Asset --> Botão Explore


<img width="681" height="361" alt="image" src="https://github.com/user-attachments/assets/d26a337e-7ac3-4721-86d5-e60e74ef2c6e" />

asfdfghj


<img width="678" height="712" alt="image" src="https://github.com/user-attachments/assets/62d0e48d-9a4d-4b8a-9307-f278f399f2b6" />


Depois escolhe qual a propriedade/ variável que quer visualizar

<img width="249" height="206" alt="image" src="https://github.com/user-attachments/assets/6d3a2dcd-88ca-40bc-908a-014b4dc37479" />


Se for na opção "Run Query" / "Run Queries" -dependendo do período de tempo que selecionar (last 24/12/6/3/1 hour(s) ou datas anteriores) - poderá visualisar o gráfico que criou

<img width="1613" height="457" alt="image" src="https://github.com/user-attachments/assets/b419cd43-fde1-4073-9eeb-e6a52ee889c1" />


Se quiser adicionar alertas, é necessário usar transformações com as data sources da AWS IoT SiteWise (e recomendável usar num panel com um uníco query ) uma vez que o formato dos dados retornados/devolvidos pela query não é compatível com o  formato que o sistema/ mecanismo de alertas do grafana aceita ( tipo "wide series", ou seja, uma única série numérica por query refid) uma vez que o que é enviado para o grafana envolve tres séries numéricas (timestamp, o valor da variável, e a qualidade do envio)- referência do chat gpt (descobrir a referência ou bibliografia onde se encontra esta parte).



Para tal , salve as suas alterações da dashboard e no canto inferior esquerdo do painel de visualização  clique em "transformations" (ver seguinte site: [Query and transform data | Grafana documentation] https://grafana.com/docs/grafana/latest/panels-visualizations/query-transform-data/



























