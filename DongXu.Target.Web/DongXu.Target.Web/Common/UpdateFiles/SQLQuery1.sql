/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[SerialNumber]
      ,[BusinessTypeId]
      ,[BusinessId]
      ,[Status]
      ,[CreateTime]
      ,[EndTime]
  FROM [ImmovableProject].[dbo].[ReceiptTable]

  select  tmpmonth, status,count(status) as num from
                            (
                            select DATEPART(month, createTime) as tmpMonth, status
                             from[dbo].[ReceiptTable]
                             where  DATEPART(YEAR, createTime) = '2019'
                             ) t
                             group by tmpmonth, status
                             order by tmpMonth

							 select * from dbo.ReceiptTable

							   select  tmpmonth, status,count(status) as num from
                            (
                            select DATEPART(month, createTime) as tmpMonth, status
                             from[dbo].[ReceiptTable]
                             where  DATEPART(YEAR, createTime) = '2019'
                             ) t
                             group by tmpmonth, status
                             order by tmpMonth

select * from Jurisdiction a inner join RoleJurisdiction b on a.Id=b.JurisdictionId inner join Roles c on b.RoleId = c.Id inner join PersonRole d on c.Id = d.RoleId inner join Person e on e.Id = d.PersonId where e.UserName='tianxin' and e.UserPassword='1209'

select a.SerialNumber,a.Status,a.CreateTime,c.BusinessName from ReceiptTable a inner join BusinessType b on a.BusinessTypeId=b.Id
inner join Business c on b.Id=c.BusinessTypeId

select tmpMonth,status,name,COUNT(status) as num from(
select DATEPART(MONTH,a.createtime) as tmpMonth,a.status,c.BusinessName as name from ReceiptTable a inner join BusinessType b on a.BusinessTypeId=b.Id
inner join Business c on b.Id=c.BusinessTypeId where  DATEPART(MONTH,a.createtime)='5') t group by tmpMonth,Status,name order by tmpMonth

select tmpMonth,status,name,COUNT(status) as num from(
select DATEPART(MONTH,a.createtime) as tmpMonth,a.status,c.BusinessName as name from ReceiptTable a inner join BusinessType b on a.BusinessTypeId=b.Id
inner join Business c on b.Id=c.BusinessTypeId ) t group by tmpMonth,Status,name order by tmpMonth

select tmpYear,tmpMonth,status,name,COUNT(status) as num from(
select DATEPART(YEAR,a.createtime) as tmpYear, DATEPART(MONTH,a.createtime) as tmpMonth,a.status,c.BusinessName as name from ReceiptTable a inner join BusinessType b on a.BusinessTypeId=b.Id
inner join Business c on b.Id=c.BusinessTypeId where DATEPART(YEAR,a.CreateTime)='2019' and DATEPART(MONTH,a.CreateTime)='5' ) t group by tmpYear,tmpMonth,Status,name order by tmpYear,tmpMonth

select tmpYear,tmpMonth,status,name,COUNT(status) as num from(select DATEPART(YEAR, a.createtime) as tmpYear,DATEPART(MONTH,a.CreateTime) as tmpMonth , a.status, c.BusinessName as name from ReceiptTable a inner join BusinessType b on a.BusinessTypeId = b.Id inner join Business c on b.Id = c.BusinessTypeId where DATEPART(YEAR, a.CreateTime) = '2019') t group by tmpYear,tmpMonth,Status, name order by tmpYear,tmpMonth
select tmpYear,tmpMonth,status,name,COUNT(status) as num from(select DATEPART(YEAR, a.createtime) as tmpYear,DATEPART(MONTH,a.CreateTime) as tmpMonth , a.status, c.BusinessName as name from ReceiptTable a inner join BusinessType b on a.BusinessTypeId = b.Id inner join Business c on b.Id = c.BusinessTypeId where DATEPART(MONTH, a.CreateTime) = '5') t group by tmpYear,tmpMonth,Status, name order by tmpYear,tmpMonth

select Status,CreateTime,COUNT(Id) as num from ReceiptTable where Status=1  group by CreateTime,Status 

select Status,CreateTime,COUNT(Id) as num from ReceiptTable where Status=0 group by CreateTime,Status 

delete from ReceiptTable where Id in(67,68,69,70)
select tmpMonth,status,COUNT(status) as num from(select DATEPART(MONTH, createtime) as tmpMonth, status from dbo.ReceiptTable ) t group by tmpMonth, Status order by tmpMonth

select tmpMonth,status,COUNT(status) as num from(select DATEPART(MONTH, createtime) as tmpMonth, status from dbo.ReceiptTable where DATEPART(MONTH, createtime) = '5') t group by tmpMonth, Status order by tmpMonth

select status,createtime,COUNT(Status) as num from ReceiptTable where Status=1  group by CreateTime,Status

select Status createtime,COUNT(Status) as num from ReceiptTable group by CreateTime,status

select COUNT(status) as num from ReceiptTable

update Person set UserPassword='',PersonPhone='' where Id=''

select tmpMonth,status,COUNT(status) as num from(select DATEPART(MONTH, createtime) as tmpMonth, status from dbo.ReceiptTable where DATEPART(MONTH, createtime) = '5') t group by tmpMonth, Status order by tmpMonth

--select * from (
--select *,ROW_NUMBER() over (order by id) as num from student
--) t where t.num between  ((@pageIndex-1)* @pageSize+1) and ((@pageIndex)* @pageSize)

select * from(select *, ROW_NUMBER() over(order by Id) as num from Obligee) as t where t.num between 1 and 3*1


--select  top 3 * from student 
--where id not in ( select top ((@pageIndex-1)* @pageSize) id from student order by id )
--order by id

select top 3 * from Obligee where Id not in(select top((0)*3) id from Obligee order by Id) order by Id

select * from UploadFiles where 1=1 and UploadFiles.UploadFileTypeId=15 order by UploadFileCreatTime desc offset (0*3) rows fetch next (3) rows only

select tmpMonth,status,COUNT(status) as num from(select DATEPART(MONTH, createtime) as tmpMonth, status from dbo.ReceiptTable ) t group by tmpMonth, Status order by tmpMonth