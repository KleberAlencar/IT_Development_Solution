-- 4. Testar a procedure de verificação de investimentos
DECLARE @Status VARCHAR(10), @Mensagem VARCHAR(MAX);

EXEC VerificarInvestimentoExistente 
    @Investidor = 'Produto 4',
    @ProdutoComprado = 'Produto 1',
    @Status = @Status OUTPUT,
    @Mensagem = @Mensagem OUTPUT;

SELECT @Status AS Status, @Mensagem AS Mensagem;

GO