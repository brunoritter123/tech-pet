using M31.FluentApi.Attributes;
using OpenQA.Selenium;
using Testes.Builders.DTOs;

namespace Builders;

[FluentApi(builderClassName: "CreateTesteBuilder")]
public class TesteBuilder
{
    [FluentMember(0)]
    public IWebDriver Driver { get; private set; }
    
    [FluentMethod(1)]
    private void LogarCom(UsuarioDto usuario)
    {
        Driver.Navigate().GoToUrl("http://localhost:4200");
        Driver.Manage().Window.Size = new System.Drawing.Size(1368, 768);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        
        var loginInput = Driver.FindElement(By.CssSelector("input[name='login']"));
        loginInput.SendKeys("joao9@hotmail.com");
        
        var passwordInput = Driver.FindElement(By.CssSelector("input[name='password']"));
        passwordInput.SendKeys("teste");
        
        var entrarButton = Driver.FindElement(By.CssSelector("po-button[ng-reflect-label='Entrar']"));
        entrarButton.Click();
    }
}