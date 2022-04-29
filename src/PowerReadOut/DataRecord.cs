using System.Text;
using System.Text.Json.Serialization;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace PowerReadOut;

internal struct DataRecord
{
    private readonly Dictionary<DataType, string> _data;

    public DataRecord(Dictionary<DataType, string> data)
    {
        _data = data;

        DeviceName = data.ContainsKey(DataType.DeviceName) ? data[DataType.DeviceName] : string.Empty;
        DeviceId = data.ContainsKey(DataType.PowerDeviceId) ? data[DataType.PowerDeviceId] : string.Empty;
        TimeStamp = data.ContainsKey(DataType.TimeStamp) ? data[DataType.TimeStamp] : string.Empty;
        PowerDeviceId = data.ContainsKey(DataType.PowerDeviceId) ? data[DataType.PowerDeviceId] : string.Empty;
        PowerDeviceSerialNumber = data.ContainsKey(DataType.PowerDeviceSerialNumber) ? data[DataType.PowerDeviceSerialNumber] : string.Empty;
        PowerUsedTariff1 = data.ContainsKey(DataType.PowerUsedTariff1) ? data[DataType.PowerUsedTariff1] : string.Empty;
        PowerUsedTariff2 = data.ContainsKey(DataType.PowerUsedTariff2) ? data[DataType.PowerUsedTariff2] : string.Empty;
        PowerGeneratedTariff1 = data.ContainsKey(DataType.PowerGeneratedTariff1) ? data[DataType.PowerGeneratedTariff1] : string.Empty;
        PowerGeneratedTariff2 = data.ContainsKey(DataType.PowerGeneratedTariff2) ? data[DataType.PowerGeneratedTariff2] : string.Empty;
        CurrentTariff = data.ContainsKey(DataType.CurrentTariff) ? data[DataType.CurrentTariff] : string.Empty;
        TotalPowerGenerated = data.ContainsKey(DataType.TotalPowerGenerated) ? data[DataType.TotalPowerGenerated] : string.Empty;
        TotalPowerUsed = data.ContainsKey(DataType.TotalPowerUsed) ? data[DataType.TotalPowerUsed] : string.Empty;
        PowerFailureCount = data.ContainsKey(DataType.PowerFailureCount) ? data[DataType.PowerFailureCount] : string.Empty;
        LongPowerFailureCount = data.ContainsKey(DataType.LongPowerFailureCount) ? data[DataType.LongPowerFailureCount] : string.Empty;
        PowerFailureLog = data.ContainsKey(DataType.PowerFailureLog) ? data[DataType.PowerFailureLog] : string.Empty;
        L1Voltage = data.ContainsKey(DataType.L1Voltage) ? data[DataType.L1Voltage] : string.Empty;
        L2Voltage = data.ContainsKey(DataType.L2Voltage) ? data[DataType.L2Voltage] : string.Empty;
        L3Voltage = data.ContainsKey(DataType.L3Voltage) ? data[DataType.L3Voltage] : string.Empty;
        L1Amperage = data.ContainsKey(DataType.L1Amperage) ? data[DataType.L1Amperage] : string.Empty;
        L2Amperage = data.ContainsKey(DataType.L2Amperage) ? data[DataType.L2Amperage] : string.Empty;
        L3Amperage = data.ContainsKey(DataType.L3Amperage) ? data[DataType.L3Amperage] : string.Empty;
        L1PowerUsage = data.ContainsKey(DataType.L1PowerUsage) ? data[DataType.L1PowerUsage] : string.Empty;
        L2PowerUsage = data.ContainsKey(DataType.L2PowerUsage) ? data[DataType.L2PowerUsage] : string.Empty;
        L3PowerUsage = data.ContainsKey(DataType.L3PowerUsage) ? data[DataType.L3PowerUsage] : string.Empty;
        L1PowerGenerated = data.ContainsKey(DataType.L1PowerGenerated) ? data[DataType.L1PowerGenerated] : string.Empty;
        L2PowerGenerated = data.ContainsKey(DataType.L2PowerGenerated) ? data[DataType.L2PowerGenerated] : string.Empty;
        L3PowerGenerated = data.ContainsKey(DataType.L3PowerGenerated) ? data[DataType.L3PowerGenerated] : string.Empty;
        DeviceType = data.ContainsKey(DataType.DeviceType) ? data[DataType.DeviceType] : string.Empty;
        GasDeviceId = data.ContainsKey(DataType.GasDeviceId) ? data[DataType.GasDeviceId] : string.Empty;
        GasUsed = data.ContainsKey(DataType.GasUsed) ? data[DataType.GasUsed] : string.Empty;
        ProtocolVersion = data.ContainsKey(DataType.ProtocolVersion) ? data[DataType.ProtocolVersion] : string.Empty;
        PowerBreakerState = data.ContainsKey(DataType.PowerBreakerState) ? data[DataType.PowerBreakerState] : string.Empty;
        MaxPhasePower = data.ContainsKey(DataType.MaxPhasePower) ? data[DataType.MaxPhasePower] : string.Empty;
        L1FuseThreshold = data.ContainsKey(DataType.L1FuseThreshold) ? data[DataType.L1FuseThreshold] : string.Empty;
        TextMessage = data.ContainsKey(DataType.TextMessage) ? data[DataType.TextMessage] : string.Empty;
        DevicesOnBus = data.ContainsKey(DataType.DevicesOnBus) ? data[DataType.DevicesOnBus] : string.Empty;
        GasDeviceSerialNumber = data.ContainsKey(DataType.GasDeviceSerialNumber) ? data[DataType.GasDeviceSerialNumber] : string.Empty;
        GasBreakerState = data.ContainsKey(DataType.GasBreakerState) ? data[DataType.GasBreakerState] : string.Empty;
        GasUsageTimestamp = data.ContainsKey(DataType.GasUsageTimeStamp) ? data[DataType.GasUsageTimeStamp] : string.Empty;
    }

