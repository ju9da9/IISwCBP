# Siemens Insights Hub

- dizer o que é

O primeiro passo para começar a criar soluções no Insights Hub é modelar corretamente os seus dados e ativos.  
Para isso, o fluxo recomendado é:

1. Criar os **Aspects**
2. Criar os **Types**
3. Criar os **Assets**

Essa sequência ajuda a estruturar a informação de forma consistente e facilita a reutilização do modelo em diferentes equipamentos ou máquinas.

Os **Aspects** são a representação digital das variáveis de um equipamento e um mecanismo de modelação de dados para assets. Eles agrupam datapoints relacionados com base na sua associação lógica e podem consistir em várias variáveis.
Em termos práticos, um Aspect define quais dados um asset pode expor, como medições, estados ou sinais de operação.

Um **Type** é um modelo pré-configurado para um asset. Os assets assumem as propriedades do type no qual são baseados. Dentro de um Type, pode-se definir quais Aspects fazem parte do modelo, permitindo padronizar a estrutura dos assets criados a partir dele.

Um **Asset** é a representação digital de uma combinação de equipamentos ou de uma máquina com uma ou várias unidades de automação, por exemplo um PLC, conectadas ao Mindsphere.
O Asset é o objeto final que representa o ativo real no sistema, permitindo monitorização, organização e utilização dos dados provenientes dos dispositivos ligados.
