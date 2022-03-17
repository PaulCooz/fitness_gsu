namespace Models.SaveManages
{
    public interface ISaveService
    {
        T Get<T>(string key, T defaultValue);
        void Set<T>(string key, T value);
        bool HasKey(string key);
    }
}
