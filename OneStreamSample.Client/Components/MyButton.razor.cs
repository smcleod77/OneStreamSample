using Microsoft.AspNetCore.Components;

namespace OneStreamSample.Client.Components; 

public partial class MyButton
{
    #region Variables
    [Parameter] public bool IsLoading { get; set; }
    [Parameter] public string ButtonClass { get; set; }
    [Parameter] public string Class { get; set; }

    [Parameter] public bool? Disabled { get; set; }
    [Parameter] public string DisabledTitleText { get; set; } = "Disabled";
    [Parameter] public string TitleText { get; set; } = String.Empty;

    [Parameter] public bool? Autofocus { get; set; }

    [Parameter] public bool Hidden { get; set; }

    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> AdditionalAttributes { get; set; }

    /// <summary>
    /// Measurement for min-width css styling (ie. 300px, 2rem, 5em, etc.)
    /// </summary>
    [Parameter] public string MinWidth { get; set; }

    [Parameter] public string Style { get; set; } = String.Empty;
    #endregion

    #region Lifecycle Functions
    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (!String.IsNullOrWhiteSpace(MinWidth))
        {
            Style += $"min-width:{MinWidth};";
        }
        if (Hidden)
        {
            Style += $"display:none;";
        }
    }
    #endregion

    #region Private Functions
    private string GetButtonClass()
    {
        var retVal = "btn-primary";
        if (!String.IsNullOrWhiteSpace(ButtonClass))
        {
            retVal = ButtonClass;
        }
        return retVal;
    }
    #endregion
}
