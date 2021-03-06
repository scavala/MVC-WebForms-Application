USE [AdventureWorksOBP]
GO
/****** Object:  StoredProcedure [dbo].[DetaljiKupca]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DetaljiKupca]
	@id int
AS
BEGIN
	select * from Kupac where IDKupac=@id
END
GO
/****** Object:  StoredProcedure [dbo].[DohvatiDrzave]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DohvatiDrzave]
AS
BEGIN
	select * from Drzava 
END
GO
/****** Object:  StoredProcedure [dbo].[DohvatiGradove]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[DohvatiGradove]
@drzavaID int 
as 
begin 
select * from Grad where DrzavaID=@drzavaID
end
GO
/****** Object:  StoredProcedure [dbo].[DohvatiKategorije]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DohvatiKategorije]
AS
BEGIN
	select * from Kategorija 
END
GO
/****** Object:  StoredProcedure [dbo].[DohvatiKupce]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DohvatiKupce]
AS
BEGIN
	select * from Kupac 
END
GO
/****** Object:  StoredProcedure [dbo].[DohvatiPotkategorije]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DohvatiPotkategorije]
AS
BEGIN
	select * from Potkategorija 
END
GO
/****** Object:  StoredProcedure [dbo].[GetGrad]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetGrad]
@gradID int 
as 
begin 
select * from Grad where IDGrad=@gradID
end

GO
/****** Object:  StoredProcedure [dbo].[GetKategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetKategorija]
	@id int
as
begin
	select * from Kategorija where IDKategorija=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetKomercijalist]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetKomercijalist]
	@idKomercijalist int
as
begin
	select Ime, Prezime from Komercijalist where Komercijalist.IDKomercijalist = @idKomercijalist
end
GO
/****** Object:  StoredProcedure [dbo].[GetKreditnaKartica]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[GetKreditnaKartica]
	@idKK int
as
begin
	select Tip from KreditnaKartica where IDKreditnaKartica=@idKK
end
GO
/****** Object:  StoredProcedure [dbo].[GetNazivProizvoda]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[GetNazivProizvoda]
	@id int
as
begin
	select Naziv from Proizvod where IDProizvod=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetPotkategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetPotkategorija]
@id int 
as 
begin 
select * from Potkategorija where IDPotkategorija=@id
end

GO
/****** Object:  StoredProcedure [dbo].[GetProizvod]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetProizvod]
	@id int
as
begin
	select * from Proizvod where IDProizvod=@id
end
GO
/****** Object:  StoredProcedure [dbo].[GetProizvodi]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GetProizvodi]
AS
BEGIN
	select * from Proizvod 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertKategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertKategorija]
	@Naziv nvarchar(50)
as
begin
IF NOT EXISTS
(
    SELECT *
    FROM Kategorija
    WHERE Naziv=@Naziv
)
BEGIN
INSERT INTO [dbo].[Kategorija]
           ([Naziv])
     VALUES
           (@Naziv)
		   END

end
GO
/****** Object:  StoredProcedure [dbo].[InsertPotkategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsertPotkategorija]
	@Naziv nvarchar(50),
	@kategorijaID int
as
begin
IF NOT EXISTS
(
    SELECT *
    FROM Potkategorija
    WHERE Naziv=@Naziv
)
BEGIN
INSERT INTO [dbo].Potkategorija
           ([Naziv],KategorijaID)
     VALUES
           (@Naziv,@kategorijaID)
		   END

end
GO
/****** Object:  StoredProcedure [dbo].[InsertProizvod]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[InsertProizvod]
	
	@naziv nvarchar(50),
	@brojproizvoda nvarchar(50),
	@boja nvarchar(50),
	@minkol int,
	@cijena money,
	@potkategorijaid int
as
begin


INSERT INTO [dbo].[Proizvod]
           ([Naziv]
           ,[BrojProizvoda]
           ,[Boja]
           ,[MinimalnaKolicinaNaSkladistu]
           ,[CijenaBezPDV]
           ,[PotkategorijaID])
     VALUES
           (@naziv
           ,@brojproizvoda
           ,@boja
           ,@minkol
           ,@cijena
           ,@potkategorijaid)




end
GO
/****** Object:  StoredProcedure [dbo].[KaskadnoObrisiKategoriju]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[KaskadnoObrisiKategoriju]
	@id int
AS




delete from Stavka where ProizvodID in (Select IDProizvod from Proizvod where PotkategorijaID in(
select IDPotkategorija from Potkategorija where KategorijaID=@id))

delete from Proizvod where PotkategorijaID in(
select IDPotkategorija from Potkategorija where KategorijaID=@id)
delete from Potkategorija where KategorijaID=@id
delete from Kategorija where IDKategorija=@id

GO
/****** Object:  StoredProcedure [dbo].[KaskadnoObrisiPotkategoriju]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[KaskadnoObrisiPotkategoriju]
	@id int
AS




delete from Stavka where ProizvodID in (Select IDProizvod from Proizvod where PotkategorijaID=@id)

delete from Proizvod where PotkategorijaID=@id

delete from Potkategorija where IDPotkategorija=@id
GO
/****** Object:  StoredProcedure [dbo].[KaskadnoObrisiProizvod]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[KaskadnoObrisiProizvod]
	@id int
AS


delete from Stavka where ProizvodID=@id

delete from Proizvod where IDProizvod=@id
GO
/****** Object:  StoredProcedure [dbo].[UpdateKategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[UpdateKategorija]
	@id int,
	@Naziv nvarchar(50)
	

AS
BEGIN
	update Kategorija set Naziv=@Naziv where IDKategorija=@id 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateKupac]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateKupac]
	@id int,
	@ime nvarchar(50),
	@prezime nvarchar(50),
	@email nvarchar(50),
	@telefon nvarchar(25),
	@gradid int
AS
BEGIN
	update Kupac set Ime=@ime, Prezime=@prezime, Email=@email, Telefon=@telefon, GradID=@gradid where IDKupac=@id 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePotkategorija]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePotkategorija]
	@id int,
	@Naziv nvarchar(50),
	@kategorijaid int
	

AS
BEGIN
	update Potkategorija set Naziv=@Naziv,KategorijaID=@kategorijaid where IDPotkategorija=@id 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProizvod]    Script Date: 6.7.2021. 4:57:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProizvod]
	@id int,
	@naziv nvarchar(50),
	@brojproizvoda nvarchar(50),
	@boja nvarchar(50),
	@minkol int,
	@cijena money,
	@potkategorijaid int
AS
BEGIN
	update Proizvod set Naziv=@naziv, BrojProizvoda=@brojproizvoda, Boja=@boja, MinimalnaKolicinaNaSkladistu=@minkol, CijenaBezPDV=@cijena,PotkategorijaID=@potkategorijaid where IDProizvod=@id 
END
GO
