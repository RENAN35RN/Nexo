namespace Nexo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("RevealPage", typeof(Views.RevealPage));
    }
}