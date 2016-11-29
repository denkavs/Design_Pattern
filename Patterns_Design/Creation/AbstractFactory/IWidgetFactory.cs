namespace Patterns_Design.Creation.AbstractFactory
{
    public interface IWidgetFactory
    {
        IWidgetButton CreateWidgetButton();
        IWidgetDialog CreateWidgetDialog();
    }
}