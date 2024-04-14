using Microsoft.AspNetCore.Components;

namespace OneStreamSample.Client.Components;

public partial class LoadingSpinner
{
    [Parameter] public string Class { get; set; }
    [Parameter] public LoadingSpinnerSize Size { get; set; }
    [Parameter] public bool Centered { get; set; }

    public string SizeClass => Size switch
    {
        LoadingSpinnerSize.ExtraSmall => "extra-small",
        LoadingSpinnerSize.Medium => "medium",
        LoadingSpinnerSize.Large => "large",
        _ => ""
    };
}

public enum LoadingSpinnerSize
{
    /// <summary>
    /// The default size of the loading spinner.
    /// </summary>
    Small,
    Medium,
    Large,
    ExtraSmall
}
