# Siemens Insights Hub

- dizer o que é

O primeiro passo para começar a criar soluções no Insights Hub é modelar corretamente os seus dados através de Aspects Types e Assets. Após a criação destes, será possível fazer o processo de onboarding, que consiste no
Para isso, a ordem recomendada é a seguinte:

1. [Criar **Aspects**](#1-criar-um-aspect)
2. [Criar **Types**](#2-criar-um-type)
3. [Criar **Assets**](#3-criar-um-asset)
4. [Processo de **Onboarding**](#processo-de-onboarding)

Essa sequência ajuda a estruturar a informação de forma consistente e facilita a reutilização do modelo em diferentes equipamentos ou máquinas.


Os **Aspects** são a representação digital das variáveis de um equipamento e um mecanismo de modelação de dados para assets. Eles agrupam datapoints relacionados com base na sua associação lógica e podem consistir em várias variáveis.
Em termos práticos, um Aspect define quais dados um asset pode expor, como medições, estados ou sinais de operação.

Um **Type** é um modelo pré-configurado para um asset. Os assets assumem as propriedades do type no qual são baseados. Dentro de um Type, pode-se definir quais Aspects fazem parte do modelo, permitindo padronizar a estrutura dos assets criados a partir dele.

Um **Asset** é a representação digital de uma combinação de equipamentos ou de uma máquina com uma ou várias unidades de automação, por exemplo um PLC, conectadas ao Mindsphere.
O Asset é o objeto final que representa o ativo real no sistema, permitindo monitorização, organização e utilização dos dados provenientes dos dispositivos ligados.


<img width="1920" height="1080" alt="Aspects_Types_Assets" src="https://github.com/user-attachments/assets/afa01656-550d-49fc-b6fd-fb22f42e9eca" />


---
# Criação de Aspects, Types e Assets

## 1. Criar um Aspect


No **Asset Manager**, e clique em **View your aspects**.

<img width="1115" height="760" alt="image" src="https://github.com/user-attachments/assets/9287a296-dda2-451a-912d-9c2152a1a83f" />


Clique em **Create Aspect** e preencha os seguintes campos:

- Name
- Description
- Category: `Dynamic`

<img width="895" height="600" alt="image" src="https://github.com/user-attachments/assets/f63e7623-a3c0-45e1-887d-50c0de2adb62" />


Em seguida, abra a janela **Variables** e clique em **Add Variable**. 

Adicione as variáveis necessárias que representam este aspect e no final, clique em **Save** para guardar o Aspect.


<img width="1309" height="540" alt="image" src="https://github.com/user-attachments/assets/43225fad-d368-4cc6-91a2-46d4c03ec888" />


<img width="1813" height="517" alt="image" src="https://github.com/user-attachments/assets/2972ced9-c790-4182-96b5-17e47f80a0a6" />


---


## 2. Criar um Type

No **Asset Manager**, clique em **View your types**

<img width="1115" height="760" alt="image" src="https://github.com/user-attachments/assets/38a4f9d5-2015-45cd-af85-25e9daaf998b" />


Dentro da página dos Types procure por **Basic Agent** e clique na seta desta opção. Escolha **MindConnectLib** como type e clique em **Create type**.


<img width="1172" height="604" alt="image" src="https://github.com/user-attachments/assets/339ca24f-ed44-4041-998c-a65e3db4fc67" />

Preencha:

- Name
- Description (Insira uma breve descrição do equipamento ou processo.
- Adicione uma imagem para fácil identificação do type
  
> O Type ID normalmente é preenchido automáticamente. Caso não aconteça, escreva de modo a ser igual ao Name.

Depois clique em **Browse Aspects**, procure e seleccione o Aspect criado anteriormente `Machine_Variables`, clique em **Add** (caso tenha outros outros aspects no qual queira adicionar seleccione também ).

<img width="1722" height="782" alt="image" src="https://github.com/user-attachments/assets/cb2ae504-58ad-4007-8fc6-be1a2010a266" />

Após já ter adicionado todos os aspects necessários, clique em **Save**.

<img width="1806" height="287" alt="image" src="https://github.com/user-attachments/assets/0bb6ab83-e6d8-4208-96ca-9d58dfd2cc00" />


---

## 3. Criar um Asset

No **Asset Manager**, clique em **View your assets**.

<img width="1115" height="760" alt="image" src="https://github.com/user-attachments/assets/6d04112d-ac1e-4a47-a0b9-1f587d26c82e" />

Clique em **Create Asset**

Preencha os seguintes campos:

- Name
- Description
- Asset type (Associe o Type criado anteriormente (neste caso, é `Machine_type`)
- Location (Alternativo)
- Image (Alternativo - para uma fácil identificação do type)

<img width="813" height="539" alt="image" src="https://github.com/user-attachments/assets/e15a0f5a-3cd3-4403-84b3-a80c6339e7b5" />

No final, clique em **Save**

<img width="1840" height="881" alt="image" src="https://github.com/user-attachments/assets/964d90fb-a097-4002-a273-7c5ceabaf7f6" />



---

# Processo de Onboarding
