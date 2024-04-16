SELECT	T1.Numero AS 'Número Processo',
		T0.Nome AS 'Nome Pessoa',
		FORMAT(T1.DataVencimento, 'dd/MM/yyyy') As 'Data Vencimento',
		FORMAT(T2.DataPagamento, 'dd/MM/yyyy') AS 'Data Pagamento',
		REPLACE(T1.Valor, '.', ',') AS 'Valor Líquido',
		CASE
			WHEN ISNULL(T2.Numero, 0) > 0 THEN 'Conta Paga'
			ELSE 'Conta a Pagar'
		END AS 'Status'
FROM Senior.dbo.Pessoas T0
	JOIN Senior.dbo.ContasAPagar T1 ON (T0.Id = T1.CodigoFornecedor)
	LEFT JOIN Senior.dbo.ContasPagas T2 ON (T1.Numero = T2.Numero) AND (T1.CodigoForecedor = T2.CodigoFornecedor)
