#  How to visualise graphical data in Azure Digital Twins with Azure Data Explorer

Antes de configurar a instância ADT, deve-se criar um event hub **(Explicar porquê)**

Vá a página da Envent Hubs na Azure portal e crie um Event Hub namespace **(explicar o que é)**

<p align="center">
<img width="1543" height="911" alt="image" src="https://github.com/user-attachments/assets/b4c42ef8-ea18-49fa-9a84-1076647964f3" />
</p>

Depois preenche os requerimentos de acordo com a seguinte imagem. Se já tiver um grupo utilize o mesmo grupo para criar um Namespace. Depois clique em 'Review + Create' e depois volte a clicar em 'Create'

<p align="center">
<img width="828" height="823" alt="image" src="https://github.com/user-attachments/assets/6808b70c-fca1-41c9-947e-73a931098841" />
</p>

Assim que aparecer a próxima imagem , pode -se confimar que o <Event hub namespace já foi criado. De seguida, clicar em 'Go to resource'.

<p align="center">
<img width="809" height="493" alt="image" src="https://github.com/user-attachments/assets/684a4295-2d5a-4a3d-bd34-b248c29e181a" />
</p>

Na página, para criar Um Event Hub  clique em '+ Event Hub'

<p align="center">
<img width="795" height="594" alt="image" src="https://github.com/user-attachments/assets/d5ab43b6-a9b2-4000-84e6-96b4ad9810fd" />
</p>

Preencha os seguintes parametros e depois clique em  Review + Create

The partition count setting allows you to parallelize consumption across many consumers. For more information, see Partitions.

The message retention setting specifies how long the Event Hubs service keeps data. For more information, see Event retention.

<p align="center">
<img width="964" height="798" alt="image" src="https://github.com/user-attachments/assets/83f97f69-4a9f-48d1-8ba8-8dda10161b75" />
</p>

Rem Review + Create, selecione em Create

É possível verificar a criação do event hub, nas 'entities' do Event hub namespace, como mostra a Imagem seguinte

<p align="center">
<img width="1862" height="682" alt="image" src="https://github.com/user-attachments/assets/3476ca46-5dab-4056-9dcd-37fa5727682d" />
</p>

O próximo passo passa por Criar um Azure Data Explorer Cluster e uma database gratuitos. Para isso, inicie sessão no Azure Data Explorer. Assim que iniciar sessão, vá no separador lateral "My Cluster" e clique em "Create cluster and database"

<p align="center">
<img width="1624" height="866" alt="image" src="https://github.com/user-attachments/assets/9cd6efb6-630c-4576-b233-2d9c0aa4cf60" />
</p>

Irá aparecer uma janela pop-up para preencher os seguintes parãmetros e depois clique em "create"

<p align="center">
<img width="683" height="672" alt="image" src="https://github.com/user-attachments/assets/78842b71-5fc3-4f74-8f67-4b0981a60139" />
</p>

Ainda na página "My Cluster" crie uma database

<p align="center">
<img width="1281" height="424" alt="image" src="https://github.com/user-attachments/assets/b74af661-3914-4fee-b6ab-0460f442672e" />
</p>

Insisra um nome para a Database e clique em 'Next: Create Database'

<p align="center">
<img width="866" height="778" alt="image" src="https://github.com/user-attachments/assets/a8f469a1-e18e-4622-9179-acfea7796a9e" />

Faz o upgrade do cluster

<p align="center">
<img width="672" height="837" alt="image" src="https://github.com/user-attachments/assets/fa63d5c2-aebd-4bf4-839a-3c6dfc81749b" />
</p>

<p align="center">
<img width="503" height="177" alt="image" src="https://github.com/user-attachments/assets/c6248dbc-6649-4ed2-bdd4-642054a55978" />
</p>

------------------------

Na instância da Azure Digital Twins, ir no separador Connect Outputs --> Data History. De pois clique em "Create a Connection"

