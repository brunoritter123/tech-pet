using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Builders;
using Testes.Builders.Dados;

namespace Testes;

public class UnitTest1 : IDisposable
{
    private readonly IWebDriver _driver;

    public UnitTest1()
    {
        // Configura o driver para o Chrome
        _driver = new ChromeDriver();
    }

    [Fact]
    public void SearchOnGoogle_ShouldReturnRelevantResults()
    {
        var teste = CreateTesteBuilder
            .WithDriver(_driver)
            .LogarCom(Usuarios.UsuarioComum);
        
        
        
        
        
        var menuOrdemServico = _driver.FindElement(By.CssSelector("po-menu-item[ng-reflect-label='Order de Serviço']"));
        menuOrdemServico.Click();
        
        var novaOsButton = _driver.FindElement(By.CssSelector("po-button[ng-reflect-label='Nova Ordem em Avaliação']"));
        novaOsButton.Click();
    }

    public void Dispose()
    {
        // Fecha o navegador após o teste
        _driver.Quit();
        _driver.Dispose();
    }
}