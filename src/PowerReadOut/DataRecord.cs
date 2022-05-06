using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.VisualBasic.CompilerServices;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace PowerReadOut;

internal struct DataRecord
{
    private readonly Dictionary<DataType, RecordValue> _data;

    public DataRecord(Dictionary<DataType, RecordValue> data)
    {
        _data = data;
    }

    [JsonPropertyName("device_name")]
    public RecordValue? DeviceName  => _data.ContainsKey(DataType.DeviceName) ? _data[DataType.DeviceName] : null; 

    [JsonPropertyName("device_id")]
    public RecordValue? DeviceId => _data.ContainsKey(DataType.PowerDeviceId) ? _data[DataType.PowerDeviceId] :null;
    
    [JsonPropertyName("device_type")]
    public RecordValue?DeviceType  => _data.ContainsKey(DataType.DeviceType) ? _data[DataType.DeviceType] : null; 

    [JsonPropertyName("protocol_version")]
    public RecordValue?ProtocolVersion  => _data.ContainsKey(DataType.ProtocolVersion) ? _data[DataType.ProtocolVersion] : null; 

    [JsonPropertyName("power_breaker_state")]
    public RecordValue?PowerBreakerState  => _data.ContainsKey(DataType.PowerBreakerState) ? _data[DataType.PowerBreakerState] : null; 

    [JsonPropertyName("power_device_serial_number")]
    public RecordValue?PowerDeviceSerialNumber  => _data.ContainsKey(DataType.PowerDeviceSerialNumber) ? _data[DataType.PowerDeviceSerialNumber] : null; 

    [JsonPropertyName("l1_power_usage")]
    public RecordValue?L1PowerUsage  => _data.ContainsKey(DataType.L1PowerUsage) ? _data[DataType.L1PowerUsage] : null; 

    [JsonPropertyName("l2_power_usage")]
    public RecordValue?L2PowerUsage  => _data.ContainsKey(DataType.L2PowerUsage) ? _data[DataType.L2PowerUsage] : null; 

    [JsonPropertyName("l3_power_usage")]
    public RecordValue?L3PowerUsage  => _data.ContainsKey(DataType.L3PowerUsage) ? _data[DataType.L3PowerUsage] : null; 

    [JsonPropertyName("l1_power_generated")]
    public RecordValue?L1PowerGenerated  => _data.ContainsKey(DataType.L1PowerGenerated) ? _data[DataType.L1PowerGenerated] : null; 

    [JsonPropertyName("l2_power_generated")]
    public RecordValue?L2PowerGenerated  => _data.ContainsKey(DataType.L2PowerGenerated) ? _data[DataType.L2PowerGenerated] : null; 

    [JsonPropertyName("l3_power_generated")]
    public RecordValue?L3PowerGenerated  => _data.ContainsKey(DataType.L3PowerGenerated) ? _data[DataType.L3PowerGenerated] : null; 

    [JsonPropertyName("l1_amperage")]
    public RecordValue?L1Amperage  => _data.ContainsKey(DataType.L1Amperage) ? _data[DataType.L1Amperage] : null; 

    [JsonPropertyName("l2_amperage")]
    public RecordValue?L2Amperage  => _data.ContainsKey(DataType.L2Amperage) ? _data[DataType.L2Amperage] : null; 

    [JsonPropertyName("l3_amperage")]
    public RecordValue?L3Amperage  => _data.ContainsKey(DataType.L3Amperage) ? _data[DataType.L3Amperage] : null; 

    [JsonPropertyName("l1_voltage")]
    public RecordValue?L1Voltage  => _data.ContainsKey(DataType.L1Voltage) ? _data[DataType.L1Voltage] : null; 

    [JsonPropertyName("l2_voltage")]
    public RecordValue?L2Voltage  => _data.ContainsKey(DataType.L2Voltage) ? _data[DataType.L2Voltage] : null; 

    [JsonPropertyName("l3_voltage")]
    public RecordValue?L3Voltage  => _data.ContainsKey(DataType.L3Voltage) ? _data[DataType.L3Voltage] : null; 

    [JsonPropertyName("current_tariff")]
    public RecordValue?CurrentTariff  => _data.ContainsKey(DataType.CurrentTariff) ? _data[DataType.CurrentTariff] : null; 

    [JsonPropertyName("power_generated_tariff_1")]
    public RecordValue?PowerGeneratedTariff1  => _data.ContainsKey(DataType.PowerGeneratedTariff1) ? _data[DataType.PowerGeneratedTariff1] : null; 

    [JsonPropertyName("power_generated_tariff_2")]
    public RecordValue?PowerGeneratedTariff2  => _data.ContainsKey(DataType.PowerGeneratedTariff2) ? _data[DataType.PowerGeneratedTariff2] : null; 

    [JsonPropertyName("power_used_tariff_1")]
    public RecordValue?PowerUsedTariff1  => _data.ContainsKey(DataType.PowerUsedTariff1) ? _data[DataType.PowerUsedTariff1] : null; 

