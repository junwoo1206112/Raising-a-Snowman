using System.Collections.Generic;

namespace Snowman.Core.Data
{
    public interface IDataService
    {
        T GetConfig<T>(string key) where T : class;
        IEnumerable<T> GetAllConfigs<T>() where T : class;
        void LoadAllData();
    }
}
