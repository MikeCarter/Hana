<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Rob Conery: Contact
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>With Respect to Inquiries</h1>
    
    My name is Rob Conery and this is my blog. I used to work at Microsoft with the ASP.NET
    peeps and have since moved on to begin work on my new venture - <a href="http://tekpub.com">Tekpub</a>.
    I am also the creator/curator/smooth operator of <a href="http://subsonicproject.com">SubSonic</a> - the greatest
    piece of software ever considered by the mind of man. The fact that the universe spoke through 
    me to bring you SubSonic is indeed an honor. I am humbled.

    <h2>Resume</h2>
    For inquries pertaining to my employment, <a href="/resume">I have fashioned a resume for your consideration</a>. A PDF download is 
    also available should you wish to read that instead of the fine HTML page I have created in your honor.

    <h2>Correspondence</h2>
    If you would like to send me a message directly, please fill out the form below and it will be sent electronically
    to my current physical location, and merged into my psyche by the mischevous electrons under my employ.
    
    <div style="margin-top:16px"><img src="/content/images/dear.png" /></div>
    <textarea style="font-family:Georgia;font-size:1.6em;color: black; background-color: transparent;width:65%; height:250px" name="message"></textarea>
    <div>
        <img src="/content/images/regards.png" />
        
    </div>
    <p>
    <input type="text" name="from" style="font-family:Georgia;font-size:1.6em;width:243px"/> <br />
    </p>
    <p>
    <input type="image" src="/content/images/stamp.jpg" alt="lick and send" style="border:0px"/>
    </p>
</asp:Content>
