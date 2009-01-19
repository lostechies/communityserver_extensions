using System;
using System.Web.UI;
using CommunityServer.Blogs.Controls;
using CommunityServer.Components;
using CommunityServer.Controls;
using Telligent.DynamicConfiguration.Components;
using GroupData=CommunityServer.Blogs.Controls.GroupData;
using GroupList=CommunityServer.Blogs.Controls.GroupList;

namespace Lostechies.CS.Fragments
{
    public class BlogrollFragment : ConfigurableContentFragmentBase
    {
        private string fragmentName = "Blogroll";

        public override void AddContentControls(Control control)
        {
            fragmentName = GetStringValue("widgetName", "Blogroll");
            GroupList groupList = new GroupList();
            groupList.ItemTemplate = new WrappedControlItemTemplate(BindGroupListContent, CreateGroupListContentControls);
            control.Controls.Add(groupList);
        }

        protected void BindGroupListContent(Control control, IDataItemContainer dataItemContainer)
        {
            control.Controls.Add(new LiteralControl("<div class=\"CommonListArea\">"));
            GroupData groupData = new GroupData();
            groupData.Property = "Name";
            groupData.Tag = WrappedControlTag.H2;
            groupData.CssClass = "CommonListTitle";
            control.Controls.Add(groupData);

            control.Controls.Add(new LiteralControl("<br />"));
            WeblogList weblogList = new WeblogList();
            CommunityServer.Controls.SectionQuery query = new CommunityServer.Controls.SectionQuery();
            query.SortBy = (SectionSortBy)Enum.Parse(typeof(SectionSortBy), "Name");
            query.SortOrder = (SortOrder)Enum.Parse(typeof(SortOrder), "Ascending");
            query.PagerID = "PagerID";
            query.PageSize = 100;
            weblogList.QueryOverrides = query;
            weblogList.ItemTemplate = new WrappedControlItemTemplate(BindWeblogListContent, CreateWeblogListContentControls);
            control.Controls.Add(weblogList);

            PostbackPager pager = new PostbackPager();
            pager.ID = "PagerID";
            control.Controls.Add(pager);

            control.Controls.Add(new LiteralControl("</div>"));
        }


        public override string FragmentDescription
        {
            get { return "View All blogs with Post Count and Comment Count"; }
        }

        public override string FragmentName
        {
            get { return fragmentName; }
        }

        protected void CreateGroupListContentControls(Control control)
        {
            // do nothing
        }

        protected void BindWeblogListContent(Control control, IDataItemContainer dataItemContainer)
        {

            WeblogData blogName = new WeblogData();
            blogName.Property = "Name";
            blogName.Tag = WrappedControlTag.B;
            blogName.LinkTo = WeblogLinkTo.HomePage;
            control.Controls.Add(blogName);

            control.Controls.Add(new LiteralControl("<br />"));

            WeblogData postCount = new WeblogData();
            postCount.Property = "PostCount";
            control.Controls.Add(postCount);

            LiteralControl postText = new LiteralControl(" Posts | ");
            control.Controls.Add(postText);

            WeblogData commentCount = new WeblogData();
            commentCount.Property = "CommentCount";
            control.Controls.Add(commentCount);

            LiteralControl commentText = new LiteralControl(" Comments");
            control.Controls.Add(commentText);

            control.Controls.Add(new LiteralControl("<br />"));
        }

        protected void CreateWeblogListContentControls(Control control)
        {
            // do nothing
        }

        public override PropertyGroup[] GetPropertyGroups()
        {
            PropertyGroup group = new PropertyGroup("group1", "Options", 0);
            Property widgetName = new Property("widgetName", "Widget Name", PropertyType.String, 0, fragmentName);
            group.Properties.Add(widgetName);
            return new[] { group };
        }
    }
}