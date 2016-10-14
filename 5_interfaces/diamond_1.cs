public interface IUIControl
{
    void Paint();
}

public interface IEditBox : IUIControl
{
}

public interface IDropList : IUIControl
{
}

public class ComboBox : IEditBox, IDropList
{
    public void Paint() {
        // paint implementation for ComboBox
    }
}
