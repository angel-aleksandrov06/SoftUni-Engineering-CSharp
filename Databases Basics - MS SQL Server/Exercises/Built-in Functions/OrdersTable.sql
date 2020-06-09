Select ProductName, OrderDate, DATEADD(day, 3, OrderDate) AS [Pay Due], DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
	From Orders