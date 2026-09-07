using Nexo.ViewModels;

namespace Nexo.Views;

public partial class RevealPage : ContentPage
{
    public RevealPage(RevealViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
