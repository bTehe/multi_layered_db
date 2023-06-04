namespace PL
{
    public static class Menu
    {
        private static int selectedIdx = 0;

        public static void MainMenu()
        {
            CustomMenu someMenu = new CustomMenu("BILLBOARD")
                .Add("Show all the ads", () => FilePerformer.ShowAllAds())
                .Add("Create an ad", () => FilePerformer.CreateAd())
                .Add("Deactivate an ad", () => FilePerformer.DeactivateAd())
                .Add("Activate an ad", () => FilePerformer.ActivateAd())
                .Add("Delete an ad", () => FilePerformer.DeleteAd())
                .Add("Exit", CustomMenu.Close);

            while (selectedIdx != 5)
            {
                selectedIdx = someMenu.Run();
            }
        }
    }
}
