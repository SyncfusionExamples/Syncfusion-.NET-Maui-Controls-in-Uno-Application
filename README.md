# Syncfusion-.NET-Maui-Controls-in-Uno-Application
This article will guide you through the process of using Syncfusion Maui controls within an Uno application using .NET MAUI Embedding. 

## Creating a UNO Application with .NET Maui Embedding
1.	Launch Visual Studio and create a new project by selecting "Create a new project." Choose "UNO Platform App" from the project templates.
2.	Select either the Blank or Recommended preset template. To enable .NET Maui embedding, customize the options accordingly.
 
3.	In the Features section, ensure to include the MAUI Embedding feature. Remember that these controls are only compatible with the platforms that .NET MAUI supports - iOS, Android, MacOS, and Windows. Therefore, deselect other platforms before creating the application.  

4.	After creating the application, you will notice a .NET MAUI class library (e.g. SyncfusionMauiApp.MauiControls) in the project, which allows you to add references to third-party .NET MAUI control libraries and define the .NET MAUI controls to be displayed within the Uno application.
 
5.	Run the application by selecting the desired platform from the dropdown and pressing F5 or clicking the Run button.

## Integrating Syncfusion Maui Controls with Uno Platform Application

To integrate Syncfusion Maui controls, such as the .NET Maui Cartesian Chart, follow these steps:

1.	Install the Syncfusion.MAUI.Charts NuGet package in the MauiControls (e.g. SyncfusionMauiApp.MauiControls) project. 
2.	Add the appropriate namespace and initialize the CartesianChart in the EmbeddedControl XAML file.

```
<ContentView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:charts="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
             x:Class="SyncfusionMauiApp.MauiControls.EmbeddedControl"
             HorizontalOptions="Fill"
             VerticalOptions="Fill">

  <charts:SfCartesianChart />
</ContentView>
```
3.	Open the `AppBuilderExtensions.cs` file and add the Syncfusion MAUI core hosting namespace. Register the Syncfusion core handler by adding the `ConfigureSyncfusionCore` method.
using Syncfusion.Maui.Core.Hosting;
namespace SyncfusionMauiApp;

```
public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiControls(this MauiAppBuilder builder) =>
        builder
        .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("SyncfusionMauiApp/Assets/Fonts/OpenSansRegular.ttf", "OpenSansRegular");
                fonts.AddFont("SyncfusionMauiApp/Assets/Fonts/OpenSansSemibold.ttf", "OpenSansSemibold");
            });
}
```

4.	Register a trial license key to use the Syncfusion MAUI controls by opening the `App.xaml.cs` file and adding the `RegisterLicense` method with the key.

```
public partial class App : Application
{
    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Add license key");
        InitializeComponent();
    }
}
```

5.	In this example, I’m to explore the population growth of various countries in the .NET Maui Cartesian Chart. So that, Add `ChartDataModel` and `ChartDataViewModel` classes to the MauiControls project to manage the chart data.

```
public class ChartDataModel
{
    public string? Name { get; set; }
    public double Value { get; set; }
}

public class ChartDataViewModel
{
    public ObservableCollection<ChartDataModel> ColumnData{ get; set; }

    public ChartDataViewModel()
    {
        ColumnData = new ObservableCollection<ChartDataModel>
        {
            new ChartDataModel(){Name = "China", Value=0.541},
            new ChartDataModel(){Name="Egypt" , Value=0.818},
            new ChartDataModel(){Name = "Bolivia", Value=1.51},
            new ChartDataModel(){Name = "Mexico",Value =1.302},
            new ChartDataModel(){Name = "Brazil", Value =2.017},
        };
    }
}

```

6.	Create an instance of the ViewModel, set it as the BindingContext, and define the `SfCartesianChart` in XAML. Add `ColumnSeries` to the chart and bind the `ColumnData` property of the ViewModel to the `ColumnSeries.ItemsSource` as follows.

```
<ContentView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:charts="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
             xmlns:local="clr-namespace:SyncfusionMauiApp.MauiControls"
             x:Class="SyncfusionMauiApp.MauiControls.EmbeddedControl"
             HorizontalOptions="Fill"
             VerticalOptions="Fill">

  <charts:SfCartesianChart>
    <charts:SfCartesianChart.BindingContext>
      <local:ChartDataViewModel />
    </charts:SfCartesianChart.BindingContext>

    <charts:SfCartesianChart.XAxes>
      <charts:CategoryAxis />
    </charts:SfCartesianChart.XAxes>

    <charts:SfCartesianChart.YAxes>
      <charts:NumericalAxis />
    </charts:SfCartesianChart.YAxes>

    <charts:ColumnSeries ItemsSource="{Binding ColumnData}"
                         XBindingPath="Name"
                         YBindingPath="Value"/>
  </charts:SfCartesianChart>
</ContentView>
```
