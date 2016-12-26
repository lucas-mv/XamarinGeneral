public class NavigationRoutines
{
    //Navigation routine for when the app is in a MasterDetailPage context
    public async Task NavigateMasterDetail(Page page)
    {
        if (page == null)
            {
                return;
            }

        var masterDetail = App.Current.MainPage as MasterDetailPage;

        if (masterDetail == null || masterDetail.Detail == null)
            return;         

        var navigationPage = masterDetail.Detail as NavigationPage;
        if (navigationPage == null)
        {
            masterDetail.Detail = new NavigationPage(page);
            masterDetail.IsPresented = false;
            return;
        }

        await navigationPage.Navigation.PushAsync(page);

        navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack[navigationPage.Navigation.NavigationStack.Count - 2]);
        masterDetail.IsPresented = false;
    }
}
