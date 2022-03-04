namespace Controllers.Popups
{
    public interface IPopup
    {
        void Initialize(PopupsController popupsController);
        void Annihilate();
    }
}
