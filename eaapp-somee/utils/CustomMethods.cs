namespace eaapp_somee.utils
{
    public static class CustomMethods
    {
        // Method to click an IWebElement
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        // Method to submit a form using an IWebElement
        public static void SubmitForm(this IWebElement element)
        {
            element.Submit();
        }

        // Method to enter text into a IWebElement
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        // Method to select an option from a dropdown by text, value, or index
        public static void SelectDropdown(this IWebElement locator, string text, string attribute)
        {
            var selectElement = new SelectElement(locator);
            switch (attribute)
            {
                case "text": selectElement.SelectByText(text); break;
                case "value": selectElement.SelectByValue(text); break;
                case "index": selectElement.SelectByIndex(int.Parse(text)); break;
                default: throw new ArgumentException("Invalid attribute specified. Use 'text', 'value', or 'index'.");
            }
        }

        // Method to select multiple options from a multi-select dropdown by text, value, or index
        public static void MultiSelect(this IWebElement locator, string[] values, string attribute)
        {
            var selectElement = new SelectElement(locator);
            foreach (var value in values)
            {
                switch (attribute)
                {
                    case "value": selectElement.SelectByValue(value); break;
                    case "index": selectElement.SelectByIndex(int.Parse(value)); break;
                    case "text": selectElement.SelectByText(value); break;
                    default: throw new ArgumentException("Invalid attribute specified. Use 'text', 'value', or 'index'.");
                }
            }
        }

        // Method to get all selected options from a multi-select dropdown
        public static List<string> GetSelectedOptions(this IWebElement locator)
        {
            var options = new List<string>();
            var selectElement = new SelectElement(locator);
            var selectedOption = selectElement.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
    }
}
