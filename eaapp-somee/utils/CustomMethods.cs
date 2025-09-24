namespace eaapp_somee.utils
{
    public static class CustomMethods
    {
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }
    }
}
