using Behaviors;

namespace Degano.Views
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void OnEmailTextChange(object sender, EventArgs e)
        {
            UserInfo.EMail = ((Entry)sender).Text;
            CheckIsValid();
        }

        private void OnPasswordTextChange(object sender, EventArgs e)
        {
            UserInfo.Password = ((Entry)sender).Text;
            CheckIsValid();
        }

        private void OnSubmitClick(object sender, EventArgs e) => Navigation.PushAsync(new MainPage());

        private void CheckIsValid()
        {
            Submit.IsEnabled = EmailEntry.Behaviors.OfType<EmailValidatorBehavior>().First().IsValid && PasswordEntry.Behaviors.OfType<TextValidatorBehavior>().First().IsValid;
            PasswordLabel.IsVisible = !PasswordEntry.Behaviors.OfType<TextValidatorBehavior>().First().IsValid;
            EmailLabel.IsVisible = !EmailEntry.Behaviors.OfType<EmailValidatorBehavior>().First().IsValid;
        }
    }
}
