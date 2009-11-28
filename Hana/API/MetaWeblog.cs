using System;
using System.Collections.Generic;
using System.Web;
using CookComputing.XmlRpc;
using System.IO;
using System.Web.Security;
using System.Text;

namespace Hana.API
{
    
    public class MetaWeblog : APIBase, IMetaWeblog {
        public MetaWeblog():base(){
        }

        public MetaWeblog(IAuthentication auth):base(auth){
        }

        public int NewCategory(string blogid, 
            string username, string password, string newCategory) {
            
            int result = 0;
            if (ValidateUser(username, password)){
                if (!Hana.Model.Category.Exists(x => x.Description == newCategory)){
                    var newCat = new Hana.Model.Category();
                    newCat.Description = newCategory;
                    newCat.Add();
                    result = newCat.CategoryID;
                }
            }

            return result;
        }


        public bool DeletePost(string appKey, string postid, string username, string password, bool publish)
        {
            if (ValidateUser(username, password))
            {
                bool result = false;

                Hana.Model.Categories_Post.Delete(x => x.PostID == int.Parse(postid));
                Hana.Model.Comment.Delete(x => x.PostID == int.Parse(postid));
                Hana.Model.Tags_Post.Delete(x => x.PostID == int.Parse(postid));
                Hana.Model.Post.Delete(x => x.PostID == int.Parse(postid));

                result = true;
                return result;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public bool UpdatePost(string postid, string username, string password, Post post, bool publish)
        {
            bool result = false;
            if (ValidateUser(username, password)) {

                var updatePost = Hana.Model.Post.SingleOrDefault(x => x.PostID == int.Parse(postid));

                updatePost.Body = post.description;
                updatePost.ModifiedOn = DateTime.Now;


                updatePost.Title = post.title;
                if (!string.IsNullOrEmpty(post.wp_slug)) {
                    updatePost.Slug = post.wp_slug;
                } else {
                    updatePost.Slug = updatePost.Title.CreateSlug();
                }
                 
                updatePost.Update();

                //set categories and tags

                if (post.categories != null) {
                    Hana.Model.Categories_Post.Delete(x => x.PostID == updatePost.PostID);

                    updatePost.CategorySlug = post.categories[0].CreateSlug();
                    foreach (var c in post.categories) {
                        AssignCategory(updatePost.PostID, c);
                    }
                }

                var tags = new string[0];
                if (!String.IsNullOrEmpty(post.mt_keywords)) {
                    tags = post.mt_keywords.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    updatePost.Tags = string.Join(",", tags);
                } 
                if (!String.IsNullOrEmpty(post.mt_keywords)) {

                    foreach (var t in tags) {
                        AssignTag(updatePost.PostID, t);
                    }
                }

                return result;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public Category[] GetCategories(string blogid, string username, string password)
        {
            if (ValidateUser(username, password))
            {
                var list = Hana.Model.Category.All();
                var cats = new List<Category>();
                string siteUrl = Hana.Model.Blog.BlogURL;

                foreach (var item in list)
                {
                    Category c = new Category();
                    c.categoryId = item.CategoryID.ToString();
                    c.description = item.Description;
                    c.htmlUrl = siteUrl + "/category/" + item.Slug;
                    c.rssUrl = siteUrl + "/category/" + item.Slug + ".rss";
                    c.title = item.Description;
                    cats.Add(c);
                }

                return cats.ToArray();
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public Post GetPost(string postid, string username, string password)
        {
            if (ValidateUser(username, password))
            {
                Post post = new Post();

                var title = Hana.Model.Post.SingleOrDefault(x => x.PostID == int.Parse(postid));
                post.title =title.Title;
                post.postid = postid;
                post.description = title.Body;
                post.wp_slug = title.Slug;

                var results=new List<string>();
                var cats = Hana.Model.Post.Categories(title.PostID);
                foreach (var cat in cats)
                {
                    results.Add(cat.Description);
                }

                post.categories = results.ToArray();

                //tags
                post.mt_keywords = title.Tags;


                return post;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public Post[] GetRecentPosts(string blogid, string username, string password, int numberOfPosts)
        {
            if (ValidateUser(username, password))
            {
                List<Post> posts = new List<Post>();

                var qry = Hana.Model.Post.Recent(numberOfPosts);

                foreach (var p in qry)
                {
                    Post post = new Post();
                    post.title = p.Title;
                    post.postid = p.PostID.ToString();
                    post.dateCreated = p.CreatedOn;
                    post.description = p.Body;
                    posts.Add(post);
                }

                return posts.ToArray();
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public UserBlog[] GetUsersBlogs(string key, string username, string password)
        {
            if (ValidateUser(username, password))
            {
                List<UserBlog> infoList = new List<UserBlog>();
                UserBlog info = new UserBlog();

                info.blogid = "0";
                info.blogName = Hana.Model.Blog.BlogName;
                info.url = Hana.Model.Blog.BlogURL;

                infoList.Add(info);
                return infoList.ToArray();
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public UserInfo GetUserInfo(string appKey, string username, string password)
        {
            if (ValidateUser(username, password))
            {
                UserInfo info = new UserInfo();
                var user = Membership.GetUser(username);

                info.email = user.Email;
                info.firstname = user.UserName;
                info.lastname = "";
                info.nickname = "";

                return info;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }

        public MediaObjectInfo NewMediaObject(string blogid, string username, string password, MediaObject mediaObject)
        {
            if (ValidateUser(username, password))
            {
                MediaObjectInfo objectInfo = new MediaObjectInfo();


                //ick
                string uploadDirectory = HttpContext.Current.Server.MapPath("~/Content/Uploads/");

                string filename = Path.GetFileName(mediaObject.name);
                string filePath = Path.Combine(uploadDirectory, filename);

                string siteUrl = "";

                string fileUrl = siteUrl + "/content/uploads/" + filename;

                if (!Directory.Exists(uploadDirectory))
                    Directory.CreateDirectory(uploadDirectory);
                
                System.IO.File.WriteAllBytes(filePath, mediaObject.bits);
                objectInfo.url = fileUrl;

                return objectInfo;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }
        
        public int SetCategories(string postid, string username, string password, Category[] cats)
        {
            var post = Hana.Model.Post.SingleOrDefault(x => x.PostID == int.Parse(postid));
            
            //delete em
            Hana.Model.Categories_Post.Delete(x=>x.PostID==int.Parse(postid));
            
            //save the cats
            foreach(var cat in cats)
            {
                AssignCategory(int.Parse(postid), cat.categoryName);
            }

            return 0;
        }

        void AssignCategory(int postID, string category){
            var hanaCat = Hana.Model.Category.SingleOrDefault(x => x.Description == category);
            if (hanaCat == null) {
                hanaCat = new Model.Category();
                hanaCat.Description = category;
                hanaCat.Slug = category.CreateSlug();
                hanaCat.Add();
            }

            var rel = new Hana.Model.Categories_Post();
            rel.PostID = postID;
            rel.CategoryID = hanaCat.CategoryID;
            rel.Add();
        }
        void AssignTag(int postID, string tag) {
            var hanaTag = Hana.Model.Tag.SingleOrDefault(x => x.Description == tag);
            if (hanaTag == null) {
                hanaTag = new Model.Tag();
                hanaTag.Description = tag;
                hanaTag.Slug = tag.CreateSlug();
                hanaTag.Add();
            }

            var rel = new Hana.Model.Tags_Post();
            rel.PostID = postID;
            rel.TagID = hanaTag.TagID;
            rel.Add();
        }
        public string AddPost(string blogid, string username, string password, Post post, bool publish)
        {
            if (ValidateUser(username, password))
            {

                var newPost = new Hana.Model.Post();
                newPost.Author = Hana.Model.Blog.Owner;
                newPost.CreatedOn = DateTime.Now;
                newPost.ModifiedOn = DateTime.Now;
                newPost.Title = post.title;
                newPost.Body = post.description;
                if (!string.IsNullOrEmpty(post.mt_text_more))
                    newPost.Body += post.mt_text_more;

                newPost.Slug = newPost.Title.CreateSlug();
                if (!string.IsNullOrEmpty(post.wp_slug))
                    newPost.Slug = post.wp_slug;

                var tags = new string[0];
                if (!String.IsNullOrEmpty(post.mt_keywords)){
                    tags = post.mt_keywords.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    newPost.Tags = string.Join(",", tags);
                }

                if (publish && post.dateCreated > DateTime.MinValue) {
                    newPost.PublishedOn = post.dateCreated;
                } else if (publish) {
                    newPost.PublishedOn = DateTime.Now;
                } else {
                    newPost.PublishedOn = DateTime.Now.AddDays(365);
                }     

                newPost.Excerpt = Hana.Model.Post.CreateSummary(newPost);

                newPost.Add();
                //save the cats

                if (post.categories.Length>0)
                {
                    newPost.CategorySlug = post.categories[0].CreateSlug();
                    foreach (var c in post.categories)
                    {
                        AssignCategory(newPost.PostID, c);
                    }
                }


                if(!String.IsNullOrEmpty(post.mt_keywords)){

                    foreach (var t in tags) {
                      AssignTag(newPost.PostID,t);  
                    }
                }

                return Hana.Model.Blog.BlogURL+newPost.Slug;
            }
            throw new XmlRpcFaultException(0, "User is not valid!");
        }


        #region IXmlRpcProxy Members

        public System.Security.Cryptography.X509Certificates.X509CertificateCollection ClientCertificates
        {
            get { throw new NotImplementedException(); }
        }

        public string ConnectionGroupName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.CookieContainer CookieContainer
        {
            get { throw new NotImplementedException(); }
        }

        public System.Net.ICredentials Credentials
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Expect100Continue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.WebHeaderCollection Headers
        {
            get { throw new NotImplementedException(); }
        }

        public Guid Id
        {
            get { throw new NotImplementedException(); }
        }

        public int Indentation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool KeepAlive
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public XmlRpcNonStandard NonStandard
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool PreAuthenticate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Version ProtocolVersion
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.IWebProxy Proxy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event XmlRpcRequestEventHandler RequestEvent;

        public event XmlRpcResponseEventHandler ResponseEvent;

        public string[] SystemListMethods()
        {
            throw new NotImplementedException();
        }

        public string SystemMethodHelp(string MethodName)
        {
            throw new NotImplementedException();
        }

        public object[] SystemMethodSignature(string MethodName)
        {
            throw new NotImplementedException();
        }

        public int Timeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Url
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseIndentation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool UseIntTag
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string UserAgent
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Encoding XmlEncoding
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string XmlRpcMethod
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
