//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using SimpleJSON;



namespace cfg.role
{ 

public sealed partial class BonusInfo :  Bright.Config.BeanBase 
{
    public BonusInfo(JSONNode _json) 
    {
        { if(!_json["type"].IsNumber) { throw new SerializationException(); }  Type = (item.ECurrencyType)_json["type"].AsInt; }
        { if(!_json["coefficient"].IsNumber) { throw new SerializationException(); }  Coefficient = _json["coefficient"]; }
        PostInit();
    }

    public BonusInfo(item.ECurrencyType type, float coefficient ) 
    {
        this.Type = type;
        this.Coefficient = coefficient;
        PostInit();
    }

    public static BonusInfo DeserializeBonusInfo(JSONNode _json)
    {
        return new role.BonusInfo(_json);
    }

    public item.ECurrencyType Type { get; private set; }
    public float Coefficient { get; private set; }

    public const int __ID__ = -1354421803;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Type:" + Type + ","
        + "Coefficient:" + Coefficient + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
