using System.ComponentModel;
using System.Drawing;

namespace BoundaryTask.Settingss
{
    public class PaletteSettings
    {
        //ColorGraphicsMethod0
        [DisplayName("Точное решение")]
        [Category("Цвет графика")]
        public Color ExactSolution { get; set; } = Color.GreenYellow;

        //ColorGraphicsMethod1
        [DisplayName("Метод разностной прогонки")]
        [Category("Цвет графика")]
        public Color DifferentialSweepMethod { get; set; } = Color.DarkOrchid;

        //ColorGraphicsMethod2
        [DisplayName("Метод стрельбы")]
        [Category("Цвет графика")]
        public Color ShootingMethod { get; set; } = Color.Red;

    }
}