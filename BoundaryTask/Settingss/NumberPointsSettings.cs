using System.ComponentModel;

namespace BoundaryTask.Settingss
{
    public class NumberPointsSettings
    {
        [DisplayName("Колличество точек")]
        [Category("Точки")]
        public int NumberPoints { get; set; } = 18;
    }
}