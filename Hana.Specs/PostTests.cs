using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Hana.Model;

namespace Hana.Specs {
    public class PostTests {

        [Fact]
        public void PublishedPosts_Should_Return_Posts_With_PublishDate_Less_Than_Today(){
            var posts = new List<Post>();
            var oldPost = new Post();
            oldPost.Title = "Old Post";
            oldPost.PublishedOn = DateTime.Now.AddDays(-3);
            var newPost = new Post();
            newPost.Title = "New Post";
            newPost.PublishedOn = DateTime.Now.AddDays(3);
            
            posts.Add(oldPost);
            posts.Add(newPost);

            //Set up SubSonic
            Post.Setup(posts);

            var result = Post.Published();

            Assert.Equal(1,result.Count());
            Assert.Equal("Old Post", result.First().Title);


        }
        [Fact]
        public void PostsByTag_Should_Return_Related_Posts(){
            var posts = new List<Post>();
            var tags = new List<Tag>();
            var rel = new List<Tags_Post>();
            
            var post = new Post();
            post.PostID = 1;
            post.Title = "Tagged Post";
            posts.Add(post);

            var tag = new Tag();
            tag.TagID = 1;
            tag.Description = "tag";
            tags.Add(tag);

            var tp = new Tags_Post();
            tp.PostID = 1;
            tp.TagID = 1;
            rel.Add(tp);

            //setup SubSonic
            Post.Setup(posts);
            Tag.Setup(tags);
            Tags_Post.Setup(rel);

            var result = Post.PostsByTags("tag");
            Assert.Equal(1,result.Count());

        }
        [Fact]
        public void PostsByCategory_Should_Return_Related_Posts() {
            var posts = new List<Post>();
            var cats = new List<Category>();
            var rel = new List<Categories_Post>();

            var post = new Post();
            post.PostID = 1;
            post.Title = "Tagged Post";
            posts.Add(post);

            var cat = new Category();
            cat.CategoryID = 1;
            cat.Description = "category";
            cats.Add(cat);

            var cp = new Categories_Post();
            cp.PostID = 1;
            cp.CategoryID = 1;
            rel.Add(cp);

            //setup SubSonic
            Post.Setup(posts);
            Category.Setup(cats);
            Categories_Post.Setup(rel);

            var result = Post.PostsByCategory("category");
            Assert.Equal(1, result.Count());

        }

    }
}