    [JsonPropertyName("power_used_tariff_2")]
    public RecordValue?PowerUsedTariff2  => _data.ContainsKey(DataType.PowerUsedTariff2) ? _data[DataType.PowerUsedTariff2] : null; 

    [JsonPropertyName("total_power_used")]
    public RecordValue?TotalPowerUsed  => _data.ContainsKey(DataType.TotalPowerUsed) ? _data[DataType.TotalPowerUsed] : null; 

    [JsonPropertyName("total_power_generated")]
    public RecordValue?TotalPowerGenerated  => _data.ContainsKey(DataType.TotalPowerGenerated) ? _data[DataType.TotalPowerGenerated] : null; 

    [JsonPropertyName("max_phase_power")]
    public RecordValue?MaxPhasePower  => _data.ContainsKey(DataType.MaxPhasePower) ? _data[DataType.MaxPhasePower] : null; 

    [JsonPropertyName("l1_fuse_threshold")]
    public RecordValue?L1FuseThreshold  => _data.ContainsKey(DataType.L1FuseThreshold) ? _data[DataType.L1FuseThreshold] : null; 

    [JsonPropertyName("power_failure_count")]
    public RecordValue?PowerFailureCount  => _data.ContainsKey(DataType.PowerFailureCount) ? _data[DataType.PowerFailureCount] : null; 

    [JsonPropertyName("power_failure_log")]
    public RecordValue?PowerFailureLog  => _data.ContainsKey(DataType.PowerFailureLog) ? _data[DataType.PowerFailureLog] : null; 

    [JsonPropertyName("long_power_failure_count")]
    public RecordValue?LongPowerFailureCount  => _data.ContainsKey(DataType.LongPowerFailureCount) ? _data[DataType.LongPowerFailureCount] : null; 

    [JsonPropertyName("gas_device_id")]
    public RecordValue?GasDeviceId  => _data.ContainsKey(DataType.GasDeviceId) ? _data[DataType.GasDeviceId] : null; 

    [JsonPropertyName("gas_device_serial_number")]
    public RecordValue?GasDeviceSerialNumber  => _data.ContainsKey(DataType.GasDeviceSerialNumber) ? _data[DataType.GasDeviceSerialNumber] : null; 

    [JsonPropertyName("gas_breaker_state")]
    public RecordValue?GasBreakerState  => _data.ContainsKey(DataType.GasBreakerState) ? _data[DataType.GasBreakerState] : null; 

    [JsonPropertyName("gas_used")]
    public RecordValue?GasUsed  => _data.ContainsKey(DataType.GasUsed) ? _data[DataType.GasUsed] : null; 

    [JsonPropertyName("gas_usage_timestamp")]
    public RecordValue?GasUsageTimestamp  => _data.ContainsKey(DataType.GasUsageTimeStamp) ? _data[DataType.GasUsageTimeStamp] : null; 

    [JsonPropertyName("devices_on_bus")]
    public RecordValue?DevicesOnBus  => _data.ContainsKey(DataType.DevicesOnBus) ? _data[DataType.DevicesOnBus] : null; 

    [JsonPropertyName("timestamp")]
    public RecordValue?TimeStamp  => _data.ContainsKey(DataType.TimeStamp) ? _data[DataType.TimeStamp] : null; 

    [JsonPropertyName("text_message")]
    public RecordValue?TextMessage  => _data.ContainsKey(DataType.TextMessage) ? _data[DataType.TextMessage] : null; 


