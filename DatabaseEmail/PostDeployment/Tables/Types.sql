SET NOCOUNT ON

MERGE INTO [dbo].[Types] AS [Target]
USING (VALUES
  (0,N'Sender')
 ,(1,N'To')
 ,(2,N'Cc')
 ,(3,N'Bcc')
) AS [Source] ([IdType],[Desc])
ON ([Target].[IdType] = [Source].[IdType])
WHEN MATCHED AND (
	NULLIF([Source].[Desc], [Target].[Desc]) IS NOT NULL OR NULLIF([Target].[Desc], [Source].[Desc]) IS NOT NULL) THEN
 UPDATE SET
  [Target].[Desc] = [Source].[Desc]
WHEN NOT MATCHED BY TARGET THEN
 INSERT([IdType],[Desc])
 VALUES([Source].[IdType],[Source].[Desc])
WHEN NOT MATCHED BY SOURCE THEN 
 DELETE;

DECLARE @mergeError int
 , @mergeCount int
SELECT @mergeError = @@ERROR, @mergeCount = @@ROWCOUNT
IF @mergeError != 0
 BEGIN
 PRINT 'ERROR OCCURRED IN MERGE FOR [dbo].[Types]. Rows affected: ' + CAST(@mergeCount AS VARCHAR(100)); -- SQL should always return zero rows affected
 END
ELSE
 BEGIN
 PRINT '[dbo].[Types] rows affected by MERGE: ' + CAST(@mergeCount AS VARCHAR(100));
 END
GO


SET NOCOUNT OFF
GO