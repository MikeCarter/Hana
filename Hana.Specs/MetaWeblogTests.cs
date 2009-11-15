using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hana.API;
using Moq;
using Xunit;

namespace Hana.Specs {
    public class MetaWeblogTests {

        MetaWeblog GetMeta(){
            var mock = new Moq.Mock<IAuthentication>();
            mock.Setup(x => x.UserIsValid(
                It.IsAny<string>(), 
                It.IsAny<string>())
                ).Returns(true);
            
            return new MetaWeblog(mock.Object);
        }

        [Fact]
        public void MW_Should_Return_10_Categories(){
            var mw = GetMeta();
            Hana.Model.Category.Setup(10);

            var result = mw.GetCategories("1", "", "");

            Assert.Equal(10,result.Count());

        }

        [Fact]
        public void MW_Should_Add_New_Category(){
            var mw = GetMeta();

            int before = Hana.Model.Category.All().Count();
            Assert.Equal(0, before);
            
            mw.NewCategory("1", "", "", "Juice");

            int after = Hana.Model.Category.All().Count();
            Assert.Equal(1, after);

            var cat = Hana.Model.Category.All().First();
            Assert.Equal("Juice",cat.Description);

        }
        [Fact]
        public void MW_Should_Retrieve_Post() {
            var mw = GetMeta();

            var post = new Hana.Model.Post();
            post.Body = "La La La";
            post.PostID = 1;
            Hana.Model.Post.Setup(post);

            var result = mw.GetPost("1", "", "" );

            Assert.Equal("La La La", result.description);


        }
        [Fact]
        public void MW_Should_Update_Post() {
            var mw = GetMeta();

            var post = new Hana.Model.Post();
            post.Body = "La La La";
            post.PostID = 1;
            Hana.Model.Post.Setup(post);

            Post p=new Post();
            p.description = "Jeepers Creepers";


            mw.UpdatePost("1", "", "", p, true);

            post = Hana.Model.Post.SingleOrDefault(x => x.PostID == 1);
            Assert.Equal("Jeepers Creepers",post.Body);


        }

        [Fact]
        public void MW_Should_5_Recent_Posts_Of_10() {
            var mw = GetMeta();
            Hana.Model.Post.Setup(10);

            var result=mw.GetRecentPosts("1", "", "",5);

            Assert.Equal(5,result.Count());


        }

        [Fact]
        public void MW_Should_5_Recent_Posts_With_Title_Body_Set() {
            var mw = GetMeta();
            var posts = new List<Hana.Model.Post>();
            for(int i=0;i<10;i++){
                var p = new Hana.Model.Post();
                p.PostID = i;
                p.Title = "Title " + i;
                p.Body = "Body " + i;
                posts.Add(p);
            }
            Hana.Model.Post.Setup(posts);
            
            var result = mw.GetRecentPosts("1", "", "", 5);

            var noTitle = result.Any(x => String.IsNullOrEmpty(x.title));
            var noBody = result.Any(x => String.IsNullOrEmpty(x.description));


            Assert.False(noTitle);
            Assert.False(noBody);

        }

        [Fact]
        public void MW_Should_Return_Url_Name_For_BlogInfo(){
            var mw = GetMeta();
            var result = mw.GetUsersBlogs("", "", "");

            Assert.Equal(1,result.Length);
            Assert.Equal("http://blog.wekeroad.com/",result[0].url);
            Assert.Equal("Rob Conery", result[0].blogName);
            Assert.Equal("0", result[0].blogid);


        }


        [Fact]
        public void MW_Should_Add_Post(){
            var mw = GetMeta();
            Assert.Equal(0,Hana.Model.Post.All().Count());
            
            var p = new Post();
            p.title = "Title";
            p.description = "Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep";
            p.mt_keywords = "tag1, tag2";
            p.wp_slug = "sluggy-slug";

            mw.AddPost("0", "", "", p, true);
            Assert.Equal(1,Hana.Model.Post.All().Count());


            var p2 = Hana.Model.Post.All().First();
            Assert.Equal("Title", p2.Title);
            Assert.Equal("Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep", p2.Body);
            Assert.Equal("Lorem Ipsum Lorem Ipsum", p2.Excerpt.Trim());
            Assert.Equal("sluggy-slug", p2.Slug);
            Assert.Equal("tag1, tag2", p2.Tags);


        }
        public void MW_Should_Save_Tags_When_Adding_Post() {
            var mw = GetMeta();
            Assert.Equal(0, Hana.Model.Post.All().Count());

            var p = new Post();
            p.title = "Title";
            p.description = "Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep";
            p.mt_keywords = "tag1, tag2";
            p.wp_slug = "sluggy-slug";

            mw.AddPost("0", "", "", p, true);
            Assert.Equal(2, Hana.Model.Tag.All().Count());

        }

        public void MW_Should_Save_Categories_When_Adding_Post() {
            var mw = GetMeta();
            Assert.Equal(0, Hana.Model.Post.All().Count());

            var p = new Post();
            p.title = "Title";
            p.description = "Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep";
            p.categories = new string[]{"cat1","cat2"};
            p.wp_slug = "sluggy-slug";

            mw.AddPost("0", "", "", p, true);
            Assert.Equal(2, Hana.Model.Category.All().Count());

        }
        [Fact]
        public void MW_Should_Add_Post_With_Generated_Slug_When_No_Slug_Passed() {
            var mw = GetMeta();
            Assert.Equal(0, Hana.Model.Post.All().Count());

            var p = new Post();
            p.title = "A long title";
            p.description = "Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep";
            p.mt_keywords = "tag1, tag2";

            mw.AddPost("0", "", "", p, true);
            Assert.Equal(1, Hana.Model.Post.All().Count());


            var p2 = Hana.Model.Post.All().First();
            Assert.Equal("A long title", p2.Title);
            Assert.Equal("Lorem Ipsum Lorem Ipsum <!--more--> Beep Beep", p2.Body);
            Assert.Equal("Lorem Ipsum Lorem Ipsum", p2.Excerpt.Trim());
            Assert.Equal("a-long-title", p2.Slug);

        }

    }
}
