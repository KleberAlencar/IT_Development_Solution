-- 5. Testar a procedure de verificacao de precos
EXEC VerificarPrecoProduto @Produto = 'Produto A';
EXEC VerificarPrecoProduto @Produto = 'Produto X'; -- produto inexistente
EXEC VerificarPrecoProduto @Produto = 'Produto B';
GO