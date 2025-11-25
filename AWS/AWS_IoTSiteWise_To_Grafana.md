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

Insira as seguintes ações conforme se encontra na imagem seguinte

'''
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

'''

<img width="579" height="286" alt="image" src="https://github.com/user-attachments/assets/f3ede255-cad9-442c-b189-f62762344ae7" />