    [JsonPropertyName("device_name")]
    public string DeviceName { get; }

    [JsonPropertyName("device_id")]
    public string DeviceId { get; }
    [JsonPropertyName("power_device_id")]
    public string PowerDeviceId { get; }
    
    [JsonPropertyName("device_type")]
    public string DeviceType { get; }
    [JsonPropertyName("protocol_version")]
    public string ProtocolVersion { get; }
    [JsonPropertyName("power_breaker_state")]
    public string PowerBreakerState { get; }
    [JsonPropertyName("power_device_serial_number")]
    public string PowerDeviceSerialNumber { get; }
    [JsonPropertyName("l1_power_usage")]
    public string L1PowerUsage { get; }
    [JsonPropertyName("l2_power_usage")]
    public string L2PowerUsage { get; }
    [JsonPropertyName("l3_power_usage")]
    public string L3PowerUsage { get; }
    [JsonPropertyName("l1_power_generated")]
    public string L1PowerGenerated { get; }
    [JsonPropertyName("l2_power_generated")]
    public string L2PowerGenerated { get; }
    [JsonPropertyName("l3_power_generated")]
    public string L3PowerGenerated { get; }
    [JsonPropertyName("l1_amperage")]
    public string L1Amperage { get; }
    [JsonPropertyName("l2_amperage")]
    public string L2Amperage { get; }
    [JsonPropertyName("l3_amperage")]
    public string L3Amperage { get; }
    [JsonPropertyName("l1_voltage")]
    public string L1Voltage { get; }
    [JsonPropertyName("l2_voltage")]
    public string L2Voltage { get; }
    [JsonPropertyName("l3_voltage")]
    public string L3Voltage { get; }
    [JsonPropertyName("current_tariff")]
    public string CurrentTariff { get; }
    [JsonPropertyName("power_generated_tariff_1")]
    public string PowerGeneratedTariff1 { get; }
    [JsonPropertyName("power_generated_tariff_2")]
    public string PowerGeneratedTariff2 { get; }
    [JsonPropertyName("power_used_tariff_1")]
    public string PowerUsedTariff1 { get; }
    [JsonPropertyName("power_used_tariff_2")]
    public string PowerUsedTariff2 { get; }
    [JsonPropertyName("total_power_used")]
    public string TotalPowerUsed { get; }
    [JsonPropertyName("total_power_generated")]
    public string TotalPowerGenerated { get; }
    [JsonPropertyName("max_phase_power")]
    public string MaxPhasePower { get; }
    [JsonPropertyName("l1_fuse_threshold")]
    public string L1FuseThreshold { get; }
    [JsonPropertyName("power_failure_count")]
    public string PowerFailureCount { get; }
    [JsonPropertyName("power_failure_log")]
    public string PowerFailureLog { get; }
    [JsonPropertyName("long_power_failure_count")]
    public string LongPowerFailureCount { get; }

    [JsonPropertyName("gas_device_id")]
    public string GasDeviceId { get; }
    [JsonPropertyName("gas_device_serial_number")]
    public string GasDeviceSerialNumber { get; }
    [JsonPropertyName("gas_breaker_state")]
    public string GasBreakerState { get; }
    [JsonPropertyName("gas_used")]
    public string GasUsed { get; }
    [JsonPropertyName("gas_usage_timestamp")]
    public string GasUsageTimestamp { get; }
    
