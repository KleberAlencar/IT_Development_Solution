-- 4. Procedure para verificacao de precos
IF OBJECT_ID('VerificarPrecoProduto', 'P') IS NOT NULL
    DROP PROCEDURE VerificarPrecoProduto;
GO

CREATE PROCEDURE VerificarPrecoProduto
    @Produto VARCHAR(100)
AS
BEGIN
    DECLARE @HoraAtual INT = DATEPART(HOUR, GETDATE());
    DECLARE @DataLimite DATE;
    DECLARE @PrecoEncontrado DECIMAL(10,2);
    DECLARE @DataEncontrada DATE;
    DECLARE @Status VARCHAR(10);
    DECLARE @Mensagem VARCHAR(200);

    IF @HoraAtual < 10
        SET @DataLimite = DATEADD(DAY, -1, CAST(GETDATE() AS DATE));
    ELSE IF @HoraAtual < 13
        SET @DataLimite = DATEADD(DAY, -5, CAST(GETDATE() AS DATE));
    ELSE
        SET @DataLimite = DATEADD(DAY, -30, CAST(GETDATE() AS DATE));

    SELECT TOP 1 @PrecoEncontrado = Preco,
                 @DataEncontrada = DataReferencia
      FROM Precos
     WHERE UPPER(Produto) = UPPER(@Produto)
       AND DataReferencia >= @DataLimite
     ORDER BY DataReferencia DESC;

    IF @PrecoEncontrado IS NULL
    BEGIN
        SET @PrecoEncontrado = 0;
        SET @Status = 'NÃO OK';
        SET @Mensagem = 'Preço não encontrado dentro do intervalo permitido.';
    END
    ELSE
    BEGIN
        SET @Status = 'OK';
        SET @Mensagem = 'Preço encontrado com sucesso.';
    END

    SELECT @Produto AS Produto,
           @PrecoEncontrado AS Preco,
           @DataEncontrada AS DataReferencia,
           @Status AS Status,
           @Mensagem AS Mensagem;
END;
GO