<p align="center">
<img width="1621" height="882" alt="image" src="https://github.com/user-attachments/assets/019f99f2-2c67-4615-a75d-d58aefb76db5" />
</p>

Selecione a opção "System- Assigned" no parãmetro de 'Authentication' e clique em Next

<p align="center">
<img width="1266" height="465" alt="image" src="https://github.com/user-attachments/assets/15ec0f66-306c-4259-813d-a76b3b123ee1" />
</p>

> NOTA: Caso não tenha If you don't already have a managed identity enabled for your Azure Digital Twins instance ( , you see this [page first](https://learn.microsoft.com/en-us/azure/digital-twins/how-to-set-up-instance-portal#enabledisable-managed-identity-for-the-instance) , asking you to turn on Identity for the instance as the first step for the data history connection. Caso já esteja ativado siga para o próximo passo

Na página 'Send' Preencha os requesitos com os recursos criados do Event hub e Clique em 'Next'

<p align="center">
<img width="1294" height="789" alt="image" src="https://github.com/user-attachments/assets/db8d740f-d388-4c75-bec2-33f8d275386c" />
</p>

Na página 'Store', selecione a subscrição pretendida, selecionne o cluster criado anteriormente e selecione a base de dados já também criada.
Em 'table names', dê um nome em **Property event table name**, tal como está na imagem abaixo e ative a opção **Include property removal events** (checkbox selecionada na imagem abaixo).
Clique em **Next** para avançar.

<p align="center">
<img width="1278" height="815" alt="image" src="https://github.com/user-attachments/assets/b69888e2-18f1-4c2a-adef-1ddfe8b34a08" />
</p>

Na página 'Permission', são apresentados os roles necessários para que a instância do **Azure Digital Twins** consiga:
- enviar dados para o **Event Hub**
- ligar ao **Azure Data Explorer** (cluster e base de dados)

Para cada um dos blocos apresentados, atribua permissões (Grant permission) em:
- **Azure Event Hubs Data Owner**
- **Contributor on the Azure Data Explorer cluster**
- **Admin on the Azure Data Explorer database**
  
Em cada bloco, quando surgir a mensagem de confirmação para prosseguir com a atribuição de roles, clique em **Yes**.
<p align="center">
<img width="1263" height="809" alt="image" src="https://github.com/user-attachments/assets/9acf5c33-cec7-4f06-8696-dfa5fcb659c4" />
</p>

> Nota: É normal O Azure Event Hubs Data Owner não estar selecionado, porque pode já ter permissões iguais ou superiores atribuídas manualmente, permitido que aavence para o próximo passo
> <p align="center">
> <img width="824" height="296" alt="image" src="https://github.com/user-attachments/assets/f176672f-ac28-4d34-8df0-ccd5f4d42771" />
> </p>

Depois de concluir as atribuições necessárias, clique em **Next** para avançar para **Review + create**.

Após receber a confirmação de que já foi criada uma connection, clique em **Open Azure data Explorer** para confirmar.

<p align="center">
<img width="876" height="233" alt="image" src="https://github.com/user-attachments/assets/1b751e8b-b9fa-4f01-8696-0a15659d928c" />
</p>

Na Azure Digital Twins:
Clique no botão (já ativada) da data history da Azure Digital Twins, Onde poderá ver o histórico das suas variáveis em formato de gráfico ou tabela.

<p align="center">
<img width="1393" height="741" alt="image" src="https://github.com/user-attachments/assets/a9982849-3fbd-4363-abe6-e947d4f6153d" />
</p>

<p align="center">
<img width="929" height="631" alt="image" src="https://github.com/user-attachments/assets/7ab3d1e9-f953-47db-90db-201b07552f80" />
</p>

<p align="center">
<img width="932" height="628" alt="image" src="https://github.com/user-attachments/assets/938b8903-e862-49bf-a334-4513581c5a1d" />
</p>


