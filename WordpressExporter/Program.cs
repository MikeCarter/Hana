using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hana.Model;
using WP;

namespace WordpressExporter {
    class Program {
        static void Main(string[] args) {

            //ImportTags();
            //ImportCategories();
            ImportPosts();
            Console.ReadLine();
        }

        static void ImportTags(){
            Write("Deleting tags");
            //delete existing
            Tag.Delete(x => x.TagID > 0);

            //pull the WP tags
            var query = from t in wp_term.All()
                        join tt in wp_term_taxonomy.All() on t.term_id equals tt.term_id
                        where tt.taxonomy == "post_tag"
                        select t;

            foreach (var term in query){
                //add the tag to the DB
                Write("Adding tag "+term);
                var t = new Tag();
                t.Description = term.name;
                t.Slug = term.slug;
                t.Add();
            }
            Write("Finished importing tags **************************");

        }

        static void ImportCategories(){
            Write("Deleting Categories");
            //delete existing
            Category.Delete(x => x.CategoryID > 0);
            //pull the WP tags
            var query = from t in wp_term.All()
                        join tt in wp_term_taxonomy.All() on t.term_id equals tt.term_id
                        where tt.taxonomy == "category"
                        select t;

            foreach (var term in query) {
                //add the tag to the DB
                Write("Adding category " + term);
                var c = new Category();
                c.Description = term.name;
                c.Slug = term.slug;
                c.Add();
            }
            Write("Finished importing categories **************************");
        }

        static void ImportPosts(){
            Write("Deleting Posts, Comments and Tag/Category associations");
            //delete existing
            Tags_Post.Delete(x => x.PostID > 0);
            Categories_Post.Delete(x => x.PostID > 0);
            Comment.Delete(x=>x.CommentID>0);
            Post.Delete(x => x.PostID > 0);

            var posts = wp_post.All().Where(x => x.post_status == "publish");
            foreach (var post in posts){
                
                Write("Adding Post "+post.post_title);
                
                Post p=new Post();
                p.PostID = (int)post.ID;
                p.Title = post.post_title;
                p.Author = "Rob Conery";
                p.PublishedOn = post.post_date;
                p.CreatedOn = post.post_date;
                p.ModifiedOn = post.post_modified;
                p.Slug = post.post_name;
                p.Body = post.post_content;
                p.Excerpt = post.Excerpt;
                p.CommentCount = wp_comment.All().Count(x => x.comment_post_ID == post.ID);
                p.IsPublished = true;

                p.Add();

                //get the tags for this post
                var tags = (from t in wp_term.All()
                            join tt in wp_term_taxonomy.All() on t.term_id equals tt.term_id
                            join tr in wp_term_relationship.All() on tt.term_taxonomy_id equals tr.term_taxonomy_id
                            where tt.taxonomy == "post_tag" && tr.object_id==post.ID
                            select t).ToList();

                for (int i = 0; i < tags.Count; i++){
                    Write("Setting tag " + tags[i].name);
                    p.Tags += tags[i].name;
                    if (i + 1 < tags.Count)
                        p.Tags += ",";

                    //set the association
                    var t = Tag.SingleOrDefault(x => x.Description == tags[i].name);
                    if(t!=null){
                        var tp=new Tags_Post();
                        tp.PostID = p.PostID;
                        tp.TagID = t.TagID;
                        tp.Add();
                    }

                }

                //get the categories for this post
                var cats = (from t in wp_term.All()
                            join tt in wp_term_taxonomy.All() on t.term_id equals tt.term_id
                            join tr in wp_term_relationship.All() on tt.term_taxonomy_id equals tr.term_taxonomy_id
                            where tt.taxonomy == "category" && tr.object_id == post.ID
                            select t).ToList();

                for (int i = 0; i < cats.Count; i++) {
                    Write("Setting category " + cats[i].name);
                    //set the association
                    var c = Category.SingleOrDefault(x => x.Description == cats[i].name);
                    if (c != null) {
                        var cp = new Categories_Post();
                        cp.PostID = p.PostID;
                        cp.CategoryID = c.CategoryID;
                        cp.Add();
                    }

                }

                //import the comments
                ImportComments(post.ID);

            }

            Write("Finished importing Posts **************************");
            
        }

        static void ImportComments(ulong postID){

            var comments = wp_comment.All().Where(x => x.comment_approved == "1" && x.comment_post_ID==postID);
            foreach (var comment in comments){
                Write("Adding comment from "+comment.comment_author);
                
                Comment c=new Comment();
                c.CommentID = (int)comment.comment_ID;
                c.PostID = (int)comment.comment_post_ID;
                c.Author = comment.comment_author;
                c.IP = comment.comment_author_IP;
                c.Email = comment.comment_author_email;
                c.URL = comment.comment_author_url;
                c.CreatedOn = comment.comment_date;
                c.Body = comment.comment_content.Replace("\r","<br \\>");
                c.ParentID = (int)comment.comment_parent;
                c.PublishedOn = comment.comment_date;
                c.Add();
            }


            
        }


        static void Write(string message){
            Console.WriteLine(message);
        }
    }
}
