using Prism.Interactivity.InteractionRequest;

namespace MyPrism_WPF.Notifications
{
    public interface ICustomNotification : IConfirmation
    {
        string SelectedItem { get; set; }
    }
}
