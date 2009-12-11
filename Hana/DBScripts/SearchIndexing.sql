
--setup the DB
--enable the FT index
exec sp_fulltext_database 'enable'

--create the catalog - need to have rights to do this
exec sp_fulltext_catalog 'HanaCatalog', 'create'

--add the tables to the index
exec sp_fulltext_table 'Posts', 'create', 'HanaCatalog', 'PK_Posts'

--add the columns
exec sp_fulltext_column 'Posts', 'Body', 'add'
exec sp_fulltext_column 'Posts', 'Title', 'add'

--activate them
exec sp_fulltext_table 'Posts', 'activate'

--enable background updates
exec sp_fulltext_table 'Posts','start_change_tracking'
exec sp_fulltext_table 'Posts','start_background_updateindex' 

--start population
exec sp_fulltext_catalog 'HanaCatalog','start_full'


--The Function

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchPosts]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'Create FUNCTION [dbo].[SearchPosts] 
(    
    @search nvarchar(500)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT PostID, Title 
		,KEY_TBL.RANK as ''Rank''
	FROM Posts 
		INNER JOIN FREETEXTTABLE(Posts, Body, 
			@search) AS KEY_TBL
			ON Posts.PostID = KEY_TBL.[KEY]
)' 
END
GO