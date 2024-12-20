using i_hate_this.View;

namespace i_hate_this
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CentralPage), typeof(CentralPage));
        }
        
    }
}