    public static DataRecord FromBytes(byte[] telegram)
    {
        var data = new Dictionary<DataType, RecordValue>();
        
        data.Add(DataType.DeviceName, new RecordValue(RecordUnit.String,  Encoding.UTF8.GetString(telegram[1..4])));

        var index = 6;
        foreach (var b in telegram[index..])
        {
            if (char.IsControl((char) b))
            {
                data.Add(DataType.PowerDeviceId, new RecordValue(RecordUnit.String, Encoding.UTF8.GetString(telegram[6..index])));
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
            AddRecordValue(record[..data_start], record[(data_start + 1)..^1], ref data);
        }

        return new DataRecord(data);
    }

    private static void AddRecordValue(string obisCode, string value, ref Dictionary<DataType, RecordValue> data)
    {
        switch (obisCode)
        {
            case "0-0:1.0.0":
                data.Add(DataType.TimeStamp, new RecordValue(RecordUnit.Timestamp, value));
                return;
            case "0-0:96.1.1":
                data.Add(DataType.PowerDeviceSerialNumber, new RecordValue(RecordUnit.String, value));
                return;
            case "0-n:24.1.0":
                data.Add(DataType.DeviceType, new RecordValue(RecordUnit.String, value));
                return;
            case "0-n:96.1.0":
                data.Add(DataType.GasDeviceId, new RecordValue(RecordUnit.String, value));
                return;
            case "1-0:1.8.1":
                data.Add(DataType.PowerUsedTariff1, new RecordValue(RecordUnit.Kilowatt, value[..value.IndexOf('*')]));
                return;
            case "1-0:1.8.2":
                data.Add(DataType.PowerUsedTariff2, new RecordValue(RecordUnit.Kilowatt, value[..value.IndexOf('*')]));
                return;
            case "1-0:2.8.1":
                data.Add(DataType.PowerGeneratedTariff1, new RecordValue(RecordUnit.Kilowatt, value[..value.IndexOf('*')]));
                return;
            case "1-0:2.8.2":
                data.Add(DataType.PowerGeneratedTariff2, new RecordValue(RecordUnit.Kilowatt, value[..value.IndexOf('*')]));
                return;
            case "0-0:96.14.0":
                data.Add(DataType.CurrentTariff, new RecordValue(RecordUnit.Integer, value));
                return;
            case "1-0:1.7.0":
                data.Add(DataType.TotalPowerUsed, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:2.7.0":
                data.Add(DataType.TotalPowerGenerated,
                    new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "0-0:96.7.21":
                data.Add(DataType.PowerFailureCount, new RecordValue(RecordUnit.Integer, value));
                return;
            case "0-0:96.7.9":
                data.Add(DataType.LongPowerFailureCount, new RecordValue(RecordUnit.Integer, value));
                return;
            case "1-0:99.97.0":
                data.Add(DataType.PowerFailureLog, new RecordValue(RecordUnit.String, value));
                return;

            case "1-0:32.7.0":
                data.Add(DataType.L1Voltage, new RecordValue(RecordUnit.Volt, value[..value.IndexOf('*')]));
                return;
            case "1-0:52.7.0":
                data.Add(DataType.L2Voltage, new RecordValue(RecordUnit.Volt, value[..value.IndexOf('*')]));
                return;
            case "1-0:72.7.0 ":
                data.Add(DataType.L3Voltage, new RecordValue(RecordUnit.Volt, value[..value.IndexOf('*')]));
                return;
            case "1-0:31.7.0":
                data.Add(DataType.L1Amperage, new RecordValue(RecordUnit.Ampere, value[..value.IndexOf('*')]));
                return;
            case "1-0:51.7.0":
                data.Add(DataType.L2Amperage, new RecordValue(RecordUnit.Ampere, value[..value.IndexOf('*')]));
                return;
            case "1-0:71.7.0":
                data.Add(DataType.L3Amperage, new RecordValue(RecordUnit.Ampere, value[..value.IndexOf('*')]));
                return;

            case "1-0:21.7.0":
                data.Add(DataType.L1PowerUsage, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:41.7.0":
                data.Add(DataType.L2PowerUsage, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:61.7.0 ":
                data.Add(DataType.L3PowerUsage, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:22.7.0":
                data.Add(DataType.L1PowerGenerated, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:42.7.0":
                data.Add(DataType.L2PowerGenerated, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;
            case "1-0:62.7.0":
                data.Add(DataType.L3PowerGenerated, new RecordValue(RecordUnit.Watt, (decimal.Parse(value[..value.IndexOf('*')]) * 1000).ToString()));
                return;

            case "0-n:24.2.1":
                throw new NotImplementedException();

            case "0-0:96.1.4":
            case "0:96.1.4":
                data.Add(DataType.ProtocolVersion, new RecordValue(RecordUnit.String, value));
                return;
            case "0-0:96.3.10":
                data.Add(DataType.PowerBreakerState, new RecordValue(RecordUnit.Boolean, value));
                return;
            case "0-0:17.0.0":
                data.Add(DataType.MaxPhasePower, new RecordValue(RecordUnit.Kilowatt, value[..value.IndexOf('*')]));
                return;
            case "1-0:31.4.0":
                data.Add(DataType.L1FuseThreshold, new RecordValue(RecordUnit.Ampere, value[..value.IndexOf('*')]));
                return;
            case "0-0:96.13.0":
                data.Add(DataType.TextMessage, new RecordValue(RecordUnit.String, value));
                return;
            case "0-1:24.1.0":
                data.Add(DataType.DevicesOnBus, new RecordValue(RecordUnit.Integer, value));
                return;
            case "0-1:96.1.1":
                data.Add(DataType.GasDeviceSerialNumber, new RecordValue(RecordUnit.String, value));
                return;
            case "0-1:24.4.0":
                data.Add(DataType.GasBreakerState, new RecordValue(RecordUnit.Boolean, value));
                return;
            case "0-1:24.2.3":
                data.Add(DataType.GasUsageTimeStamp, new RecordValue(RecordUnit.Timestamp, value[..value.IndexOf(')')]));
                var gasUsed = value[(value.IndexOf('(') + 1)..];
                data.Add(DataType.GasUsed, new RecordValue(RecordUnit.CubicMeter, gasUsed[..gasUsed.IndexOf('*')]));
                return;
            default:
                throw new Exception($"{obisCode} is an unknown data type");
        }
    }
}