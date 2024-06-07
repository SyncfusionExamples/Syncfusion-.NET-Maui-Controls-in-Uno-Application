using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncfusionMauiApp.MauiControls;

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
