CREATE DATABASE Cursos

USE [Cursos]

CREATE TABLE [Categoria](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])
)

GO

CREATE TABLE [Curso](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([Id])


)

GO

INSERT INTO [CAtegoria]([Nome]) VALUES('Backend')
INSERT INTO [CAtegoria]([Nome]) VALUES('Frontend')
INSERT INTO [CAtegoria]([Nome]) VALUES('Mobile')

INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Fundamentos de C#', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Fundamentos de OOP', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Angular', 2)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Flutter', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Flutter e SQLIte', 3)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('APIs', 1)



select * from [Categoria]
select * from [Curso]

UPDATE [Curso] SET [CategoriaId] = 3 WHERE [Nome] = 'Flutter'


-- SELECTS

select TOP 2 [Id], [Nome] FROM [Curso]

select distinct top 100 [Id], [Nome] FROM [Categoria] -- TRAZ APENAS DISTINTOS
select top 100 [Id], [Nome] FROM [Categoria]

SELECT [Nome], [CategoriaId] FROM [Curso] WHERE [CategoriaId] = 1 AND [Id] = 1
SELECT * FROM [Categoria]

--ORDER BY 
SELECT * FROM [Curso] ORDER BY [Nome]
SELECT * FROM [Curso] ORDER BY [Nome] DESC


--UPDATE

UPDATE [Categoria] SET [Nome] = 'Back-End' where [Nome] = 'Backend'

--Executar poucos updates, podemos abrir transaction
BEGIN TRANSACTION 

UPDATE 
[Categoria] SET [Nome] = 'Backend' where [Nome] = 'Back-End'

--ROLLBACK
COMMIT --DESFAZER


-- max, min e count

SELECT top 100 MIN([Id]) from [Curso]
SELECT top 100 COUNT([Id]) from [Curso]
SELECT top 100 AVG([Id]) from [Curso]
SELECT top 100 SUM([Id]) from [Curso]

-- LIKE

select top 100 * from [Curso] where [Nome] like '%Fundamentos' -- Começa com fundamentos
select top 100 * from [Curso] where [Nome] like 'Fundamentos%' -- Termina com fundamentos
select top 100 * from [Curso] where [Nome] like '%Fundamentos%' -- contém fundamentos

-- in, between

SELECT TOP 100 * FROM [Curso] WHERE [Id] IN (1,2) -- Está presente nessa lista
SELECT TOP 100 * FROM [Curso] WHERE [Id] BETWEEN 1 AND 3 -- Entre 1 e 3