# CASE 4:

## 1. INSTRUÇÕES:
- Você pode e deve executar os códigos abaixo no seu ambiente de desenvolvimento antes de responder os cases.

- Você pode pesquisar qualquer coisa, a qualquer momento. Lembre-se entretanto de atribuir a origem devida caso tenha utilizado código do StackOverflow, etc.

- Escreva tudo o que achar relevante para sua resposta. Não esperamos que responda a prova com código, mas fique à vontade caso queira exemplificar o seu pensamento.

- Os cases apresentados são fictícios. Não há uma única resposta correta. Use o seu próprio julgamento e experiência.

## 2. PROBLEMA:
Defina uma classe que represente um Super-herói com **Nome**, **data de nascimento** e **nível de Kryptonita**. O Super-herói pode Voar, caso o nível de Kryptonita seja menor que 2. Quando o Super-herói estiver voando, retorne uma string “Voando...”.

## 3. INSTRUÇÕES INICIAIS:
Selecionar o projeto **SuperHero** para executar o código.

## 4. RESOLUÇÃO:
- Criada classe SuperHero com os atributos Name, Alias, BirthDate e KryptoniteLevel.
- Foi definido método FlightPowers com modificador virtual (pode ou não ser sobrescrito) e que retorna uma string informando se o super-herói está voando.
- Classes derivadas de SuperHero foram criadas como Superman, Batman, GeneralZod, GreenArrow e TheFlash.
- Algumas classes derivadas sobreescrevem o método FlightPowers para retornar uma string específica.
- Na Program.cs foi criada uma lista de super-heróis e um loop para imprimir informações e método FlightPowers de cada super-herói.
- Existem diferentes estratégias para implementação, considerei aqui a mais simples, mas poderia haver uma propriedade booleana definindo se o super-herói pode voar.

