using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using System;

namespace Acme.BookStore.Blazor.Client.Shared
{
    public partial class TabbedMainLayout : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool IsCollapseShown { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        private void ToggleCollapse()
        {
            IsCollapseShown = !IsCollapseShown;
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            IsCollapseShown = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
