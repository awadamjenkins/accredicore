using Accredi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Pages;

public partial class LoginOrLogoutPage : ContentPage, ITransientDependency
{
	public LoginOrLogoutPage(LoginOrLogoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}