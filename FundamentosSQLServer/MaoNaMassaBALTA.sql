--O BANCO DE DADOS UTILIZADO FOI BAIXADO NO REPOSITÓRIO DISPONIBILIZADO DURANTE O CURSO DE SQL SERVER DA TRILHA BACKEND DO BALTA.IO.
-- FONTE: https://balta.io/

USE [balta]


select [Id],[Tag], [Title], [Summary] from [Course]

select [Course].[Id] as [ID COURSE], [Course].[Title] as [TITLE COURSE], 
    [Author].[Id] as [ID AUTHOR], [Author].[Name] as [AUTHOR NAME] from [Course] 
    FULL OUTER JOIN [Author] ON [Course].[AuthorId] = [Author].[Id]


select * from [Course]
select * from [Author]
select * from [Career]
select * from [CareerItem]
select * from [Category]

--SOMAR DURAÇÃO CURSO

select top 1000 SUM([DurationInMinutes]) as [Sum of duration in minutes] from [Course]

-- MEDIA DURAÇÃO EM MINUTOS DO CURSO
select top 1000 AVG([DurationInMinutes]) as [Sum of duration in minutes] from [Course]

-- SELECIONANDO NOME POR ORDEM ALFABÉTICA
select [Name] from [Author] order by [Name]

-- selecionando curso por data

SELECT * from [Course] where [CreateDate] between '2018-01-01' and '2022-01-01'

--Procurando no sumário 
SELECT * from [Category] where [Summary] like '%Desenvolv%'
SELECT * from [Category] where [Summary] like '%Software%'
SELECT * from [Course] where [Summary] like '%Back%'

