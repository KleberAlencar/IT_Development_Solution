# CASE 6:

## 1. INSTRUÇÕES:
- Você pode e deve executar os códigos abaixo no seu ambiente de desenvolvimento antes de responder os cases.

- Você pode pesquisar qualquer coisa, a qualquer momento. Lembre-se entretanto de atribuir a origem devida caso tenha utilizado código do StackOverflow, etc.

- Escreva tudo o que achar relevante para sua resposta. Não esperamos que responda a prova com código, mas fique à vontade caso queira exemplificar o seu pensamento.

- Os cases apresentados são fictícios. Não há uma única resposta correta. Use o seu próprio julgamento e experiência.

## 2. PROBLEMA:
**Verificação de dados por período**

Um usuário abriu uma solicitação de melhoria para que o sistema realize o pagamento com base no último preço com limite nos últimos 30 dias. No entando, foram estabelecidas algumas regras adicionais de acordo com o horário atual. Sendo:

- Até as 10h, o sistema deve considerar os preços de até 1 dia anterior
- Até as 13h, o sistema deve considerar os preços de até 5 dias anteriores
- Apos as 13h, o sistema deve considerar os preços de até 30 dias anteriores
- Caso não encontre preço segundo as regras, o sistema deve retornar preço zero, status erro e uma mensagem informando que o preço não foi encontrado.

A tabela de preços contém os seguintes campos: Produto, Data Referência, Preço

Dados as premissas, você deve elaborar uma procedure que realize essas verificações na tabela de preços e retorne o preço encontrado, a data referência encontrada e um status ok/não ok.

## 3. CONSIDERAÇÕES:
1. Por se tratar de procedure entendo que tudo deverá ser resolvido nesta camada, inclusive a regra de negócio.
2. É uma base de dados relacional.
3. Não estão sendo consideradas outras tabelas que podem ajudar na verificação.
4. O valor da coluna Produto é armazenado na base com o tipo string, porém poderia ser um valor numérico.
5. A solução apresentada é uma solução pontual, baseada nas informações fornecidas, para melhor resolução seriam importantes mais informações.

## 4. INSTRUÇÕES INICIAIS:
1. Poderá ser utilizado o comando 'docker compose up -d' do Case 5 (anterior) para subir o container do banco de dados SQL Server.

## 5. RESOLUÇÃO:
1. Executar script de criação da tabela e inserção dos dados iniciais.
   **01_Criar_Tabela_Precos.sql**

2. Criar a procedure que irá realizar as validações.
   **02_Criar_Procedure_Verificacao_Precos.sql**

3. Testar procedure via script.
   **03_Testar_Procedure.sql**
