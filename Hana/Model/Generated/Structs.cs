


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace Hana.Model {
	
        /// <summary>
        /// Table: Categories_Posts
        /// Primary Key: CategoryID
        /// </summary>

        public class Categories_PostsTable: DatabaseTable {
            
            public Categories_PostsTable(IDataProvider provider):base("Categories_Posts",provider){
                ClassName = "Categories_Post";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PostID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
            
            public IColumn PostID{
                get{
                    return this.GetColumn("PostID");
                }
            }
				
   			public static string PostIDColumn{
			      get{
        			return "PostID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Tags_Posts
        /// Primary Key: PostID
        /// </summary>

        public class Tags_PostsTable: DatabaseTable {
            
            public Tags_PostsTable(IDataProvider provider):base("Tags_Posts",provider){
                ClassName = "Tags_Post";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("TagID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PostID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn TagID{
                get{
                    return this.GetColumn("TagID");
                }
            }
				
   			public static string TagIDColumn{
			      get{
        			return "TagID";
      			}
		    }
            
            public IColumn PostID{
                get{
                    return this.GetColumn("PostID");
                }
            }
				
   			public static string PostIDColumn{
			      get{
        			return "PostID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Tags
        /// Primary Key: TagID
        /// </summary>

        public class TagsTable: DatabaseTable {
            
            public TagsTable(IDataProvider provider):base("Tags",provider){
                ClassName = "Tag";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("TagID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Slug", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }
            
            public IColumn TagID{
                get{
                    return this.GetColumn("TagID");
                }
            }
				
   			public static string TagIDColumn{
			      get{
        			return "TagID";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Slug{
                get{
                    return this.GetColumn("Slug");
                }
            }
				
   			public static string SlugColumn{
			      get{
        			return "Slug";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Categories
        /// Primary Key: CategoryID
        /// </summary>

        public class CategoriesTable: DatabaseTable {
            
            public CategoriesTable(IDataProvider provider):base("Categories",provider){
                ClassName = "Category";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Slug", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }
            
            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Slug{
                get{
                    return this.GetColumn("Slug");
                }
            }
				
   			public static string SlugColumn{
			      get{
        			return "Slug";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Comments
        /// Primary Key: CommentID
        /// </summary>

        public class CommentsTable: DatabaseTable {
            
            public CommentsTable(IDataProvider provider):base("Comments",provider){
                ClassName = "Comment";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("CommentID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PostID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Author", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("IP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("URL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("CreatedOn", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("ParentID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn CommentID{
                get{
                    return this.GetColumn("CommentID");
                }
            }
				
   			public static string CommentIDColumn{
			      get{
        			return "CommentID";
      			}
		    }
            
            public IColumn PostID{
                get{
                    return this.GetColumn("PostID");
                }
            }
				
   			public static string PostIDColumn{
			      get{
        			return "PostID";
      			}
		    }
            
            public IColumn Author{
                get{
                    return this.GetColumn("Author");
                }
            }
				
   			public static string AuthorColumn{
			      get{
        			return "Author";
      			}
		    }
            
            public IColumn IP{
                get{
                    return this.GetColumn("IP");
                }
            }
				
   			public static string IPColumn{
			      get{
        			return "IP";
      			}
		    }
            
            public IColumn Email{
                get{
                    return this.GetColumn("Email");
                }
            }
				
   			public static string EmailColumn{
			      get{
        			return "Email";
      			}
		    }
            
            public IColumn URL{
                get{
                    return this.GetColumn("URL");
                }
            }
				
   			public static string URLColumn{
			      get{
        			return "URL";
      			}
		    }
            
            public IColumn CreatedOn{
                get{
                    return this.GetColumn("CreatedOn");
                }
            }
				
   			public static string CreatedOnColumn{
			      get{
        			return "CreatedOn";
      			}
		    }
            
            public IColumn Body{
                get{
                    return this.GetColumn("Body");
                }
            }
				
   			public static string BodyColumn{
			      get{
        			return "Body";
      			}
		    }
            
            public IColumn ParentID{
                get{
                    return this.GetColumn("ParentID");
                }
            }
				
   			public static string ParentIDColumn{
			      get{
        			return "ParentID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: Posts
        /// Primary Key: PostID
        /// </summary>

        public class PostsTable: DatabaseTable {
            
            public PostsTable(IDataProvider provider):base("Posts",provider){
                ClassName = "Post";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PostID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Author", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });

                Columns.Add(new DatabaseColumn("PublishedOn", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CreatedOn", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ModifiedOn", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Title", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("Slug", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("Body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("Tags", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("Excerpt", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("CommentCount", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("IsPublished", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }
            
            public IColumn PostID{
                get{
                    return this.GetColumn("PostID");
                }
            }
				
   			public static string PostIDColumn{
			      get{
        			return "PostID";
      			}
		    }
            
            public IColumn Author{
                get{
                    return this.GetColumn("Author");
                }
            }
				
   			public static string AuthorColumn{
			      get{
        			return "Author";
      			}
		    }
            
            public IColumn PublishedOn{
                get{
                    return this.GetColumn("PublishedOn");
                }
            }
				
   			public static string PublishedOnColumn{
			      get{
        			return "PublishedOn";
      			}
		    }
            
            public IColumn CreatedOn{
                get{
                    return this.GetColumn("CreatedOn");
                }
            }
				
   			public static string CreatedOnColumn{
			      get{
        			return "CreatedOn";
      			}
		    }
            
            public IColumn ModifiedOn{
                get{
                    return this.GetColumn("ModifiedOn");
                }
            }
				
   			public static string ModifiedOnColumn{
			      get{
        			return "ModifiedOn";
      			}
		    }
            
            public IColumn Title{
                get{
                    return this.GetColumn("Title");
                }
            }
				
   			public static string TitleColumn{
			      get{
        			return "Title";
      			}
		    }
            
            public IColumn Slug{
                get{
                    return this.GetColumn("Slug");
                }
            }
				
   			public static string SlugColumn{
			      get{
        			return "Slug";
      			}
		    }
            
            public IColumn Body{
                get{
                    return this.GetColumn("Body");
                }
            }
				
   			public static string BodyColumn{
			      get{
        			return "Body";
      			}
		    }
            
            public IColumn Tags{
                get{
                    return this.GetColumn("Tags");
                }
            }
				
   			public static string TagsColumn{
			      get{
        			return "Tags";
      			}
		    }
            
            public IColumn Excerpt{
                get{
                    return this.GetColumn("Excerpt");
                }
            }
				
   			public static string ExcerptColumn{
			      get{
        			return "Excerpt";
      			}
		    }
            
            public IColumn CommentCount{
                get{
                    return this.GetColumn("CommentCount");
                }
            }
				
   			public static string CommentCountColumn{
			      get{
        			return "CommentCount";
      			}
		    }
            
            public IColumn IsPublished{
                get{
                    return this.GetColumn("IsPublished");
                }
            }
				
   			public static string IsPublishedColumn{
			      get{
        			return "IsPublished";
      			}
		    }
            
                    
        }
        
}