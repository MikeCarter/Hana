using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Extensions;
using System.Text.RegularExpressions;

namespace WP {
    public partial class wp_post {

        public string Excerpt{
             get{

                if (string.IsNullOrEmpty(post_content))
                    return "";
                 //see if there is a break put in by LiveWriter
                 if(this.post_content.Contains("<!--more-->")){
                     return this.post_content.Chop("<!--more-->");
                 }else{
                     return this.CreateSummary();
                 }
             }   
        }

        public string CreateSummary() {
            string result = this.post_content;
            if (this.post_content.Length > 500) {

                var entry = this.post_content.StripHTML();
                //regex on the sentences and return the first 2
                var reg = new Regex(@"[^.?!]+[.?!]");
                var matches = reg.Matches(entry);
                if(matches.Count >1){
                    result = matches[0].Value + matches[1].Value;
                }else if(matches.Count>0){
                    result = matches[0].Value;
                }

                
            }
            return result;
        }
    
    }
}
