using i_hate_this.ViewModel;

namespace i_hate_this.View;

public partial class CentralPage : ContentPage
{
	public CentralPage()
	{
		InitializeComponent();

		BindingContext = new CentralViewModel();
	}
}