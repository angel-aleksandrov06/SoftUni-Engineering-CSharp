SELECT * 
	FROM Towns
	WHERE LEFT([Name],1) IN ('M', 'K', 'B', 'E')
	ORDER BY [Name] ASC

SELECT *
	FROM Towns
	WHERE [NAME] LIKE '[MKBE]%'
	ORDER BY [Name] ASC