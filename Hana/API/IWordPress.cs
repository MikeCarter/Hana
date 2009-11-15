using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace Hana.API
{
    public interface IWordPress: IXmlRpcProxy
    {
        [XmlRpcMethod("wp.newCategory")]
        bool DeleteCategory(string blogId, string username, string password, string category_id);
        [XmlRpcMethod("wp.deleteComment")]
        bool DeleteComment(string blogId, string username, string password, string comment_id);
        [XmlRpcMethod("wp.deletePage")]
        bool DeletePage(string blogId, string username, string password, string post_id, string page_id);
        [XmlRpcMethod("wp.editComment")]
        bool EditComment(string blogId, string username, string password, Comment comment);
        [XmlRpcMethod("wp.editPage")]
        string EditPage(string blogId, string username, string password, string post_id, Page content);
        [XmlRpcMethod("wp.getAuthors")]
        Author[] GetAuthors(string blogId, string username, string password);
        [XmlRpcMethod("wp.getCategories")]
        Category[] GetCategories(string blogId, string username, string password);
        [XmlRpcMethod("wp.getComment")]
        Comment GetComment(string blogId, string username, string password, string commentId);
        [XmlRpcMethod("wp.getCommentCount")]
        CommentCount GetCommentCount(string blogId, string username, string password, string post_id);
        [XmlRpcMethod("wp.getComments")]
        Comment[] GetComments(string blogId, string username, string password, CommentFilter filter);
        [XmlRpcMethod("wp.getCommentStatusList")]
        string[] GetCommentStatusList(string blogId, string username, string password, string post_id);
        [XmlRpcMethod("wp.getOptions")]
        Option[] GetOptions(string blogId, string username, string password, string[] options);
        [XmlRpcMethod("wp.getPage")]
        Page GetPage(string blogId, string username, string password, string pageId);
        [XmlRpcMethod("wp.getPageList")]
        PageMin[] GetPageList(string blogId, string username, string password);
        [XmlRpcMethod("wp.getPages")]
        Page[] GetPages(string blogId, string username, string password);
        [XmlRpcMethod("wp.getPageTemplates")]
        PageTemplate[] GetPageTemplates(string blogId, string username, string password);
        [XmlRpcMethod("wp.getPostStatusList")]
        string[] GetPostStatusList(string blogId, string username, string password);
        [XmlRpcMethod("wp.getTags")]
        TagInfo[] GetTags(string blogId, string username, string password);
        [XmlRpcMethod("wp.getUsersBlogs")]
        UserBlog[] GetUserBlogs(string username, string password);
        [XmlRpcMethod("wp.newCategory")]
        string NewCategory(string blogId, string username, string password, Category category);
        [XmlRpcMethod("wp.newComment")]
        int NewComment(string blogId, string username, string password, string post_id, Comment coment);
        [XmlRpcMethod("wp.newPage")]
        string NewPage(string blogId, string username, string password, string post_id, Page content);
        [XmlRpcMethod("wp.setOptions")]
        Option[] SetOptions(string blogId, string username, string password);
        [XmlRpcMethod("wp.suggestCategories")]
        Category[] SuggestCategories(string blogId, string username, string password, string category, int max_results);
        [XmlRpcMethod("wp.uploadFile")]
        File UploadFile(string blogId, string username, string password, Data data);
    }
}
