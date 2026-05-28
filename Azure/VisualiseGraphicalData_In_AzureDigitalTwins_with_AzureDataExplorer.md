#  How to visualise graphical data in Azure Digital Twins with Azure Data Explorer

Antes de configurar a instância ADT, deve-se criar um event hub.

<img width="1543" height="911" alt="image" src="https://github.com/user-attachments/assets/b4c42ef8-ea18-49fa-9a84-1076647964f3" />

Depois preenche os requerimentos de acordo com a seguinte imagem. Se já tiveir um grupo utilize o mesmo grupo para criar um Namespace. Depois clique em Review + Create e depois volte a clicar em 'Create

<img width="828" height="823" alt="image" src="https://github.com/user-attachments/assets/6808b70c-fca1-41c9-947e-73a931098841" />

Assim que aparecer a próxima imagem , pode -se confimar que o <Event hub namespace já foi criado. De seguida, clicar em 'Go to resource'.

<img width="809" height="493" alt="image" src="https://github.com/user-attachments/assets/684a4295-2d5a-4a3d-bd34-b248c29e181a" />

Na página, para criar Um Event Hub  clique em '+ Event Hub'

<img width="795" height="594" alt="image" src="https://github.com/user-attachments/assets/d5ab43b6-a9b2-4000-84e6-96b4ad9810fd" />


Preencha os seguintes parametros e depois clique em  Review + Create

The partition count setting allows you to parallelize consumption across many consumers. For more information, see Partitions.

The message retention setting specifies how long the Event Hubs service keeps data. For more information, see Event retention.

<img width="964" height="798" alt="image" src="https://github.com/user-attachments/assets/83f97f69-4a9f-48d1-8ba8-8dda10161b75" />

Rem Review + Create, selecione em Create

É possível verificar a criação do event hub, nas 'entities' do Event hub namespace, como mostra a Imagem seguinte

<img width="1862" height="682" alt="image" src="https://github.com/user-attachments/assets/3476ca46-5dab-4056-9dcd-37fa5727682d" />
