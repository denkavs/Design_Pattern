namespace Patterns_Design.Creation.AbstractFactory
{
    public class MotifWidgetFactory : IWidgetFactory
    {
        public IWidgetButton CreateWidgetButton()
        {
            throw new System.NotImplementedException();
        }

        public IWidgetDialog CreateWidgetDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}