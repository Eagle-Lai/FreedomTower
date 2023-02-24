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



namespace cfg.condition
{ 

public sealed partial class ContainsItem :  condition.RoleCondition 
{
    public ContainsItem(JSONNode _json)  : base(_json) 
    {
        { if(!_json["item_id"].IsNumber) { throw new SerializationException(); }  ItemId = _json["item_id"]; }
        { if(!_json["num"].IsNumber) { throw new SerializationException(); }  Num = _json["num"]; }
        { if(!_json["reverse"].IsBoolean) { throw new SerializationException(); }  Reverse = _json["reverse"]; }
        PostInit();
    }

    public ContainsItem(int item_id, int num, bool reverse )  : base() 
    {
        this.ItemId = item_id;
        this.Num = num;
        this.Reverse = reverse;
        PostInit();
    }

    public static ContainsItem DeserializeContainsItem(JSONNode _json)
    {
        return new condition.ContainsItem(_json);
    }

    public int ItemId { get; private set; }
    public item.Item ItemId_Ref { get; private set; }
    public int Num { get; private set; }
    public bool Reverse { get; private set; }

    public const int __ID__ = 1961145317;
    public override int GetTypeId() => __ID__;

    public override void Resolve(Dictionary<string, object> _tables)
    {
        base.Resolve(_tables);
        this.ItemId_Ref = (_tables["item.TbItem"] as item.TbItem).GetOrDefault(ItemId);
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        base.TranslateText(translator);
    }

    public override string ToString()
    {
        return "{ "
        + "ItemId:" + ItemId + ","
        + "Num:" + Num + ","
        + "Reverse:" + Reverse + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}
