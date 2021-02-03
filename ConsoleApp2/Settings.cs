using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

namespace ConsoleApp2
{
    public class Settings : IDescription, ISettings
    {
        [Description("Порт Платы")] public string PortName { get; set; } = "";
        [Description("Положение платы")] public string BoardLocations { get; set; } = "первый слот";
        [Description("Тактовая частота")] public string ClockLsnValue { get; set; } = "20 МГц";
        [Description("Значение ID")] public int IdBoard { get; set; } = 1;
        [Description("Значение МШУ")] public string LnaValue { get; set; } = "0 дБ";
        [Description("Значение УПЧ")] public int IfaValue { get; set; } = 3;
        [Description("Значение частоты приемника")] public string FreqRxValue { get; set; } = "370 МГц";
        [Description("Значение частоты передатчика")] public string FreqTxValue { get; set; } = "375 МГц";
        [Description("Значение ослабления передатчика")] public string TxAttValue { get; set; } = "9 дБ";
        [Description("Режим работы")] public string OperatingModes { get; set; } = "сброс";
    }
}
