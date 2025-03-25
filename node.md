## 引入一些 Nuget 包
```
● CommunityToolkit.MVVM
● Microsoft.Extensions.DependencyInjection
● MaterialDesignThemes
● MaterialDesignThemes.MahApps
● Masuit.Tools.Core https://www.masuit.tools/api.html
● Microsoft.Extensions.Configuration
● Microsoft.Extensions.Configuration.Json
● Microsoft.Extensions.Configuration.Binder 
● Microsoft.Extensions.Options 
● SqlSugarCore
● NLog.Extensions.Logging
```
## View 必有
```xml
xmlns:vm="clr-namespace:TulingScadaSystem.ViewModels"
xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
d:DataContext="{d:DesignInstance vm:MainViewModel}"
d:DesignHeight="800"
d:DesignWidth="1200"
Background="{DynamicResource MaterialDesign.Brush.Background}"
FontFamily="Microsoft YaHei"
FontSize="16"
TextElement.FontSize="16"
TextElement.FontWeight="Regular"
TextElement.Foreground="{DynamicResource MaterialDesignBody}"
```
## 图标和文字一起
```xml
<StackPanel Margin="10"
                        HorizontalAlignment="Center"
                        Orientation="Horizontal">
                <materialDesign:PackIcon Width="50"
                                         Height="50"
                                         Margin="5"
                                         VerticalAlignment="Center"
                                         Foreground="#1b2755"
                                         Kind="ChartScatterPlotHexbin" />
                <TextBlock HorizontalAlignment="Center"
                           VerticalAlignment="Center"
                           FontSize="40"
                           Foreground="#1b2755"
                           Style="{StaticResource MaterialDesignTitleSmallTextBlock}"/>
</StackPanel>
```
## ListView 绑定
```xml
   <i:Interaction.Triggers>
                 <i:EventTrigger EventName="PreviewMouseUp">
                         <i:InvokeCommandAction Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=UserControl}, Path=DataContext.NavigationCommand}" CommandParameter="{Binding}" />
               </i:EventTrigger>
   </i:Interaction.Triggers>
```
## 日志及参数配置
```C#
  //测试日志功能和参数获取
    private readonly ILogger<MainViewModel> _logger;
    private RootParam RootParamProp;
```
## Bool 转 string
```xml
 <UserControl.Resources>
        <conv:BoolToStringConverter x:Key="Bool2Bg"
                                    FalseValue="White"
                                    TrueValue="#E3F2FD" />
    </UserControl.Resources>
```