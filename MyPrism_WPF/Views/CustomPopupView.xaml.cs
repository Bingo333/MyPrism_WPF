using System;
using System.Windows;
using System.Windows.Controls;
using Prism.Interactivity.InteractionRequest;

namespace MyPrism_WPF.Views
{
    /// <summary>
    /// Interaction logic for CustomPopupView
    /// </summary>
    public partial class CustomPopupView : UserControl, IInteractionRequestAware
    {
        public CustomPopupView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FinishInteraction?.Invoke();
        }

        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }
    }
}
