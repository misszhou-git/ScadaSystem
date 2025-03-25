using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulingScadaSystem.Models
{
    public class FormulaEntity : EntityBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string? _description;

        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private bool? _isSelected;

        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }


        private float? _degreasingSetPressureUpperLimit;

        /// <summary>
        /// 脱脂压力上限
        /// </summary>
        public float? DegreasingSetPressureUpperLimit
        {
            get => _degreasingSetPressureUpperLimit;
            set => SetProperty(ref _degreasingSetPressureUpperLimit, value);
        }

        private float? _degreasingSetPressureLowerLimit;

        /// <summary>
        /// 脱脂压力下限
        /// </summary>
        public float? DegreasingSetPressureLowerLimit
        {
            get => _degreasingSetPressureLowerLimit;
            set => SetProperty(ref _degreasingSetPressureLowerLimit, value);
        }

        private float? _roughWashingSprayPumpOverloadUpperLimit;

        /// <summary>
        /// 粗洗泵过载
        /// </summary>
        public float? RoughWashingSprayPumpOverloadUpperLimit
        {
            get => _roughWashingSprayPumpOverloadUpperLimit;
            set => SetProperty(ref _roughWashingSprayPumpOverloadUpperLimit, value);
        }

        private float? _roughWashingLevelLowerLimit;

        /// <summary>
        ///  粗洗液位下限
        /// </summary>
        public float? RoughWashingLevelLowerLimit
        {
            get => _roughWashingLevelLowerLimit;
            set => SetProperty(ref _roughWashingLevelLowerLimit, value);
        }

        private float? _ceramicCoatingSprayPumpOverloadUpperLimit;

        /// <summary>
        ///  陶化泵过载
        /// </summary>
        public float? CeramicCoatingSprayPumpOverloadUpperLimit
        {
            get => _ceramicCoatingSprayPumpOverloadUpperLimit;
            set => SetProperty(ref _ceramicCoatingSprayPumpOverloadUpperLimit, value);
        }

        private float? _fineWashingSprayPumpOverloadUpperLimit;

        /// <summary>
        ///  精洗泵过载
        /// </summary>
        public float? FineWashingSprayPumpOverloadUpperLimit
        {
            get => _fineWashingSprayPumpOverloadUpperLimit;
            set => SetProperty(ref _fineWashingSprayPumpOverloadUpperLimit, value);
        }
        private float? _fineWashingLevelLowerLimit;

        /// <summary>
        ///  精洗液位下限
        /// </summary>
        public float? FineWashingLevelLowerLimit
        {
            get => _fineWashingLevelLowerLimit;
            set => SetProperty(ref _fineWashingLevelLowerLimit, value);
        }
        private float? _moistureFurnaceTemperatureUpperLimit;

        /// <summary>
        ///  水分炉温度上限
        /// </summary>
        public float? MoistureFurnaceTemperatureUpperLimit
        {
            get => _moistureFurnaceTemperatureUpperLimit;
            set => SetProperty(ref _moistureFurnaceTemperatureUpperLimit, value);
        }

        private float? _moistureFurnaceTemperatureLowerLimit;

        /// <summary>
        ///  水分炉温度下限
        /// </summary>
        public float? MoistureFurnaceTemperatureLowerLimit
        {
            get => _moistureFurnaceTemperatureLowerLimit;
            set => SetProperty(ref _moistureFurnaceTemperatureLowerLimit, value);
        }

        private float? _coolingRoomCentrifugalFanOverloadUpperLimit;

        /// <summary>
        ///  冷却室风机过载
        /// </summary>
        public float? CoolingRoomCentrifugalFanOverloadUpperLimit
        {
            get => _coolingRoomCentrifugalFanOverloadUpperLimit;
            set => SetProperty(ref _coolingRoomCentrifugalFanOverloadUpperLimit, value);
        }

        private float? _curingOvenTemperatureUpperLimit;

        /// <summary>
        ///  固化炉温度上限
        /// </summary>
        public float? CuringOvenTemperatureUpperLimit
        {
            get => _curingOvenTemperatureUpperLimit;
            set => SetProperty(ref _curingOvenTemperatureUpperLimit, value);
        }

        private float? _curingOvenTemperatureLowerLimit;

        /// <summary>
        ///  固化炉温度下限
        /// </summary>
        public float? CuringOvenTemperatureLowerLimit
        {
            get => _curingOvenTemperatureLowerLimit;
            set => SetProperty(ref _curingOvenTemperatureLowerLimit, value);
        }

        private float? _conveyorSetSpeed;

        /// <summary>
        ///  输送机速度
        /// </summary>
        public float? ConveyorSetSpeed
        {
            get => _conveyorSetSpeed;
            set => SetProperty(ref _conveyorSetSpeed, value);
        }

        private float? _conveyorSetFrequency;

        /// <summary>
        ///  输送机频率
        /// </summary>
        public float? ConveyorSetFrequency
        {
            get => _conveyorSetFrequency;
            set => SetProperty(ref _conveyorSetFrequency, value);
        }
    }
}