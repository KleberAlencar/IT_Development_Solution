-- 3. Procedure para verificacao de informacao existente
IF OBJECT_ID('VerificarInvestimentoExistente', 'P') IS NOT NULL
    DROP PROCEDURE VerificarInvestimentoExistente;
GO

CREATE PROCEDURE VerificarInvestimentoExistente
    @Investidor VARCHAR(100),
    @ProdutoComprado VARCHAR(100),
    @Status VARCHAR(10) OUTPUT,
    @Mensagem VARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    CREATE TABLE #Caminho (
        Produto VARCHAR(100)
    );

    INSERT INTO #Caminho (Produto)
    VALUES (@ProdutoComprado);

    DECLARE @ProdutoAtual VARCHAR(100);

    WHILE EXISTS (
        SELECT 1 FROM #Caminho c
        WHERE EXISTS (
            SELECT 1 FROM Investimentos i
            WHERE i.Investidor = c.Produto
              AND i.ProdutoComprado NOT IN (SELECT Produto FROM #Caminho)
        )
    )
    BEGIN
        DECLARE cur CURSOR FOR
        SELECT Produto FROM #Caminho;

        OPEN cur;
        FETCH NEXT FROM cur INTO @ProdutoAtual;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            INSERT INTO #Caminho (Produto)
            SELECT ProdutoComprado
            FROM Investimentos
            WHERE Investidor = @ProdutoAtual
              AND ProdutoComprado NOT IN (SELECT Produto FROM #Caminho);

            FETCH NEXT FROM cur INTO @ProdutoAtual;
        END

        CLOSE cur;
        DEALLOCATE cur;
    END

    IF EXISTS (SELECT 1 FROM #Caminho WHERE Produto = @Investidor)
    BEGIN
        SET @Status = 'Não Ok';
        SET @Mensagem = 'Registro existente: ao inserir [' + @Investidor + ' -> ' + @ProdutoComprado +
                        '], verique o relacionamento Investidor/Produto.';
    END
    ELSE
    BEGIN
        SET @Status = 'Ok';
        SET @Mensagem = 'Cadastro permitido.';
    END

    DROP TABLE #Caminho;
END
GO