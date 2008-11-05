using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Lostechies.CS.Fragments.tests.BlogrollFragmentSpecs
{
    [TestFixture]
    public class when_rendering_the_custom_blogroll
    {
        private BlogrollFragment blogroll;

        [SetUp]
        public void Setup()
        {
            blogroll = new BlogrollFragment();    
        }

        [Test]
        public void should_have_a_fragment_description()
        {
            Assert.That(blogroll.FragmentDescription, Is.EqualTo("View All blogs with Post Count and Comment Count"));
        }

        [Test]
        public void should_have_a_fragment_name()
        {
            Assert.That(blogroll.FragmentName, Is.EqualTo("Blogroll"));
        }

        //Test inheritence fun
    }
}