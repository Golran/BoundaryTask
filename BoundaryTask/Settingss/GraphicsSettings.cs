using System.ComponentModel;

namespace BoundaryTask.Settingss
{
    public class GraphicsSettings
    {
        //UsingMethod0
        [DisplayName("Точное решение")]
        [Category("Отображать графики")]
        public bool ExactSolution { get; set; } = true;

        //UsingMethod1
        [DisplayName("Метод разностной прогонки")]
        [Category("Отображать графики")]
        public bool DifferentialSweepMethod { get; set; } = true;

        //UsingMethod2
        [DisplayName("Метод стрельбы")]
        [Category("Отображать графики")]
        public bool ShootingMethod { get; set; } = true;

        //UsingMethod0
        [DisplayName("Точное решение")]
        [Category("Толщина графика")]
        public int ExactSolutionBorderWidth { get; set; } = 6;

        //UsingMethod1
        [DisplayName("Метод разностной прогонки")]
        [Category("Толщина графика")]
        public int DifferentialSweepMethodBorderWidth { get; set; } = 2;

        //UsingMethod2
        [DisplayName("Метод стрельбы")]
        [Category("Толщина графика")]
        public int ShootingMethodBorderWidth { get; set; } = 5;



    }
}