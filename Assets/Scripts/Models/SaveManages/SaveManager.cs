namespace Models.SaveManages
{
    public class SaveManager
    {
        public static readonly ISaveService Current = new FileSaveService();

        #region Keys

        public const string DataArray = "dataArray";

        #endregion
    }
}
