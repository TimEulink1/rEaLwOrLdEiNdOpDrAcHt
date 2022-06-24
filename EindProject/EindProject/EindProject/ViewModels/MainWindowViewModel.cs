using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using EindProject.Models;
using EindProject.Services;
using System.Threading.Tasks;


namespace EindProject.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ApiService apiService = new ApiService();
        private readonly ConfigService configService = new ConfigService();
        private readonly SuncalculatorService suncalculatorService = new SuncalculatorService();

        private int count;
        public int Count 
        {
            get => count;
            set
            {
                this.RaiseAndSetIfChanged(ref count, value);
            }
        }
        private string apiKey;
        public string ApiKey
        {
            get => apiKey;
            set
            {
                this.RaiseAndSetIfChanged(ref apiKey, value);
                configService.SetApiKey(value);
            }
        }
        private string siteId;
        public string SiteId
        {
            get => siteId;
            set { 
                this.RaiseAndSetIfChanged(ref siteId, value);
                configService.SetSiteID(value);
            }
        }
        private string postcode;
        public string Postcode
        {
            get => postcode;
            set
            {
                this.RaiseAndSetIfChanged(ref postcode, value);
                configService.SetPostalCode(value);
            }
        }
        private string prognosisPerPenal;
        public string PrognosisPerPenal
        {
            get => prognosisPerPenal;
            set
            {
                this.RaiseAndSetIfChanged(ref prognosisPerPenal, value);
            }
        }

        private string prognosTotal;
        public string PrognosTotal
        {
            get => prognosTotal;
            set
            {
                this.RaiseAndSetIfChanged(ref prognosTotal, value);
            }
        }

        private EnvBenfitsResult envBenfitsResult;

        public EnvBenfitsResult EnvBenfitsResult
        {
            get => envBenfitsResult;
            set => this.RaiseAndSetIfChanged(ref envBenfitsResult, value);
        }
        private InverterResult inverterResult;

        public InverterResult InverterResult
        {
            get => inverterResult;
            set => this.RaiseAndSetIfChanged(ref inverterResult, value);
        }
        public ICommand AddOneCommand { get; private set; }
        public MainWindowViewModel()
        {
            AddOneCommand = ReactiveCommand.Create(() => { Count++; });
            ApiKey = configService.GetApiKey();
            SiteId = configService.GetSiteID();
            Postcode = configService.GetPostalCode();
        }

        public async Task DoSomething()
        {
            var envBenfitsResultTask = apiService.GetEnvBenifitsAsync(SiteId, ApiKey);
            var inverterDataResultTask = apiService.GetInverterDataAsync(SiteId, ApiKey);
            var WheaterDataResultTask = apiService.GetWheaterDataAsync(postcode);

            var envBenfitsDataResult = await envBenfitsResultTask;
            var inverterDataResult = await inverterDataResultTask;


            envBenfitsDataResult.EnvBenefits.lightBulbs = Math.Round(envBenfitsDataResult.EnvBenefits.lightBulbs, 0);
            envBenfitsDataResult.EnvBenefits.treesPlanted = Math.Round(envBenfitsDataResult.EnvBenefits.treesPlanted, 0);
            EnvBenfitsResult = envBenfitsDataResult;

            inverterDataResult.overview.lifeTimeData.energy = Math.Round(inverterDataResult.overview.lifeTimeData.energy, 0);
            inverterDataResult.overview.lastYearData.energy = Math.Round(inverterDataResult.overview.lastYearData.energy, 0);
            inverterDataResult.overview.lastMonthData.energy = Math.Round(inverterDataResult.overview.lastMonthData.energy, 0);
            inverterDataResult.overview.lastDayData.energy = Math.Round(inverterDataResult.overview.lastDayData.energy, 0);
            inverterDataResult.overview.currentPower.power = Math.Round(inverterDataResult.overview.currentPower.power, 0);
            InverterResult = inverterDataResult;

            var WheaterDataResult = await WheaterDataResultTask;
            var whattsM2 =  suncalculatorService.calculateSunWattM2(WheaterDataResult);
            var precentage = configService.GetEfficiëntiePercentageConfig();
            PrognosisPerPenal = suncalculatorService.calculateWattsPerPanal(whattsM2, precentage).ToString();
            PrognosTotal = suncalculatorService.calculateWattsTotal(whattsM2, precentage, 18).ToString();

        }
    }
}
