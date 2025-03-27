using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using TulingScadaSystem.Helpers;
using TulingScadaSystem.Models;
using TulingScadaSystem.Services;
using TulingScadaSystem.Views;
//using XyLicense.Library;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace TulingScadaSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/mvvm/ioc

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; private set; }

        public App()
        {
            Services = ConfigureService();
            this.InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //var result = LicenceHelper.ValidLicense();

            //if (!result)
            //{
            //    var mac = ComputerHelper.GetComputerDetail();
            //    MessageBox.Show($"License 授权失败，请联系管理员！{mac}");

            //    return;
            //}

            // 切换主题，变为 AliceBlue
            ThemeManager.Current.ChangeTheme(this, ThemeManager.Current.AddTheme(
                RuntimeThemeGenerator.Current.GenerateRuntimeTheme("Light", Colors.AliceBlue)
                ));

            // 启动我们的 ShellView 这样的窗体
            Services.GetService<ShellView>()?.Show();
        }

        // 做所有依赖注入的事情
        private IServiceProvider? ConfigureService()
        {
            var services = new ServiceCollection();

            // 配置类实现
            ConfigureJsonByBinder(services);

            // 配置 GlobalConfig
            services.AddSingleton<GlobalConfig>();

            // 注入我们需要的服务
            services.AddSingleton<UserSession>();

            // 注册所有的 View 和 ViewModel
            RegisterViewsAndViewModels(services);

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// 将 Json 文件里面的内容映射到 RootParam 类上
        /// </summary>
        private void ConfigureJsonByBinder(ServiceCollection services)
        {
            var cfgBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory + "\\Configs")
                .AddJsonFile("appsettings.json", false, true);
            var configuration = cfgBuilder.Build();
            // 实现单例注入和日志
            services.AddSingleton<IConfiguration>(configuration)
                .AddLogging(log => { 
                    log.ClearProviders();
                    log.SetMinimumLevel(LogLevel.Trace);
                    log.AddNLog();
                });
            // 1. 获取日志参数 ILogger<T>
            var nLogConfig = configuration.GetSection("NLog");
            LogManager.Configuration = new NLogLoggingConfiguration(nLogConfig);

            // 2. 改造 SqlSugarHelper
            var parseResult = Enum.TryParse<SqlSugar.DbType>(configuration["SqlParam:DbType"], out var dbType);
            var connectionString = configuration["SqlParam:ConnectionString"];

            if (parseResult)
            {
                SqlSugarHelper.AddSqlSugarSetup(dbType, connectionString);
            }

            // 3. 参数配置及映射 IOptionsSnapshot<RootParam>.Value
            services.AddOptions()
                .Configure<RootParam>(e => configuration.Bind(e))
                .Configure<SqlParam>(e => configuration.GetSection("SqlParam").Bind(e))
                .Configure<SystemParam>(e => configuration.GetSection("SystemParam").Bind(e))
                .Configure<PlcParam>(e => configuration.GetSection("PlcParam").Bind(e));
        }

        private void RegisterViewsAndViewModels(ServiceCollection services)
        {
            var assembly = typeof(App).Assembly;
            var viewTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("View") && !t.IsAbstract)
                .ToList();

            foreach (var viewType in viewTypes)
            {
                // 注册 View
                services.AddSingleton(viewType);

                // 查找并注册对应的 ViewModel
                var viewModelName = $"{viewType.Namespace.Replace(".Views", ".ViewModels")}.{viewType.Name}Model";
                var viewModelType = assembly.GetTypes()
                    .FirstOrDefault(t => t.FullName == viewModelName);

                if (viewModelType != null)
                {
                    services.AddSingleton(viewModelType);
                }
            }
        }
    }

}
