using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Hana.Model;


namespace Hana.Specs {
    public class HomeViewModelTests {


        [Fact]
        public void HomeViewModel_Should_Set_10_Recent_Posts_When_10_Passed_In(){
            //SubSonic fakery... awesome...
            //these aren't the posts you're looking for...
            Post.Setup(100);

            var recent = Post.All().Take(10);
            var model = new HomeViewModel(recent, recent, recent, recent);

            Assert.Equal(10,model.RecentPosts.Count);
        }
        [Fact]
        public void HomeViewModel_Should_Set_10_SubSonic_Posts_When_10_Passed_In() {

            Post.Setup(100);
            var recent = Post.All().Take(10);
            var model = new HomeViewModel(recent, recent, recent, recent);

            Assert.Equal(10, model.SubSonicPosts.Count);
        }
        [Fact]
        public void HomeViewModel_Should_Set_10_Popular_Posts_When_10_Passed_In() {

            Post.Setup(100);
            var recent = Post.All().Take(10);
            var model = new HomeViewModel(recent, recent, recent, recent);

            Assert.Equal(10, model.PopularPosts.Count);
        }
        [Fact]
        public void HomeViewModel_Should_Set_10_Tekpub_Posts_When_10_Passed_In() {

            Post.Setup(100);
            var recent = Post.All().Take(10);
            var model = new HomeViewModel(recent, recent, recent, recent);

            Assert.Equal(10, model.TekpubPosts.Count);
        }
    }
}