    [JsonPropertyName("devices_on_bus")]
    public string DevicesOnBus { get; }
    [JsonPropertyName("timestamp")]
    public string TimeStamp { get; }
    [JsonPropertyName("text_message")]
    public string TextMessage { get; }


    public static DataRecord FromBytes(byte[] telegram)
    {
        var data = new Dictionary<DataType, string>();
        data.Add(DataType.DeviceName, Encoding.UTF8.GetString(telegram[1..4]));

        var index = 6;
        foreach (var b in telegram[index..])
        {
            if (char.IsControl((char) b))
            {
                data.Add(DataType.PowerDeviceId, Encoding.UTF8.GetString(telegram[6..index]));
                break;
            }

            index++;
        }

        index += 4;
        var start = index;
        foreach (var b in telegram[index..])
        {
            if (b == '!')
            {
                break;
            }

            index++;
        }

        var dataString = Encoding.UTF8.GetString(telegram[start..index]);

        foreach (var line in dataString.Split(Environment.NewLine))
        {
            var record = line.Trim();

            if (string.IsNullOrEmpty(record))
            {
                continue;
            }

            var data_start = record.IndexOf('(');
            var id = GetDataType(record[..data_start]);
            var value = record[(data_start + 1)..^1];

            if (id == DataType.GasUsageRecord)
            {
                data.Add(DataType.GasUsageTimeStamp, value[..value.IndexOf(')')]);
                data.Add(DataType.GasUsed, value[(value.IndexOf('(')+1)..]);
                continue;
            }

            data.Add(id, value);
        }

        return new DataRecord(data);
    }

    private static DataType GetDataType(string dataType)
    {
        switch (dataType)
        {
            case "0-0:1.0.0":
                return DataType.TimeStamp;
            case "0-0:96.1.1":
                return DataType.PowerDeviceSerialNumber;
            case "0-n:24.1.0":
                return DataType.DeviceType;
            case "0-n:96.1.0":
                return DataType.GasDeviceId;
            case "1-0:1.8.1":
                return DataType.PowerUsedTariff1;
            case "1-0:1.8.2":
                return DataType.PowerUsedTariff2;
            case "1-0:2.8.1":
                return DataType.PowerGeneratedTariff1;
            case "1-0:2.8.2":
                return DataType.PowerGeneratedTariff2;
            case "0-0:96.14.0":
                return DataType.CurrentTariff;
            case "1-0:1.7.0":
                return DataType.TotalPowerUsed;
            case "1-0:2.7.0":
                return DataType.TotalPowerGenerated;
            case "0-0:96.7.21":
                return DataType.PowerFailureCount;
            case "0-0:96.7.9":
                return DataType.LongPowerFailureCount;
            case "1-0:99.97.0":
                return DataType.PowerFailureLog;


            case "1-0:32.7.0":
                return DataType.L1Voltage;
            case "1-0:52.7.0":
                return DataType.L2Voltage;
            case "1-0:72.7.0 ":
                return DataType.L3Voltage;
            case "1-0:31.7.0":
                return DataType.L1Amperage;
            case "1-0:51.7.0":
                return DataType.L2Amperage;
            case "1-0:71.7.0":
                return DataType.L3Amperage;

            case "1-0:21.7.0":
                return DataType.L1PowerUsage;
            case "1-0:41.7.0":
                return DataType.L2PowerUsage;
            case "1-0:61.7.0 ":
                return DataType.L3PowerUsage;
            case "1-0:22.7.0":
                return DataType.L1PowerGenerated;
            case "1-0:42.7.0":
                return DataType.L2PowerGenerated;
            case "1-0:62.7.0":
                return DataType.L3PowerGenerated;

            case "0-n:24.2.1":
                return DataType.GasUsed;

            case "0-0:96.1.4":
                return DataType.ProtocolVersion;
            case "0-0:96.3.10":
                return DataType.PowerBreakerState;
            case "0-0:17.0.0":
                return DataType.MaxPhasePower;
            case "1-0:31.4.0":
                return DataType.L1FuseThreshold;
            case "0-0:96.13.0":
                return DataType.TextMessage;
            case "0-1:24.1.0":
                return DataType.DevicesOnBus;
            case "0-1:96.1.1":
                return DataType.GasDeviceSerialNumber;
            case "0-1:24.4.0":
                return DataType.GasBreakerState;
            case "0-1:24.2.3":
                return DataType.GasUsageRecord;
            default:
                throw new Exception($"{dataType} is an unknown data type");
        }
    }
}