SELECT f1.Id, f1.[Name], CONCAT(f1.Size, 'KB') AS [Size]
	FROM Files f1
	WHERE 
	(
	SELECT COUNT(*)
	FROM Files f2
	WHERE f1.Id = f2.ParentId
	) = 0 
	ORDER BY Id, [Name], f1.Size DESC

SELECT f1.Id, f1.[Name], CONCAT(f1.Size, 'KB') AS [Size]
	FROM Files f1
	WHERE Id NOT IN
		(
		SELECT DISTINCT ParentId FROM Files f2
		WHERE ParentId IS NOT NULL
		)
	ORDER BY Id, [Name], f1.Size DESC