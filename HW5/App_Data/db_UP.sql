CREATE TABLE dbo.DMVs
(
	ID					INT IDENTITY (1,1) NOT NULL,
	Permit				INT NOT NULL,
	FullName			NVARCHAR(192) NOT NULL,
	DOB					DateTime NOT NULL,
	ResidenceAddress    NVARCHAR(192) NOT NULL,
	City				NVARCHAR(64) NOT NULL,
	StateAbbreviated	NVARCHAR(2) NOT NULL, 
	ZipCode				INT NOT NULL,
	County				NVARCHAR(64) NOT NULL,
	CONSTRAINT [PK_dbo.dmv] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.DMVs (Permit,FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County) VALUES
			(8673443, 'Frank Johnson','1942-03-13 00:00:00', '1432 Wyrmwood Rd.' , 'Dallas', 'OR', 33442, 'Adelaide'),
			(1937542, 'Frannie Kay','1978-12-1 00:00:00', '132 1st St.' , 'Olympia', 'WA', 42622, 'Filstin'),
			(8673443, 'Julie Mac','1993-04-25 00:00:00', '6934 Brunst Rd.' , 'Debran', 'GA', 33442, 'Colston'),
			(8673443, 'Mikhail Monroe','1978-08-09 00:00:00', '192 Central Ave.' , 'Stockland', 'OK', 19276, 'Cricklin'),
			(8673443, 'Joe Burns','1988-07-22 00:00:00', '3497 Cork St.' , 'Turner', 'MN', 78004, 'Luclad');
GO