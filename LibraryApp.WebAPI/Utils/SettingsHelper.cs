using LibraryApp.Data.Abstract;

namespace LibraryApp.WebAPI.Utils;

public static class SettingsHelper
{
    public static int AllowedDelayForResponses { get; private set; }
    public static float FinePerDay { get; private set; }
    public static int DefaultBorrowDuration { get; private set; }
    public static int ExtraDurationForReturningFast { get; private set; }

    public static async void InitSettingsFromDb(ISettingRepository settingRepository)
    {
        AllowedDelayForResponses = int.Parse(await settingRepository.GetValueByNameAsync("allowed-delay-for-responses"));
        FinePerDay = float.Parse(await settingRepository.GetValueByNameAsync("fine-per-day"));
        DefaultBorrowDuration = int.Parse(await settingRepository.GetValueByNameAsync("default-borrow-duration"));
        ExtraDurationForReturningFast = int.Parse(await settingRepository.GetValueByNameAsync("extra-duration-for-returning-fast"));
    }
}