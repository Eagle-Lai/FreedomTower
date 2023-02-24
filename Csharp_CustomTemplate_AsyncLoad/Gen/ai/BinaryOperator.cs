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



namespace cfg.ai
{ 

public sealed partial class BinaryOperator :  ai.KeyQueryOperator 
{
    public BinaryOperator(JSONNode _json)  : base(_json) 
    {
        { if(!_json["oper"].IsNumber) { throw new SerializationException(); }  Oper = (ai.EOperator)_json["oper"].AsInt; }
        { if(!_json["data"].IsObject) { throw new SerializationException(); }  Data = ai.KeyData.DeserializeKeyData(_json["data"]);  }
        PostInit();
    }

    public BinaryOperator(ai.EOperator oper, ai.KeyData data )  : base() 
    {
        this.Oper = oper;
        this.Data = data;
        PostInit();
    }

    public static BinaryOperator DeserializeBinaryOperator(JSONNode _json)
    {
        return new ai.BinaryOperator(_json);
    }

    public ai.EOperator Oper { get; private set; }
    public ai.KeyData Data { get; private set; }

    public const int __ID__ = -979891605;
    public override int GetTypeId() => __ID__;

    public override void Resolve(Dictionary<string, object> _tables)
    {
        base.Resolve(_tables);
        Data?.Resolve(_tables);
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        base.TranslateText(translator);
        Data?.TranslateText(translator);
    }

    public override string ToString()
    {
        return "{ "
        + "Oper:" + Oper + ","
        + "Data:" + Data + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
