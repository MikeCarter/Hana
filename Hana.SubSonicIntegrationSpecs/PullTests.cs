using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using SubSonic.Query;
using SubSonic.DataProviders;
using System.Data;
using SubSonic.Repository;
using Hana.Model.Repo;
using Hana.Model;

namespace Hana.SubSonicIntegration {
    public class PullTests {
        IBlogRepository repo;
        IDataProvider provider;
        public PullTests() {
            repo = new WPRepository();
            provider=ProviderFactory.GetProvider("wp");
        }

        [Fact]
        public void Can_Connect_To_DB() {
            
            var sql = "SELECT ID From wp_posts LIMIT 1";
            bool connected = false;
            using (IDataReader query = new CodingHorror(provider, sql)
                .ExecuteReader()) {
                connected = query.Read();

            }

            Assert.True(connected, "Can't connect to MySQL DB");
        }
        [Fact]
        public void GetPosts_Should_Return_Correct_count_of_Posts() {
            var sql = "SELECT COUNT(ID) From wp_posts";
            var baseCount = new CodingHorror(provider, sql)
                .ExecuteScalar<int>();

            var allCount = repo.GetPosts().Count();

            Assert.Equal(baseCount, allCount);
        }
        [Fact]
        public void GetPosts_Should_Return_list_of_Posts() {

            var sql = "SELECT COUNT(ID) From wp_posts";
            var baseCount = new CodingHorror(provider, sql)
                .ExecuteScalar<int>();
            var posts = repo.GetPosts();
            
            Assert.Equal(baseCount, posts.Count());
        }
        [Fact]
        public void GetPosts_Should_Return_list_of_Posts_by_status() {

            var sql = "SELECT COUNT(ID) From wp_posts where post_status='publish'";
            var baseCount = new CodingHorror(provider, sql)
                .ExecuteScalar<int>();
            var posts = repo.GetPosts()
                .Where(x=>x.Status==Post.Status_Published);

            Assert.Equal(baseCount, posts.Count());
        }
        [Fact]
        public void GetPosts_Should_Be_Able_To_Return_Single() {

            var post = repo.GetPosts().Where(x => x.Slug == "temet-nosce")
                .SingleOrDefault();

            Assert.NotNull(post);
        }

        [Fact]
        public void SubSonic_Should_Return_Authors_With_All_Information() {

            var authors = WP.wp_user.All();
            Assert.Equal("Rob Conery", authors.First().display_name);
            Assert.Equal("rob@wekeroad.com", authors.First().user_email);
        }
        [Fact]
        public void SubSonic_Should_Return_Posts_With_All_Information() {

            var posts = WP.wp_post.All();
            Assert.Equal("I'm Moving To SubText", posts.First().post_title);
            Assert.True(posts.First().post_content.Length >0);
        }

        [Fact]
        public void GetPosts_Should_Return_Single_Post_Which_Is_Correctly_Bound() {
            var post = repo.GetPost("temet-nosce", 0, 0, 0);
            Assert.Equal("Temet Nosce", post.Title);
        }
    }
}
