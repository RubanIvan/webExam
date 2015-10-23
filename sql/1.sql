--DROP TABLE WordPackage
CREATE TABLE WordPackage (
        WordPackageID    int IDENTITY NOT NULL PRIMARY KEY,
		UserName		 NVARCHAR(1024),
		Title			 NVARCHAR(1024)
)
--drop TABLE Word
CREATE TABLE Word(
		WordID int IDENTITY NOT NULL PRIMARY KEY,
		WordPackageID   int,
		En				NVARCHAR(2048),
		Ru				NVARCHAR(2048)
)


ALTER TABLE Word  WITH CHECK ADD  CONSTRAINT [FK_WordPackage_WordPackageID] FOREIGN KEY(WordPackageID)
REFERENCES WordPackage(WordPackageID)
GO


select * from WordPackage
select * from word

--delete from WordPackage