using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CookComputing.XmlRpc;
using System.Web.Security;

namespace Hana.API
{
    public class Wordpress : MetaWeblog ,IWordPress 
    {
        public Wordpress(IAuthentication auth):base(auth){
        }
        public Wordpress()
            : base() {
        }
        #region IWordPress Members

        public bool DeleteCategory(string blogId, string username, string password, string category_id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteComment(string blogId, string username, string password, string comment_id)
        {
            throw new NotImplementedException();
        }

        public bool DeletePage(string blogId, string username, string password, string post_id, string page_id)
        {
            throw new NotImplementedException();
        }

        public bool EditComment(string blogId, string username, string password, Comment comment)
        {
            throw new NotImplementedException();
        }

        public string EditPage(string blogId, string username, string password, string post_id, Page content)
        {
            throw new NotImplementedException();
        }

        public Author[] GetAuthors(string blogId, string username, string password)
        {

            var item = new Author();
            item.display_name = Hana.Model.Blog.Owner;
            item.user_id = "rob";
            item.user_login = username;

            return  new Author[]{item};
        }

        public Category[] GetCategories(string blogId, string username, string password)
        {
            return base.GetCategories(blogId, username, password);
        }

        public Comment GetComment(string blogId, string username, string password, string commentId)
        {
            throw new NotImplementedException();
        }

        public CommentCount GetCommentCount(string blogId, string username, string password, string post_id)
        {
            throw new NotImplementedException();
        }

        public Comment[] GetComments(string blogId, string username, string password, CommentFilter filter)
        {
            throw new NotImplementedException();
        }

        public string[] GetCommentStatusList(string blogId, string username, string password, string post_id)
        {
            throw new NotImplementedException();
        }

        public Option[] GetOptions(string blogId, string username, string password, string[] options)
        {
            throw new NotImplementedException();
        }

        public Page GetPage(string blogId, string username, string password, string pageId)
        {
            throw new NotImplementedException();
        }

        public PageMin[] GetPageList(string blogId, string username, string password)
        {
            throw new NotImplementedException();
        }

        public Page[] GetPages(string blogId, string username, string password)
        {
            throw new NotImplementedException();
        }

        public PageTemplate[] GetPageTemplates(string blogId, string username, string password)
        {
            throw new NotImplementedException();
        }

        public string[] GetPostStatusList(string blogId, string username, string password)
        {
            throw new NotImplementedException();
        }

        public TagInfo[] GetTags(string blogId, string username, string password)
        {
            var tags = Hana.Model.Tag.All();
            var result = new List<TagInfo>();
            foreach (var tag in tags){
                var t = new TagInfo();
                t.slug = tag.Slug;
                t.name = tag.Description;
                t.id = tag.TagID.ToString();
                t.html_url = Hana.Model.Blog.Owner + "/tags/" + tag.Slug;
                t.rss_url = Hana.Model.Blog.Owner + "/tags/" + tag.Slug+".rss";
                result.Add(t);
            }
            return result.ToArray();
        }

        public UserBlog[] GetUserBlogs(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string NewCategory(string blogId, string username, string password, Category category)
        {

            return base.NewCategory(blogId, username, password, category.categoryName).ToString();
        }

        public int NewComment(string blogId, string username, string password, string post_id, Comment coment)
        {
            throw new NotImplementedException();
        }

        public string NewPage(string blogId, string username, string password, string post_id, Page content)
        {
            throw new NotImplementedException();
        }

        public Option[] SetOptions(string blogId, string username, string password)
        {
            throw new NotImplementedException();
        }

        public Category[] SuggestCategories(string blogId, string username, string password, string category, int max_results)
        {
            throw new NotImplementedException();
        }

        public File UploadFile(string blogId, string username, string password, Data data)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
