using CommunityToolkit.Maui.Alerts;
using System.Text;

namespace InvScanPro.Helpers;

internal static class DisplayHelper
{
    internal static async Task DisplayToast(
        string label,
        string? preMessage = null,
        string? postMessage = null)
    {
        Application.Current!.Resources.TryGetValue(label, out var labelValue);
        var sb = new StringBuilder();
        sb.AppendJoin(" ", preMessage, labelValue?.ToString(), postMessage);

        await Toast.Make(sb.ToString()).Show();
    }

    internal static async Task<bool> DisplayAlert(
        string titleLabel,
        string messageLabel,
        string yesLabel,
        string noLabel,
        string? preMessage = null,
        string? postMessage = null)
    {
        Application.Current!.Resources.TryGetValue(titleLabel, out var title);
        Application.Current.Resources.TryGetValue(messageLabel, out var message);
        Application.Current.Resources.TryGetValue(yesLabel, out var yes);
        Application.Current.Resources.TryGetValue(noLabel, out var no);

        var sb = new StringBuilder();
        sb.AppendJoin(" ",preMessage, message?.ToString(), postMessage);

        return await Application.Current.MainPage!.DisplayAlert(
            title?.ToString(),
            sb.ToString(),
            yes?.ToString(),
            no?.ToString());
    }
}
