namespace Patterns_Design.Creation.AbstractFactory
{
    public class PMWidgetFactory : IWidgetFactory
    {
        public IWidgetButton CreateWidgetButton()
        {
            return new PMButton();
        }

        public IWidgetDialog CreateWidgetDialog()
        {
            return new PmDialog();
        }
    }
}