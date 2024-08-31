using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract;

public interface ISettingRepository
{
    IQueryable<Setting> Settings { get; }

    Task<string> GetValueByNameAsync(string name);
    Task CreateSettingAsync(Setting settings);
    Task UpdateSettingAsync(Setting settings);
    Task DeleteSettingAsync(Setting settings);
}