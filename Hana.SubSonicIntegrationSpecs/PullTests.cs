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

namespace Hana.SubSonicIntegrationSpecs {
    public class PullTests {
        Hana.Model.IBlogRepository repo;
        IDataProvider provider;
        public PullTests() {
            repo = new WPRepository();
            provider=ProviderFactory.GetProvider("wp");
        }

        [Fact]
        public void Can_Connect_To_DB() {
            
            var sql = "SELECT ID From wp_posts LIMIT 1";
            bool connected = false;
            using (IDataReader query = new CodingHorror(provider, sql).ExecuteReader()) {
                connected = query.Read();

            }

            Assert.True(connected, "Can't connect to MySQL DB");
        }

        [Fact]
        public void All_Should_Return_Correct_count_of_Posts() {
            var sql = "SELECT COUNT(ID) From wp_posts";
            var baseCount = new CodingHorror(provider, sql).ExecuteScalar<int>();

            var allCount = repo.GetPosts().Count();

            Assert.Equal(baseCount, allCount);
        }
        [Fact]
        public void All_Should_Return_list_of_Posts() {

            var sql = "SELECT COUNT(ID) From wp_posts";
            var baseCount = new CodingHorror(provider, sql).ExecuteScalar<int>();
            var posts = repo.GetPosts();

            Assert.Equal(baseCount, posts.Count());
        }
        [Fact]
        public void All_Should_Return_list_of_Posts_by_status() {

            var sql = "SELECT COUNT(ID) From wp_posts where post_status='published'";
            var baseCount = new CodingHorror(provider, sql).ExecuteScalar<int>();
            var posts = repo.GetPosts().Where(x=>x.Status==Post.Status_Published);

            Assert.Equal(baseCount, posts.Count());
        }

        [Fact]
        public void All_Should_Return_Single_Post() {
            var post = repo.GetPost("temet-nosce", 0, 0, 0);
            Assert.NotNull(post);
        }
    }
}
