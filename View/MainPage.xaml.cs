using i_hate_this.ViewModel;
using System.Text.RegularExpressions;

namespace i_hate_this.View;

public partial class MainPage : ContentPage
{
    

    public MainPage()
    {
        InitializeComponent();

        BindingContext = new MainViewModel();
    }

    private void OnPhoneEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var isValid = Regex.IsMatch(PhoneEntry.Text ?? string.Empty, @"^\d+$");
        PhoneErrorLabel.IsVisible = !isValid;
        UpdateRegisterButtonState();
    }

    private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var isValid = (PasswordEntry.Text?.Length ?? 0) > 5;
        PasswordErrorLabel.IsVisible = !isValid;
        UpdateRegisterButtonState();
    }

    private void OnTermsCheckboxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        UpdateRegisterButtonState();
    }

    private void OnTermsLabelTapped(object sender, EventArgs e)
    {
        TermsAndConditionsCheckbox.IsChecked = !TermsAndConditionsCheckbox.IsChecked;
    }

    private void UpdateRegisterButtonState()
    {
        var isPhoneValid = !PhoneErrorLabel.IsVisible;
        var isPasswordValid = !PasswordErrorLabel.IsVisible;
        var isTermsChecked = TermsAndConditionsCheckbox.IsChecked;

        RegisterButton.IsEnabled = isPhoneValid && isPasswordValid && isTermsChecked;
    }
}

    

