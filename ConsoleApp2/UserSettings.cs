using System.Configuration;

sealed class UserSettings : ApplicationSettingsBase
{
	[UserScopedSetting()]
    [DefaultSettingValue("")]
    public System.String PortName
    {
        get => (System.String)this[nameof(PortName)];
        set => this[nameof(PortName)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("первый слот")]
    public System.String BoardLocations
    {
        get => (System.String)this[nameof(BoardLocations)];
        set => this[nameof(BoardLocations)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("20 МГц")]
    public System.String ClockLsnValue
    {
        get => (System.String)this[nameof(ClockLsnValue)];
        set => this[nameof(ClockLsnValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("1")]
    public System.Int32 IdBoard
    {
        get => (System.Int32)this[nameof(IdBoard)];
        set => this[nameof(IdBoard)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("0 дБ")]
    public System.String LnaValue
    {
        get => (System.String)this[nameof(LnaValue)];
        set => this[nameof(LnaValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("3")]
    public System.Int32 IfaValue
    {
        get => (System.Int32)this[nameof(IfaValue)];
        set => this[nameof(IfaValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("370 МГц")]
    public System.String FreqRxValue
    {
        get => (System.String)this[nameof(FreqRxValue)];
        set => this[nameof(FreqRxValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("375 МГц")]
    public System.String FreqTxValue
    {
        get => (System.String)this[nameof(FreqTxValue)];
        set => this[nameof(FreqTxValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("9 дБ")]
    public System.String TxAttValue
    {
        get => (System.String)this[nameof(TxAttValue)];
        set => this[nameof(TxAttValue)] = value;
    }
	[UserScopedSetting()]
    [DefaultSettingValue("сброс")]
    public System.String OperatingModes
    {
        get => (System.String)this[nameof(OperatingModes)];
        set => this[nameof(OperatingModes)] = value;
    }
}


