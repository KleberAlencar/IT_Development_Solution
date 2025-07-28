-- 1. Criação da tabela principal
IF OBJECT_ID('Investimentos', 'U') IS NOT NULL
    DROP TABLE Investimentos;

-- OBS.: Provavelmente não criaria uma tabela com as colunas neste formato
CREATE TABLE Investimentos (
    Investidor VARCHAR(100),
    ProdutoComprado VARCHAR(100)
);

-- 2. Inserção de dados iniciais
INSERT INTO Investimentos (Investidor, ProdutoComprado) VALUES
('Produto 1', 'Produto 2'),
('Produto 2', 'Produto 3'),
('Produto 3', 'Produto 4');

GO