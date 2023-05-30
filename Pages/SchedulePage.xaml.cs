namespace app_myconference.Pages;

public partial class SchedulePage : ContentPage
{
    readonly ScheduleViewModel vm;
    public static int Day { get; set; }
    public SchedulePage(ScheduleViewModel vm)
    {
        InitializeComponent();

        
        Day++;
        vm.Day = Day;

        BindingContext = this.vm = vm;
    }
}
