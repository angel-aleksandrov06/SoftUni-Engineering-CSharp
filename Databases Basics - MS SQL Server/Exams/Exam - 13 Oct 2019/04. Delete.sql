DELETE FROM RepositoriesContributors
WHERE RepositoryId = (Select Id
	FROM Repositories
	WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (Select Id
	FROM Repositories
	WHERE [Name] = 'Softuni-Teamwork')