using BoundaryTask.Settingss;

namespace BoundaryTask.Actionss
{
    public class PaletteSettingsAction : IUiAction
    {
        private readonly PaletteSettings paletteSettings;

        public PaletteSettingsAction(PaletteSettings paletteSettings)
        {
            this.paletteSettings = paletteSettings;
        }

        public string Name => "Цвета графиков";
        public string Category => "Настройки";

        public void Perform()
        {
            SettingsForm.For(paletteSettings).ShowDialog();
        }
    }
}