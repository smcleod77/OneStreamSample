using Microsoft.AspNetCore.Components;
using OneStreamSample.Client.Services.Interfaces;
using OneStreamSample.Shared;

namespace OneStreamSample.Client.Components;

public partial class FeatureWidget
{
    #region Variables
    [Inject] private IOneStreamService OneStreamService { get; set; }

    private OneStreamModel Model = null;
    private bool IsLoading = true;
    private bool IsUpdatingModel = false;
    private string ErrorMessage = String.Empty;
    private string SuccessMessage = String.Empty;
    #endregion

    #region Lifecycle Functions
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (firstRender)
        {
            try
            {
                Model = await OneStreamService.GetAsync();
                StateHasChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
                StateHasChanged();
            }
        }
    }
    #endregion

    #region Event Handlers
    protected async Task UpdateClicked()
    {
        try
        {
            ErrorMessage = String.Empty;
            SuccessMessage = String.Empty;
            IsUpdatingModel = true;
            StateHasChanged();

            var success = await OneStreamService.UpdateAsync(Model);
            if (success)
            {
                SuccessMessage = "Update Successful";
            }
            else
            {
                ErrorMessage = "Update Failed";
            }
            StateHasChanged();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsUpdatingModel = false;
            StateHasChanged();
        }
    }
    #endregion
}