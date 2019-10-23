SET NOCOUNT ON
GO

MERGE INTO [dbo].[Priority] AS [Target]
USING (VALUES
  (0,N'Normal')
 ,(1,N'Low')
 ,(2,N'High')
) AS [Source] ([IdPriority],[Desc])
ON ([Target].[IdPriority] = [Source].[IdPriority])
WHEN MATCHED AND (
	NULLIF([Source].[Desc], [Target].[Desc]) IS NOT NULL OR NULLIF([Target].[Desc], [Source].[Desc]) IS NOT NULL) THEN
 UPDATE SET
  [Target].[Desc] = [Source].[Desc]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([IdPriority],[Desc])
 VALUES([Source].[IdPriority],[Source].[Desc])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE;

DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Priority]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[dbo].[Priority] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO


SET NOCOUNT OFF
GO