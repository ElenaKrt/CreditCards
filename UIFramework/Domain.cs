namespace UIFramework
{
    public class Domain
    {
        public class DomElement
        {
            public DomElementType AttributeName { get; set; }

            public string AttributeValue { get; set; }

            public DomElement(DomElementType attributeName, string attributeValue)
            {
                this.AttributeName = attributeName;
                this.AttributeValue = attributeValue;
            }

        }

        public enum DomElementType
        {
            ClassName,
            CssSelector,
            Id,
            LinkText,
            Name,
            PartialLinkText,
            TagName,
            XPath,
            JQuerySelector,
        }

        public enum Browser
        {
           
            IExplorer,
            Chrome, 
            Firefox,
            Safari,
            None
        }
    }
}
