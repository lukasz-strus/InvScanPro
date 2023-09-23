namespace InvScanPro.Helpers;

internal static class DisplayHelper
{
    internal static async Task DisplayError(
        string titleLabel,
        string messageLabel)
    {
        Application.Current!.Resources.TryGetValue(titleLabel, out object title);
        Application.Current!.Resources.TryGetValue(messageLabel, out object message);

        await Application.Current!.MainPage!.DisplayAlert(title.ToString(), message.ToString(), "OK");
    }

    internal static async Task<bool> DisplayAlert(
        string titleLabel,
        string messageLabel,
        string yesLabel,
        string noLabel)
    {
        Application.Current!.Resources.TryGetValue(titleLabel, out object title);
        Application.Current!.Resources.TryGetValue(messageLabel, out object message);
        Application.Current!.Resources.TryGetValue(yesLabel, out object yes);
        Application.Current!.Resources.TryGetValue(noLabel, out object no);

        return await Application.Current!.MainPage!.DisplayAlert(
            title.ToString(),
            message.ToString(),
            yes.ToString(),
            no.ToString());
    }

    internal static async Task<string> DisplayPromptAsync(
        string titleLabel,
        string messageLabel,
        string acceptLabel,
        string cancelLabel)
    {
        Application.Current!.Resources.TryGetValue(titleLabel, out object title);
        Application.Current!.Resources.TryGetValue(messageLabel, out object message);
        Application.Current!.Resources.TryGetValue(acceptLabel, out object accept);
        Application.Current!.Resources.TryGetValue(cancelLabel, out object cancel);

        return await Application.Current!.MainPage!.DisplayPromptAsync(
            title.ToString(),
            message.ToString(),
            accept.ToString(),
            cancel.ToString());
    }
}
