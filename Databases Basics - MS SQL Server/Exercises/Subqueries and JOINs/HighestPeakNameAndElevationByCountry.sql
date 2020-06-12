SELECT TOP(5)
	  Country, 
	  CASE
		  WHEN PeakName IS NULL THEN '(no highest peak)'
		  ELSE PeakName 
		END AS [Highest Peak Name],
	  CASE
		  WHEN Elevation IS NULL THEN 0
		  ELSE Elevation 
		END AS [Highest Peak Elevation],
	  CASE
		  WHEN MountainRange IS NULL THEN '(no mountain)'
		  ELSE MountainRange 
		END AS [Mountain]
		FROM(
			SELECT *,
					DENSE_RANK() OVER (PARTITION BY [Country] ORDER BY [Elevation] DESC) AS [PeakRank]
				FROM(
					SELECT 
						CountryName AS [Country],
						p.PeakName,
						p.Elevation,
						m.MountainRange
						FROM Countries c
						LEFT JOIN MountainsCountries mc
						ON mc.CountryCode = c.CountryCode
						LEFT JOIN Mountains m
						ON m.Id = mc.MountainId
						LEFT JOIN Peaks p
						ON p.MountainId = m.Id
					) AS [FullInfoQuery]
			) AS [PeakRankingQuery]
	WHERE [PeakRank] = 1
	ORDER BY Country ASC, [Highest Peak Name] ASC