-- 1. Criacao tabela principal
IF OBJECT_ID('Precos', 'U') IS NOT NULL 
	DROP TABLE Precos;

CREATE TABLE Precos (
    Produto VARCHAR(100) NOT NULL,
    DataReferencia DATE NOT NULL,
    Preco DECIMAL(10,2) NOT NULL
);

-- 2. Integridade e performance
ALTER TABLE Precos ADD CONSTRAINT CK_Preco_Positive CHECK (Preco >= 0);
CREATE INDEX IDX_Produto_Data ON Precos (Produto, DataReferencia); 

-- 3. Insercao de dados iniciais
DELETE FROM Precos;
INSERT INTO Precos (Produto, DataReferencia, Preco) VALUES
  ('Produto A', CAST(GETDATE() AS DATE), 10.00),    
  ('Produto A', DATEADD(DAY, -1, GETDATE()), 9.50), 
  ('Produto A', DATEADD(DAY, -3, GETDATE()), 9.00),  
  ('Produto A', DATEADD(DAY, -6, GETDATE()), 8.50),  
  ('Produto A', DATEADD(DAY, -20, GETDATE()), 8.00), 
  ('Produto A', DATEADD(DAY, -31, GETDATE()), 7.50), -- 31 dias (fora da janela)
  ('Produto B', CAST(GETDATE() AS DATE), 20.00),    
  ('Produto B', DATEADD(DAY, -1, GETDATE()), 19.50), 
  ('Produto B', DATEADD(DAY, -3, GETDATE()), 19.00),  
  ('Produto B', DATEADD(DAY, -6, GETDATE()), 18.50),  
  ('Produto B', DATEADD(DAY, -20, GETDATE()), 18.00), 
  ('Produto B', DATEADD(DAY, -31, GETDATE()), 17.50); -- 31 dias (fora da janela)  
GO
