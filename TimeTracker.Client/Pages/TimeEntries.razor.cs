/*

// C# code-behind example for a Blazor component

using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.Client.Pages
{
    public partial class TimeEntries
    {
        [Inject] HttpClient Http { get; set; }

        private List<TimeEntryResponse> timeEntries = new List<TimeEntryResponse>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<List<TimeEntryResponse>>("api/timeentry");
            if(result != null)
            {
                timeEntries = result;
            }
        }
    }
}

*/
