namespace AutoTestsSelenium.Support
{
    public class xPaths
    {
        public readonly By EmailInput = By.XPath("//input[@name='email']");
        public readonly By PasswordInput = By.XPath("//input[@name='password']");
        public readonly By EnterButton = By.XPath("//button[text()='Войти']");
        public readonly By CreateGroupAside = By.XPath("//span[text()='Создать группу']");
        public readonly By EnterGroupName = By.XPath("//input[@placeholder='Введите название']");
        public readonly By ChooseCourse = By.XPath("//div[@class='drop-down-filter  ']");
        public readonly By BackendC = By.XPath("//li[text()='Backend C#']");
    }
}
