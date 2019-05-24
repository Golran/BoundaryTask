namespace BoundaryTask.Actionss
{
    public class CreateAction : IUiAction
    {
        private readonly ChartHolder chartHolder;

        public CreateAction(ChartHolder chartHolder)
        {
            this.chartHolder = chartHolder;
        }

        public string Name => "Создать график";
        public string Category => "Создать";

        public void Perform()
        {
            chartHolder.MakeGraphics();
        }
    }
}